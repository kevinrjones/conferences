function MasterViewModel() {
    var self = this;

    self.todos = new ListModel(
     {
         cardinalityFormatter: function (count) {
             return (count == 1) ? resources.res('Todo.Resources.Resources.PostCardinalityOne') : count.toString() + " " + resources.res('Todo.Resources.Resources.PostCardinalityMany');
         }
     });

    self.todo = ko.observable(new TodoItemViewModel({ parent: self }));
    self.user = new UserModel();

    self.addTodoText = resources.res('Todo.Resources.Resources.AddTodoText');
    self.addTodo = function () {
        if (self.todo().todoText() != "") {
            self.todo().order(self.todos.items().length + 1);
            self.todo().nestingLevel(1);
            self.todos.push(self.todo());
            self.todos.renumber();
            Block();
            $.connection.todoHub.server.addTodo( self.todo().getDataToSerialize())
                .done(function (data) {
                    if (data) {
                        self.todos.removeAll();
                        $(data).each(function () {
                            var todo = new TodoItemViewModel({ parent: self, data: this });
                            self.todos.push(todo);
                        });
                    }
                })
                .fail(function (error) {
                    console.log(error);
                    handleSignalRFail(error);
                })
                .always(function () {
                    Unblock();
                });
            return false;
        }
    };

    self.getTodos = function () {
        $.connection.todoHub.server.getTodos()
            .done(function (data) {
                if (data) {
                    $(data).each(function () {
                        var todo = new TodoItemViewModel({ parent: self, data: this });
                        self.todos.push(todo);
                    });
                }
            })
            .fail(function (error) {
                console.log(error);
                handleSignalRFail(error);
            });
    };

    self.oninit = function () {
        $.connection.userHub.server.getUser()
            .done(function (data) {
                if (data) {
                    self.user.init(data);
                    self.getTodos();
                } else {
                    self.user.isAuthenticated(false);
                }
            })
            .fail(function (error) {
                handleSignalRFail(error);
            }).always(function () {
                ko.applyBindings(self);
            });
    };

    self.todos.onreorder = function () {
        Block();
        var items = [];
        $(self.todos.items()).each(function () {
            items.push(this.getDataToSerialize());
        });
        $.connection.todoHub.server.saveTodos(items)
            .done(function (data) {})
            .fail(function (error) {
                console.log(error);
                handleSignalRFail(error);
            }).always(function () {
                Unblock();
            });
    };

    self.todos.renumber = function () {
        var list = self.todos.items();

        var indices = [0];
        var prevLevel = -1;

        for (var i = 0; i < list.length; i++) {
            var item = list[i];
            var currentLevel = item.nestingLevel();

            for (var popLevel = currentLevel; popLevel < prevLevel; popLevel++)
                indices.pop();

            while (currentLevel >= indices.length)
                indices.push(0);

            var number = " ";

            indices[currentLevel]++;
            for (var level = 1; level < indices.length; level++) {
                var local = indices[level];
                number = number + local + ".";
            }

            item.number(number);
            var targetOrder = i + 1;
            if (item.order() != targetOrder) {
                item.order(targetOrder);
            }
            prevLevel = currentLevel;
        }
    };

}
