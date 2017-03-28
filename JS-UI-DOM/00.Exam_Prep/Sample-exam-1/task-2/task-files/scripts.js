$.fn.tabs = function() {
    var $tabControl = this;
    $tabControl.addClass("tabs-container");
    hideTabCOntrolContent();

    $tabControl.on("click", ".tab-item-title", function() {
        var $clicked = $(this);
        hideTabCOntrolContent();
        $tabControl.find(".tab-item").removeClass("current");
        $clicked.next().show();
        $clicked.parent().addClass("current");
    });

    function hideTabCOntrolContent() {
        $tabControl.find(".tab-item-content").hide();
    };
};