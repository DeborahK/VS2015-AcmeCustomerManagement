CREATE TABLE [dbo].[Phone] (
    [PhoneId]                INT           IDENTITY (1, 1) NOT NULL,
    [CustomerId]             INT           NULL,
    [PhoneNumberDescription] NVARCHAR (50) NULL,
    [PhoneNumber]            NVARCHAR (50) NULL,
    CONSTRAINT [PK_Phone] PRIMARY KEY CLUSTERED ([PhoneId] ASC)
);

