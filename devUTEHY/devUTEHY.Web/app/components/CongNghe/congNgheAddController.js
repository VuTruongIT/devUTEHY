(function (app) {
    app.controller('congNgheAddController', congNgheAddController);

    congNgheAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];

    function congNgheAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.congnghe = {
            NgayTao: new Date(),
        }


        $scope.AddCongNghe = AddCongNghe;

        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.congnghe.TieuDe = commonService.getSeoTitle($scope.congnghe.Ten);
        }

        function AddCongNghe() {
            apiService.post('/api/congnghe/create', $scope.congnghe,
                function (result) {
                    notificationService.displaySuccess(result.data.Ten + ' đã được thêm mới.');
                    $state.go('cong_nghes');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công.');
                });
        }
        function loadLoaiCongNghe() {
            apiService.get('/api/loaicongnghes/getallparents', null, function (result) {
                $scope.loaiCongNghes = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }
        $scope.ChooseImageIcon = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.congnghe.Icon = fileUrl;
                })
            }
            finder.popup();
        }
        $scope.ChooseImageLogo = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.congnghe.Logo = fileUrl;
                })
            }
            finder.popup();
        }


        

        loadLoaiCongNghe();
    }

})(angular.module('devUTEHY.cong_nghes'));