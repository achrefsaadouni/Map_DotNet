(function () {
    'use strict';

    var byId = function (id) {
        return document.getElementById(id);
    };



    // Advanced groups
    [
        {
            name: 'advanced',
            pull: true,
            put: true
        },
        {
            name: 'advanced',
            pull: true,
            put: true
        }].forEach(function (groupOpts, i) {
            Sortable.create(byId('advanced-' + (i + 1)), {
                sort: (i != 1),
                group: groupOpts,
                animation: 150
            });
        });



})();