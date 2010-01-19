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

CREATE PROCEDURE [dbo].[ReporteAnualPorEmpleadoCargo]

@cargo varchar
AS
BEGIN

SET NOCOUNT ON;

SELECT  C.NOMBRE AS NOMBRE, sum(12*C.SUELDOMAXIMO) as ANUALMAX, sum(12*C.SUELDOMINIMO) as ANUALMINIMO
	    FROM dbo.Empleado E, dbo.CARGO C
		WHERE E.Estado='Activo' and E.IdCargo=C.IdCargo and C.Nombre=@cargo
        group by C.NOMBRE;
     
END;