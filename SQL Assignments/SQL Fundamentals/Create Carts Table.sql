USE MyDb

CREATE TABLE Carts (
    Id int PRIMARY KEY IDENTITY(1,1),
	UserId int FOREIGN KEY REFERENCES Users(Id),
);