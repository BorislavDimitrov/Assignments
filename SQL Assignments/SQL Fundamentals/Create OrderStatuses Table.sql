USE MyDb

CREATE TABLE OrderStatuses (
    Id int PRIMARY KEY IDENTITY(1,1),
	Name varchar(100) NOT NULL,
);