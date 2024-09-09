(function (app) {
    app.controller('loaiCongNgheListController', loaiCongNgheListController);

    loaiCongNgheListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function loaiCongNgheListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.loaiCongNghes = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getLoaiCongNghes = getLoaiCongNghes;
        $scope.keyword = '';

        //1
        $scope.search = search;
        //2
        $scope.deleteLoaiCongNghe = deleteLoaiCongNghe;
        //3
        $scope.selectAll = selectAll;
        $scope.deleteMultiple = deleteMultiple;

        //3b xử lý xóa nhiều
        function deleteMultiple() {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var listId = [];
                $.each($scope.selected, function (i, item) {
                    listId.push(item.ID);
                });
                var config = {
                    params: {
                        checkedLoaiCongNghe: JSON.stringify(listId)
                    }
                }
                apiService.del('/api/loaicongnghes/deletemulti', config, function (result) {
                    notificationService.displaySuccess('Xóa thành công ' + result.data + ' bản ghi.');
                    search();
                }, function (error) {
                    notificationService.displayError('Xóa không thành công');
                });
            });
        }

        //3a xử lý check chọn tất cả
        $scope.isAll = false;
        function selectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.loaiCongNghes, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.loaiCongNghes, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        $scope.$watch("loaiCongNghes", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);

        //2
        function deleteLoaiCongNghe(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('/api/loaicongnghes/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
        }

        //1
        //khởi chạy lần đầu trả về danh sách đã phân trang
        function search() {
            getLoaiCongNghes();
        }
        function getLoaiCongNghes(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 10
                }
            }
            apiService.get('/api/loaicongnghes/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy!');
                } else {
                    notificationService.displaySuccess('Đã tìm thấy ' + result.data.TotalCount + ' bản ghi.');
                }
                $scope.loaiCongNghes = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load loaicongnghe failed.');
            });
        }

        $scope.getLoaiCongNghes();
    }
})(angular.module('devUTEHY.loai_cong_nghes'));