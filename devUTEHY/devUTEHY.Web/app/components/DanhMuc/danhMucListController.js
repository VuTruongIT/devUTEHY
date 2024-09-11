(function (app) {
    app.controller('danhMucListController', danhMucListController);

    danhMucListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function danhMucListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.danhmucs = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getDanhMucs = getDanhMucs;
        $scope.keyword = '';

        $scope.search = search;
        $scope.deleteDanhMuc = deleteDanhMuc;
        $scope.selectAll = selectAll;
        $scope.deleteMultipleDanhMucs = deleteMultipleDanhMucs;

        //4
        function deleteMultipleDanhMucs() {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var listId = [];
                $.each($scope.selected, function (i, item) {
                    listId.push(item.ID);
                });
                var config = {
                    params: {
                        checkedDanhMucs: JSON.stringify(listId)
                    }
                }
                apiService.del('/api/danhmuc/deletemulti', config, function (result) {
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
                angular.forEach($scope.danhmucs, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.danhmucs, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }
        $scope.$watch("danhmucs", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);

        //3
        function deleteDanhMuc(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('/api/danhmuc/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
        }


        //1
        function search() {
            getDanhMucs();
        }
        function getDanhMucs(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 10
                }
            }
            apiService.get('/api/danhmuc/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy!');
                } else {
                    notificationService.displaySuccess('Đã tìm thấy ' + result.data.TotalCount + ' bản ghi.');
                }
                $scope.danhmucs = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load product failed.');
            });
        }

        $scope.getDanhMucs();
    }
})(angular.module('devUTEHY.danh_mucs'));