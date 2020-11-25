using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Argumentos
{
    public class TareaArgumento: ConsultaArgumento
    {
        public Tarea Tarea { get; set; }    
        public string Users { get; set; }
        public string Types { get; set; }
        public string Clases { get; set; }

        public string Linea { get; set; }

        public int Priority { get; set; }

        public string XmlDeListadoDeTareas { get; set; }
        public IList<string> ListaDeOperadores { get; set; }

        public string Xml { get; set; }
        public string Razon { get; set; }
        public int OlaDePicking { get; set; }
        public decimal WAVE_PICKING_ID { get; set; }
        public decimal PHYSICAL_COUNT_HEADER_ID { get; set; }

        public TareaDetalle FilaTareaDetalle { get; set; }
        public OrdenDeCompraDetalle FilaOrdenDeCompraDetalle { get; set; }
        public int indiceFilaModificadaManualmente { get; set; }

        public string reference { get; set; }
        public string reason { get; set; }
        public int taskId { get; set; }
    }
}
