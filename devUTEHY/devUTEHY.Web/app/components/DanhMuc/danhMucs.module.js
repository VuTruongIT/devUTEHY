/// <reference path="../../../assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('devUTEHY.danh_mucs', ['devUTEHY.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('danh_mucs', {
            url: "/danh_mucs",
            templateUrl: "/app/components/DanhMuc/danhMucListView.html",
            parent: 'base',
            controller: "danhMucListController"
        })
            .state('add_danh_muc', {
                url: "/add_danh_muc",
                parent: 'base',
                templateUrl: "/app/components/DanhMuc/danhMucAddView.html",
                controller: "danhMucAddController"
            })
            .state('edit_danh_muc', {
                url: "/edit_danh_muc/:id",
                parent: 'base',
                templateUrl: "/app/components/DanhMuc/danhMucEditView.html",
                controller: "danhMucEditController"
            });
    }
})();