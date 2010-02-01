ALTER PROCEDURE dbo.ConsultarCargoNuevo
@NombreCargo  varchar(20)

AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;

	SELECT c.[IdCargo] as Idcargo
		  
	FROM [BddProy2].[dbo].[Cargo] c

	where c.Nombre =@NombreCargo

END