 USE AdventureWorks2019
 
 --Get total pay rate for each department
 SELECT d.DepartmentID, SUM(ph.Rate) AS TotalDepartmentPayRate
 from HumanResources.Department d
 JOIN 
	HumanResources.EmployeeDepartmentHistory dh ON dh.DepartmentID = d.DepartmentID
JOIN 
	HumanResources.EmployeePayHistory ph ON ph.BusinessEntityID = dh.BusinessEntityID
GROUP BY d.DepartmentID
ORDER BY TotalDepartmentPayRate DESC