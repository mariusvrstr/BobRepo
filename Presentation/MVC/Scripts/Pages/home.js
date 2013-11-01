$.JBOB.page = function() {
    var page = {};

    page.ux = {};

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
    ux.scrollCreate = function() {
        var pos = $('#profCreate').position();
        $('html, body').stop().animate({ scrollLeft: pos.left + 'px' }, 1000, 'easeOutQuint');
    };

    return ux;
}();