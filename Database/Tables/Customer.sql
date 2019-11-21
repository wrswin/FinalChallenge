CREATE TABLE [dbo].[Customer] (
	[CustNo] INT NOT NULL PRIMARY KEY,
	[CustName] NVARCHAR(50) NOT NULL,
	[CustAddress] NVARCHAR(100) NOT NULL,
	[CustPcode] INT NOT NULL,
	[InterestCode] NCHAR(2) NOT NULL,
	FOREIGN KEY ([InterestCode]) REFERENCES [dbo].[Interest]
);