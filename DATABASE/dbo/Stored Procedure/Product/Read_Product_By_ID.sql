CREATE PROCEDURE [dbo].[Read_Product_By_ID]
	@Product_ID int
AS
	SELECT * from dbo.Product
	WHERE Product_ID = @Product_ID