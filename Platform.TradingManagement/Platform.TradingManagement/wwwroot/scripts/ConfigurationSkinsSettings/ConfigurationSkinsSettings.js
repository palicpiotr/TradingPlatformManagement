$(function () {        
        $('#skinNameFilter').keyup(function () {
            filterGrid();
        });
    });

    $(function () {
        $('#licenceeNameFilter').keyup(function () {
            filterGrid();
        });
    });

    function filterGrid() {
        var searchStrName = $('#skinNameFilter').val();
        var searchStrLicencee = $('#licenceeNameFilter').val();
        var grid = $("#configurationSkinsGrid").data("kendoGrid");
        grid.dataSource.filter([{ field: "SkinName", operator: "startswith", value: searchStrName },
                                { field: "LicenceeName", operator: "startswith", value: searchStrLicencee }]);
    }

    function GetCurrentConfigurationId() {
        return { configurationId: $("#Configurations").data("kendoDropDownList").value() }
    }

    function onConfigurationChange() {
        refreshGrid();
    }

    function onConfigurationDataBound() {
        setConfigurationFromURL();
        refreshGrid();
    }

    function onGridDataSourceRequestEnd(e) {
        if (e.type == "update") {
            refreshGrid();
        }
    }

    //function onGridDataBound(e) {
    //    var grid = $('#configurationSkinsGrid').data('kendoGrid');
    //    var gridData = grid.dataSource.view();
    //    for (var i = 0; i < gridData.length; i++) {
    //        var currentUid = gridData[i].uid;
    //        if (gridData[i].Template.Name == "Empty") {
    //            var currentRow = grid.table.find("tr[data-uid='" + currentUid + "']");
    //            var manageButton = $(currentRow).find(".btn-manage-event");
    //            manageButton.hide();
    //        }
    //    }
    //}

    function refreshGrid() {
        $('#configurationSkinsGrid').data('kendoGrid').dataSource.read();
        $('#configurationSkinsGrid').data('kendoGrid').refresh();
    }

    function getURLParameter(name) {
        return decodeURIComponent((new RegExp('[?|&]' + name + '=' + '([^&;]+?)(&|#|;|$)').exec(location.search) || [null, ''])[1].replace(/\+/g, '%20')) || null;
    }

    function setConfigurationFromURL() {
        var configurationId = getURLParameter('configurationId');
        if (configurationId != null) {
            $("#Configurations").data("kendoDropDownList").select(parseInt(configurationId));
            $("#Configurations").data("kendoDropDownList").enable(false);
        }
    }