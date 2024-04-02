USE AdventureWorks2019

--Get the person with the highest SalesYTD
SELECT BusinessEntityID, FirstName, LastName FROM Person.Person 
WHERE BusinessEntityID =
(
	SELECT BusinessEntityID FROM Sales.SalesPerson 
	WHERE SalesYTD =
	(
		SELECT MAX(SalesYTD) from Sales.SalesPerson
	)
)