USE MyDb

CREATE TABLE Categories (
  Id int PRIMARY KEY IDENTITY(1,1),
  Name varchar(150) NOT NULL,
  Description varchar(255) NOT NULL,
);