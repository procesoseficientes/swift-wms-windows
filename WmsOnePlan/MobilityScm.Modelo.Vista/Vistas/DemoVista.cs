using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MobilityScm.Modelo.Controladores;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Servicios;
using MobilityScm.Utilerias;

namespace MobilityScm.Modelo.Vistas
{
    public partial class DemoVista : Form , IDemoVista 
    {
        public DemoVista()
        {
            InitializeComponent();
            Mvx.Ioc.Register<IDemoServicio,DemoServicio>();
            Mvx.Ioc.Register<IDemoControlador,DemoControlador>();
            Mvx.Ioc.RegisterSingleton<IDemoVista,DemoVista>(this);
            Mvx.Ioc.Resolve<IDemoControlador>();
        }

        private void Demo_Load(object sender, EventArgs e)
        {
            VistaTerminoDeCargar?.Invoke(this, null);
        }

        public event EventHandler VistaTerminoDeCargar;
        public event EventHandler VistaCargandosePorPrimeraVez;

        public IList<Entidad> Listado
        {
            get { return null;  }
            set { uiLista.DataSource = value; } 
        }
    }
}
