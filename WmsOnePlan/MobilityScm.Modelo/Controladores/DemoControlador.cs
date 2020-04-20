using System.Collections.Generic;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Vistas;

namespace MobilityScm.Modelo.Controladores
{
    public class DemoControlador:IDemoControlador
    {
        private readonly IDemoVista _vista;

        public DemoControlador(IDemoVista vista)
        {
            _vista = vista;
            SubscribirEventos();
        }

        void SubscribirEventos()
        {
            _vista.VistaTerminoDeCargar += _vista_VistaTerminoDeCargar;
            _vista.VistaCargandosePorPrimeraVez += _vista_VistaCargandosePorPrimeraVez;
        }

        private void _vista_VistaCargandosePorPrimeraVez(object sender, System.EventArgs e)
        {
        }

        private void _vista_VistaTerminoDeCargar(object sender, System.EventArgs e)
        {
            var ls = new  List<Entidad>();
            ls.Add(new Entidad
            {
                Descripcion =  "Descripcion 01"
                , Nombre = "Nombre 01"
            });

            ls.Add(new Entidad
            {
                Descripcion = "Descripcion 02"
                ,
                Nombre = "Nombre 02"
            });

            ls.Add(new Entidad
            {
                Descripcion = "Descripcion 03"
                ,
                Nombre = "Nombre 03"
            });

            ls.Add(new Entidad
            {
                Descripcion = "Descripcion 04"
                ,
                Nombre = "Nombre 04"
            });

            _vista.Listado = ls; 
        }

        public IDemoServicio DemoServicio { get; set; }
    }
}