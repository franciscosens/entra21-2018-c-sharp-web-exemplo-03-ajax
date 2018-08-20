CREATE TABLE funcionarios (
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(100) NOT NULL, 
	idade TINYINT NOT NULL,
	salario DECIMAL(8,2) NOT NULL
);

INSERT INTO funcionarios (nome, idade, salario) VALUES 
('Francisco Lucas Sens', 24, 1000.96);

SELECT * FROM funcionarios;