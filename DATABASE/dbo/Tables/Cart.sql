CREATE TABLE [dbo].[Cart] (
    [Cart_ID]     INT NOT NULL IDENTITY,
    [User_ID] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Cart_ID] ASC),
    FOREIGN KEY ([User_ID]) REFERENCES [dbo].[UserAccount] ([User_ID])
);

