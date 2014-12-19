/*
Name:		PhoneInsert

Purpose:	Insert all fields from Phone

Developer: 	Deborah Kurata
			InStep Technologies, Inc (www.insteptech.com)

Date:		4/12/11

Modifications:
	Date	Developer	Description
*/

CREATE PROCEDURE dbo.PhoneInsert
(
    @PhoneId                       int output,
    @CustomerId                    int,
    @PhoneNumberDescription        nvarchar(50),
    @PhoneNumber                   nvarchar(50)
)
AS
    INSERT INTO Phone
    (
            CustomerId,
            PhoneNumberDescription,
            PhoneNumber
    )
    VALUES
    (
            @CustomerId,
            @PhoneNumberDescription,
            @PhoneNumber
   )

    SELECT @PhoneId = SCOPE_IDENTITY()

RETURN