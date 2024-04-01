USE AdventureWorks2019

--Get the average list price for each product
SELECT p.Name, AVG(plph.ListPrice) AS AverageListPrice
FROM Production.Product p
LEFT JOIN
	Production.ProductListPriceHistory plph ON p.ProductID = plph.ProductID
GROUP BY p.Name
ORDER BY AverageListPrice DESC