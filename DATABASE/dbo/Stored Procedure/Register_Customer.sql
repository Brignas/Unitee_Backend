CREATE PROCEDURE [dbo].[Register_Customer]
	@User_ID int
	, @User_FirstName varchar(200)
	, @User_LastName varchar(200)
	, @User_Email varchar(200)
	, @User_PhoneNum varchar(200)
	, @User_Password varchar(200)
	, @Department_ID int
	, @User_Gender varchar(200)
AS
	INSERT INTO dbo.UserAccount
	(
		User_ID
		, User_FirstName
		, User_LastName
		, User_Email
		, User_PhoneNum
		, User_Password
		, Department_ID
		, User_Gender
		, User_IsActive
		, User_Role
	)
	VALUES
	(
		@User_ID
		, @User_FirstName
		, @User_LastName
		, @User_Email
		, @User_PhoneNum
		, @User_Password
		, @Department_ID
		, @User_Gender
		, 1
		, 1
	)
