CREATE TABLE [dbo].[UserAccount] (
    [User_ID]        INT            NOT NULL,
    [Department_ID]      INT            NULL,
    [User_FirstName] NVARCHAR (255) NOT NULL,
    [User_LastName]  NVARCHAR (255) NOT NULL,
    [User_Password]  NVARCHAR (255) NOT NULL,
    [User_Email]     NVARCHAR (255) NOT NULL,
    [User_PhoneNum]  NVARCHAR(255)            NOT NULL,
    [User_Gender]    NVARCHAR (255) NOT NULL,
    [User_Image]     NVARCHAR (MAX)   NULL,
    [User_IsActive]  BIT            NOT NULL,
    [User_ShopName] NVARCHAR(255) NULL, 
    [User_Role] INT NULL DEFAULT 1, 
    PRIMARY KEY CLUSTERED ([User_ID] ASC),
    FOREIGN KEY ([Department_ID]) REFERENCES [dbo].[Department] ([Department_ID])
);

