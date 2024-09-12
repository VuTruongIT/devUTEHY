(function (app) {
    app.controller('danhMucEditController', danhMucEditController);

    danhMucEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService', '$stateParams'];

    function danhMucEditController(apiService, $scope, notificationService, $state, commonService, $stateParams) {
        $scope.danhMuc;
        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }
        $scope.UpdatedanhMuc = UpdatedanhMuc;

        $scope.moreImages = [];
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.danhMuc.TieuDe = commonService.getSeoTitle($scope.danhMuc.Ten);
        }

        //1
        function loadDanhMucDetail() {
            apiService.get('/api/danhmuc/getbyid/' + $stateParams.id, null, function (result) {
                $scope.danhMuc = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        //3
        function UpdatedanhMuc() {
            apiService.put('/api/danhmuc/update', $scope.danhMuc,
                function (result) {
                    notificationService.displaySuccess(result.data.Ten + ' đã được cập nhật.');
                    $state.go('danh_mucs');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.');
                });
        }

        //2
        function loadCongNghe() {
            apiService.get('/api/congnghe/getallparents', null, function (result) {
                $scope.congNghes = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }


        loadCongNghe();

        loadDanhMucDetail();
    }

})(angular.module('devUTEHY.danh_mucs'));