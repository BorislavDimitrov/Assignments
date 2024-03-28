USE MyDb

CREATE TABLE OrderItems (
    Id int PRIMARY KEY IDENTITY(1,1),
	OrderId int FOREIGN KEY REFERENCES Orders(Id),
	ProductId int FOREIGN KEY REFERENCES Products(Id),
	Quantity int NOT NULL
);