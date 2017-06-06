/* MAKE SURE YOU HAVE CREATED THE PROCEDURE FIRST */

USE db_book;
GO

EXEC dbo.getBookInfo 'The Lost Tribe', 'Sharpstown';

EXEC dbo.getBookInfo null, 'Central', 'Stephen King';

EXEC dbo.getBookInfo null, 'Sharpstown';

EXEC dbo.getBookInfo;