CREATE PROCEDURE [dbo].[IngresarFactura]
(
@titulo varchar(50),
@descripcion varchar(50),
@porcentaje real,
@fecha smalldatetime,
@fechaingreso smalldatetime,
@estado varchar(50),
@idpropuesta int
)
AS
BEGIN
insert into factura (titulo, descripcion, porcentaje, fecha, fechaingreso, estado, idpropuesta) values (@titulo, @descripcion, @porcentaje, @fecha, @fechaingreso, @estado, @idpropuesta)
END