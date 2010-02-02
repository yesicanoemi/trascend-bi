set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:	<Manuel Vargas, Maria Salazar>
-- Create date: <31/01/2010>
-- Description:	<permisos de un usuario>
-- =============================================
ALTER PROCEDURE [dbo].[ConsultarIdPermiso]

@NombrePermiso varchar(20)
AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;

SELECT IdPermiso from dbo.Permiso
WHERE (Nombre = @NombrePermiso)

END
