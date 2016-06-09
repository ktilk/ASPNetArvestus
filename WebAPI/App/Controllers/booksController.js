angular.module('booksapp.controllers', [])
    .controller("booksController", function ($scope, booksService) {
        $scope.books = [];
        $scope.selectedBook = {};

        function displayData() {
            booksService.getBooks().then(function (resp) {
                $scope.books = resp.data;
                console.log($scope.books);
            });
        }

        displayData();

        $scope.edit = function (book) {
            console.log("edit from controller called!");
            $scope.selectedBook = book;
        }

        $scope.createOrEdit = function (book) {
            console.log("createOrEdit from controller called!");
            $scope.selectedBook = book;
            var id = book.bookId;
            console.log("selectedPerson väärtustatud!");
            console.log($scope.selectedBook);
            if (id == null) {
                console.log("controlleris ifi sees createPerson!");
                $scope.books = booksService.createBook(book);
            } else {
                console.log("controlleris ifi sees updatePerson!");
                $scope.books = booksService.updateBook($scope.selectedBook);
            }
        }
    });