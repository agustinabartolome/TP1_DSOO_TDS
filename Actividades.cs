using System;
using System.Collections.Generic;
using System.Text;
using static TP_1.Socios;

namespace TP_1
{
    internal class Actividades
    {
      

        public string nombreActividad { get; set; }
        public string idActividad { get; set; }
        public string profesor { get; set; }
        public string lugar { get; set; }
        public List<Socios> sociosInscriptos { get; set; }

        public int cuposDisponibles { get; set; }

        public Actividades(string nombreActividadClub, string idActividadClub, string profesorActividad, string lugarActividad, int cuposActividad)
        {
            nombreActividad = nombreActividadClub;
            idActividad = idActividadClub; 
            profesor = profesorActividad; 
            lugar = lugarActividad;
            cuposDisponibles = cuposActividad;
            sociosInscriptos = new List<Socios>();
        }


        public Actividades(string nombreActividadClub, int cuposDisponibles)
        {
            nombreActividad = nombreActividadClub;
            this.cuposDisponibles = cuposDisponibles;
            sociosInscriptos = new List<Socios>(); // Inicializar la lista de identificadores de socios
        }

       

        public static void inicializarActividades(List<Actividades> actividadesClub)
        {
            actividadesClub.Add(new Actividades("Boxeo", "1", "Pedro Ruiz", "Sala Boxing A", 8));
            actividadesClub.Add(new Actividades("Zumba", "7", "Julieta Martinez", "Aula 5", 15));
            actividadesClub.Add(new Actividades("Natacion", "3", "Martina Fernandez", "Pileta Olimpica 2", 8));
            actividadesClub.Add(new Actividades("Pilates", "2", "Marta Lucero", "Sala Pilates 2", 4));
            actividadesClub.Add(new Actividades("Pesas", "6", "Tomas Rodriguez", "Sala abierta interior", 15));
        }

        // Método para reservar un cupo cuando un socio se inscribe en la actividad
        public void reservarCupo()
        {
            if (cuposDisponibles > 0)
            {
                cuposDisponibles--;
                Console.WriteLine("Cupo reservado con éxito.");
            }
            else
            {
                throw new InvalidOperationException("No hay cupos disponibles para esta actividad.");
            }
        }

    }
}
