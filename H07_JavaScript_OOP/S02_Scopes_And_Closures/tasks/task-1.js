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
			*	Book title and category name must be between 2 and 100 characters, including letters, 
			*   digits and special characters ('!', ',', '.', etc)
			*	Author is any non-empty string
			*	Unique params are Book title and Book ISBN
			*	Book ISBN is an unique code that contains either 10 or 13 digits
			*	If something is not valid - throw Error
*/

function solve() {
    var library = (function () {
        var books = [];
        var categories = [];

        function listBooks(book) {
            var newListBooks = books.slice(),
                prop;

            if (book !== 'undefined') {
                for (prop in book) {
                    newListBooks = books.filter(function (item) {
                        return item[prop] === book[prop];
                    });
                }
            }

            books = newListBooks.slice();

            return books;
        }

        function addBook(book) {
            parameterAlreadyExists(book.title, 'title');
            parameterAlreadyExists(book.isbn, 'isbn');
            checkIsbnI(book.isbn);
            checkCategoryOrBookNameLength(book.title);
            checkCategoryOrBookNameLength(book.category);
            checkAuthor(book.author);

            book.ID = books.length + 1;

            if (categories.indexOf(book.category) < 0) {
                addCategory(book.category);
            }

            categories[book.category].books.push(book);
            books.push(book);

            return book;
        }        

        function listCategories() {
            var newListCategories = [];

            Array.prototype.push.apply(newListCategories, Object.keys(categories));

            return newListCategories;
        }

        function addCategory(name) {
            categories[name] = {
                books: [],
                ID: categories.length + 1
            };
        }

        function parameterAlreadyExists(name, type) {
            for (var ind = 0, len = books.length; ind < len; ind += 1) {
                if (books[ind][type] === name) {
                    throw new Error('Book ' + type + ' must be unique !');
                }
            }
        }

        function checkAuthor(author) {
            if (typeof author !== 'string' || author === '') {
                throw new Error('Author must be a non-empty string !');
            }
        }

        function checkCategoryOrBookNameLength(name) {
            if (name.length < 2 || name.length > 100) {
                throw new Error('Text length must be between 2 and 100 characters !');
            }
        }

        function checkIsbnI(isbn) {
            if (isbn.length !== 10 && isbn.length !== 13) {
                throw new Error('ISBN must contain only 10 or 13 digits !');
            }

            if (isbn.split('').every(function (digit) {
                    return isNaN(digit);
            })) {
                throw new Error('ISBN must be a valid number');
            }
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
    }());

    return library;
}


module.exports = solve;
