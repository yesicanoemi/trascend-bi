USE [BddProy2]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Dinangela Rojas, Daniel Trejo>
-- Create date: <28/01/2010>
-- Description:	<Consulta de Contacto por Telefono>
-- =============================================

CREATE PROCEDURE [dbo].[ConsultarContactoXTelefono_3]

@CodigoArea int,
@Numero     int

AS
BEGIN

SET NOCOUNT ON;
	SELECT C.NOMBRE, C.APELLIDO, C.AREANEGOCIO, C.CARGO , T.CODIGOAREA, T.NUMERO, TT.Nombre, CL.Nombre, C.IdContacto
	FROM dbo.contacto C,dbo.telefono T, dbo.cliente CL, dbo.TipoTelefono TT
	WHERE (((T.CodigoArea= @CodigoArea and T.Numero= @Numero) and T.IdContacto=C.IdContacto) and (C.IdCliente = CL.IdCliente) and (TT.id = T.IdTipoTelefono))
END 