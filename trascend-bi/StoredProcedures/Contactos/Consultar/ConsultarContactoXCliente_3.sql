USE [BddProy2]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Dinangela Rojas, Daniel Trejo>
-- Create date: <28/01/2010>
-- Description:	<Consulta de Contacto por Cliente>
-- =============================================

CREATE PROCEDURE [dbo].[ConsultarContactoXCliente_3]

@IdCliente int

AS
BEGIN

SET NOCOUNT ON;
	SELECT C.NOMBRE, C.APELLIDO, C.AREANEGOCIO, C.CARGO , T.CODIGOAREA, T.NUMERO, TT.Nombre, CL.Nombre, C.IdContacto
	FROM dbo.contacto C,dbo.telefono T, dbo.cliente CL, dbo.TipoTelefono TT
	WHERE (C.IdCliente = @IdCLiente) and (CL.IdCliente = @IdCliente) and (T.IdContacto=C.IdContacto) and (TT.id = T.IdTipoTelefono) 
END 