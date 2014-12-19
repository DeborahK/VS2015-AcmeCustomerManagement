/*
Name:		CustomerInsert

Purpose:	Insert all fields from Customer

Developer: 	Deborah Kurata
			InStep Technologies, Inc (www.insteptech.com)

Date:		6/12/2010

Modifications:
	Date	Developer	Description
*/

CREATE PROCEDURE dbo.CustomerInsert
(
    @CustomerId                 int output,
    @LastName                   nvarchar(50),
    @FirstName                  nvarchar(50),
    @EmailAddress               nvarchar(50),
	@CustomerType				int
)
AS
    INSERT INTO Customer
    (
            LastName,
            FirstName,
            EmailAddress,
			CustomerType
    )
    VALUES
    (
            @LastName,
            @FirstName,
            @EmailAddress,
			@CustomerType
   )

    SELECT @CustomerId = SCOPE_IDENTITY()

RETURN