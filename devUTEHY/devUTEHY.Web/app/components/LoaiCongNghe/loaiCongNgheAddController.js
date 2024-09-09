(function (app) {
    app.controller('loaiCongNgheAddController', loaiCongNgheAddController);

    loaiCongNgheAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];

    function loaiCongNgheAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.loaiCongNghe = {
            CreatedDate: new Date(),
            Status: true,
        }
        $scope.GetSeoTitle = GetSeoTitle;
        function GetSeoTitle() {
            $scope.loaiCongNghe.TieuDeSEO = commonService.getSeoTitle($scope.loaiCongNghe.Ten);
        }

        $scope.AddLoaiCongNghe = AddLoaiCongNghe;

        function AddLoaiCongNghe() {
            apiService.post('/api/loaicongnghes/create', $scope.loaiCongNghe,
                function (result) {
                    notificationService.displaySuccess(result.data.Ten + ' đã được thêm mới.');
                    $state.go('loai_cong_nghes');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');
                });
        }
        function loadLoaiCongNghe() {
            apiService.get('/api/loaicongnghes/getallparents', null, function (result) {
                $scope.parentLoaiCongNghe = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }

        loadLoaiCongNghe();
    }

})(angular.module('devUTEHY.loai_cong_nghes'));