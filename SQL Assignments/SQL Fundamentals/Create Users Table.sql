USE MyDb

CREATE TABLE Users (
    Id int IDENTITY(1,1) PRIMARY KEY,
	Username varchar(100) NOT NULL,
    Email varchar(100) NOT NULL,
	Password varchar(255) NOT NULL,
	PhoneNumber varchar(50) NOT NULL,
	AddressId int FOREIGN KEY REFERENCES Addresses(Id)
);