USE AdventureWorks2019

--Get products that have no subcomponents
SELECT p.ProductID, p.Name, p.ProductNumber, p.ListPrice
FROM   Production.Product p
WHERE  p.SellEndDate is NULL
AND p.DiscontinuedDate is NULL
AND NOT EXISTS 
	   (SELECT 1
        FROM  Production.BillOfMaterials bom
        WHERE p.ProductID = bom.ProductAssemblyID)
ORDER BY ListPrice DESC