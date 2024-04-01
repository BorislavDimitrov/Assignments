use AdventureWorks2019

--Get the number of employees working in each department
SELECT d.Name, count(e.BusinessEntityID) AS EmployeesInDepartment
FROM HumanResources.Employee e
JOIN 
	HumanResources.EmployeeDepartmentHistory dh ON e.BusinessEntityID = dh.BusinessEntityID
JOIN 
	HumanResources.Department d ON dh.DepartmentID = d.DepartmentID 
GROUP BY d.Name