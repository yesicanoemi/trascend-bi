-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CPIdProp] 
	-- Add the parameters for the stored procedure here
	@Parametro int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT P.*,V.*
FROM Propuesta P, Version V
WHERE (P.IdPropuesta = @Parametro)AND(P.IdPropuesta = V.IdPropuesta)AND(P.Estado='Activo')AND(V.IdVersion = (SELECT MAX(Ve.IdVersion)FROM Version Ve WHERE (Ve.IdPropuesta = P.IdPropuesta)))
END
GO