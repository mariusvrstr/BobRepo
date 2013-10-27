$.JBOB.page = function () {
    var page = {};

    page.tableName = "dataTableExample";
    page.initialize = function () {
        $('#' + page.tableName).addClass('active');
    };

    page.loadUserTable = function (tableData) {
        page.tableData = tableData;
        
        $.JBOB.dataTables.refreshContent(page.tableName, page.tableData, $.JBOB.objectFactory.createUserTableColumns());
    };

    page.links = {};

    return page;
}();



$.JBOB.page.objectFactory = function () {
    var objectFactory = {};
    
    return objectFactory;
}();



$.JBOB.page.dataAccess = function () {
    var dataAccess = {};

    var onUserJsonPageRetrievedSuccess = function(serverData) {
        var clientData =  $.JBOB.dataTables.createClientArray(
                serverData,
                $.JBOB.objectFactory.createClientUser);

        $.JBOB.dataTables.refreshContent($.JBOB.page.tableName,
            clientData, $.JBOB.objectFactory.createUserTableColumns());
    };

    var onUserHtmlPageRetrievedSuccess = function (partialHtml) {
        $('#userPartialWrapper').html(partialHtml);
    };

    dataAccess.getJsonUserPage = function () {
        $.JBOB.dataAccess.submitAjaxGetRequest($.JBOB.page.links.getUserJsonUrl, onUserJsonPageRetrievedSuccess);
    };
    
    dataAccess.getHtmlUserPage = function () {
        $.JBOB.dataAccess.submitAjaxGetRequest($.JBOB.page.links.getUserHtmlUrl, onUserHtmlPageRetrievedSuccess);
    };

    return dataAccess;
}();