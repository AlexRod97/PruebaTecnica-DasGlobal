
CREATE TABLE Empresa (
empresaID INT PRIMARY KEY IDENTITY(1,1),
nombre VARCHAR(20) NOT NULL,
pais VARCHAR(20) NOT NULL
);

CREATE TABLE Sucursal (
sucursalID INT PRIMARY KEY IDENTITY(1,1), 
empresaID INT NOT NULL,
nombre VARCHAR(20) NOT NULL,
direccion VARCHAR(300) NOT NULL, 
telefono VARCHAR(8) NOT NULL
CONSTRAINT FK_Empresa FOREIGN KEY(empresaID) REFERENCES Empresa (empresaID),
CHECK (telefono NOT LIKE '%[^0-9]%' AND DATALENGTH(telefono)= 8) 
);

CREATE TABLE Colaborador (
colaboradorID INT PRIMARY KEY IDENTITY(1,1),
sucursalID INT NOT NULL,
cui VARCHAR(13) NOT NULL,
nombre VARCHAR(50) NOT NULL,
CONSTRAINT FK_Sucursal FOREIGN KEY(sucursalID) REFERENCES Sucursal (sucursalID),
CHECK (cui NOT LIKE '%[^0-9]%' AND DATALENGTH(cui)= 13) 
);