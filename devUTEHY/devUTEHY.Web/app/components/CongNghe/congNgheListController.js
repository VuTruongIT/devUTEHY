(function (app) {
    app.controller('congNgheListController', congNgheListController);

    congNgheListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function congNgheListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.congnghes = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getCongNghes = getCongNghes;
        $scope.keyword = '';

        $scope.search = search;
        $scope.deleteCongNghe = deleteCongNghe;
        $scope.selectAll = selectAll;
        $scope.deleteMultiple1 = deleteMultiple1;

        //4
        function deleteMultiple1() {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var listId = [];
                $.each($scope.selected, function (i, item) {
                    listId.push(item.ID);
                });
                var config = {
                    params: {
                        checkedCongNghes: JSON.stringify(listId)
                    }
                }
                apiService.del('/api/congnghe/deletemulti', config, function (result) {
                    notificationService.displaySuccess('Xóa thành công ' + result.data + ' bản ghi.');
                    search();
                }, function (error) {
                    notificationService.displayError('Xóa không thành công');
                });
            });
        }
        
        //2
        $scope.isAll = false;
        function selectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.congnghes, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.congnghes, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }
        $scope.$watch("congnghes", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);

        //3
        function deleteCongNghe(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('/api/congnghe/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
        }


        //1
        function search() {
            getCongNghes();
        }
        function getCongNghes(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 10
                }
            }
            apiService.get('/api/congnghe/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy!');
                } else {
                    notificationService.displaySuccess('Đã tìm thấy ' + result.data.TotalCount + ' bản ghi.');
                }
                $scope.congnghes = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load product failed.');
            });
        }

        $scope.getCongNghes();
    }
})(angular.module('devUTEHY.cong_nghes'));