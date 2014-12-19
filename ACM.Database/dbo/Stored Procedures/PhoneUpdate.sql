/*
Name:		PhoneUpdate

Purpose:	Update all fields from Customer

Developer: 	Deborah Kurata
			InStep Technologies, Inc (www.insteptech.com)

Date:		4/12/11

Modifications:
	Date	Developer	Description
*/

CREATE PROCEDURE dbo.PhoneUpdate
(
    @PhoneId                       int,
    @CustomerId                    int,
    @PhoneNumberDescription        nvarchar(50),
    @PhoneNumber                   nvarchar(50)
)
AS
    UPDATE Phone
        SET
            CustomerId = @CustomerId,
            PhoneNumberDescription = @PhoneNumberDescription,
            PhoneNumber = @PhoneNumber
    WHERE
            PhoneId = @PhoneId
RETURN