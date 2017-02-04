/* Task Description */
/* 
 *	Create a module for working with books
 *	The module must provide the following functionalities:
 *	Add a new book to category
 *	Each book has unique title, author and ISBN
 *	It must return the newly created book with assigned ID
 *	If the category is missing, it must be automatically created
 *	List all books
 *	Books are sorted by ID
 *	This can be done by author, by category or all
 *	List all categories
 *	Categories are sorted by ID
 *	Each book/catagory has a unique identifier (ID) that is a number greater than or equal to 1
 *	When adding a book/category, the ID is generated automatically
 *	Add validation everywhere, where possible
 *	Book title and category name must be between 2 and 100 characters, including letters, digits and special characters ('!', ',', '.', etc)
 *	Author is any non-empty string
 *	Unique params are Book title and Book ISBN
 *	Book ISBN is an unique code that contains either 10 or 13 digits
 *	If something is not valid - throw Error
 */
function solve() {
    var library = (function() {
        var books = [];
        var categories = [];

        function listBooks(obj) {
            if (obj === undefined) {
                return books;
            }
            let key = Object.keys(obj)[0];
            if (books.every(b => b[key] !== obj[key])) {
                return [];
            } else {
                return books.filter(b => b[key] === obj[key]);
            }
            let sorted = books
                .sort((a, b) => { return a[key] > b[key] ? 1 : -1; });
            return books;
        }

        function addBook(book) {
            if (!book.author || !book.isbn || !book.title) {
                throw "Error";
            }
            if (exists(book, "title") ||
                exists(book, "isbn") ||
                !validateTitle(book.title) ||
                !validateISBN(book.isbn) ||
                !validateAuthor(book.author)
            ) {
                throw "Error";
            }

            book.ID = books.length + 1;
            books.push(book);
            return book;
        }

        function listCategories() {
            let contain = false;
            for (b = 0, len = books.length; b < len; b++) {
                for (let c = 0; c < categories.length; c += 1) {
                    if (categories[c] === books[b].category) {
                        contain = true;
                        break;
                    }
                }
                if (!contain) {
                    categories.push(books[b].category);
                }
            }
            return categories;
        }

        return {
            books: {
                list: listBooks,
                add: addBook
            },
            categories: {
                list: listCategories
            }
        };

        // help functions
        function exists(book, prop) {
            if (books.length > 0) {
                return books.some(b => b[prop] === book[prop]);
            }
        }

        function validateTitle(t) {
            return (t.length >= 2 && t.length <= 100);
        }

        function validateISBN(i) {
            let is = String(i);
            return (is.length === 10 || is.length === 13);
        }

        function validateAuthor(a) {
            return (a.length > 0);
        }

    }());
    return library;
}
module.exports = solve;