USE MyDb

CREATE TABLE Reviews (
    Id int PRIMARY KEY IDENTITY(1,1),
	ProductId int FOREIGN KEY REFERENCES Products(Id),
	ReviewDate date NOT NULL,
	Content varchar(255) NOT NULL,
	Rate int NOT NULL,
);