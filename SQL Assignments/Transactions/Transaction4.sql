USE AdventureWorks2019

--Get the highest rated product and increase its list price by 5%
BEGIN TRANSACTION

BEGIN TRY

	DECLARE @ProductID int

	SELECT TOP 1 @ProductID =  ProductID FROM
	Production.ProductReview
	GROUP BY ProductID
	ORDER BY AVG(Rating) DESC

	PRINT @ProductID

	DECLARE @ListPrice int

	SELECT @ListPrice = ListPrice
	FROM Production.Product
	WHERE ProductID = @ProductID

	PRINT @ListPrice

	UPDATE Production.Product
	SET ListPrice = @ListPrice * 1.05, ModifiedDate = GETDATE()
	WHERE ProductID = @ProductID

	COMMIT TRANSACTION
END TRY

BEGIN CATCH
  IF @@ERROR <> 0 
  BEGIN
    DECLARE @ErrorMessage NVARCHAR(4000);
    SET @ErrorMessage = ERROR_MESSAGE(); 
    PRINT 'Transaction failed: ' + @ErrorMessage; 
    ROLLBACK; 
  END;
END CATCH;