(function (app) {
    app.controller('congNgheEditController', congNgheEditController);

    congNgheEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService', '$stateParams'];

    function congNgheEditController(apiService, $scope, notificationService, $state, commonService, $stateParams) {
        $scope.congnghe;
        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }
        $scope.UpdateCongNghe = UpdateCongNghe;

        $scope.moreImages = [];
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.congnghe.TieuDe = commonService.getSeoTitle($scope.congnghe.Ten);
        }

        //1
        function loadCongNgheDetail() {
            apiService.get('/api/congnghe/getbyid/' + $stateParams.id, null, function (result) {
                $scope.congnghe = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        //3
        function UpdateCongNghe() {
            apiService.put('/api/congnghe/update', $scope.congnghe,
                function (result) {
                    notificationService.displaySuccess(result.data.Ten + ' đã được cập nhật.');
                    $state.go('cong_nghes');
                }, function (error) {
                    notificationService.displayError('Cập nhật không thành công.');
                });
        }

        //2
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

        loadCongNgheDetail();
    }

})(angular.module('devUTEHY.cong_nghes'));