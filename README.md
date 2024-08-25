<h1>Trabajo práctico: colección de datos </h1>

<h3>Trabajo práctico grupal realizado para la materia "Desarrollo de Sistemas Orientado a Objetos"</h3>

Descripción y consdignas:
Usando el ejemplo de la biblioteca visto durante la semana en la explicación, el club deportivo administra una colección de socios registrados. De los socios, se conoce su nombre y número de identificación. Cada socio puede participar en un máximo de 3 actividades deportivas simultáneamente.
Cuando un socio se inscribe en una actividad deportiva, se reserva un cupo para él en esa actividad. Es decir, se debe retirar el cupo de la lista de cupos disponibles de la actividad deportiva para asignarlo al socio inscripto.

1. Realizar el UML considerando el ejemplo de la Biblioteca pero incluyendo además los nuevos requerimientos.
2. Desarrollar el método "altaSocio" que, pasándole los parámetros necesarios, registre a un socio en la lista de socios si no estaba previamente registrado.
3. Desarrollar el método "inscribirActividad" de la clase ClubDeportivo, el cual recibe por parámetro el nombre de la actividad deportiva y el número de identificación del socio que desea inscribirse, y retorna una cadena de texto con los
posibles valores:
 "INSCRIPCIÓN EXITOSA" (en este caso, el socio se ha inscrito correctamente en la actividad deportiva y se ha reservado un cupo para él).
 "ACTIVIDAD INEXISTENTE" (cuando la actividad deportiva no se encuentra dentro de la colección de actividades en el club deportivo).
 "TOPE DE ACTIVIDADES ALCANZADO" (cuando el socio ya participa en tres actividades deportivas).
 "SOCIO INEXISTENTE" (cuando el socio no se encuentra registrado dentro de la colección de socios en el club deportivo).

Diagrama UML: ![Diagrama de clases-Club deportivo-1-Diagrama UML-TP1-GRUPO 2](https://github.com/user-attachments/assets/09f09950-ff91-4007-9201-053078d1bc62)

