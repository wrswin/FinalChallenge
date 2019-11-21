CREATE TABLE [dbo].[Order] (
	[CustNo] INT NOT NULL,
	[RecordID] NVARCHAR(10) NOT NULL,
	[DateOrdered] DATE NOT NULL,
	[Price] MONEY NOT NULL,
	PRIMARY KEY ([CustNo], [RecordID], [DateOrdered]),
	FOREIGN KEY ([CustNo]) REFERENCES [dbo].[Customer],
	FOREIGN KEY ([RecordID]) REFERENCES [dbo].[Record]
);