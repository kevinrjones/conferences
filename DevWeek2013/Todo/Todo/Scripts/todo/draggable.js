function initDraggable(self, listmodel) {
    
    self.offsetY = ko.observable(0);

    self.isDragging = ko.observable(false);

    self.onMouseDown = function (item, e) {
        self.startX = e.originalEvent.clientX;
        self.startY = e.originalEvent.clientY;
        if (e.originalEvent.preventDefault)
            e.originalEvent.preventDefault();
        self.mouseDown = true;
        self.startIndex = ko.utils.arrayIndexOf(listmodel.items(), self);
        self.currentIndex = self.startIndex;
        $(document).on("mouseup", self.onMouseUp);
        $(document).on("mousemove", self.onMouseMove);

    };
    
    self.onMouseUp = function () {
        $(document).off("mousemove", self.onMouseMove);
        $(document).off("mouseup", self.onMouseUp);
        if (self.isDragging()) {
            self.offsetY(0);
            self.isDragging(false);
            if (listmodel.onreorder != null)
                listmodel.onreorder();
        } else {
            if (self.onClick!=null)
                self.onClick();
        }
    };

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

            if (self.canDrag != null && !self.canDrag())
                return;

            if (!self.isDragging()) {
                self.isDragging(true);
            }

            var oldIndex = self.currentIndex;
            var offset = newIndex - self.currentIndex;
            var targetIndex = self.currentIndex + offset;

            if (targetIndex < 0) {
                offsetY = -itemHeight / 2;
                targetIndex = 0;
            }

            var maxIndex = items.length - 1;
            if (targetIndex > maxIndex) {
                if (targetIndex != maxIndex)
                    offsetY = itemHeight / 2;
                targetIndex = maxIndex;

            }

            self.offsetY(offsetY);

            if (targetIndex != oldIndex) {

                if (self.canDragOver != null) {
                    var currentItem = items[targetIndex];
                    if (!self.canDragOver(currentItem))
                        return;
                }

                var direction = -1;
                if (newIndex > self.currentIndex)
                    direction = +1;

                items.splice(self.currentIndex, 1);

                var animateHeight = itemHeight;

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

                self.currentIndex = targetIndex;
                items.splice(targetIndex, 0, self);
                targetIndex++;

                listmodel.items(items);

            }


        }

    };

    self.animateY = function () {
        var offsetY = self.offsetY();
        if (offsetY == 0)
            return;
        if (offsetY < 0)
            offsetY += 2;
        else
            offsetY -= 4;
        self.offsetY(offsetY);
        setTimeout(self.animateY, 10);
    };

}