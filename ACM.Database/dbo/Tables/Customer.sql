CREATE TABLE [dbo].[Customer] (
    [CustomerId]   INT           IDENTITY (1, 1) NOT NULL,
    [LastName]     NVARCHAR (50) NULL,
    [FirstName]    NVARCHAR (50) NULL,
    [EmailAddress] NVARCHAR (50) NULL,
    [CustomerType] INT           NULL,
    CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([CustomerId] ASC)
);

