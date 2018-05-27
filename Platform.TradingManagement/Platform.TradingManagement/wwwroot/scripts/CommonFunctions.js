function setCookie(cookieName, cookieValue, lifespanInDays, validDomain) {
    var domainString = validDomain ? ("; domain=" + validDomain) : '';
    document.cookie = cookieName
        + "=" + encodeURIComponent(cookieValue)
        + "; max-age=" + 60 * 60 * 24 * lifespanInDays
        + "; path=/" + domainString;
}

function getCookie(cname) {
    var name = cname + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i].trim();
        if (c.indexOf(name) == 0) return decodeURIComponent(c.substring(name.length, c.length));
    }
    return "";
}


function sendRequest(url, method, data, dataType, callbacks) {

    $(".loading-spinner").show();

    $.ajax({

        url: url,
        type: method,
        data: JSON.stringify(data),
        dataType: dataType,
        contentType: "application/json; charset=utf-8",

        success: function (data) {
            $(".loading-spinner").hide();

            callbacks.onSCallback(data);
        },

        error: function (data) {
            $(".loading-spinner").hide();

            callbacks.onECallback(data);
        },

        statusCode: {

            401: function () { authenticationRequire(); $("#details").empty(); $(".loading-spinner").hide(); }
        }
    });
}

function showPopupMessage(head, message, type) {

    new PNotify({

        'title': head,
        'text': message,
        'type': type,
        'styling': 'bootstrap3'
    });
}

function getErrorMessage(error) {
    if (!error.errors && !error.Errors)
        return true;

    var key = error.errors == undefined ? "Errors" : "errors";

    Object.keys(error[key]).forEach(

        function (message, index, arr) {

            showResultWindow(error[key][message], 0);
        });
}

//parse string value from server to bool 
function parseBool(val) {
    if ((typeof val === 'string' && (val.toLowerCase() === 'true' || val.toLowerCase() === 'yes')) || val === 1)
        return true;
    else if ((typeof val === 'string' && (val.toLowerCase() === 'false' || val.toLowerCase() === 'no')) || val === 0)
        return false;
    return null;
}


/**
 * Grid error handling
 */
function gridErrorHandler(e) {
    riseError(e);
    cancelGridChanges(e);
}

function riseError(e) {
    var message = "";
    if (e.errors) {
        $.each(e.errors, function (key, value) {
            message += this + "\n";
        });
    }
    else {
        message += 'UnknownError';
    }
    errorMessage(message);
}

function cancelGridChanges(e) {
    var grid = e.sender;
    grid.cancelChanges();
}

function errorMessage(message) {
    showPopupMessage('Error', message, 'error');
}

function successMessage(message) {
    showPopupMessage('Error', message, 'success');
}