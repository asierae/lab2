CREATE PROCEDURE getTareasProfesor
	@profesor nvarchar(80),
	@asignatura nvarchar(30)
AS
SELECT * FROM ((TareasGenericas as tg INNER JOIN GruposTrabajo as gt  ON tg.CodAsig=@asignatura and codAsig=gt.asignatura)INNER JOIN ProfesoresGrupo as pg ON pg.email=@profesor and pg.codigogrupo=gt.codigo)