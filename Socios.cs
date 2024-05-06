using System;
using System.Collections.Generic;
using System.Text;

namespace TP_1
{
    internal class Socios
    {

        public string nombreAsociado { get; set; }
        public string apellidoAsociado { get; set; }
        public string idAsociado { get; set; }

        public List<Actividades> ActividadesInscritas { get; set; }

        public Socios(string nombreSocio, string idSocio, string apellidoSocio)
        {
            nombreAsociado = nombreSocio;
            apellidoAsociado = apellidoSocio;
            idAsociado = idSocio;
            ActividadesInscritas = new List<Actividades>();
        }


        public Socios()
        {
            
            ActividadesInscritas = new List<Actividades>();
        }

        // Método para inicializar datos precargados de socios a modo de ejemplo
        public static void InicializarSocios(List<Socios> asociados)
        {
            asociados.Add(new Socios("Mariano", "123456", "Perez"));
            asociados.Add(new Socios("Luciana", "789002", "Martinez"));
            asociados.Add(new Socios("Luca", "908764", "Fernandez"));
            asociados.Add(new Socios("Camila", "567386", "Muñoz"));
            asociados.Add(new Socios("Joaquin", "123490", "Ruiz"));
        }


    }
}
