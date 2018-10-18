// adds the bootstrap active class to the navbar item when it is clicked
$(function () {
    var current = location.pathname;
    $('nav li a').each(function () {
        var $this = $(this);
        // if the current path is the same as the href, make the a element active
        if ($this.attr('href') == current) {
            $this.addClass('active');
        }
    })
})