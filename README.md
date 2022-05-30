# ProjetoAvanade


Projeto em desenlvolvimento para a conclusão do curso técnico de Redes e Dev do Senai informática.
O projeto consiste em um sistema mobile sobre um bicicletario conectado com um aplicativo e sistema web
diretamente na azure.

## 🚀 Começando

Essas instruções permitirão que você obtenha uma cópia do projeto em operação na sua máquina local para fins de desenvolvimento e teste.

Consulte **Implantação** para saber como implantar o projeto.

### 📋 Pré-requisitos

De que coisas você precisa para instalar o software e como instalá-lo?

Você irá precisar dos seguintes itens instalados e configurados em sua máquina para estar testando localmente:
###
--- Postman - testar as requisições da API
###
--- SSMS - SQL Server usado para criar o banco de dados
###
--- Visual Studio 2019 - usado para codar em C# e rodar a aplicação
###
### Pacotes necessários para implementação de APIs:
###
 System.Data.SqlClient 
	- permite a conexão com o banco de dados quando fazemos manualmente
###
 System.IdentityModel.Tokens.Jwt
	- criar e validar o JWT
###
 Microsoft.AspNetCore.Authentication.JwtBearer 
	- integrar a parte de autenticação JWT Bearer
###
 Swashbuckle.AspNetCore 
	- permite a integração com Swagger
###
 Microsoft.EntityFrameworkCore.SqlServer 
###
 Microsoft.EntityFrameworkCore.SqlServer.Design
###
  Microsoft.EntityFrameworkCore.Tools
  - Essa e as duas anteriores nos permitem trabalhar com EF Core
###
  Microsoft.AspNetCore.Mvc.NewtonsoftJson 
	- Permite formatações do JSON 
    


### 🔧 Instalação

Para começar, forque o repositório para que você possa modificar e subir alterações na sua versão;
![forcar-projeto](https://user-images.githubusercontent.com/61885997/169832596-98880b82-b719-4090-96ed-ab418e76bdfe.PNG)
###


Dentro do projeto forcado na sua conta, copie o link do projeto
![clonar-repositorio PNG](https://user-images.githubusercontent.com/61885997/169836248-5f5aef49-4af1-4f09-a87e-92ac4d975acc.png)

Clone ele para sua aréa de trabalho usando o git bash com o comando git clone -link-clonado-
![abrir-gitbash](https://user-images.githubusercontent.com/61885997/169836686-60690659-9ca3-4d73-9ab1-8a385bced092.png)
![comando-clonar](https://user-images.githubusercontent.com/61885997/169836842-ef3b9698-6556-4ec1-9aff-1515454fdbdd.png)

Após ter clonado o repositório, abra o banco de dados

![Abra-o-banco](https://user-images.githubusercontent.com/61885997/169837276-ed687aa0-8f41-4477-a569-8527083c0bbe.png)


para conseguir achar e colar os scripts, com o git bash novamente dentro da pasta clonada, vá para a branch de BancodeDados com o    
git checkout -branch-
![git-checkout](https://user-images.githubusercontent.com/61885997/169837546-3cdeaa57-3aa0-457f-bc31-198c5bac5947.png)
![dentro-db](https://user-images.githubusercontent.com/61885997/169838493-329d3841-ed60-423f-a896-bda7666b2464.png)

Vá em scripts   


![clique-em-scripts](https://user-images.githubusercontent.com/61885997/169838578-66651f61-0ce6-48fb-8882-dd9cf0a1dd74.png)
![scripts-do-banco](https://user-images.githubusercontent.com/61885997/169838982-0aa8c7df-4146-4950-a543-f5b34d367b9a.png)

Entre no SSMS e logue com suas credenciais criadas
![logar-ssms](https://user-images.githubusercontent.com/61885997/169838854-b8c5ecc9-9a31-4a2e-8e35-aa7d81a5a995.png)

jogue os scripts dentro do SSMS   


![cole-os-scripts](https://user-images.githubusercontent.com/61885997/169839290-757b558e-d88f-4aea-b9a9-ce38f5af8cdd.png)



selecione os comandos e execute para estar criando o banco de dados


![criar-o-banco](https://user-images.githubusercontent.com/61885997/170983296-8a310857-d349-4204-af17-4958d98c23ff.png)




selecione o comando "USE AVANADE GO" e execute ou vá manualmente para selecionar o banco



![selecionar-o-banco](https://user-images.githubusercontent.com/61885997/170983469-a2c420f3-5721-44f6-ab1b-587a1e27d4c7.png)



primeiro com DDL, selecione todo o script e execute



![selecione-e-execute1](https://user-images.githubusercontent.com/61885997/170983985-36bfe4a6-7dec-4ea7-9317-2f245ef8577a.png)



o retorno esperado é esse (as tabelas apareceram pelo "SELECT * FROM 'tabela' ")



![retorno1](https://user-images.githubusercontent.com/61885997/170984055-6d12cd11-5ff5-402a-bfd8-5c9169df746c.png)



para inserir os dados, repita os mesmos passos



![selecione-e-execute2](https://user-images.githubusercontent.com/61885997/170985694-badbad18-f709-4c41-8478-dbb2fb02a727.png)



e o retorno esperado é igual ao primeiro



![retorno2](https://user-images.githubusercontent.com/61885997/170985858-18e175f5-78af-4f82-b28f-a28bc3b5d8e8.png)



esse é para a visualização no momento.. repita os mesmos passos para obter o mesmo retorno, se tudo tiver ocorrido como o esperado;



![selecione-e-execute3-e-retorno3](https://user-images.githubusercontent.com/61885997/170986255-aa25b19c-4667-4ca9-90b0-444eb12e0230.png)



No git bash, volte para a main utilizando o git checkout



![voltar-main](https://user-images.githubusercontent.com/61885997/170986474-c9b344e0-7ed7-422c-bd93-5e53743354e5.png)



abra a solução, que no caso é a API



![abrir-solucao](https://user-images.githubusercontent.com/61885997/170986599-edf98687-b275-446b-b046-5452a10d807d.png)



com os pacotes necessários falados lá no começo do tutorial (é aqui dentro do Nuget para realizar isso)



![nuget](https://user-images.githubusercontent.com/61885997/170987315-6be99c4a-55ea-4c7f-9d40-874ed5a85947.png)


 
quando tudo carregar, entre aqui para mudar a string de conexão para conectar com o banco de dados



![ir-em-appsettings](https://user-images.githubusercontent.com/61885997/170986864-1053f009-e98a-4bcf-b218-ef5a84f4f1c3.png)



troque a string para a sua


![trocar-string](https://user-images.githubusercontent.com/61885997/170986919-b7c0173f-a35d-4cdf-9da0-6e1c731987e5.png)



clique na setinha para mostrar mais um appsettings para alterar a string de conexão também



![appsettings-2](https://user-images.githubusercontent.com/61885997/170986982-cbb57b63-7f1f-4745-b639-bfb40f6ed5d3.png)



execute a API e com isso irá abrir o swagger



![executa-api](https://user-images.githubusercontent.com/61885997/170988043-b4bdd7af-ed5d-45ec-af42-6df9a4dd61a7.png)



![swagger](https://user-images.githubusercontent.com/61885997/170988084-73310331-f74f-480f-9873-0f454bf054fc.png)



  
## ⚙️ Executando os testes

Explicar como executar os testes automatizados para este sistema.

### 🔩 Analise os testes de ponta a ponta

Explique que eles verificam esses testes e porquê.

```
Dar exemplos
```

### ⌨️ E testes de estilo de codificação

Explique que eles verificam esses testes e porquê.

```
Dar exemplos
```

## 📦 Desenvolvimento

Adicione notas adicionais sobre como implantar isso em um sistema ativo

## 🛠️ Construído com

<div style="display: inline_block"><br>
  <img align="center" alt="avanade-HTML" height="30" width="40" src="https://raw.githubusercontent.com/devicons/devicon/1119b9f84c0290e0f0b38982099a2bd027a48bf1/icons/html5/html5-original.svg">
  <img align="center" alt="avanade-CSS" height="30" width="40" src="https://raw.githubusercontent.com/devicons/devicon/master/icons/css3/css3-original.svg">
  <img align="center" alt="avanade-Csharp" height="30" width="40" src="https://raw.githubusercontent.com/devicons/devicon/1119b9f84c0290e0f0b38982099a2bd027a48bf1/icons/csharp/csharp-original.svg">
  <img align="center" alt="avanade-js" height="30" width="40" src="https://raw.githubusercontent.com/devicons/devicon/1119b9f84c0290e0f0b38982099a2bd027a48bf1/icons/javascript/javascript-original.svg">
  <img align="center" alt="avanade-expo" height="30" width="40" src="https://www.diverseagency.it/static/images/expo.png">
  
  ###

* [Dropwizard](http://www.dropwizard.io/1.0.2/docs/) - O framework web usado
* [Maven](https://maven.apache.org/) - Gerente de Dependência
* [ROME](https://rometools.github.io/rome/) - Usada para gerar RSS

## 🖇️ Colaborando

Por favor, leia o [COLABORACAO.md](https://gist.github.com/usuario/linkParaInfoSobreContribuicoes) para obter detalhes sobre o nosso código de conduta e o processo para nos enviar pedidos de solicitação.

## 📌 Versão

Nós usamos [SemVer](http://semver.org/) para controle de versão. Para as versões disponíveis, observe as [tags neste repositório](https://github.com/suas/tags/do/projeto). 

## ✒️ Autores

Mencione todos aqueles que ajudaram a levantar o projeto desde o seu início

* **Um desenvolvedor** - *Trabalho Inicial* - [umdesenvolvedor](https://github.com/linkParaPerfil)
* **Fulano De Tal** - *Documentação* - [fulanodetal](https://github.com/linkParaPerfil)

Você também pode ver a lista de todos os [colaboradores](https://github.com/usuario/projeto/colaboradores) que participaram deste projeto.

## 📄 Licença

Este projeto está sob a licença (sua licença) - veja o arquivo [LICENSE.md](https://github.com/usuario/projeto/licenca) para detalhes.

## 🎁 Expressões de gratidão

* Conte a outras pessoas sobre este projeto 📢
* Convide alguém da equipe para uma cerveja 🍺 
* Obrigado publicamente 🤓.
* etc.


---
⌨️ com ❤️ por [ProjetoAvanade](https://github.com/ProjetoAvanade) 😊
