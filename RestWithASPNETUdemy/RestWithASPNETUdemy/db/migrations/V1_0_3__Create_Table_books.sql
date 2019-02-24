CREATE TABLE IF NOT EXISTS books(
	Id int(10) AUTO_INCREMENT PRIMARY KEY,
	Author longtext,
	LaunchDate datetime(6) NOT NULL,
	Price decimal(62, 2) NOT NULL,
	Title longtext
) ENGINE = InnoDB DEFAULT CHARSET = latin1