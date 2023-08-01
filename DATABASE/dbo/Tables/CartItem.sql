CREATE TABLE [dbo].[CartItem] (
    [CartItem_ID]       INT NOT NULL IDENTITY,
    [Cart_ID]           INT NOT NULL,
    [Product_ID]        INT NOT NULL,
    [CartItem_Quantity] INT NOT NULL,
    [Size_ID]           INT NOT NULL,
    PRIMARY KEY CLUSTERED ([CartItem_ID] ASC),
    FOREIGN KEY ([Cart_ID]) REFERENCES [dbo].[Cart] ([Cart_ID]),
    FOREIGN KEY ([Product_ID]) REFERENCES [dbo].[Product] ([Product_ID]),
);

