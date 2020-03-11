Create Database SenaturTarde;
Use SenaturTarde;


Create Table Pacotes (
IdPacote Int Primary key Identity,
NomePacote  Varchar (255) unique,
Descricao  Text   not null ,
DataIda  Date not null, 
DataVolta Date not null,
Valor Decimal not null,
Ativo Bit not null ,  
NomeCidade Varchar (255) not null
);

Create Table TiposUsuario (
IdTipoUsuario  Int Primary key Identity,
Titulo Varchar (255) not null ,
);

Create Table Usuarios (
IdUsuario  Int Primary key Identity,
Email Varchar (255) unique ,
Senha Varchar  (255)not null ,
IdTipoUsuario INT FOREIGN KEY REFERENCES  TiposUsuario (IdTipoUsuario)

);