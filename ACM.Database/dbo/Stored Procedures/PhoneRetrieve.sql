/*
Name:		PhoneRetrieve

Purpose:	Retrieve all fields from Phone

Developer: 	Deborah Kurata
			InStep Technologies, Inc (www.insteptech.com)

Date:		4/11/2011

Modifications:
	Date	Developer	Description
*/

CREATE PROCEDURE dbo.PhoneRetrieve

AS
    SELECT
            PhoneId,
			CustomerId,
            PhoneNumberDescription,
            PhoneNumber
    FROM
            Phone WITH (NOLOCK)
RETURN