USE AdventureWorks2019

SELECT 
    ROW_NUMBER() OVER (PARTITION BY pa.PostalCode ORDER BY sp.SalesYTD DESC) AS RowNum,
    p.LastName,
    sp.SalesYTD,
    pa.PostalCode
FROM 
 Person.Person p
JOIN 
	Sales.SalesPerson sp ON p.BusinessEntityID = sp.BusinessEntityID
JOIN 
	Person.Address pa ON sp.TerritoryID = pa.AddressID
WHERE 
    sp.TerritoryID IS NOT NULL
    AND sp.SalesYTD <> 0
ORDER BY 
    pa.PostalCode ASC, sp.SalesYTD DESC;