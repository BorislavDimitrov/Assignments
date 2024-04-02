USE AdventureWorks2019

--Get which employees had their pay rates changed after 2010 year
SELECT *
FROM HumanResources.Employee E
WHERE EXISTS 
	(SELECT *
	FROM HumanResources.EmployeePayHistory EPH
	WHERE E.BusinessEntityID = EPH.BusinessEntityID 
	AND YEAR(EPH.RateChangeDate) > 2010 )