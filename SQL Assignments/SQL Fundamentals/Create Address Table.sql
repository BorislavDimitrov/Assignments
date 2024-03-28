USE MyDb

CREATE TABLE Address (
  Id int PRIMARY KEY IDENTITY(1,1),
  AddressLine1 varchar(255) NOT NULL,
  AddressLine2 varchar(255) NULL,
  PostalCode int NOT NULL,
  City varchar(255) NOT NULL,
  Country varchar(255) NOT NULL,
);