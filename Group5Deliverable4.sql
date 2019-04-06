--Chas Davis, Tyson Baker, Andrew Browning, Rodney Roe
--INFO 4407
--Jon Holmes
--Deliverable 4
--4/2/2018

--1.
SELECT e.EmployeeID, p.FirstName, p.LastName FROM Employees e
	JOIN People p
	ON e.PersonID = p.PersonID
	ORDER BY p.LastName, p.FirstName ASC

--2.
SELECT p.FirstName, p.LastName, pn.Number, a.StreetAddress, ci.Name, s.Name, z.Number FROM Customers c
	JOIN People p
	ON c.PersonID = p.PersonID
	JOIN PhoneNumbers pn
	ON pn.PhoneNumberID = p.PhoneNumberID
	JOIN Addresses a
	ON a.AddressID = p.AddressID
	JOIN ZipCodes z
	ON z.ZipCodeID = a.ZipCodeID
	JOIN Cities ci
	ON ci.CityID = a.CityID
	JOIN States s
	ON s.StateID = ci.StateID
	ORDER BY p.LastName, p.FirstName ASC

--3.
SELECT cc.CreditCardID, cc.Number, ct.Name, CONVERT(nvarchar(2),  MONTH(cc.DateOfExpiration)) + '/' + CONVERT(nvarchar(4),  YEAR(cc.DateOfExpiration)) as [Expiration Date] FROM People p
	JOIN Customers c ON c.PersonID = p.PersonID
	JOIN CustomerToCreditCards ctc ON ctc.CustomerID = c.CustomerID
	JOIN CreditCards cc ON cc.CreditCardID = ctc.CreditCardID
	JOIN CreditCardTypes ct ON ct.CreditCardTypeID = cc.CreditCardTypeID
	WHERE p.FirstName LIKE 'Richard' AND p.LastName LIKE 'Nixon'

--4.
SELECT t.TechNumber,s.LaborHours,t.HourlyWage, s.LaborHours*t.HourlyWage AS 'Weekly Salary' FROM Technicians t
	JOIN ServiceForms sf ON sf.TechnicianID=t.TechnicianID
	JOIN [Services] s ON s.ServiceFormID=sf.ServiceFormID
	WHERE s.LaborHours > 40

--5.
SELECT id.[Description] FROM ItemDetails id
	JOIN Items i
	ON i.ItemDetailID = id.ItemDetailID
	JOIN Suppliers s
	ON s.SupplierID = i.SupplierID
	WHERE s.Name LIKE 'a_r%'

--6.
SELECT e.EmployeeNumber, p.FirstName, p.LastName, p.MiddleName,
	COUNT(sf.SalesFormID) AS 'Sales Count',
	SUM(sf.Amount)*.10 AS 'Commission'
	FROM Salespersons s
	JOIN Employees e
	ON e.EmployeeID = s.EmployeeID
	JOIN People p
	ON p.PersonID = e.PersonID
	JOIN SalesForms sf
	ON sf.SalespersonID = s.SalespersonID
	GROUP BY s.SalespersonID, e.EmployeeNumber, p.FirstName, p.LastName, p.MiddleName
	ORDER BY Commission DESC

--7.
SELECT CONCAT(p.FirstName,' ', p.LastName) AS [Name], i.SerialNumber, id.ModelNumber, id.[Description], CONCAT(Month(sf.DateIssued),'/',DAY(sf.DateIssued),'/',YEAR(sf.DateIssued)) AS PurchaseDate FROM People p
	JOIN Customers c ON c.PersonID = p.PersonID
	JOIN SalesForms sf ON sf.CustomerID = c.CustomerID
	JOIN Items i ON i.ItemID = sf.ItemID
	JOIN ItemDetails id ON id.ItemDetailID = i.ItemDetailID
WHERE sf.DateIssued = '05/10/2005'

--8.
DECLARE @FirstName nvarchar(60)
DECLARE @LastName nvarchar(60)
DECLARE @CustomerNumber int
	SET @FirstName = 'Brock'
	SET @LastName = 'Luna'
	SET @CustomerNumber = 54545
SELECT FirstName, LastName, CustomerNumber, DateIssued, ProblemDescription FROM People
	JOIN Customers ON People.PersonID = Customers.PersonID
	JOIN ServiceForms ON Customers.CustomerID = ServiceForms.CustomerID
	WHERE FirstName = @FirstName AND LastName = @LastName OR CustomerNumber = @CustomerNumber

--9. 
--Part a:
SELECT id.ProductCategoryID, id.[Description], id.ModelNumber, COUNT (sf.SalesFormID) AS SaleCount
	FROM ItemDetails id
	JOIN Items i 
	ON id.ItemDetailID = i.ItemDetailID
	JOIN SalesForms sf 
	ON i.ItemID = sf.ItemID
	GROUP BY ProductCategoryID, [Description], ModelNumber
--Part b:
SELECT id.ProductCatagoryID, id.[Description], id.ModelNumber, COUNT --(sf.SalesFormID) AS SaleCount
	FROM ItemDetails id
	JOIN Items i
	ON id.ItemDetailID = i.ItemDetailID
	JOIN SalesForms sf
	ON i.ItemID = sf.ItemID
	GROUP BY ProductCatagoryID, [Description], ModelNumber
	HAVING COUNT(sf.SalesFormID) = 
	(SELECT MAX(SaleCount)
		FROM 
		(SELECT id.ProductCatagoryID, id.[Description], id.ModelNumber, COUNT --(sf.SalesFormID) AS SaleCount
		FROM ItemDetails id
		JOIN Items i
		ON id.ItemDetailID = i.ItemDetailID
		JOIN SalesForms sf
		ON i.ItemID = sf.ItemID
		GROUP BY ProductCatagoryID, [Description], ModelNumber
		) SubQuery
	)

--10.
SELECT ModelNumber, [Description], COUNT(Items.SupplierID) NumberOfSuppliers, ProductCategoryID FROM ItemDetails
	JOIN Items ON ItemDetails.ItemDetailID = Items.ItemDetailID
	GROUP BY ProductCategoryID, ModelNumber, [Description]

--11.
SELECT ProductCategories.[Type], ModelNumber, [Description], YEAR(DateIssued) RepairYear FROM ProductCategories
	JOIN ItemDetails ON ProductCategories.ProductCategoryID = ItemDetails.ProductCategoryID
	JOIN ServiceForms ON ItemDetails.ItemDetailID = ServiceForms.ItemDetailID
	WHERE DateIssued BETWEEN '1/1/2005' AND '12/31/2005'

--12.
SELECT s.Number, s.[Name] FROM Suppliers s
	JOIN SupplyOrders so
	ON so.SupplierID = s.SupplierID
	WHERE so.DateRecieved <> ''
	ORDER BY(s.[Name]) ASC