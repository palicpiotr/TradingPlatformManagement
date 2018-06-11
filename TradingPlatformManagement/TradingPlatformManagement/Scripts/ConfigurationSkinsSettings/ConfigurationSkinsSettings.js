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

    function onConfigurationDataBound() {     
        setConfigurationFromURL();
        refreshGrid();
    }
    
    function onGridDataSourceRequestEnd(e) {
        if (e.type == "update") {
            refreshGrid();
        }
    }

    function refreshGrid() {
        $('#configurationSkinsGrid').data('kendoGrid').dataSource.read();
        $('#configurationSkinsGrid').data('kendoGrid').refresh();
    }

    function getURLParameter(name) {
        return decodeURIComponent((new RegExp('[?|&]' + name + '=' + '([^&;]+?)(&|#|;|$)').exec(location.search) || [null, ''])[1].replace(/\+/g, '%20')) || null;
    }

    function setConfigurationFromURL() {    
        var configId = getURLParameter('configId');       
        var configs = $("#Configurations").data("kendoDropDownList");
        if (configId != null) {
            configs.value(configId);
        }
    }