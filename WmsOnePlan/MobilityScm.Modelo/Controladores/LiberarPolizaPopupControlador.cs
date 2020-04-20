using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Vertical.Entidades;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.Controladores
{
    public class LiberarPolizaPopupControlador : ILiberarPolizaPopupControlador
    {
        private readonly ILiberarPolizaPopup _popup;

        public IVencimientoDePolizasServicio VencimientoDePolizasServicio { get; set; }
        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        public LiberarPolizaPopupControlador(ILiberarPolizaPopup popup)
        {
            _popup = popup;
            SuscribirEventos();
        }

        private void SuscribirEventos()
        {
            _popup.UsuarioDeseaDesbloquearPolizas += _popup_UsuarioDeseaDesbloquearPolizas;
        }

        private void _popup_UsuarioDeseaDesbloquearPolizas(object sender, PolizaArgumento e)
        {
            try
            {
                foreach (var poliza in _popup.Polizas.ToList().Where(p => p.IS_SELECTED))
                {
                    poliza.UNLOCK_COMMENT = e.UNLOCK_COMMENT;
                    poliza.UNLOCK_DOCUMENT = e.UNLOCK_DOCUMENT;
                    poliza.UNLOCK_USER = e.UNLOCK_USER;
                    var op = VencimientoDePolizasServicio.DesbloquearPoliza(new PolizaArgumento { Poliza = poliza });
                    if (op.Resultado != ResultadoOperacionTipo.Error) continue;
                    InteraccionConUsuarioServicio.MensajeErrorDialogo(op.Mensaje);
                    break;
                }
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }
    }
}
