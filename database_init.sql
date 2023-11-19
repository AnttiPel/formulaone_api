CREATE TABLE drivers (
	id INT PRIMARY KEY,
	name VARCHAR ( 50 ) NOT NULL,
	nationality VARCHAR ( 50 ) NOT NULL,
	updated TIMESTAMP NOT NULL
);

CREATE TABLE grand_prix (
	id INT PRIMARY KEY,
	name VARCHAR ( 50 ) NOT NULL,
	date TIMESTAMP NOT NULL,
	location VARCHAR ( 50 ) NOT NULL,
	updated TIMESTAMP NOT NULL
);

CREATE TABLE points (
	id INT PRIMARY KEY,
	driver_id INT NOT NULL,
	total_points INT NOT NULL,
	updated TIMESTAMP NOT NULL,
	FOREIGN KEY (driver_id) REFERENCES drivers (id)
);

CREATE TABLE results (
	id INT PRIMARY KEY,
	grand_prix_id INT NOT NULL,
	driver_id INT NOT NULL,
	position INT NOT NULL,
	points INT NOT NULL,
	updated TIMESTAMP NOT NULL,
	FOREIGN KEY (driver_id) REFERENCES drivers (id),
	FOREIGN KEY (grand_prix_id) REFERENCES grand_prix (id)
);
