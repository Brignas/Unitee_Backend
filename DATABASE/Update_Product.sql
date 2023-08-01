CREATE PROCEDURE [dbo].[Update_Product]
    @Product_ID int,
	@Department_ID int,
    @Product_Name varchar(200),
    @Product_Description varchar(200),
    --@Product_Image nvarchar(200),
    @Product_Gender nvarchar(200),
    --@Product_Type_ID int,
    @Product_Price float,
    @Product_Quantity int
    --@Size_ID int
AS
    UPDATE dbo.Product SET 
	Department_ID = @Department_ID,
    Product_Name = @Product_Name,
    Product_Description = @Product_Description,
    --@Product_Image ,
    Product_Gender = @Product_Gender,
    --@Product_Type_ID ,
    Product_Price = @Product_Price,
    Product_Quantity = @Product_Quantity
    --@Size_ID int
    WHERE Product_ID = @Product_ID
    
	
