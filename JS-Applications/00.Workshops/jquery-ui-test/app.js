$(document).ready(function() {
    $("#date").datepicker();
    $("#progressbar").progressbar({ value: 20 }).resizable();
    $("#accordion").accordion();
    $(".button").button().draggable();
    $("#dialog").dialog();
    $("#sortable > li").addClass("ui-widget-content");
    $("#sortable").addClass("ui-widget").sortable();
});