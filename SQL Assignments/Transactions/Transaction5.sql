USE AdventureWorks2019

--Get the average Sale YTD and give more 100 bonus to the sale persons that have higher than the average and decrease the bonus with 10% of the people with lower than the average.
BEGIN TRANSACTION

BEGIN TRY

	DECLARE @AverageSalePersonYTD money

	SELECT @AverageSalePersonYTD = AVG(SalesYTD) FROM Sales.SalesPerson
	GROUP BY BusinessEntityID 

	PRINT @AverageSalePersonYTD

	UPDATE Sales.SalesPerson
	SET Bonus = Bonus + 100
	WHERE SalesYTD > @AverageSalePersonYTD
		
	UPDATE Sales.SalesPerson
	SET Bonus = Bonus * (1 - 0.1)
	WHERE SalesYTD < @AverageSalePersonYTD

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