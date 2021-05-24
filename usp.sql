CREATE OR ALTER PROC usp_Empresa
@Opcion INT,
@Nombre VARCHAR(20) NULL,
@Pais VARCHAR(20) NULL
AS 
BEGIN 

IF(@Opcion = 1) 
	BEGIN 
		SELECT *
		FROM Empresa
	END 

IF(@Opcion = 2)
BEGIN 
	INSERT INTO Empresa (Nombre, Pais)
				VALUES (@Nombre, @Pais)
END 

END 

EXEC usp_Empresa 1, NULL, NULL

/********************************************/
CREATE OR ALTER PROC usp_Sucursal
@Opcion INT,
@SucursalID INT NULL,
@EmpresaID INT NULL,
@Nombre VARCHAR(20) NULL,
@Direccion VARCHAR(300) NULL,
@Telefono VARCHAR(8) NULL

AS 
BEGIN 

IF(@Opcion = 1) 
	BEGIN 
		SELECT *
		FROM Sucursal
	END 

IF(@Opcion = 2) 
BEGIN 
	UPDATE Sucursal
	SET 
	Nombre = @Nombre, 
	Direccion = @Direccion, 
	Telefono = @Telefono
	WHERE SucursalID = @SucursalID
END

IF(@Opcion = 3)
	BEGIN 
	DELETE
	FROM Sucursal
	WHERE SucursalID = @SucursalID
END

IF(@Opcion = 4)
BEGIN 
	INSERT INTO Sucursal (EmpresaID, Nombre, Direccion, Telefono)
				VALUES (@EmpresaID, @Nombre, @Direccion, @Telefono)
END 

END 

EXEC usp_Sucursal 1

/********************************************/
CREATE OR ALTER PROC usp_Colaborador
@Opcion INT,
@Cui VARCHAR(13) NULL,
@Nombre VARCHAR(50) NULL

AS 
BEGIN 


IF(@Opcion = 1) 
	BEGIN 
		SELECT *
		FROM Colaborador
	END 

IF(@Opcion = 2)
	BEGIN 
		INSERT INTO Colaborador (Nombre, cui)
				VALUES (@Nombre, @Cui)
	END
END 

EXEC usp_Colaborador 1