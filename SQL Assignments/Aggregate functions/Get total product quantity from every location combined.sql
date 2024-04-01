USE AdventureWorks2019

--Get total product quantity from every location combined
SELECT p.Name, SUM(pi.Quantity)
FROM Production.Product p
JOIN 
	Production.ProductInventory pi ON p.ProductID = pi.ProductID
GROUP BY p.Name