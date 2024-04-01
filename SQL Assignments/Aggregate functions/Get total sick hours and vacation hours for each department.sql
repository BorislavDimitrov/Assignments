use AdventureWorks2019

--Get the total sick hours and total vacation hours for each department
SELECT d.Name, SUM(e.SickLeaveHours) AS TotalSickLeaveHours, SUM(e.VacationHours) AS TotalVacationHours
FROM HumanResources.Employee e
JOIN 
	HumanResources.EmployeeDepartmentHistory dh ON e.BusinessEntityID = dh.BusinessEntityID
JOIN 
	HumanResources.Department d ON dh.DepartmentID = d.DepartmentID 
group by d.Name
order by SUM(e.SickLeaveHours) DESC, SUM(e.VacationHours) DESC
