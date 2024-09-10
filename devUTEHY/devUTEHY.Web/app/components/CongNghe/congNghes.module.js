/// <reference path="../../../assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('devUTEHY.cong_nghes', ['devUTEHY.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('cong_nghes', {
            url: "/cong_nghes",
            templateUrl: "/app/components/CongNghe/congNgheListView.html",
            parent: 'base',
            controller: "congNgheListController"
        })
            .state('add_cong_nghe', {
                url: "/add_cong_nghe",
                parent: 'base',
                templateUrl: "/app/components/CongNghe/congNgheAddView.html",
                controller: "congNgheAddController"
            })
            .state('edit_cong_nghe', {
                url: "/edit_cong_nghe/:id",
                parent: 'base',
                templateUrl: "/app/components/CongNghe/congNgheEditView.html",
                controller: "congNgheEditController"
            });

    }
})();