USE AdventureWorks2019

--Get the count of employees with certain martial status
SELECT e.MaritalStatus, COUNT(e.MaritalStatus)
FROM HumanResources.Employee e
GROUP BY e.MaritalStatus