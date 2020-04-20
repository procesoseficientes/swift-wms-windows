using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Controladores;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Servicios;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.Popups
{
    public partial class LiberarPolizaPopup : Form, ILiberarPolizaPopup
    {
        #region Eventos
        public event EventHandler<PolizaArgumento> UsuarioDeseaDesbloquearPolizas;
        #endregion

        #region Propiedades 
        public IList<Poliza> Polizas { get; set; }
        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }
        #endregion

        #region Contructor y Eventos de Carga
        private void LiberarPolizaPopup_Load(object sender, EventArgs e){ }

        public LiberarPolizaPopup()
        {
            InitializeComponent();
            RegistrarClase();
        }

        public LiberarPolizaPopup(IList<Poliza> polizas)
        {
            InitializeComponent();
            RegistrarClase();
            Polizas = polizas;
        }
        #endregion

        #region Metodos

        private void RegistrarClase()
        {
            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();
            Mvx.Ioc.RegisterType<IVencimientoDePolizasServicio, VencimientoDePolizasServicio>();

            Mvx.Ioc.RegisterSingleton<ILiberarPolizaPopup, LiberarPolizaPopup>(this);
            Mvx.Ioc.RegisterType<ILiberarPolizaPopupControlador, LiberarPolizaPopupControlador>();
            Mvx.Ioc.Resolve<ILiberarPolizaPopupControlador>();
        }

        private bool ValidarCamposDesbloqueo()
        {
            return UiTxtDocumento.Text != "" && UiMemoComentario.Text != "";
        }
        #endregion

        #region Eventos de Controles
        private void UiBtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UiBtnGrabar_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposDesbloqueo())
            {
                InteraccionConUsuarioServicio.Mensaje("Debe de llenar todos los campos para liberar las pólizas.");
                return;
            }

            try
            {
                UsuarioDeseaDesbloquearPolizas?.Invoke(sender, new PolizaArgumento
                {
                    UNLOCK_COMMENT = UiMemoComentario.Text
                    ,
                    UNLOCK_DOCUMENT = UiTxtDocumento.Text
                    ,
                    UNLOCK_USER = InteraccionConUsuarioServicio.ObtenerUsuario()
                });

                InteraccionConUsuarioServicio.MensajeExito("Pólizas liberadas exitosamente.");
                Close();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(ex.Message);
            }
        }
        #endregion
    }
}
