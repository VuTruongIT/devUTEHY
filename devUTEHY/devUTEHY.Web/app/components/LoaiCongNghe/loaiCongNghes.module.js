/// <reference path="../../../assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('devUTEHY.loai_cong_nghes', ['devUTEHY.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider.state('loai_cong_nghes', {
            url: "/loai_cong_nghes",
            templateUrl: "/app/components/LoaiCongNghe/loaiCongNgheListView.html",
            parent: 'base',
            controller: "loaiCongNgheListController"
        })
            .state('add_loai_cong_nghe', {
                url: "/add_loai_cong_nghe",
                parent: 'base',
                templateUrl: "/app/components/LoaiCongNghe/loaiCongNgheAddView.html",
                controller: "loaiCongNgheAddController"
            })
            .state('edit_loai_cong_nghe', {
                url: "/edit_loai_cong_nghe/:id",
                parent: 'base',
                templateUrl: "/app/components/LoaiCongNghe/loaiCongNgheEditView.html",
                controller: "loaiCongNgheEditController"
            });;

    }
})();