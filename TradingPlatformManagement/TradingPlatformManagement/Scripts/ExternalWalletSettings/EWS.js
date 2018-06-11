function onEdit(e) {

    var editor = ace.edit("newEWSSettings");
    var textbox = $('#HiddenSettings').css("display", "none");
    var text = formatPrettyXml(textbox[0].value);
    var stringText;

    editor.resize();
    editor.setTheme("ace/theme/twilight");
    editor.getSession().setMode("ace/mode/xml");
    editor.getSession().setValue(text);

    editor.getSession().on('change', function () {
        stringText = "";
        stringText = formatToRowXML(editor.getSession().getValue());
        $('#HiddenSettings')[0].kendoBindingTarget.source.Settings = stringText;
    });

    //Forses kendo to call "EWSUpdate" action in any case
    //of action "update"
    e.model.dirty = true;
}

//Formates XML row to XML-like view
function formatPrettyXml(xml) {
    var formatted = '';
    var reg = /(>)(<)(\/*)/g;
    xml = xml.replace(reg, '$1\r\n$2$3');
    var pad = 0;
    $.each(xml.split('\r\n'), function (index, node) {
        var indent = 0;
        if (node.match(/.+<\/\w[^>]*>$/)) {
            indent = 0;
        } else if (node.match(/^<\/\w/)) {
            if (pad != 0) {
                pad -= 1;
            }
        } else if (node.match(/^<\w[^>]*[^\/]>.*$/)) {
            indent = 1;
        } else {
            indent = 0;
        }

        var padding = '';
        for (var i = 0; i < pad; i++) {
            padding += '  ';
        }

        formatted += padding + node + '\r\n';
        pad += indent;
    });
    return formatted;
}

//Formates XML back to row
function formatToRowXML(xml) {
    var rawNumbers = xml.split('<')[0];
    var xses = xml.split('>')[xml.split('>').length - 1];
    xml = xml.replace(rawNumbers, "").replace(xses, "");
    xml = xml.toString().trim().replace(/(\r\n|\n|\r)/g, "");
    xml = xml.replace(/\s</g, "<").replace(/>\s/g, ">");
    return xml;
}

function riseError(e, unknownError, errorTitle) {
    var message = "";
    if (e.errors) {
        $.each(e.errors, function (key, value) {
            message += this + "\n";
        });
    }
    else {
        message += unknownError;
    }
    showPopupMessage(errorTitle, message, 'error');
}

function cancelGridChanges(e) {
    var grid = e.sender;
    grid.cancelChanges();
}

function showPopupMessage(title, message, type) {
    new PNotify({
        'title': title,
        'text': message,
        'type': type,
        'styling': 'bootstrap3'
    });
}
