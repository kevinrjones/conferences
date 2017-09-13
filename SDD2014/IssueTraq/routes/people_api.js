var data = {
    "people": [
        {
            "id": 1,
            "firstname": "Lorem ipsum",
            "lastname": "dolor"
        },
        {
            "id": 2,
            "firstname": "Sed egestas",
            "lastname": "ante et "
        }
    ]
};

var PeopleServer = function (app) {

    var server = {};

    app.get('/api/person', function (req, res) {
        var people = [];
        data.people.forEach(function (person, i) {
            people.push({
                firstname: person.firstname,
                lastname: person.lastname,
                children: [{id: 1, name: 'Harry'}, {id: 2, name: 'Sam'}]
            });
        });
        res.json(people);
    });

    app.get('/api/person/:id', function (req, res) {
        var id = req.params.id;
        if (id >= 0 && id < data.people.length) {
            res.json(
                data.people[id]
            );
        } else {
            res.json(false);
        }
    });

    app.post('/api/person', function (req, res) {
        data.people.push(req.body);
        res.json(req.body);
    });

    app.put('/api/person/:id', function (req, res) {
        var id = req.params.id;

        if (id >= 0 && id < data.people.length) {
            data.people[id] = req.body;
            res.json(true);
        } else {
            res.json(false);
        }
    });

    app.delete('/api/person/:id', function (req, res) {
        var id = req.params.id;

        if (id >= 0 && id < data.people.length) {
            data.people.splice(id, 1);
            res.json(true);
        } else {
            res.json(false);
        }
    });

    server.app = app;
    return server;
};


module.exports = PeopleServer;