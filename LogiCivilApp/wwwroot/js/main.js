(function () {
    "use strict";

    var treeviewMenu = $('.app-menu');

    // Toggle Sidebar
    $('[data-toggle="sidebar"]').click(function (event) {
        event.preventDefault();
        $('.app').toggleClass('sidenav-toggled');
    });

    // Activate sidebar treeview toggle
    $("[data-toggle='treeview']").click(function (event) {
        event.preventDefault();
        if (!$(this).parent().hasClass('is-expanded')) {
            treeviewMenu.find("[data-toggle='treeview']").parent().removeClass('is-expanded');
        }
        $(this).parent().toggleClass('is-expanded');
    });

    // Set active menu item
    document.addEventListener('DOMContentLoaded', function () {
        var currentPath = window.location.pathname;
        var menuItems = document.querySelectorAll('.app-menu__item, .treeview-item');

        menuItems.forEach(function (menuItem) {
            var href = menuItem.getAttribute('href');
            if (href && currentPath.includes(href)) {
                menuItem.classList.add('active');

                // If the active item is a submenu, open the parent
                var parentTreeview = menuItem.closest('.treeview');
                if (parentTreeview) {
                    parentTreeview.querySelector('.app-menu__item').classList.add('active');
                    parentTreeview.querySelector('.treeview-menu').classList.add('is-expanded');
                }
            }
        });
    });

})();