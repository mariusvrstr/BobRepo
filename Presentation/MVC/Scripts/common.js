$.JBOB = function() {
    var jbob = {};

    jbob.page = {};
    jbob.objectFactory = {};
    jbob.dataAccess = {};
    jbob.untils = {};

    return jbob;
}();

$.JBOB.dataTables = function() {
    var dataTables = {};    

    var initDataTable = function (dataTableId, data, columns) {
        var dataTableContent = {
            "aaData": data,
            "aoColumns": columns
        };

        $('#' + dataTableId).not('.initialized').addClass('initialized').dataTable(dataTableContent);
    };

    dataTables.refreshContent = function (dataTableId, data, columns) {
        
        if ($('#' + dataTableId).hasClass('initialized')) {
            var table = $('#' + dataTableId).dataTable();

            var oSettings = table.fnSettings();

            table.fnClearTable(0);
            table.fnDraw();

            for (var i = 0; i < data.length; i++) {
                table.oApi._fnAddData(oSettings, data[i]);
            }

            oSettings.aiDisplay = oSettings.aiDisplayMaster.slice();
            table.fnDraw();
            
        } else {
            initDataTable(dataTableId, data, columns);
        }
    };

    dataTables.createClientArray = function (serverList, singleMapCallback) {
        var clientList = [];

        if (serverList != undefined) {
            for (var k = 0, bound = serverList.length; k < bound; k++) {
                var serverItem = serverList[k];
                var clientItem = singleMapCallback(serverItem);
                clientList.push(clientItem);
            }
        }

        return clientList;
    };

    return dataTables;
}();


$.JBOB.objectFactory = function () {
    var objectFactory = {};
    
   

    objectFactory.createClientUser = function (serverUser) {
        if (serverUser == undefined) {
            return null;
        }
        return [serverUser.Name, serverUser.Surname, serverUser.Login];
    };

    objectFactory.createUserTableColumns = function () {
        return  [
           { "sTitle": "Name" },
           { "sTitle": "Surname" },
           { "sTitle": "Login" }
        ];
    };

  

    return objectFactory;
}();

$.JBOB.dataAccess = function () {
    var dataAccess = {};

    dataAccess.submitAjaxGetRequest = function (targetUrl, successFunction) {
        $.get(targetUrl, successFunction);
    };

    dataAccess.submitAjaxPostJsonRequest = function (targetUrl, jsonData, successFunction) {
        var jsonString = JSON.stringify(jsonData);

        $.ajax({
            type: 'POST',
            url: targetUrl,
            data: jsonString,
            success: successFunction,
            contentType: "application/json",
            dataType: 'json'
        });
    };


    return dataAccess;
}();