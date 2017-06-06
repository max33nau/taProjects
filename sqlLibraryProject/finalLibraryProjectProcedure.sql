/* MAKE SURE YOU CREATE YOUR DATABASE and POPULATE TABLES in the finalLibraryProject.sql File */
USE db_book;
GO

CREATE PROCEDURE dbo.getBookInfo 
@bookTitle VARCHAR(50) = null, @branchName VARCHAR(50) = null, @bookAuthor VARCHAR(50) = null
AS
BEGIN
	BEGIN TRY
		DECLARE @bookFound INT;
		SET @bookFound = (SELECT COUNT(*) FROM tbl_book WHERE @bookTitle =  tbl_book.book_Title);
		DECLARE @branchFound INT;
		SET @branchFound = (SELECT COUNT(*) FROM tbl_library_branch WHERE @branchName =  tbl_library_branch.library_BranchName);
		DECLARE @authorFound INT;
		SET @authorFound = (SELECT COUNT(*) FROM tbl_author WHERE @bookAuthor = tbl_author.author_AuthorName);
		IF(@bookTitle IS NULL AND @branchName IS NULL AND @bookAuthor IS NULL)
			BEGIN
			/* 3. Retrieve the names of all borrowers who do not have any books checked out. */
			SELECT a.borrower_Name AS 'People with no Loans' FROM tbl_borrower a 
				LEFT JOIN tbl_loans b ON a.borrower_CardNo = b.loans_CardNo
				WHERE b.loans_CardNo IS NULL;
			/* 5. For each library branch, retrieve the branch name and the total number of books loaned out from that branch */
			SELECT b.library_BranchName AS 'Branch Name',  COUNT(a.loans_Bookid) AS 'Number of Loans' FROM tbl_loans a
				INNER JOIN tbl_library_branch b ON b.library_Branchid = a.loans_Branchid
				GROUP BY b.library_BranchName;
			/* 6. Retrieve the names, addresses, and number of books checked out for all borrowers who have more than 5 books
				checked out. */
			SELECT a.borrower_Name as 'Name:', a.borrower_Address AS 'Address:', COUNT(b.loans_Bookid) AS 'Number of Books'  FROM tbl_borrower a
				INNER JOIN tbl_loans b ON a.borrower_CardNo = b.loans_CardNo
				GROUP BY a.borrower_Name, a.borrower_Address HAVING COUNT(b.loans_Bookid) > 5;
			END
		ELSE IF(@branchName IS NULL AND @bookAuthor IS NULL)
			BEGIN
			/* 2. How many copies of the book titled "The Lost Tribe" are owned by each library branch?" */
			IF @bookFound <> 0 
				SELECT SUM(a.copies_No_Of_Copies) AS 'Total Number Of Copies' FROM tbl_copies a
					INNER JOIN tbl_book b ON a.copies_Bookid = b.book_Bookid
					INNER JOIN tbl_library_branch c ON a.copies_Branchid = c.library_Branchid
					WHERE @bookTitle = b.book_Title;
			ELSE 
				PRINT('We currently do not have a copy of '+@bookTitle + ' at one of library locations.');
			END
		ELSE IF(@bookTitle IS NULL AND @bookAuthor IS NULL)
			BEGIN
			/* 4. For each book that is loaned out from the "Sharpstown" branch and whose DueDate is today, retrieve,
			the book title, the borrower's name, and the borrower's address */
			IF @branchFound = 0
				PRINT('The branch name ' + @branchName + ' has currently not been constructed yet')
			ELSE 
				DECLARE @today DATE
				SET @today = (SELECT CONVERT(date, SYSDATETIME()));
				IF (SELECT COUNT(*) FROM tbl_loans WHERE @today = tbl_loans.loans_DueDate) = 0
					PRINT('No books are due today');
				ELSE
					SELECT a.book_Title AS 'Book Title', c.borrower_Name AS 'Borrower Name', c.borrower_Address 
					AS 'Borrower Address' FROM tbl_book a
						INNER JOIN tbl_loans b ON a.book_Bookid = b.loans_Bookid
						INNER JOIN tbl_borrower c ON b.loans_CardNo = c.borrower_CardNo
						INNER JOIN tbl_library_branch d ON b.loans_Branchid = d.library_Branchid
						WHERE @today = b.loans_DueDate AND @branchName = d.library_BranchName;
			END
		ELSE IF(@bookAuthor IS NULL)
			BEGIN
			/* 1. How many copies of the book titled "The Lost Tribe" are owned by the library branch whose name is "Sharpstown"? */
			IF @bookFound <> 0 AND @branchFound <> 0
				SELECT a.copies_No_Of_Copies AS 'Number Of Copies at Branch' FROM tbl_copies a 
					INNER JOIN tbl_book b ON a.copies_Bookid = b.book_Bookid
					INNER JOIN tbl_library_branch c ON a.copies_Branchid = c.library_Branchid
					WHERE @bookTitle = b.book_Title AND @branchName = c.library_BranchName;
			ELSE IF @bookFound = 0 AND @branchFound <> 0
				PRINT('Unable to find book ' + @bookTitle +' for the books we carry');
			ELSE IF @bookFound <> 0 AND @branchFound = 0
				PRINT('Unable to find the branch ' + @branchName +' .');
			ELSE 
				PRINT('Invalid book title and branch name');
			END
		ELSE IF(@bookTitle IS NULL)
			BEGIN
			/* 7. For each book authored (or co-authored) by "Stephen King", retrieve the title and the number of copies
			owned by the library branch whose name is "Central" */
			IF @authorFound <> 0 AND @branchFound <> 0
				SELECT b.book_Title AS 'Book Title', a.copies_No_Of_Copies AS 'Number Of Copies at Branch' FROM tbl_copies a 
					INNER JOIN tbl_book b ON a.copies_Bookid = b.book_Bookid
					INNER JOIN tbl_library_branch c ON a.copies_Branchid = c.library_Branchid
					INNER JOIN tbl_author d ON b.book_Bookid = d.author_Bookid
					WHERE @bookAuthor = d.author_AuthorName AND @branchName = c.library_BranchName;
			ELSE IF @authorFound = 0 AND @branchFound <> 0
				PRINT('Unable to find author ' + @bookAuthor +' for the books we carry');
			ELSE IF @authorFound <> 0 AND @branchFound = 0
				PRINT('Unable to find the branch ' + @branchName +' .');
			ELSE 
				PRINT('Invalid author and branch name');
			END
		ELSE 
			PRINT('INVALID PARAMETERS ENTERED FOR THIS PROCEDURE');
	END TRY

	BEGIN CATCH
		SELECT ERROR_NUMBER() AS ErrorNumber
		,ERROR_SEVERITY() AS ErrorSeverity
		,ERROR_STATE() AS ErrorState
		,ERROR_PROCEDURE() AS ErrorProcedure
		,ERROR_LINE() AS ErrorLine
		,ERROR_MESSAGE() AS ErrorMessage;
	END CATCH;
END;



