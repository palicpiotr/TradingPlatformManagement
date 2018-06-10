function saveBetNote(url, sMessage, eMessage) {

    var note = document.getElementById("betNote").value;

    if (note === undefined || note === null)
        return;

    var callbacks = {

        onSCallback: function (data) { showResultWindow(sMessage, 1); },
        onECallback: function (data) { showResultWindow(eMessage, 0); }
    };

    sendRequest(url, "POST", { betID: getBetID(), note: note }, "", callbacks);
}

function convertInBaseCurrency(url, sMessage, eMessage) {

    var isOpposite = document.getElementById("isBaseCurrency").checked;

    var callbacks = {

        onSCallback: function (data) { showResultWindow(sMessage, 1); convertInBaseCurrencyCallback(data, isOpposite); },
        onECallback: function (data) { showResultWindow(eMessage, 0); }
    };

    sendRequest(url, "POST" , { betID: getBetID(), isOpposite: isOpposite }, "json", callbacks);
}

function getBetID() {

    return document.getElementById("betDetailsWindow_wnd_title").innerHTML.split(": ").pop();
}

function convertInBaseCurrencyCallback(betStakes, isOpposite) {

    var columns = ["Bonus", "Duty", "TotalStake", "UnitStake", "PotentialWinnings", "Winnings"];

    betStakes.Sign = isOpposite ? betStakes.Sign : "";

    columns.forEach(function (column, index, arr) {

        Array.from(document.getElementsByClassName(column)).forEach(function (row, index, arr) {

            row.innerHTML = betStakes.Sign + betStakes.BetStakes[index][column].toFixed(2);
        });
    });

    document.getElementById("TotalTS").innerHTML = betStakes.Sign + betStakes.TotalTS.toFixed(2);
    document.getElementById("TotalBS").innerHTML = betStakes.Sign + betStakes.TotalBS.toFixed(2);
    document.getElementById("TotalDY").innerHTML = betStakes.Sign + betStakes.TotalDY.toFixed(2);
    document.getElementById("TotalPW").innerHTML = betStakes.Sign + betStakes.TotalPW.toFixed(2);
    document.getElementById("TotalWS").innerHTML = betStakes.Sign + betStakes.TotalWS.toFixed(2);
}