using System;
using System.Collections.Generic;
using TP_1.Service;

namespace TP_1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            List<Socios> servicioClubDeportivo = new List<Socios>();
            SociosService sociosService = new SociosService(servicioClubDeportivo);

            List<Actividades> actividadesClub = new List<Actividades>();
            ActividadesService actividadesService = new ActividadesService(actividadesClub);


            SociosService.inicializarSocios(servicioClubDeportivo);
            ActividadesService.inicializarActividades(actividadesClub);

            string nombreSocio;
            string apellidoSocio;
            string idSocio;

            string buscarApellido;
            string buscarIdentificacion;

            string nombreActividad;
            string idActividad;
            string profesor;
            string lugar;

            string buscarNombreActividad;

            char eleccion;

            //bool volverMenuPrincipal = false;

            /*
            // Inicialización de la lista de socios con datos precargados
            List<Socios> socios = Socios.InicializarSocios();

            // Inicialización de la lista de actividades con datos precargados
            List<Actividades> actividades = Actividades.InicializarActividades();

            Console.WriteLine("Lista de Socios:");
            foreach (var socio in socios)
            {
                Console.WriteLine($"Nombre: {socio.Nombre}, Apellido: {socio.Apellido}, ID: {socio.IdSocio}");
            }

            Console.WriteLine("\nLista de Actividades:");
            foreach (var actividad in actividades)
            {
                Console.WriteLine($"Nombre: {actividad.NombreActividad}, ID: {actividad.IdActividad}, Profesor: {actividad.Profesor}, Lugar: {actividad.Lugar}");
            }
            */

            do
            {
                Console.WriteLine("*********************************************");
                Console.WriteLine("BIENVENIDO AL CLUB DEPORTIVO");
                Console.WriteLine("*********************************************");
                Console.WriteLine("****** Elija una opción para comenzar ******");
                Console.WriteLine("*A: Sección Socios*");
                Console.WriteLine("*B: Sección Actividades*");
                Console.WriteLine("*C: Salir*");
                Console.WriteLine("*********************************************");
                Console.WriteLine("*Ingrese su opción*");

                eleccion = Console.ReadLine()[0];

                switch (eleccion)
                {


                    case 'A':

                        int opcionMenuSocios;

                        List<Socios> sociosCreados;

                        do
                        {

                            Console.WriteLine("*********************************************************");

                            Console.WriteLine("**Menú de opciones de la sección asociados del club deportivo**");

                            Console.WriteLine("*********************************************************");

                            Console.WriteLine("****** Elija una opción para comenzar  ******");

                            Console.WriteLine("1. Buscar socios por número de identificación");

                            Console.WriteLine("2. Buscar socios por Apellido");

                            Console.WriteLine("3. Registrar nuevo socio");

                            Console.WriteLine("4. Listado de socios");

                            Console.WriteLine("5. Salir");

                            Console.WriteLine("Ingrese su opción: ");

                            opcionMenuSocios = Console.ReadLine()[0];

                            //Console.ReadLine();

                            switch (opcionMenuSocios)
                            {


                                case '1':
                                    Console.WriteLine("Ingrese el número de identificación del socio que desea buscar: ");
                                    buscarIdentificacion = Console.ReadLine();
                                    Socios socioIdentificacion = sociosService.buscarSocioPorIdentificacion(buscarIdentificacion);
                                    if (socioIdentificacion != null)
                                    {
                                        Console.WriteLine("Hemos encontrado al socio: " + socioIdentificacion.idAsociado + " " + socioIdentificacion.nombreAsociado + " " + socioIdentificacion.apellidoAsociado);
                                    }
                                    else
                                    {
                                        Console.WriteLine("No se pudo encontrar ningún socio con el número de identificación " + buscarIdentificacion + ".");
                                    }

                                    break;

                                case '2': //Buscamos al socio por el apellido

                                    Console.WriteLine("Ingrese el apellido del socio que desea buscar: ");
                                    buscarApellido = Console.ReadLine();
                                    List<Socios> sociosPorApellido = sociosService.buscarSocioPorApellido(buscarApellido);
                                    if (sociosPorApellido.Count > 0)
                                    {
                                        Console.WriteLine("Hemos encontrado al siguiente asociado con ese apellido: ");
                                        foreach (Socios socio in sociosPorApellido)
                                        {
                                            Console.WriteLine("Apellido: "
                                                                + socio.apellidoAsociado
                                                                + ", Nombre: "
                                                                + socio.nombreAsociado
                                                                + ", Número de identificación: "
                                                                + socio.idAsociado);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ningún socio con ese apellido.");
                                    }
                                    break;

                                case '3': //Registramos un nuevo socio en el sistema

                                    Console.WriteLine("Ingrese el nombre del nuevo socio: ");
                                    nombreSocio = Console.ReadLine();

                                    Console.WriteLine("Ingrese el apellido del nuevo socio: ");
                                    apellidoSocio = Console.ReadLine();

                                    Console.WriteLine("Ingrese el número de identificación del nuevo socio: ");
                                    idSocio = Console.ReadLine();

                                    sociosService.crearSocio(nombreSocio, idSocio, apellidoSocio);

                                    sociosCreados = sociosService.obtenerDatosDelSocio();

                                    foreach (Socios socio in sociosCreados)
                                    {

                                        Console.WriteLine(socio);
                                    }

                                    break;

                                case '4': //Mostramos el listado de socios del sistema

                                    List<Socios> listaDeSocios = sociosService.obtenerTodosLosSocios();

                                    foreach (Socios socio in listaDeSocios)
                                    {

                                        Console.WriteLine(socio.nombreAsociado + " " + socio.apellidoAsociado + " (Número de Identificación:" + socio.idAsociado + ")");

                                    }

                                    break;

                                case '5':

                                    Console.WriteLine("Gracias por utilzar la sección de socios del Club deportivo.");

                                    break;

                                default:

                                    Console.WriteLine("Opción inválida. Intente nuevamente.");

                                    break;

                            }

                        } while (opcionMenuSocios != '5');

                        break;

                    case 'B':

                        int opcionActividadesDeportivas;

                        do
                        {

                            Console.WriteLine("***********************************************************");

                            Console.WriteLine("**Menú de opciones de la sección actividades deportivas del club**");

                            Console.WriteLine("************************************************************");

                            Console.WriteLine("****** Elija una opción para comenzar  ******");

                            Console.WriteLine("1. Buscar una actividad deportiva");

                            Console.WriteLine("2. Listado de socios que participan en determinada actividad");

                            Console.WriteLine("3. Registrar una actividad deportiva");

                            Console.WriteLine("4. Listar las actividades deportivas que se dictan en el club");

                            Console.WriteLine("5. Buscar socios en actividades deportivas");

                            Console.WriteLine("6. Reservar actividad");

                            Console.WriteLine("7. Salir");

                            Console.WriteLine("Ingrese su opción: ");

                            opcionActividadesDeportivas = Console.ReadLine()[0];

                            switch (opcionActividadesDeportivas)
                            {
                                case '1':
                                    //Buscar una actividad deportiva

                                    Console.WriteLine("Ingrese el nombre de la actividad que desea buscar: ");
                                    buscarNombreActividad = Console.ReadLine();

                                    Actividades actividadNombre = actividadesService.buscarActividad(buscarNombreActividad);

                                    if (actividadNombre != null)
                                    {

                                        Console.WriteLine("Hemos encontrado la actividad " + actividadNombre.nombreActividad + " que es dictada por: " + actividadNombre.profesor);

                                    }
                                    else
                                    {

                                        Console.WriteLine("No se pudo encontrar esa actividad en nuestro registro.");

                                    }


                                    break;

                                case '2': //Listado de socios de acuerdo a la actividad deportiva que busqué

                                    Console.WriteLine("Ingrese el nombre de la actividad que desea buscar: ");
                                    string nombreActividadBuscar = Console.ReadLine();

                                    // Buscar la actividad por su nombre
                                    Actividades actividadBuscada = actividadesService.buscarActividad(nombreActividadBuscar);

                                    if (actividadBuscada != null)
                                    {
                                        List<Socios> sociosEnActividad = actividadBuscada.sociosInscriptos;

                                        if (sociosEnActividad.Count > 0)
                                        {
                                            Console.WriteLine("Los socios inscritos en la actividad " +  nombreActividadBuscar + " son: ");

                                            foreach (Socios socio in sociosEnActividad)
                                            {
                                                Console.WriteLine("Nombre: " + socio.nombreAsociado + ", Apellido: " + socio.apellidoAsociado + ", ID: "  + socio.idAsociado + ".");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("No hay socios inscritos en la actividad " +nombreActividadBuscar + ".");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("No se encontró ninguna actividad con el nombre " + nombreActividadBuscar + ".");
                                    }

                                    break;

                                case '3':
                                    //Registrar una nueva actividad deportiva

                                    Console.WriteLine("Ingrese el nombre de la actividad: ");
                                    nombreActividad = Console.ReadLine();

                                    Console.WriteLine("Ingrese el número de identificación de la actividad: ");
                                    idActividad = Console.ReadLine();

                                    Console.WriteLine("Ingrese el nombre del profesor: ");
                                    profesor = Console.ReadLine();

                                    Console.WriteLine("Ingrese el lugar donde se va a practicar la actividad: ");
                                    lugar = Console.ReadLine();

                                    Console.WriteLine("Ingrese la cantidad de cupos disponibles: ");
                                    int cuposDisponibles;
                                    while (!int.TryParse(Console.ReadLine(), out cuposDisponibles))
                                    {
                                        Console.WriteLine("Entrada inválida. Por favor, ingrese un número válido.");
                                    }

                                    actividadesService.crearActividad(nombreActividad, idActividad, profesor, lugar, cuposDisponibles);

                                    List<Actividades> actividadesCreadas = actividadesService.obtenerDatosDeActividad();

                                    foreach (Actividades actividades in actividadesCreadas)
                                    {
                                        Console.WriteLine(actividades);
                                    }
                                    break;

                                    break;

                                case '4': //Listado de actividades que se brindan en el club

                                    List<Actividades> listaDeActividades = actividadesService.obtenerTodasLasActividades();

                                    foreach (Actividades actividades in listaDeActividades)
                                    {

                                        Console.WriteLine("Actividad: " + actividades.nombreActividad + " Número de identificación: " + actividades.idActividad + " Profesor: " + actividades.profesor + " Lugar del club: " + actividades.lugar + " .");

                                    }

                                    break;

                                case '5': //Buscar socios en actividades deportivas

                                    // Obtener el nombre y apellido del socio que se desea buscar
                                    Console.WriteLine("Ingrese el nombre del socio que desea buscar: ");
                                    string nombreSocioBuscar = Console.ReadLine();

                                    Console.WriteLine("Ingrese el apellido del socio que desea buscar: ");
                                    string apellidoSocioBuscar = Console.ReadLine();

                                    // Lista para almacenar las actividades en las que participa el socio
                                    List<Actividades> actividadesAsociado = new List<Actividades>();

                                    // Obtener todas las actividades deportivas del club
                                    List<Actividades> todasLasActividades = actividadesService.obtenerTodasLasActividades();

                                    // Buscar al socio en cada actividad
                                    foreach (Actividades actividad in todasLasActividades)
                                    {
                                        foreach (Socios socio in actividad.sociosInscriptos)
                                        {
                                            // Verificar si el nombre y apellido del socio coinciden con la búsqueda
                                            if (socio.nombreAsociado.Equals(nombreSocioBuscar) && socio.apellidoAsociado.Equals(apellidoSocioBuscar))
                                            {
                                                // Agregar la actividad a la lista de actividades del socio
                                                actividadesAsociado.Add(actividad);
                                                break; // Terminar la búsqueda en esta actividad
                                            }
                                        }
                                    }

                                    // Mostrar las actividades en las que participa el socio
                                    if (actividadesAsociado.Count > 0)
                                    {
                                        Console.WriteLine("El socio " + nombreSocioBuscar + " " + apellidoSocioBuscar + " participa en las siguientes actividades: ");
                                        foreach (Actividades actividad in actividadesAsociado)
                                        {
                                            Console.WriteLine("Nombre de la actividad: " + actividad.nombreActividad + ", Profesor: " + actividad.profesor + ", Lugar: " + actividad.lugar + ".");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("El socio " + nombreSocioBuscar + " " + apellidoSocioBuscar + " no participa en ninguna actividad.");
                                    }


                                    break;
                                
                                case '6': //Reservar una actividad deportiva por parte del socio

                                    Console.WriteLine("Ingrese el número de identificación del socio que desea reservar la actividad: ");
                                    string idSocioReserva = Console.ReadLine();

                                    Console.WriteLine("Ingrese el nombre de la actividad que desea reservar: ");
                                    string nombreActividadReserva = Console.ReadLine();

                                    Actividades actividadReserva = actividadesService.buscarActividad(nombreActividadReserva);

                                    if (actividadReserva != null)
                                    {
                                        // Realizar la reserva
                                        sociosService.reservarActividad(idSocioReserva, actividadReserva);
                                        Console.WriteLine("La reserva se realizó con éxito.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("No se encontró ninguna actividad con el nombre proporcionado.");
                                    }

                                    break;

                                case '7':

                                    Console.WriteLine("Gracias por utilzar la sección de actividades del club deportivo.");

                                    break;

                                default:

                                    Console.WriteLine("Opción inválida. Intente nuevamente.");

                                    break;

                            }


                        } while (opcionActividadesDeportivas != '7');

                        break;

                    case 'C':

                        Console.WriteLine("Gracias por consultar el sistema del club deportivo.");

                        break;

                    default:

                        Console.WriteLine("Opción inválida. Intente nuevamente.");

                        break;

                }

            } while (eleccion != 'C');
        }
    }
}