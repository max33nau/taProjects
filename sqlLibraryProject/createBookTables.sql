/* MAKE SURE YOU CREATE THE DATABASE FIRST */
USE db_book;

CREATE TABLE tbl_publisher(
	publisher_Name VARCHAR(50) PRIMARY KEY NOT NULL,
	publisher_Address VARCHAR(50) NOT NULL,
	publisher_Phone VARCHAR(50) NOT NULL
);

CREATE TABLE tbl_book(
	book_Bookid INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	book_Title VARCHAR(50) NOT NULL,
	book_PublisherName VARCHAR(50) NOT NULL CONSTRAINT fk_PublisherName FOREIGN KEY REFERENCES tbl_publisher(publisher_Name)
);

CREATE TABLE tbl_author(
	author_Bookid INT NOT NULL CONSTRAINT fk_Bookid FOREIGN KEY REFERENCES tbl_book(book_Bookid) ON UPDATE CASCADE ON DELETE CASCADE,
	author_AuthorName VARCHAR(50) NOT NULL
);

CREATE TABLE tbl_borrower(
	borrower_CardNo INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	borrower_Name VARCHAR(50) NOT NULL,
	borrower_Address VARCHAR(50) NOT NULL,
	borrower_Phone VARCHAR(50) NOT NULL
);

CREATE TABLE tbl_library_branch(
	library_Branchid INT PRIMARY KEY NOT NULL,
	library_BranchName VARCHAR(50) NOT NULL,
	library_Address VARCHAR(50) NOT NULL
);

CREATE TABLE tbl_loans(
	loans_Bookid INT NOT NULL CONSTRAINT fk_loans_Bookid FOREIGN KEY REFERENCES tbl_book(book_Bookid) ON UPDATE CASCADE ON DELETE CASCADE,
	loans_Branchid INT NOT NULL CONSTRAINT fk_Branchid FOREIGN KEY REFERENCES tbl_library_branch(library_Branchid) ON UPDATE CASCADE ON DELETE CASCADE,
	loans_CardNo INT NOT NULL CONSTRAINT fk_CardNo FOREIGN KEY REFERENCES tbl_borrower(borrower_CardNo) ON UPDATE CASCADE ON DELETE CASCADE,
	loans_DateOut DATE NOT NULL,
	loans_DueDate DATE NOT NULL
);

CREATE TABLE tbl_copies(
	copies_Bookid INT NOT NULL CONSTRAINT fk_copies_Bookid FOREIGN KEY REFERENCES tbl_book(book_Bookid) ON UPDATE CASCADE ON DELETE CASCADE,
	copies_Branchid INT NOT NULL CONSTRAINT fk_Branch_id FOREIGN KEY REFERENCES tbl_library_branch(library_Branchid) ON UPDATE CASCADE ON DELETE CASCADE,
	copies_No_Of_Copies INT NOT NULL
);