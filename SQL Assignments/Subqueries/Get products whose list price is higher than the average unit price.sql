USE AdventureWorks2019

--Get products whose list price is higher than the average unit price
 SELECT ProductID, Name, ListPrice
 FROM Production.Product
 WHERE ListPrice >
     (SELECT AVG(UnitPrice)
      FROM Sales.SalesOrderDetail)
 ORDER BY ProductID;
