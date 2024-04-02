USE AdventureWorks2019

--Get the count of products not listed in Bills of materials
SELECT Count(*) AS NotListedProductsCount
FROM   Production.Product p
WHERE  p.SellEndDate is NULL
AND p.DiscontinuedDate is NULL
AND NOT EXISTS
	(SELECT 1
	FROM   Production.BillOfMaterials bom
	WHERE  bom.ProductAssemblyID = p.ProductID
	OR bom.ComponentID = p.ProductID)