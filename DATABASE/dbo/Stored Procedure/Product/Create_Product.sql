CREATE PROCEDURE [dbo].[Create_Product]
    @User_ID int,
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
    --DECLARE @Product_ID int;

    INSERT INTO dbo.Product
    (
        User_ID,
        Department_ID,
        Product_Name,
        Product_Description,
        --Product_Image,
        Product_Gender,
        --Product_Type_ID,
        Product_Price,
        Product_Quantity
    )
    VALUES
    (
        @User_ID,
        @Department_ID,
        @Product_Name,
        @Product_Description,
        --@Product_Image,
        @Product_Gender,
        --@Product_Type_ID,
        @Product_Price,
        @Product_Quantity
    );

--    SET @Product_ID = SCOPE_IDENTITY();
--    BEGIN
--        INSERT INTO dbo.ProductSizes(Product_ID, Size_ID)
--        VALUES (@Product_ID, @Size_ID);
--    END;
--END