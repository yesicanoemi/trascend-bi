-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
USE [BddProy2]
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ReporteAnualPorEmpleadoPaquetes]

@CIEmpleado int
AS
BEGIN

SET NOCOUNT ON;

SELECT E.NOMBRE AS NOMBRE, E.APELLIDO AS APELLIDO, E.ESTADO AS ESTADO, C.NOMBRE AS NOMBRE, (12*C.SUELDOMAXIMO) AS ANUALTOTAL, (12*C.SUELDOMINIMO) AS ANUALMINIMO
	    FROM dbo.Empleado E, dbo.CARGO C
		WHERE E.Estado='Activo' and E.IdCargo=C.IdCargo and CIEmpleado=@CIEmpleado;
END;