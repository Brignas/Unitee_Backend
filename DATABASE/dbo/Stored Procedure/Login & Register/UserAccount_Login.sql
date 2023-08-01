CREATE PROCEDURE [dbo].[UserAccount_Login]
    @User_ID int,
    @User_Password varchar(200)
AS
    SELECT User_ID, User_Password, User_Role 
    FROM dbo.UserAccount
    WHERE User_ID = @User_ID AND User_Password = @User_Password