USE MyDb

CREATE TABLE Orders (
    Id int PRIMARY KEY IDENTITY(1,1),
	TotalPrice money NOT NULL,
	OrderDate date NOT NULL,
	UserId int FOREIGN KEY REFERENCES Users(Id),
	OrderStatusId int FOREIGN KEY REFERENCES OrderStatuses(Id),
	PaymentMethodId int FOREIGN KEY REFERENCES PaymentMethods(Id) UNIQUE,
);