using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Argumentos;


namespace MobilityScm.Modelo.Vistas
{
    public interface ISolicitudDeTrasladoVista
    {
        event EventHandler VistaCargandosePorPrimeraVez;
        event EventHandler<SolicitudDeTrasladoArgumento> UsuarioSeleccionoCentroDeDistribucionOrigen;
        event EventHandler<SolicitudDeTrasladoArgumento> UsuarioSeleccionoCentroDeDistribucionDestino;
        event EventHandler<ConteoFisicoArgumento> UsuarioSeleccionoCliente;
        event EventHandler<SolicitudDeTrasladoArgumento> UsuarioDeseaGuardarSolicitudDeTraslado;
        event EventHandler<SolicitudDeTrasladoArgumento> UsuarioDeseaBuscarSolicitudDeTraslado;
        event EventHandler UsuarioDeseaRefrescarCentrosDeDistribucionOrigen;
        event EventHandler UsuarioDeseaRefrescarCentrosDeDistribucionDestino;
        event EventHandler UsuarioDeseaRefrescarClientes;
        event EventHandler UsuarioDeseaRefrescarTipos;


        IList<Entidades.Configuracion> CentrosDeDistribucionOrigen { get; set; }
        IList<Entidades.Configuracion> CentrosDeDistribucionDestino { get; set; }
        IList<Entidades.Configuracion> TiposSolicitudDeTraslado { get; set; }
        IList<Bodega> BodegasOrigen { get; set; }
        IList<Bodega> BodegasDestino { get; set; }
        IList<Cliente> Clientes { get; set; }
        IList<Sku> Materiales { get; set; }

        SolicitudDeTrasladoEncabezado SolicitudDeTrasladoEncabezado { get; set; }
        IList<SolicitudDeTrasladoDetalle> SolicitudDeTrasladoDetalle { get; set; }

        int IdSolicitudDeTraslado { get; set; }

        IList<Seguridad> ListaDeSeguridad { get; set; }
    }
}
