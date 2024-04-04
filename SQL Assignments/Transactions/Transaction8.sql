USE AdventureWorks2019

--Get the vendor with highest credit rating and increase all his product max order quntity by 10
BEGIN TRANSACTION

BEGIN TRY
	
	DECLARE @MaxCreditRating int

	SELECT @MaxCreditRating =  MAX(CreditRating) FROM Purchasing.Vendor

	PRINT @MaxCreditRating

	DECLARE @VendorID int

	SELECT TOP 1 @VendorID = v.BusinessEntityID FROM Purchasing.Vendor AS v
	JOIN 
		Purchasing.ProductVendor AS pv ON pv.BusinessEntityID = v.BusinessEntityID
		WHERE CreditRating = @MaxCreditRating
		GROUP BY v.BusinessEntityID
		ORDER BY COUNT(*)

	PRINT @VendorID

	UPDATE Purchasing.ProductVendor 
	SET MaxOrderQty = MaxOrderQty + 10
	WHERE BusinessEntityID = @VendorID

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
