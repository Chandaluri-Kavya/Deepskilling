USE EmployeeManagement;
GO


IF OBJECT_ID('sp_GetEmployeeCountByDepartment', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetEmployeeCountByDepartment;
GO


CREATE PROCEDURE sp_GetEmployeeCountByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT
        DepartmentID,
        COUNT(*) AS TotalEmployees
    FROM Employees
    WHERE DepartmentID = @DepartmentID
    GROUP BY DepartmentID;
END;
GO

EXEC sp_GetEmployeeCountByDepartment 3;
GO