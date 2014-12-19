CREATE TABLE [dbo].[Invoice] (
    [InvoiceId]   INT                NOT NULL,
    [InvoiceDate] DATETIMEOFFSET (0) NULL,
    CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED ([InvoiceId] ASC)
);

