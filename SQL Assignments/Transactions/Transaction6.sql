USE AdventureWorks2019

--Trying to delete a product that was never ordered and has the highest list price should lead to throw error at Delete query and the transaction should be rolled back
BEGIN TRANSACTION

BEGIN TRY

	DECLARE @ProductIDs TABLE (ProductID INT);

	INSERT INTO @ProductIDs (ProductID)
	SELECT p.ProductID
	FROM Production.Product AS p
	LEFT JOIN Sales.SalesOrderDetail AS srd ON p.ProductID = srd.ProductID
	WHERE srd.ProductID IS NULL;

	DECLARE @DeleteProductID int

	SELECT TOP 1 @DeleteProductID = p.ProductID
	FROM Production.Product AS p
	WHERE ProductID IN (SELECT ProductID FROM @ProductIDs)
	ORDER BY p.ListPrice DESC

	PRINT @DeleteProductID

	DELETE FROM Production.Product WHERE ProductID = @DeleteProductID;

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

