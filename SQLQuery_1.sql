USE master;
GO
ALTER DATABASE TesteFCamara SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO

DROP DATABASE TesteFCamara;
CREATE DATABASE TesteFCamara;

Use TesteFCamara

CREATE TABLE Veiculo(
    ID INT IDENTITY(1,1),
    Marca  VARCHAR(50) NOT NULL, 
    Modelo VARCHAR(20) NOT NULL,
    Cor VARCHAR(15) NOT NULL,
    Placa VARCHAR(7) NOT NULL,
    Tipo VARCHAR(50) NOT NULL,
    PRIMARY KEY(ID)
)

CREATE TABLE Estabelecimento(
    ID INT IDENTITY(1,1),
    Nome  VARCHAR(100) NOT NULL, 
    CNPJ VARCHAR(15) NOT NULL,
    Endereco VARCHAR(255) NOT NULL,
    Telefone VARCHAR(20) NOT NULL,
    QtVagasCarros INT NOT NULL,
    QtVagasMotos INT NOT NULL,
    PRIMARY KEY(ID)
);

CREATE TABLE ControleDeVeiculos(
    ID INT IDENTITY(1,1),
    Veiculo INT NOT NULL,
    Estabelecimento INT NOT NULL,
    DataEntrada DATETIME,
    DataSaida DATETIME,
    FOREIGN KEY (Veiculo) REFERENCES Veiculo(ID),
    FOREIGN KEY (Estabelecimento) REFERENCES Estabelecimento(ID)
)

