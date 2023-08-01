CREATE TABLE [dbo].[Order] (
    [Order_ID]           INT            NOT NULL IDENTITY,
    [User_ID]        INT            NOT NULL,
    [Order_Total_Amount] INT            NOT NULL,
    [Order_Date]         DATETIME       NOT NULL,
    [Order_Status]       NVARCHAR (255) NOT NULL,
    [Order_PaymentProof] NVARCHAR (1)   NOT NULL,
    [Order_Receipt]      NVARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([Order_ID] ASC),
    FOREIGN KEY ([User_ID]) REFERENCES [dbo].[UserAccount]([User_ID])
);

