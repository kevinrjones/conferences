
/* set up general purpose error handler (only kicks in on localhost) */
window.onerror = function (msg, url, linenumber) {
    if (window.location.hostname == 'localhost')
        $.jGrowl('Error message: ' + msg + '\nURL: ' + url + '\nLine Number: ' + linenumber);
    return false;
};

// console replacement, just in case console not available. 
if (!window.console) console = { log: function () { } };

var model;


/* set up logging */
var log = log4javascript.getLogger();
var consoleAppender = new log4javascript.BrowserConsoleAppender();
log.addAppender(consoleAppender);

/* helper method to handle failures in SignalR connections */
function handleSignalRFail(data) {

    // if error contains "NotLoggedInException" magic string, redirect to login
    if (/NotLoggedInException/.test(data)) {
        redirectToLogin();
    }
    else {
        // notify user in Growl box
        $.jGrowl(data);
    }
}

function redirectToLogin() {

    // notify user in Growl box
    $.jGrowl('Redirecting to login...');

    // then redirect
    window.location = '/Session/New?redirectTo=' + encodeURIComponent(window.location);
}


function initCrossroads() {

    routes.initRoutes();
    //setup hasher
    function parseHash(newHash, oldHash) {
        crossroads.parse(newHash);
    }
    hasher.initialized.add(parseHash); //parse initial hash
    hasher.changed.add(parseHash); //parse hash changes
    hasher.init(); //start listening for history change

    //update URL fragment generating new history record
  //  hasher.setHash('/');
}

/* oninit called once upon first page load */

function oninit() {

    // Disable caching of AJAX responses
    $.ajaxSetup({
        cache: false
    });


    initCrossroads();
    //hasher.changed.add(hash.handleHashChange);
    //hasher.initialized.add(hash.handleHashInit);
    //hasher.init();

    
    // ensure that any attempt to leave this page attempt to pop the stack first (and hence confirms any data abandons)
    //window.onbeforeunload = function () {
    //    if (!modules.resetModule())
    //        return 'Unsaved work';
    //};

    // create new MasterViewModel, and bind using knockout
    //var masterModel = new MasterViewModel();
    //ko.applyBindings(masterModel);
}


// when the document loads, call oninit
$(function () {
    oninit();
});
