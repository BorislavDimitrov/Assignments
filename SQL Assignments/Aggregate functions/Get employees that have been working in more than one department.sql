USE AdventureWorks2019

--Get the employees that have been working in more than one department
SELECT A.*, B.FirstName, B.LastName
FROM (
    SELECT d.BusinessEntityID
FROM HumanResources.EmployeeDepartmentHistory d
GROUP BY d.BusinessEntityID
HAVING COUNT(*) > 1
) AS A
 JOIN Person.Person AS B ON A.BusinessEntityID = B.BusinessEntityID;