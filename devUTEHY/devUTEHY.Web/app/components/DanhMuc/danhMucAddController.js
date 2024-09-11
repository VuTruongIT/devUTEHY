(function (app) {
    app.controller('danhMucAddController', danhMucAddController);

    danhMucAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];

    function danhMucAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.danhmuc = {
            NgayTao: new Date(),
        }


        $scope.AddDanhMuc = AddDanhMuc;

        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.danhmuc.TieuDe = commonService.getSeoTitle($scope.danhmuc.Ten);
        }

        function AddDanhMuc() {
            apiService.post('/api/danhmuc/create', $scope.danhmuc,
                function (result) {
                    notificationService.displaySuccess(result.data.Ten + ' đã được thêm mới.');
                    $state.go('danh_mucs');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');
                });
        }
        function loadCongNghe() {
            apiService.get('/api/congnghe/getallparents', null, function (result) {
                $scope.congNghes = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }

        loadCongNghe();
    }

})(angular.module('devUTEHY.danh_mucs'));