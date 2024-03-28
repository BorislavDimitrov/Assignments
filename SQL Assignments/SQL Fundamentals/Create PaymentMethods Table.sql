USE MyDb

CREATE TABLE PaymentMethods (
    Id int PRIMARY KEY IDENTITY(1,1),
    CardType varchar(50) NOT NULL,
	CardNumber varchar(20) NOT NULL,
	ExpirationDate date NOT NULL,
);