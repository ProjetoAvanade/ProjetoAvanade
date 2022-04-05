USE [db-avanade];
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
(1,'Yuri Mitsugui Chiba','yuri@gmail.com','yuri123','12-24-2004',00000000001),
(2,'Gustavo Henrique Ferreira Alves','gustavo@gmail.com','gustavo123','07-16-2004',00000000002),
(2,'Leonardo Souza de Castro','leonardo@gmail.com','leonardo123','06-03-2005',00000000003),
(2,'Luiz Felipe Vera Cruz','luiz@gmail.com','luiz123','07-03-2002',00000000004),
(2,'Colin Lucas Batista Beluco','colin@gmail.com','colin223','09-23-2004',00000000005);
GO


--BICICLETARIO
INSERT INTO bicicletarios(nome,rua,numero,bairro,cidade,cep,horarioAberto,horarioFechado,latitude,longitude)
VALUES
('Bicicletario Alameda','Alamenda',200,'bairro um','Sao Paulo','11111111','05:00:00.0000000', '23:59:59.9999999','-23.53641','-46.6462'),
('Bicicletario Sesi Vila Leopoldina','Weber',400,'bairro dois','Sao Paulo','22222222','05:00:00.0000000','23:59:59.9999999','-23.52749','-46.72938'),
('Bicicletario Sesi Osasco','Calcadao',600,'bairro tres','Sao Paulo','33333333','05:00:00.0000000','23:59:59.9999999','-23.52681','-46.77609');
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

set dateformat ymd;
GO

INSERT INTO reservas(idUsuario,idVaga,abreTrava)
VALUES(4, 4, '2022-03-28 09:43:00.000');
GO