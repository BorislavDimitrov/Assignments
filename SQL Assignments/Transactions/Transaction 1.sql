USE AdventureWorks2019

--Trying to add new department and new employee into it should lead to error because of the second querry field OrganizationLevel and the transaction should be rolled back.
BEGIN TRANSACTION

BEGIN TRY

	INSERT INTO HumanResources.Department ( Name, GroupName, ModifiedDate)
	VALUES ('Accounting', 'Finance and Accounting', GETDATE()) 

	INSERT INTO HumanResources.Employee (BusinessEntityID, NationalIDNumber, LoginID, OrganizationNode, OrganizationLevel, JobTitle, BirthDate, MaritalStatus, Gender,
	HireDate, SalariedFlag, VacationHours, SickLeaveHours, CurrentFlag, rowguid, ModifiedDate)
	VALUES (291, 295842284, 'adventure-works\pilar0', '0x53A', 1, 'Accountant', '1987-06-10', 'M', 'M', '2009-01-04', 0, 65, 41, 1, '9E912556-88BA-41EE-B946-CB84AB4C1102', GETDATE())

	INSERT INTO HumanResources.EmployeeDepartmentHistory( BusinessEntityID, DepartmentID, ShiftID, StartDate, EndDate, ModifiedDate )
	VALUES ( IDENT_CURRENT('HumanResources.Employee'), IDENT_CURRENT('HumanResource.Department'), 1, GETDATE(), NULL, GETDATE()) 

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