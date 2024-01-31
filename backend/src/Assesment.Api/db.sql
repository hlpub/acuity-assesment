create table Books (
	Id INT PRIMARY KEY IDENTITY (1, 1),
	Title Varchar(100) not null,
	FirstName VARCHAR (50) NOT NULL,
	LastName VARCHAR (50) NOT NULL,
	TotalCopies int not null default 0,
	CopiesInUse int not null default 0,
	[Type] varchar(50),
	ISBN varchar (80),
	Category varchar(50)
);


delete from Books;


INSERT INTO Books (Title, FirstName, LastName, TotalCopies, CopiesInUse, [Type], ISBN, Category)
VALUES ('Pride and Prejudice', 'Jane', 'Austen', 100, 80, 'Hardcover', '1234567891', 'Fiction');


INSERT INTO Books (Title, FirstName, LastName, TotalCopies, CopiesInUse, [Type], ISBN, Category)
VALUES ('To Kill a Mockingbird', 'Harper', 'Lee', 75, 65, 'Paperback', '1234567892', 'Fiction');


INSERT INTO Books (Title, FirstName, LastName, TotalCopies, CopiesInUse, [Type], ISBN, Category)
VALUES ('The Catcher in the Rye', 'J.D.', 'Salinger', 50, 45, 'Hardcover', '1234567893', 'Fiction');


INSERT INTO Books (Title, FirstName, LastName, TotalCopies, CopiesInUse, [Type], ISBN, Category)
VALUES ('The Great Gatsby', 'F. Scott', 'Fitzgerald', 50, 22, 'Hardcover', '1234567894', 'Non-Fiction');


INSERT INTO Books (Title, FirstName, LastName, TotalCopies, CopiesInUse, [Type], ISBN, Category)
VALUES ('The Alchemist', 'Paulo', 'Coelho', 50, 35, 'Hardcover', '1234567895', 'Biography');


INSERT INTO Books (Title, FirstName, LastName, TotalCopies, CopiesInUse, [Type], ISBN, Category)
VALUES ('The Book Thief', 'Markus', 'Zusak', 75, 11, 'Hardcover', '1234567896', 'Mystery');


INSERT INTO Books (Title, FirstName, LastName, TotalCopies, CopiesInUse, [Type], ISBN, Category)
VALUES ('The Chronicles of Narnia', 'C.S.', 'Lewis', 100, 14, 'Paperback', '1234567897', 'Sci-Fi');


INSERT INTO Books (Title, FirstName, LastName, TotalCopies, CopiesInUse, [Type], ISBN, Category)
VALUES ('The Da Vinci Code', 'Dan', 'Brown', 50, 40, 'Paperback', '1234567898', 'Sci-Fi');


INSERT INTO Books (Title, FirstName, LastName, TotalCopies, CopiesInUse, [Type], ISBN, Category)
VALUES ('The Grapes of Wrath', 'John', 'Steinbeck', 50, 35, 'Hardcover', '1234567899', 'Fiction');


INSERT INTO Books (Title, FirstName, LastName, TotalCopies, CopiesInUse, [Type], ISBN, Category)
VALUES ('The Hitchhiker''s Guide to the Galaxy', 'Douglas', 'Adams', 50, 35, 'Paperback', '1234567900', 'Non-Fiction');


INSERT INTO Books (Title, FirstName, LastName, TotalCopies, CopiesInUse, [Type], ISBN, Category)
VALUES ('Moby-Dick', 'Herman', 'Melville', 30, 8, 'Hardcover', '8901234567', 'Fiction');


INSERT INTO Books (Title, FirstName, LastName, TotalCopies, CopiesInUse, [Type], ISBN, Category)
VALUES ('To Kill a Mockingbird', 'Harper', 'Lee', 20, 0, 'Paperback', '9012345678', 'Non-Fiction');


INSERT INTO Books (Title, FirstName, LastName, TotalCopies, CopiesInUse, [Type], ISBN, Category)
VALUES ('The Catcher in the Rye', 'J.D.', 'Salinger', 10, 1, 'Hardcover', '0123456789', 'Non-Fiction');