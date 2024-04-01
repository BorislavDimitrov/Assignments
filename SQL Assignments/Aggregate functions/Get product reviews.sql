USE AdventureWorks2019

--Get product reviews 
SELECT p.Name, pr.Rating, pr.Comments
FROM Production.ProductReview pr
JOIN 
	Production.Product p ON pr.ProductID = p.ProductID
ORDER BY pr.Rating DESC