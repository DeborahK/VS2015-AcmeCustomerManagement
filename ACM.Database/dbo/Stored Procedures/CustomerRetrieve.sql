/*
Name:		CustomerRetrieve

Purpose:	Retrieve all fields from Customer

Developer: 	Deborah Kurata
			InStep Technologies, Inc (www.insteptech.com)

Date:		6/12/2012

Modifications:
	Date	Developer	Description
*/

CREATE PROCEDURE dbo.CustomerRetrieve
AS
    SELECT
            CustomerId,
            LastName,
            FirstName,
            EmailAddress,
			CustomerType
    FROM
            Customer WITH (NOLOCK)
	ORDER BY
		LastName
RETURN