USE [db-gp11];
GO

--TIPO USUARIO
INSERT INTO tipoUsuario (tipoUsuario)
VALUES	
		('Administrador'),
		('Cliente');
GO

Select * From tipoUsuario;
GO

--USUARIOS
INSERT INTO usuarios(idTipoUsuario,nomeUsuario,email,senha,dataNascimento,cpf)
VALUES	
(1,'Yuri Mitsugui Chiba','yuri@gmail.com','yuri123','2004-12-24',00000000001),
(2,'Gustavo Henrique Ferreira Alves','gustavo@gmail.com','gustavo123','2004-07-16',00000000002),
(2,'Leonardo Souza de Castro','leonardo@gmail.com','leonardo123','2005-06-03',00000000003),
(2,'Luiz Felipe Vera Cruz','luiz@gmail.com','luiz123','2002-07-03',00000000004),
(2,'Colin Lucas Batista Beluco','colin@gmail.com','colin223','2004-09-23',00000000005);
GO

Select * From usuarios;
GO

--BICICLETARIO
INSERT INTO bicicletarios(nome,rua,numero,bairro,cidade,cep,horarioAberto,horarioFechado,latitude,longitude)
VALUES
('Bicicletário Alameda','Alamenda',200,'bairro um','São Paulo','11111111','05:00:00.0000000', '23:59:59.9999999','-23.53641','-46.6462'),
('Bicicletário Sesi Vila Leopoldina','Weber',400,'bairro dois','São Paulo','22222222','05:00:00.0000000','23:59:59.9999999','-23.52749','-46.72938'),
('Bicicletário Sesi Osasco','Calçadão',600,'bairro tres','São Paulo','33333333','05:00:00.0000000','23:59:59.9999999','-23.52681','-46.77609');
GO

SELECT * FROM bicicletarios
GO;

INSERT INTO vagas(idBicicletario,statusVaga)
VALUES(2, 0),
(2,1),
(2,0),
(2,0),
(2,0)
GO

SELECT * FROM bicicletarios
GO;

set dateformat ymd;
GO

INSERT INTO reservas(idUsuario,idVaga,abreTrava)
VALUES(2, 4, '2022-03-28 09:43:00.000');
GO

SELECT * FROM reservas
GO;