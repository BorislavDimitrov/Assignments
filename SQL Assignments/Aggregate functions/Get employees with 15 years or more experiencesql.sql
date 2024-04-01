USE AdventureWorks2019

--Get the count of employees that has atleast 15 years working experience
SELECT 
    COUNT(*) AS NumberOfPeople
FROM 
    HumanResources.Employee e
WHERE 
    DATEDIFF(YEAR, e.HireDate, GETDATE()) >= 15;