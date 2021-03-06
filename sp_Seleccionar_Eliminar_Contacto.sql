USE [Agenda]
GO
/****** Object:  StoredProcedure [dbo].[sp_Seleccionar_Eliminar_Contacto]    Script Date: 28/11/2017 13:59:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_Seleccionar_Eliminar_Contacto] 
	-- Add the parameters for the stored procedure here
	@Operacion varchar(1),
	@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if @Operacion = 'S' /*Seleccionar*/
	select * from tbAgenda where Id = @Id
	else if @Operacion = 'E' /*Eliminar*/
	delete from tbAgenda where Id = @Id
	else
	select * from tbAgenda
END
