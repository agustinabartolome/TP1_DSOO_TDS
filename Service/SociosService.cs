using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP_1.Service
{
    internal class SociosService
    {

        private List<Socios> asociados;

        private ActividadesService actividadesService;

        List<Socios> socios = new List<Socios>();
        List<Actividades> actividades = new List<Actividades>();


        public SociosService(List<Socios> asociados, ActividadesService actividadesService)
        {
            this.asociados = asociados;
            this.actividadesService = actividadesService;
        }

        public SociosService(List<Socios> asociados)
        {
            this.asociados = asociados;
            this.actividadesService = null;
        }


        public void crearSocio(string nombreSocio, string apellidoSocio, string idSocio)
        {
            // Crear una instancia de la clase Socios con los valores proporcionados
            Socios asociado = new Socios(nombreSocio, apellidoSocio, idSocio);

            // Agregar el nuevo socio a la lista de socios del club
            asociados.Add(asociado);
        }

        // Método para registrar un socio en la lista de socios si no está previamente registrado
        public void altaSocio(string nombreSocio, string apellidoSocio, string idSocio)
        {
            // Verificar si el socio ya está registrado
            foreach (var socio in asociados)
            {
                if (socio.idAsociado == idSocio)
                {
                    Console.WriteLine("El socio ya está registrado.");
                    return;
                }
            }
            // Si el socio no está registrado, se agrega a la lista de socios
            asociados.Add(new Socios(nombreSocio, idSocio, apellidoSocio));
            Console.WriteLine("Socio registrado exitosamente.");
        }

        // Método para obtener todos los datos de los socios
        public List<Socios> obtenerDatosAsociados()
        {
            return asociados;
        }

        // Método para buscar un socio por su número de identificación
        public Socios buscarSocioPorIdentificacion(string idSocio)
        {
            return asociados.Find(socio => socio.idAsociado == idSocio);
        }

        // Método para buscar socios por apellido
        public List<Socios> buscarSocioPorApellido(string apellidoSocio)
        {
            return asociados.FindAll(socio => socio.apellidoAsociado == apellidoSocio);
        }

        // Método para obtener todos los datos de un socio
        public List<Socios> obtenerDatosDelSocio()
        {
            return asociados;
        }

        // Método para obtener todos los socios
        public List<Socios> obtenerTodosLosSocios()
        {
            return asociados;
        }

        internal static void inicializarSocios(List<Socios> asociados)
        {

            asociados.Add(new Socios("Mariano", "123456", "Perez"));
            asociados.Add(new Socios("Luciana", "789002", "Martinez"));
            asociados.Add(new Socios("Luca", "908764", "Fernandez"));
            asociados.Add(new Socios("Camila", "567386", "Muñoz"));
            asociados.Add(new Socios("Joaquin", "123490", "Ruiz"));
        }

        /*
        internal static void inicializarSocios(List<Socios> servicioClubDeportivo)
        {
            servicioClubDeportivo.Add(new Socios("Joaquín", "Ruíz", "123490"));

            servicioClubDeportivo.Add(new Socios("Camila", "Muñoz", "567386"));

            servicioClubDeportivo.Add(new Socios("Luca", "Fernandez", "908764"));

            servicioClubDeportivo.Add(new Socios("Luciana", "Martínez", "789002"));

            servicioClubDeportivo.Add(new Socios("Mariano", "Perez", "123456"));
        }
        */
        /*
        public void InscribirSocioEnActividad(Socios socio, Actividades actividad)
        {
            if (actividad.cuposDisponibles > 0)
            {
                actividad.ReservarCupo(); // Reservar un cupo en la actividad
                socio.ActividadesInscritas.Add(actividad); // Agregar la actividad a las actividades inscritas por el socio
                actividad.sociosInscriptos.Add(socio); // Agregar el socio a la lista de socios inscritos en la actividad
                Console.WriteLine("El socio: " + socio.nombreAsociado + " se ha inscrito en la actividad " + actividad.nombreActividad + " con éxito.");
            }
            else
            {
                Console.WriteLine("No se puede inscribir al socio, no hay cupos disponibles en la actividad.");
            }
        }
        */


        public string inscribirActividad(string nombreActividad, string idSocio, ActividadesService actividadesService)
        {
            // Buscar la actividad por su nombre
            Actividades actividad = actividadesService.buscarActividad(nombreActividad);

            if (actividad == null)
            {
                return "Actividad inexistente";
            }

            // Verificar si hay cupos disponibles en la actividad
            if (actividad.cuposDisponibles <= 0)
            {
                return "No hay cupos disponibles";
            }

            // Buscar al socio por su identificación
            Socios socio = asociados.FirstOrDefault(s => s.idAsociado == idSocio);

            if (socio == null)
            {
                return "Socio inesxistente";
            }

            // Verificar si el socio ya está inscrito en tres actividades
            if (socio.ActividadesInscritas.Count >= 3)
            {
                return "Tope de actividades alcanzado";
            }

            // Inscribir al socio en la actividad y reservar un cupo para él
            actividadesService.inscribirSocioEnActividad(socio, actividad);

            return "Inscripcion exitosa en la actividad";
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
    }
}