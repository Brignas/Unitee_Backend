CREATE PROCEDURE [dbo].[Create_Product]
	 @Department_ID int
	, @Product_Name varchar(200)
	, @Product_Description varchar(200)
	, @Product_Image nvarchar(200)
	, @Product_Gender nvarchar(200)
	, @Product_Type_ID int
	, @Product_Price float
	, @Product_Quantity int
	, @Product_Size int
AS
	INSERT INTO dbo.Product
	(
		Department_ID
		, Product_Name
		, Product_Description
		, Product_Image
		, Product_Gender
		, Product_Type_ID
		, Product_Price
		, Product_Quantity
		, Product_Size
	)
	VALUES
	(
		@Department_ID
		, @Product_Name
		, @Product_Description
		, @Product_Image
		, @Product_Gender
		, @Product_Type_ID
		, @Product_Price
		, @Product_Quantity
		, @Product_Size
	)