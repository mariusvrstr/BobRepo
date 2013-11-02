﻿$.JBOB.page = function() {
    var page = {};

    page.ux = {};
    page.dataAccess = {};

    page.initialize = function() {
        $('#menu_home').addClass('active');
        
        $("html, body").mousewheel(function (e, delta) {
            $('html, body').stop().animate({ scrollLeft: '-=' + (150 * delta) + 'px' }, 200, 'easeOutQuint');
            e.preventDefault();
        });
    };

    return page;
}();

$.JBOB.page.ux = function () {
    var ux = {};


    ux.scrollhome = function() {
        $('html, body').stop().animate({ scrollLeft: '0px' }, 1000, 'easeOutQuint');
    };

    ux.scrollProfile = function() {
        var pos = $('#personal').position();
        $('html, body').stop().animate({ scrollLeft: pos.left + 'px' }, 1000, 'easeOutQuint');
    };
    ux.scrollScore = function() {
        var pos = $('#profScore').position();
        $('html, body').stop().animate({ scrollLeft: pos.left + 'px' }, 1000, 'easeOutQuint');
    };
    ux.scrollBadge = function() {
        var pos = $('#profBadge').position();
        $('html, body').stop().animate({ scrollLeft: pos.left + 'px' }, 1000, 'easeOutQuint');
    };
    ux.scrollCreate = function () {
        
        $("#ranking_value").text('213');
        $("#rankingAll_value").text('213/215');
        $("#badges_value").text('1');
        $("#badgesAll_value").text('1/23');
        $("#points_value").text('120');
        $("#pointsAll_value").text('120');

        var pos = $('#profCreate').position();
        $('html, body').stop().animate({ scrollLeft: pos.left + 'px' }, 1000, 'easeOutQuint');
    };

    return ux;
}();


$.JBOB.page.dataAccess = function () {
    var dataAccess = {};

    var onAddCardComplete = function() {
        console.log('Success');
                
        if ($('#cardDetail').hasClass('hide')) {
            $('#cardDetail').removeClass('hide');
        }
        
        if ($('#cardDetail').hasClass('hide')) {
            $('#cardDetail').removeClass('hide');
        }

        dataAccess.GetCreatedCard();

    };
    
    dataAccess.createCard = function () {
        var card = {
            CardId : '', 
            Name : $('#titleInput').val(),
            Description : $('#Description').val(),
            Category : $('#Category').val(),
            Weight : '100'
        };

        $.JBOB.dataAccess.submitAjaxPostJsonRequest('http://localhost:1229/Home/AddCard', card, onAddCardComplete);
    };

    dataAccess.GetCreatedCard = function () {
        var card = $.JBOB.dataAccess.submitAjaxGetRequest('http://localhost:1229/Home/Get/2', card);
    };


    return dataAccess;
}();