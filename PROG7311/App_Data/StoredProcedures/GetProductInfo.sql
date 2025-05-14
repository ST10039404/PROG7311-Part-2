CREATE PROCEDURE GetProductDataWithDefaultImage @UserID INT
AS
BEGIN
    SELECT
    ProductName,
    Category,
    ProductionDate,
    ProductPrice,
    COALESCE(ProductImage, '') AS ProductImage
	FROM
    Products
	WHERE
	FarmerID = @UserID
END
