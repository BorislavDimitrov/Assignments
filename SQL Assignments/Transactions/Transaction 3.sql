USE AdventureWorks2019

--Crating new Region, State province and Address
BEGIN TRANSACTION

BEGIN TRY

	INSERT INTO Person.CountryRegion (CountryRegionCode, Name, ModifiedDate)
	VALUES ('NZL', 'New Zealaand', GETDATE())

	INSERT INTO Person.StateProvince ( StateProvinceCode, CountryRegionCode, IsOnlyStateProvinceFlag, Name, TerritoryID, rowguid, ModifiedDate)
	VALUES ('O', 'NZL', 0, 'Otago', 1, NEWID(), GETDATE())

	DECLARE @StateID int
	SELECT @StateID = MAX(StateProvinceID)
	FROM Person.StateProvince

	INSERT INTO Person.Address ( AddressLine1, AddressLine2, City, StateProvinceID, PostalCode, SpatialLocation, rowguid, ModifiedDate)
	VALUES ('362 Leith Street North', 'Dunedin Dunedin', 'Cromwell', @StateID, 9016, NULL, NEWID(), GETDATE())

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

