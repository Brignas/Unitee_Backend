CREATE TABLE [dbo].[ProductSize] (
    [Product_ID] INT NOT NULL,
    [Size_ID] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Product_ID], [Size_ID]),
    FOREIGN KEY ([Product_ID]) REFERENCES [dbo].[Product] ([Product_ID]),
    FOREIGN KEY ([Size_ID]) REFERENCES [dbo].[Size] ([Size_ID])
);