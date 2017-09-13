function TodoItemViewModel(options) {
    var self = this;
    var parent = options.parent;

    var listmodel = parent.todos;

    ListItemModel(this, listmodel);


    initDraggable(self, listmodel);

    if (options.data != null) {
        self.id = options.data.Id;
        self.date = options.data.TodoDate == null ? null : new Date(Date.parse(options.data.TodoDate));
        self.todoDate = ko.observable(self.date);
        self.todoText = ko.observable(options.data.TodoText);
        self.nestingLevel = ko.observable(options.data.NestingLevel);
        self.order = ko.observable(options.data.Order);
        self.number = ko.observable(options.data.Number);
    } else {
        self.id = 0;
        self.todoDate = ko.observable();
        self.todoText = ko.observable("");
        self.order = ko.observable(0);
        self.nestingLevel = ko.observable(0);
        self.number = ko.observable("");
    }

    self.onClick = function () {
        listmodel.selected(self);
    };

    self.remove = function () {
        listmodel.remove(self);
    };

    self.displayDate = ko.computed(function () {
        if (self.todoDate() != null) {
            return self.todoDate().toString('dddd dd/MM/yyyy');
        } else if (self.todoDate() == Date.parse("today")) {
            return "today";
        } else {
            return "";
        }
    });

    self.displayTitle = ko.computed(function () {
        return self.number() + " " + self.todoText();
    });

    self.onMouseMove = function (originalEvent) {
        var items = listmodel.items();
        var endX = originalEvent.clientX;
        var endY = originalEvent.clientY;
        var itemHeight = 32;
        var levelWidth = 32;
        var diffY = (endY - self.startY);
        var diffX = (endX - self.startX);
        var diffYRound = Math.round(diffY / itemHeight);
        var diffXRound = Math.round(diffX / levelWidth);
        var newIndex = diffYRound + self.startIndex;
        var offsetY = diffY - (diffYRound * itemHeight);

        if (Math.abs(offsetY) > 5 || Math.abs(diffX) > 5 || self.isDragging()) {
            if (!self.isDragging()) {
                var selectedOrChecked = listmodel.selectedOrChecked();
                if (selectedOrChecked.length == 0 || selectedOrChecked.indexOf(self) == -1) {
                    listmodel.selected(self);
                }

                self.draggingList = [];

                var nestingAutoSelectLevel = -1;
                var prevInclude = true;
                var broken = false;
                for (var i = 0; i < items.length; i++) {
                    var item = items[i];
                    var nestingLevel = item.nestingLevel();
                    item.startLevel = nestingLevel;
                    var include = false;
                    if (item.isSelectedOrChecked()) {
                        if (nestingAutoSelectLevel == -1) {
                            nestingAutoSelectLevel = nestingLevel;
                        }
                        include = true;
                    }
                    else {
                        if (nestingAutoSelectLevel != -1) {
                            if (nestingLevel > nestingAutoSelectLevel) {
                                include = true;
                            }
                            else {
                                nestingAutoSelectLevel = -1;
                            }
                        }
                    }

                    if (include) {
                        if (!prevInclude && self.draggingList.length > 0) {
                            broken = true;
                            break;
                        }
                        self.draggingList.push(item);
                        item.isDragging(true);
                        item.currentIndex = i;
                    }
                    prevInclude = include;
                }
            }

            var selected = self.draggingList;
            if (selected == null || selected.length == 0)
                return;

            var rootItem = selected[0];

            var oldIndex = rootItem.currentIndex;
            var offset = newIndex - self.currentIndex;
            var targetIndex = rootItem.currentIndex + offset;

            var minLevel = 1;
            var maxLevel = 1;

            var rootIndex = items.indexOf(rootItem);
            if (rootIndex > 0) {
                var preRoot = items[rootIndex - 1];
                maxLevel = preRoot.nestingLevel() + 1;
            }

            var newLevel = rootItem.startLevel + diffXRound;
            if (newLevel < minLevel)
                newLevel = minLevel;
            if (newLevel > maxLevel)
                newLevel = maxLevel;
            var nestingOffset = newLevel - rootItem.startLevel;


            if (targetIndex < 0) {
                offsetY = -itemHeight / 2;
                targetIndex = 0;
            }

            var maxIndex = items.length - selected.length;
            if (targetIndex > maxIndex) {
                if (targetIndex != maxIndex)
                    offsetY = itemHeight / 2;
                targetIndex = maxIndex;
            }

            ko.utils.arrayForEach(selected, function (selectedItem) {
                selectedItem.offsetY(offsetY);
                selectedItem.nestingLevel(selectedItem.startLevel + nestingOffset);
            });

            if (targetIndex != oldIndex) {

                var direction = -1;
                if (newIndex > self.currentIndex)
                    direction = +1;

                items.splice(selected[0].currentIndex, selected.length);

                var animateHeight = itemHeight * selected.length;

                ko.utils.arrayForEach(selected, function (selectedItem) {
                    if (direction == +1) {
                        if (targetIndex > 0 && targetIndex <= items.length) {
                            var movingUp = items[targetIndex - 1];
                            movingUp.offsetY(animateHeight);
                            movingUp.animateY();
                        }
                    }
                    else {
                        if (targetIndex >= 0 && targetIndex < items.length) {
                            var movingDown = items[targetIndex];
                            movingDown.offsetY(-animateHeight);
                            movingDown.animateY();
                        }
                    }
                    selectedItem.currentIndex = targetIndex;
                    items.splice(targetIndex, 0, selectedItem);
                    targetIndex++;
                });
                listmodel.items(items);
            }
            listmodel.renumber();
        }
    };

    self.getDataToSerialize = function() {
        return { id: self.id, todoDate: self.todoDate(), todoText: self.todoText(), order: self.order(), nestingLevel: self.nestingLevel(), number: self.number() };
    };
}
