USE AdventureWorks2019

SELECT p.BusinessEntityID, p.FirstName, p.LastName, pp.PhoneNumber
FROM Person.Person p
JOIN Person.PersonPhone pp ON p.BusinessEntityID = pp.BusinessEntityID
WHERE p.LastName LIKE 'L%'
ORDER BY p.LastName, p.FirstName;