USE MyDb

CREATE TABLE Products (
  Id int PRIMARY KEY IDENTITY(1,1),
  Name varchar(255) NOT NULL,
  Description varchar(255) NOT NULL,
  ImageUrl varchar(255) NOT NULL,
  Price money NOT NULL,
  InStock bit NOT NULL,
);