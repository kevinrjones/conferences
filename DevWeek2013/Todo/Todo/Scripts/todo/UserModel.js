function UserModel() {
    var self = this;

    self.name = ko.observable();
    self.isAuthenticated = ko.observable(false);
    self.message = ko.observable();

    self.init = function(params) {
        self.name(params.Name);
        self.isAuthenticated(params.IsAuthenticated);
    };

    self.logout = function () {
        hasher.setHash("logout");
    };
};


