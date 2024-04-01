USE AdventureWorks2019

--Get employees full name, job title, gender and calculated current years
SELECT 
	p.FirstName + ' ' + ISNULL(p.MiddleName + ' ', '') + p.LastName AS FullName,
	e.JobTitle,
	e.Gender,
    DATEDIFF(YEAR, e.BirthDate, GETDATE()) - 
    CASE 
        WHEN DATEADD(YEAR, DATEDIFF(YEAR, e.BirthDate, GETDATE()), e.BirthDate) > GETDATE() THEN 1 
        ELSE 0 
    END AS Age
FROM 
    HumanResources.Employee e
JOIN 
	Person.Person p ON e.BusinessEntityID = p.BusinessEntityID
ORDER BY Age