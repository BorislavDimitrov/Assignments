USE AdventureWorks2019

--Get product order with maximum order quantity
SELECT od.SalesOrderID, p.Name AS ProductName, od.ProductID, od.OrderQty AS Quantity
FROM Sales.SalesOrderDetail AS od
JOIN Production.Product p ON od.ProductID = p.ProductID 
WHERE od.OrderQty = (
  SELECT MAX(OrderQty)
  FROM Sales.SalesOrderDetail AS d
  WHERE od.ProductID = d.ProductID
)
ORDER BY od.ProductID;