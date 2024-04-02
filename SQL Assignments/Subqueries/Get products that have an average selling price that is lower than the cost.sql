USE AdventureWorks2019

 --Get products that have an average selling price that is lower than the cost
  SELECT p.ProductID, p.Name, p.StandardCost, p.ListPrice,
     (SELECT AVG(o.UnitPrice)
     FROM Sales.SalesOrderDetail AS o
     WHERE p.ProductID = o.ProductID) AS AvgSellingPrice
 FROM Production.Product AS p
 WHERE StandardCost >
     (SELECT AVG(od.UnitPrice)
      FROM Sales.SalesOrderDetail AS od
      WHERE p.ProductID = od.ProductID)
 ORDER BY p.ProductID;