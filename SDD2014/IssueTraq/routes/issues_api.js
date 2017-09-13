var data = {
    "issues": [
        {
            "title": "Lorem ipsum",
            "text": "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."
        },
        {
            "title": "Sed egestas",
            "text": "Sed egestas, ante et vulputate volutpat, eros pede semper est, vitae luctus metus libero eu augue. Morbi purus libero, faucibus adipiscing, commodo quis, gravida id, est. Sed lectus."
        }
    ]
};

var IssueServer = function (app) {

    var server = {};

    app.get('/api/issues', function (req, res) {
        var issues = [];
        data.issues.forEach(function (issue, i) {
            issues.push({
                id: i,
                title: issue.title,
                text: issue.text
            });
        });
        res.json({
            issues: issues
        });
    });

    app.get('/api/issue/:id', function (req, res) {
        var id = req.params.id;
        if (id >= 0 && id < data.issues.length) {
            res.json({
                issue: data.issues[id]
            });
        } else {
            res.json(false);
        }
    });

    app.post('/api/issue', function (req, res) {
        data.issues.push(req.body);
        res.json(req.body);
    });

    app.put('/api/issue/:id', function (req, res) {
        var id = req.params.id;

        if (id >= 0 && id < data.issues.length) {
            data.issues[id] = req.body;
            res.json(true);
        } else {
            res.json(false);
        }
    });

    app.delete('/api/issue/:id', function (req, res) {
        var id = req.params.id;

        if (id >= 0 && id < data.issues.length) {
            data.issues.splice(id, 1);
            res.json(true);
        } else {
            res.json(false);
        }
    });

    server.app = app;
    return server;
};


module.exports = IssueServer;