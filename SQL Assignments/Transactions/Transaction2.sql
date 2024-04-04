USE AdventureWorks2019

--Create new Business entity and Person
BEGIN TRANSACTION

BEGIN TRY	

	INSERT INTO Person.BusinessEntity (rowguid, ModifiedDate)
	VALUES ( NEWID(), GETDATE())
	
	INSERT INTO Person.Person (BusinessEntityID, PersonType, NameStyle, Title, FirstName, MiddleName, LastName, Suffix, EmailPromotion, AdditionalContactInfo, Demographics, rowguid, ModifiedDate)
	VALUES (IDENT_CURRENT('Person.BusinessEntity'), 'EM', 0, NULL, 'Ivan', 'D', 'Dimitrov', NULL, 1, NULL,
	'<IndividualSurvey xmlns="http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/IndividualSurvey"><TotalPurchaseYTD>0</TotalPurchaseYTD></IndividualSurvey>',
	NEWID(), GETDATE())

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