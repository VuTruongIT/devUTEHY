(function (app) {
    app.controller('loaiCongNgheEditController', loaiCongNgheEditController);

    loaiCongNgheEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService'];

    function loaiCongNgheEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        $scope.loaiCongNghe = {
            CreatedDate: new Date(),
            Status: true,
        }

        $scope.UpdateLoaiCongNghe = UpdateLoaiCongNghe;
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.loaiCongNghe.TieuDeSEO = commonService.getSeoTitle($scope.loaiCongNghe.Ten);
        }

        function loadLoaiCongNgheDetail() {
            apiService.get('/api/loaicongnghes/getbyid/' + $stateParams.id, null, function (result) {
                $scope.loaiCongNghe = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function UpdateLoaiCongNghe() {
            apiService.put('/api/loaicongnghes/update', $scope.loaiCongNghe,
                function (result) {
                    notificationService.displaySuccess(result.data.Ten + ' đã được cập nhật');
                    $state.go('loai_cong_nghes');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.');
                });
        }
        function loadParentLoaiCongNghe() {
            apiService.get('/api/loaicongnghes/getallparents', null, function (result) {
                $scope.parentLoaiCongNghe = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }

        loadParentLoaiCongNghe();
        loadLoaiCongNgheDetail();
    }

})(angular.module('devUTEHY.loai_cong_nghes'));