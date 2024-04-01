USE AdventureWorks2019

--Get total persons living at each state province
SELECT ps.Name, COUNT(*)
FROM Person.Person p
JOIN 
	Person.BusinessEntityAddress pb ON p.BusinessEntityID = pb.BusinessEntityID
JOIN
	Person.Address pa ON pa.AddressID = pb.AddressID
JOIN 
	Person.StateProvince ps ON ps.StateProvinceID = pa.StateProvinceID
GROUP BY ps.Name