USE AdventureWorks2019

--Get the employees that have more vacation hours than average for their job title
SELECT E1.BusinessEntityID, E1.JobTitle, E1.VacationHours, Sub.AverageVacation
FROM HumanResources.Employee E1
JOIN (SELECT
      JobTitle,
      AVG(VacationHours) AverageVacation
      FROM HumanResources.Employee E2
      GROUP BY JobTitle) sub
ON E1.JobTitle = Sub.JobTitle
WHERE E1.VacationHours > Sub.AverageVacation
ORDER BY E1.JobTitle