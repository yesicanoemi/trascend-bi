-- =============================================
-- Author:	<Daniel Trejo>
-- Create date: <16/01/2010>
-- Description:	<Facturas emitidas en un rango de fecha>
-- =============================================
CREATE PROCEDURE [dbo].[ConsultarPermisos]

@LoginUsuario varchar(20)
AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;

SELECT IdPermiso from dbo.PermisoUsuario
WHERE (LoginUsuario = @LoginUsuario)

END