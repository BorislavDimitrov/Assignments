USE AdventureWorks2019

-- get the number of female and male employees in each department
SELECT d.Name, e.Gender, COUNT(*) AS Count
FROM HumanResources.Employee e
JOIN 
	HumanResources.EmployeeDepartmentHistory dh ON e.BusinessEntityID = dh.BusinessEntityID
JOIN 
	HumanResources.Department d ON dh.DepartmentID = d.DepartmentID 
group by d.Name, e.Gender
order by d.Name