set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author: <Dinangela Rojas, Daniel Trejo>
-- Create date: <28/01/2010>
-- Description: <Consulta de Contacto por Nombre>
-- =============================================

Create PROCEDURE [dbo].[ConsultarContactoNombreApellido_3]

@Nombre varchar(100),
@Apellido varchar(100)

AS
BEGIN
SET NOCOUNT ON;

if ((@Nombre != '%%') and (@Apellido != '%%'))
	begin
	SELECT C.NOMBRE, C.APELLIDO, C.AREANEGOCIO, C.CARGO , T.CODIGOAREA, T.NUMERO, TT.Nombre, CL.Nombre, C.IdContacto, CL.IdCliente
	FROM dbo.Contacto C, dbo.Telefono T, dbo.cliente CL, dbo.TipoTelefono TT
	WHERE (((C.APELLIDO like @Apellido) or (C.NOMBRE like @Nombre)) and (T.IdContacto=C.IdContacto) and (C.IdCliente = CL.IdCliente) and (TT.id = T.IdTipoTelefono))
	end

if ((@Apellido = '%%') and (@Nombre != '%%'))
	begin
	SELECT C.NOMBRE, C.APELLIDO, C.AREANEGOCIO, C.CARGO , T.CODIGOAREA, T.NUMERO, TT.Nombre, CL.Nombre, C.IdContacto, CL.IdCliente
	FROM dbo.Contacto C, dbo.Telefono T, dbo.cliente CL, dbo.TipoTelefono TT
	WHERE ((C.NOMBRE like @Nombre) and (T.IdContacto=C.IdContacto) and (C.IdCliente = CL.IdCliente)and (TT.id = T.IdTipoTelefono))
	end

if ((@Nombre = '%%') and (@Apellido != '%%'))
	begin
	SELECT C.NOMBRE, C.APELLIDO, C.AREANEGOCIO, C.CARGO , T.CODIGOAREA, T.NUMERO, TT.Nombre, CL.Nombre, C.IdContacto, CL.IdCliente
	FROM dbo.Contacto C, dbo.Telefono T, dbo.cliente CL, dbo.TipoTelefono TT
	WHERE ((C.Apellido like @Apellido) and (T.IdContacto=C.IdContacto) and (C.IdCliente = CL.IdCliente)and (TT.id = T.IdTipoTelefono))
	end

if ((@Nombre = '%%') and (@Apellido = '%%'))
	begin
	SELECT C.NOMBRE, C.APELLIDO, C.AREANEGOCIO, C.CARGO , T.CODIGOAREA, T.NUMERO, TT.Nombre, CL.Nombre, C.IdContacto, CL.IdCliente
	FROM dbo.Contacto C, dbo.Telefono T, dbo.cliente CL, dbo.TipoTelefono TT
	WHERE ((T.IdContacto=C.IdContacto) and (C.IdCliente = CL.IdCliente)and (TT.id = T.IdTipoTelefono))
	end
	
END
