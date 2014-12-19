/*
Name:		CustomerUpdate

Purpose:	Update all fields from Customer

Developer: 	Deborah Kurata
			InStep Technologies, Inc (www.insteptech.com)

Date:		6/12/2010

Modifications:
	Date	Developer	Description
*/

CREATE PROCEDURE dbo.CustomerUpdate
(
    @CustomerId                  int,
    @LastName                   nvarchar(50),
    @FirstName                  nvarchar(50),
    @EmailAddress               nvarchar(50),
	@CustomerType				int
)
AS
    UPDATE Customer
        SET
            LastName = @LastName,
            FirstName = @FirstName,
            EmailAddress = @EmailAddress,
			CustomerType = @CustomerType
    WHERE
            CustomerId = @CustomerId
RETURN