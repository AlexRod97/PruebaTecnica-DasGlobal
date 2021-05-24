--Listado de cursos aprobados por alumno

SELECT P.CUI, P.Nombres, P.Apellidos, C.nombre_curso
FROM PERSONA_CURSO AS PC
INNER JOIN PERSONA AS P ON PC.CUI = P.CUI 
INNER JOIN CURSO AS C ON PC.id_curso = C.id_curso
WHERE curso_aprobado = 1
GROUP BY P.CUI, P.Nombres, P.Apellidos, C.nombre_curso

--Listado de alumnos que han aprobado cursos con más de 85 puntos en el segundo semestre del año 2016

SELECT P.nombres, P.apellidos
FROM PERSONA_CURSO AS PC
INNER JOIN PERSONA AS P ON PC.CUI = P.CUI 
INNER JOIN CICLO AS C ON PC.id_ciclo = C.id_ciclo
WHERE (MONTH(C.fecha_inicio) = '6' AND YEAR(C.fecha_inicio) = '2016' AND MONTH(C.fecha_fin) = '11' AND YEAR(C.fecha_fin) = '2016') AND PC.nota_obtenida >85

--Listado de alumnos que reprobaron cursos en el año 2016

SELECT P.nombres, P.apellidos
FROM PERSONA_CURSO AS PC
INNER JOIN PERSONA AS P ON PC.CUI = P.CUI 
INNER JOIN CICLO AS C ON PC.id_ciclo = C.id_ciclo
WHERE (YEAR(C.fecha_inicio) = '2016' AND YEAR(C.fecha_fin) = '2016') AND PC.curso_aprobado = '0'

--Listado de alumnos que tienen más de 8 cursos asignados para el primer semestre del año 2017

SELECT P.CUI, P.nombres, P.apellidos
FROM PERSONA_CURSO AS PC
INNER JOIN PERSONA AS P ON PC.CUI = P.CUI 
INNER JOIN CICLO AS C ON PC.id_ciclo = C.id_ciclo
WHERE (MONTH(C.fecha_inicio) = '1' AND YEAR(C.fecha_inicio) = '2017' AND MONTH(C.fecha_fin) = '5' AND YEAR(C.fecha_fin) = '2017') AND COUNT(P.CUI) > 8
GROUP BY P.CUI, P.nombres, P.apellidos

