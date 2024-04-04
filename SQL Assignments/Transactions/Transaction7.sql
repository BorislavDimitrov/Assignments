USE AdventureWorks2019

--Check if certain product quantity is available and if it is decrease it and makes a new order, otherwise rolls back the transaction.
BEGIN TRANSACTION

BEGIN TRY
	
	--Example input values
	DECLARE @ProductID INT = 800
	DECLARE @WantedQuantity int = 2
	DECLARE @CurrentQuantity INT

	SELECT @CurrentQuantity = Quantity FROM Production.ProductInventory
	WHERE ProductID = @ProductID;

	PRINT @CurrentQuantity

	IF @CurrentQuantity >= @WantedQuantity
	BEGIN

		UPDATE Production.ProductInventory
		SET Quantity = Quantity - @WantedQuantity
		WHERE ProductID = @ProductID

		PRINT @ProductID
		PRINT @WantedQuantity

		INSERT INTO Sales.SalesOrderHeader (RevisionNumber , OrderDate , DueDate , ShipDate , Status , OnlineOrderFlag , PurchaseOrderNumber ,AccountNumber , 
		CustomerID , SalesPersonID , TerritoryID , BillToAddressID ,ShipToAddressID , ShipMethodID , CreditCardID , CreditCardApprovalCode , CurrencyRateID , SubTotal ,
		TaxAmt , Freight , Comment, rowguid, ModifiedDate)
     VALUES
           (8 ,GETDATE() , DATEADD(DAY, 5, GETDATE()) , NULL , 5 , 0 , NULL , NULL , 29749 , NULL , NULL , 974 , 974 , 5 , NULL , NULL , NULL , 
		   2244.4088 , 701.3777 , 26346.8927, 'Some comment', NEWID(), GETDATE())
	
		INSERT INTO Sales.SalesOrderDetail ( SalesOrderID,ProductID, OrderQty, UnitPrice)
		VALUES (IDENT_CURRENT('Sales.SalesOrderHeder'), @ProductID, @WantedQuantity, (SELECT ListPrice FROM Production.Product WHERE ProductID = @ProductID))

		COMMIT TRANSACTION
		PRINT 'Order detail created and inventory updated.'
	END

	ELSE
		BEGIN
			PRINT 'Insufficient stock for product. Order cannot be placed.';
			ROLLBACK; 
		END;

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
