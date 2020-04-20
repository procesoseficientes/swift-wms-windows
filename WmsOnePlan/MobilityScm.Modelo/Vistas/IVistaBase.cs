using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobilityScm.Modelo.Vistas
{
    /// <summary>
    /// Se agrega interfaz con métodos genericos de la vista. 
    /// </summary>
    public interface IVistaBase
    {
        /// <summary>
        /// Vista termino de cargar
        /// </summary>
        event EventHandler VistaTerminoDeCargar;

        /// <summary>
        /// Vista cargandose por primera vez 
        /// </summary>
        event EventHandler VistaCargandosePorPrimeraVez;

        /// <summary>
        /// Manda a ejecutar un metodo del codigo de lado del cliente.
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="sender"></param>
        void TerminoProceso(object mensaje, dynamic sender);
    }
}
