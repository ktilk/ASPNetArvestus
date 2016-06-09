angular.module("booksapp.services", [])
    .factory("booksService", function ($http) {
        var urlBase = '/api/books/';
        var booksAPI = {};

        booksAPI.getBooks = function () {
            return $http.get(urlBase);
        }
        booksAPI.updateBook = function (book) {
            console.log("updatePersons from service called!");
            return $http.put(urlBase + "/" + book.bookId, book);
        }
        booksAPI.createBook = function (book) {
            console.log("createPersons from service called!");
            return $http.post(urlBase, book);
        }
        return booksAPI;
    });