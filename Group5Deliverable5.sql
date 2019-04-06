--Chas Davis, Tyson Baker, Andrew Browning, Rodney Roe
--INFO 4407
--Jon Holmes
--Deliverable 5
--4/14/2018

--1.
--A.
CREATE PROC sprocEmployeesGetAll
AS
BEGIN
    SET NOCOUNT ON
    SELECT * FROM Employees
END
GO
--B.
CREATE PROC sprocEmployeeGet
@EmployeeID int
AS
BEGIN
    SET NOCOUNT ON
    SELECT * FROM Employees
    WHERE Employees.EmployeeID = @EmployeeID
END
GO
--C.
CREATE PROC sproc_EmployeeAdd
@FirstName nvarchar(60)
,@MiddleName nvarchar(60)
,@LastName nvarchar(60)
,@EmployeeNumber int
,@DepartmentID int
AS
BEGIN
    DECLARE @PersonID int
    INSERT INTO People
		VALUES
		(@FirstName,@MiddleName,@LastName,'1','1','1')
	SET @PersonID = @@IDENTITY
    INSERT INTO Employees
		VALUES
		(@EmployeeNumber,@DepartmentID,@PersonID)
END
GO
--D.
CREATE PROC sproc_EmployeeFirstNameUpdate
@EmployeeNumber int
AS
BEGIN
    UPDATE Employees
	SET EmployeeNumber = @EmployeeNumber
END
GO

--2.
--A.
CREATE PROCEDURE sprocSalesFormsGetAll
AS
BEGIN
	SELECT * FROM SalesForms
END
GO
--B.
CREATE PROCEDURE sprocSalesFormGetByID
@SalesFormID int
AS
BEGIN
	SELECT * FROM SalesForms
	WHERE SalesFormID = @SalesFormID
END
GO
--C.
CREATE PROCEDURE sproc_SalesFormAdd
@DateIssued datetime
,@Amount decimal(10,2)
,@SalesPersonID int
,@CustomerID int
AS
BEGIN
	INSERT INTO SalesForms(DateIssued,Amount,SalesPersonID,CustomerID)
		VALUES
		(@DateIssued
		,@Amount
		,@SalesPersonID
		,@CustomerID)
END
GO
--D.
CREATE PROCEDURE sproc_SalesFormUpdate
@SalesFormID int
,@Amount decimal(10,2)
AS
BEGIN
	UPDATE SalesForms
	SET Amount = @Amount
	WHERE SalesFormID = @SalesFormID
END
GO

--3.
--A.
CREATE PROCEDURE sprocCustomersGetAll
AS
BEGIN
SET NOCOUNT ON
	SELECT * FROM Customers C
	JOIN People p
	ON p.PersonID = c.PersonID
END
GO
--B.
CREATE PROCEDURE sprocCustomerGetID
@CustomerID int
AS
BEGIN
	SELECT * FROM Customers c
	JOIN People p
    ON p.PersonID = c.PersonID
    WHERE CustomerID = @CustomerID
END
GO
--C.
CREATE PROCEDURE sproc_CustomerAdd
@CustomerNumber int
,@FirstName nvarchar(60)
,@MiddleName nvarchar(60)
,@LastName nvarchar(60)
,@PhoneNumber int
,@EmailAddress int
,@Address int
AS
BEGIN
    DECLARE @PersonID int
    INSERT INTO People(FirstName, MiddleName,LastName, PhoneNumberID, EmailAddressID, AddressID)
		VALUES
		(@FirstName, @MiddleName, @LastName, @PhoneNumber, @EmailAddress, @Address)
		SET @PersonID = @@IDENTITY
    INSERT INTO Customers(CustomerNumber, PersonID)
		VALUES
		(@CustomerNumber, @PersonID)
END
GO
--D.
CREATE PROCEDURE sproc_CustomerModify
@CustomerNumber int, @FirstName nvarchar(60), @MiddleName nvarchar(60),
@LastName nvarchar(60), @PersonID int
AS
BEGIN
    UPDATE People
    SET FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName
    WHERE People.PersonID = @PersonID
    UPDATE Customers
    SET CustomerNumber = @CustomerNumber
    WHERE Customers.PersonID = @PersonID
END
GO

--4.
CREATE PROCEDURE sprocEmployeeFind
@FirstName nvarchar(60)
,@LastName nvarchar(60)
AS
IF EXISTS (SELECT * FROM People
            JOIN Employees ON People.PersonID = Employees.PersonID
            WHERE FirstName = @FirstName AND LastName = @LastName
            AND People.PersonID = Employees.PersonID)
BEGIN
SELECT 1 AS [Exists]
END
ELSE
BEGIN
SELECT -1 AS [Exists]
END
GO

--5.
CREATE PROC sprocEmployeesFindName
@filter nvarchar(60)
AS
BEGIN
    SELECT * FROM People WHERE FirstName LIKE @Filter 
    OR LastName LIKE @Filter 
END
GO

--6.
CREATE PROCEDURE sproc_LocationAdd
@CityName nvarchar(100)
,@ZipCodeNumber int
,@StateName nvarchar(20)
,@StateAbreviation nvarchar (3)
AS 
BEGIN
	IF NOT EXISTS 
		(SELECT * FROM States
		WHERE [Name] = @StateName
		AND Abbreviation = @StateAbreviation)
BEGIN
	INSERT INTO States([Name],Abbreviation)
		VALUES
		(@StateName, @StateAbreviation)
END
	IF NOT EXISTS 
		(SELECT * FROM Cities
		WHERE [Name] = @CityName)
BEGIN
	INSERT INTO Cities([Name])
		VALUES
		(@CityName)
END
	IF NOT EXISTS 
	(SELECT * FROM ZipCodes
	WHERE Number = @ZipCodeNumber)
BEGIN
	INSERT INTO ZipCodes(Number)
	VALUES
	(@ZipCodeNumber)
END
END
GO

--7.
CREATE PROCEDURE sprocPurchaseInformation
@PurchaseDate datetime
AS
BEGIN
    SELECT p.FirstName, p.LastName, i.SerialNumber, id.ModelNumber, id.Description, sf.DateIssued FROM People p
    JOIN Customers c
    ON  p.PersonID = c.PersonID
    JOIN SalesForms sf
    ON sf.CustomerID = c.CustomerID
    JOIN Items i
    ON i.ItemID = sf.ItemID
    JOIN ItemDetails id
    ON id.ItemDetailID = i.ItemDetailID
    WHERE sf.DateIssued > @PurchaseDate
END
GO

--8.
CREATE PROCEDURE sprocReturnsSerialNumber
@FirstDate datetime
,@SecondDate datetime
AS
BEGIN
    SELECT SerialNumber FROM Items
    JOIN ReturnedItems ON Items.ItemID = ReturnedItems.ItemID
    JOIN [Returns] ON ReturnedItems.ReturnID = [Returns].ReturnID
    WHERE DateReturned BETWEEN @FirstDate AND @SecondDate
END
GO

--9.
CREATE PROC sprocModelInfoByDate
@Date datetime
,@ProductCategoyID int
AS
BEGIN
    SELECT id.ModelNumber,i.SerialNumber FROM Items i
    JOIN ItemDetails id ON i.ItemDetailID=id.ItemDetailID
    JOIN ProductCategories pc ON pc.ProductCategoryID=id.ProductCategoryID
    JOIN SupplyOrders so ON so.ItemID=i.ItemID
    WHERE pc.ProductCategoryID = @ProductCategoyID AND so.DatePurchased < @Date
END
GO

--10.
CREATE PROCEDURE sprocItemGetByServiceTechnician
@TechnicianID int
AS
BEGIN
	SELECT * FROM ITEMS i
	JOIN ItemsToServices its 
	ON its.ItemID = i.ItemID
	JOIN [Services] s
	ON s.ServiceID = its.ServiceID
	JOIN ServiceForms sf
	ON s.ServiceFormID = sf.ServiceFormID
	JOIN Technicians t
	ON sf.TechnicianID = t.TechnicianID
	WHERE t.TechnicianID = @TechnicianID
END
GO

--11.
CREATE PROCEDURE sprocRepairsInAYear
@Date datetime
AS
BEGIN
    SET NOCOUNT ON
    DECLARE @LastYear datetime = DateAdd(YY,-1,@Date)
    SELECT id.ModelNumber, id.[Description], sf.DateIssued FROM ItemDetails id
    JOIN ServiceForms sf
    ON id.ItemDetailID = sf.ItemDetailID
    WHERE sf.DateIssued BETWEEN @LastYear AND @Date
END
GO

--12.
CREATE PROCEDURE sprocSupplierGetOrders
@NumberOfOrders int
AS
BEGIN
    SELECT DISTINCT Number, [Name] FROM Suppliers
    JOIN SupplyOrders ON Suppliers.SupplierID = SupplyOrders.SupplierID
    WHERE DATEDIFF(DAY, DateRecieved, GETDATE()) < @NumberOfOrders
END
GO