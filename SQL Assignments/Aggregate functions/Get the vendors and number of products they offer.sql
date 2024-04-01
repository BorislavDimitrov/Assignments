USE AdventureWorks2019

--Get the vendors and the number of products they offer
SELECT v.Name, COUNT(*) AS ProductsCount
FROM Purchasing.ProductVendor pv
JOIN 
	Purchasing.Vendor v ON v.BusinessEntityID = pv.BusinessEntityID
GROUP BY v.Name
ORDER BY ProductsCount DESC