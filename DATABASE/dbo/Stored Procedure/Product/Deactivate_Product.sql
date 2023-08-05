CREATE PROCEDURE [dbo].[Deactivate_Product]
	@Product_ID int
	, @Product_IsActive bit
AS
	UPDATE dbo.Product
	SET
		Product_IsActive = @Product_IsActive
	WHERE
		Product_ID = @Product_ID
