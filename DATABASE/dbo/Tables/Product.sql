CREATE TABLE [dbo].[Product] (
    [Product_ID]          INT            NOT NULL IDENTITY,
    [Department_ID]       INT            NULL,
    [Product_Name]        NVARCHAR (255) NOT NULL,
    [Product_Description] NVARCHAR (255) NOT NULL,
    [Product_Image]       NVARCHAR (1)   NULL,
    [Product_Gender]      NVARCHAR (255) NOT NULL,
    [Product_Type_ID]     NVARCHAR (255) NULL,
    [Product_Price]       FLOAT (53)     NOT NULL,
    [Product_IsActive]    BIT            NOT NULL DEFAULT 1,
    [Product_Quantity]    INT            NOT NULL DEFAULT 1,
    [Product_Size] INT NULL, 
    [User_ID] INT NULL, 
    PRIMARY KEY CLUSTERED ([Product_ID] ASC),
    FOREIGN KEY ([Department_ID]) REFERENCES [dbo].[Department] ([Department_ID])
);

