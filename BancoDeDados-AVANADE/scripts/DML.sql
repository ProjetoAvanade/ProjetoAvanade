USE AVANADE;
GO

--TIPO USUARIO
INSERT INTO tipoUsuario (tipoUsuario)
VALUES	
		('Administrador'),
		('Cliente');
GO

--USUARIOS
INSERT INTO usuarios(idTipoUsuario,nomeUsuario,email,senha,dataNascimento,cpf)
VALUES	
(1,'Yuri Mitsugui Chiba','yuri@gmail.com','yuri123','24-12-2004',00000000001),
(2,'Gustavo Henrique Ferreira Alves','gustavo@gmail.com','gustavo123','16-07-2004',00000000002),
(2,'Leonardo Souza de Castro','leonardo@gmail.com','leonardo123','03-06-2005',00000000003),
(2,'Luiz Felipe Vera Cruz','luiz@gmail.com','luiz123','03-07-2002',00000000004),
(2,'Colin Lucas Batista Beluco','colin@gmail.com','colin223','23-09-2004',00000000005);
GO


--BICICLETARIO
INSERT INTO bicicletarios(nome,rua,numero,bairro,cidade,cep,horarioAberto,horarioFechado)
VALUES
('Bicicletário Alameda','Alamenda',200,'bairro um','São Paulo','11111111','24-03-2022-06-00-30','25-03-2022-00-30-00'),
('Bicicletário Sesi Vila Leopoldina	Weber','teste',400,'bairro dois','São Paulo','22222222','24-03-2022-06-00-30','25-03-2022-00-30-00'),
('Bicicletário Sesi Osasco Calçadão','teste',600,'bairro tres','São Paulo','33333333','24-03-2022-06-00-30','25-03-2022-00-30-00');
GO


SELECT * FROM bicicletarios
GO;