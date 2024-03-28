USE MyDb

CREATE TABLE CartItems (
    Id int PRIMARY KEY IDENTITY(1,1),
	CartId int FOREIGN KEY REFERENCES Carts(Id),
	ProductId int FOREIGN KEY REFERENCES Products(Id),
	Quantity int NOT NULL,
);