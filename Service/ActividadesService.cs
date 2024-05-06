using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static TP_1.Program;

namespace TP_1.Service
{
    internal class ActividadesService
    {

        private List<Actividades> actividadesClub;

        public ActividadesService(List<Actividades> actividadesClub)
        {
            this.actividadesClub = actividadesClub;
        }

        // Método para crear una nueva actividad
        public void crearActividad(string nombreActividad, string idActividad, string profesor, string lugar, int cuposDisponibles)
        {
            // Verificar si la actividad ya existe
            if (buscarActividad(nombreActividad) != null)
            {
                Console.WriteLine("La actividad ya existe.");
                return;
            }

            // Crear una nueva instancia de la clase Actividades y asignar valores a sus propiedades
            Actividades actividad = new Actividades(nombreActividad, idActividad, profesor, lugar, cuposDisponibles);

            // Agregar la nueva actividad a la lista de actividades
            actividadesClub.Add(actividad);

            // Imprimir los detalles de la nueva actividad
            Console.WriteLine("Actividad creada: " + actividad.nombreActividad + ", Profesor: " + actividad.profesor + ", Lugar: " + actividad.lugar + ", Cupos: " + actividad.cuposDisponibles + ".");
        }

        // Método para obtener los datos de una actividad
        public List<Actividades> obtenerDatosDeActividad()
        {
            return actividadesClub;
        }

        
        // Método para obtener los datos de todas las actividades deportivas
        public List<Actividades> obtenerDatosActividadesDeportivas()
        {
            return actividadesClub;
        }

        // Método para obtener todas las actividades
        public List<Actividades> obtenerTodasLasActividades()
        {
            // Filtrar las actividades con propiedades incompletas
            List<Actividades> actividadesCompletas = actividadesClub.Where(a => !string.IsNullOrEmpty(a.idActividad) && !string.IsNullOrEmpty(a.profesor) && !string.IsNullOrEmpty(a.lugar)).ToList();
            return actividadesCompletas;
        }

        // Método para buscar una actividad por su nombre

        /*
        public Actividades buscarActividad(string nombreActividadBuscada)
        {
            foreach (Actividades actividad in actividadesClub)
            {
                if (actividad.nombreActividad.Equals(nombreActividadBuscada))
                {
                    return actividad;
                }
            }
            return null;
        }

        */

        public Actividades buscarActividad(string nombreActividadBuscada)
        {
            return actividadesClub.FirstOrDefault(actividad => actividad.nombreActividad.Equals(nombreActividadBuscada));
        }


        
        public static void inicializarActividades(List<Actividades> actividadesClub)
        {

            Actividades boxeo = new Actividades("Boxeo", "1", "Pedro Ruiz", "Sala Boxing A", 8);
            boxeo.sociosInscriptos = new List<Socios>
                {
                    new Socios("Mariano", "123456", "Perez"),
                    new Socios("Camila", "567386", "Muñoz")
                };
            actividadesClub.Add(boxeo);

            Actividades zumba = new Actividades("Zumba", "7", "Julieta Martinez", "Aula 5", 15);
            zumba.sociosInscriptos = new List<Socios>
                {
                    new Socios("Luciana", "789002", "Martínez"),
                    new Socios("Camila", "567386", "Muñoz")
                };
            actividadesClub.Add(zumba);

            Actividades natacion = new Actividades("Natacion", "3", "Martina Fernandez", "Pileta Olimpica 2", 8);
            natacion.sociosInscriptos = new List<Socios>
                {
                    new Socios("Luciana", "789002", "Martinez"),
                    new Socios("Joaquin", "123490", "Ruiz"),
                    new Socios("Luca", "908764", "Fernandez")
                };
            actividadesClub.Add(natacion);

            Actividades pilates = new Actividades("Pilates", "2", "Marta Lucero", "Sala Pilates 2", 4);
            pilates.sociosInscriptos = new List<Socios>
                {
                    new Socios("Camila", "567386", "Muñoz")
                };
            actividadesClub.Add(pilates);

            Actividades pesas = new Actividades("Pesas", "6", "Tomas Rodriguez", "Sala abierta interior", 15);
            pesas.sociosInscriptos = new List<Socios>
                {
                    new Socios("Mariano", "123456", "Perez"),
                    new Socios("Joaquin", "123490", "Ruiz")
                };
            actividadesClub.Add(pesas);

            /*
            actividadesClub.Add(new Actividades("Zumba", "7", "Julieta Martinez", "Aula 5"));
            actividadesClub.Add(new Actividades("Natacion", "3", "Martina Fernandez", "Pileta Olimpica 2"));
            actividadesClub.Add(new Actividades("Pilates", "2", "Marta Lucero", "Sala Pilates 2"));
            actividadesClub.Add(new Actividades("Pesas", "6", "Tomas Rodriguez", "Sala abierta interior"));
            */
        }

        

        public List<Actividades> ObtenerActividadesDelSocio(List<Actividades> actividades, string idSocio)
        {
            List<Actividades> actividadesDelSocio = new List<Actividades>();

            foreach (Actividades actividad in actividades)
            {
                // Verificar si el socio está inscrito en esta actividad
                if (actividad.sociosInscriptos.Any(socio => socio.idAsociado == idSocio))
                {
                    actividadesDelSocio.Add(actividad);
                }
            }

            return actividadesDelSocio;
        }

        internal List<Actividades> ObtenerActividadesDelSocio(string idSocioBuscar)
        {
            return actividadesClub;
        }


        // Método para buscar un socio en las actividades
        public List<Actividades> BuscarSocioEnActividades(string nombreSocio, string apellidoSocio)
        {
            List<Actividades> actividadesAsociado = new List<Actividades>();

            foreach (Actividades actividad in actividadesClub)
            {
                foreach (Socios socio in actividad.sociosInscriptos)
                {
                    if (socio.nombreAsociado.Equals(nombreSocio) && socio.apellidoAsociado.Equals(apellidoSocio))
                    {
                        actividadesAsociado.Add(actividad);
                        break; // Terminar la búsqueda en esta actividad
                    }
                }
            }

            return actividadesAsociado;
        }

        private List<Socios> socios;
        private List<Actividades> actividadesDeportivas;

        public ActividadesService(List<Socios> socios, List<Actividades> actividadesDeportivas)
        {
            this.socios = socios;
            this.actividadesDeportivas = actividadesDeportivas;
        }

        public string inscribirActividad(string nombreActividad, string idSocio)
        {
            // Verificar si la actividad existe
            ActividadesService actividadesService = new ActividadesService(actividadesDeportivas);
            Actividades actividad = actividadesService.buscarActividad(nombreActividad);
            if (actividad == null)
            {
                return "Actividad inexistente";
            }

            // Verificar si el socio existe
            SociosService sociosService = new SociosService(socios);
            Socios socio = sociosService.buscarSocioPorIdentificacion(idSocio);
            if (socio == null)
            {
                return "Socio inexistente";
            }

            // Verificar si el socio ya está inscrito en 3 actividades
            if (socio.ActividadesInscritas.Count >= 3)
            {
                return "Tope de actividades alcanzado por el socio";
            }

            // Verificar si el socio ya está inscrito en la actividad
            if (actividad.sociosInscriptos.Any(s => s.idAsociado == idSocio))
            {
                return "El socio ya está inscrito en esta actividad";
            }

            // Reservar un cupo para el socio en la actividad
            actividad.reservarCupo();

            // Inscribir al socio en la actividad
            actividad.sociosInscriptos.Add(socio);
            socio.ActividadesInscritas.Add(actividad);

            return "Inscripción exitosa";
        }


        public string inscribirSocioEnActividad(Socios socio, Actividades actividad)
        {
            // Verificar si hay cupos disponibles en la actividad
            if (actividad.cuposDisponibles > 0)
            {
                // Intentar inscribir al socio en la actividad
                if (!socio.ActividadesInscritas.Contains(actividad))
                {
                    actividad.reservarCupo();
                    socio.ActividadesInscritas.Add(actividad);
                    actividad.sociosInscriptos.Add(socio);
                    return "Inscripción exitosa";
                }
                else
                {
                    return "El socio ya está inscripto en la actividad";
                }
            }
            else
            {
                return "No hay cupos disponibles";
            }
        }

        internal string reservarActividad(string idSocioReserva, Actividades actividadReserva)
        {
            // Buscar al socio por su identificación
            Socios socio = buscarSocioPorIdentificacion(idSocioReserva);
            if (socio == null)
            {
                return "Socio inexistente";
            }

            // Verificar si la actividad existe
            if (actividadReserva == null)
            {
                return "Actividad inexistente";
            }

            // Intentar inscribir al socio en la actividad
            inscribirSocioEnActividad(socio, actividadReserva);

            // Devolver un mensaje de inscripción exitosa
            return "Inscripción exitosa";
        }

        private List<Socios> asociados;

        // Método para buscar un socio por su número de identificación
        public Socios buscarSocioPorIdentificacion(string idSocio)
        {
            return asociados.Find(socio => socio.idAsociado == idSocio);
        }
    }
}