USE AdventureWorks2019

SELECT SalesOrderID, SUM(LineTotal) AS Total
FROM Sales.SalesOrderDetail 
GROUP BY SalesOrderID
HAVING SUM(LineTotal) > 100000