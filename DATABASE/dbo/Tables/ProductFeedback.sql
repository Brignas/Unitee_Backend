CREATE TABLE [dbo].[ProductFeedback] (
    [Feedback_ID]         INT            NOT NULL IDENTITY,
    [Customer_ID]         INT            NOT NULL,
    [Product_ID]          INT            NOT NULL,
    [Feedback_StarRating] INT            NULL,
    [Feedback_Comment]    NVARCHAR (255) NULL,
    [Feedback_Date]       DATE           NOT NULL,
    PRIMARY KEY CLUSTERED ([Feedback_ID] ASC),
    FOREIGN KEY ([Customer_ID]) REFERENCES [dbo].[UserAccount] ([User_ID]),
    FOREIGN KEY ([Product_ID]) REFERENCES [dbo].[Product] ([Product_ID])
);

