using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Argumentos;

namespace MobilityScm.Modelo.Vistas
{
    public interface IRecepcionErpVista
    {

        event EventHandler VistaCargandosePorPrimeraVez;

        event EventHandler<DocumentoRecepcionERPArgumento> UsuarioDeseaObtenerClientes;

        event EventHandler<DocumentoRecepcionERPArgumento> UsuarioDeseaObtenerOrdenesDeCompra;

        event EventHandler<AcuerdoComercialArgumento> UsuarioDeseaObtenerAcuerdosComercialesPorCliente;

        event EventHandler<DocumentoRecepcionERPArgumento> UsuarioDeseaObtenerPolizaAseguradaPorCliente;

        event EventHandler<DocumentoRecepcionERPArgumento> UsuarioDeseaObtenerUsuario;

        event EventHandler<DocumentoRecepcionERPArgumento> UsuarioDeseaObtenerUbicaciones;

        event EventHandler<DocumentoRecepcionERPArgumento> UsuarioDeseaObtenerTipoDeRecepcion;

        event EventHandler<DocumentoRecepcionERPArgumento> UsuarioDeseaObtenerPrioridad;

        event EventHandler<DocumentoRecepcionERPArgumento> UsuarioDeseaObtenerDetalleOrdenDeCompra;

        event EventHandler<DocumentoRecepcionERPArgumento> UsuarioDeseaGrabarDocmentosErp;

        event EventHandler<DocumentoRecepcionERPArgumento> UsuarioDeseaObtenerFacturaParaDevolucion;

        IList<Usuario> Operadores { get; set; }

        IList<DocumentoRecepcionErpEncabezado> OrdenesDeCompraEncabezado { get; set; }

        IList<DocumentoRecepcionErpDetalle> OrdenesDeCompraDetalle { get; set; }

        IList<PolizaAsegurada> PolizaAseguradora { get; set; }

        IList<AcuerdoComercial> AcuerdosComerciales { get; set; }

        IList<Cliente> Clientes { get; set; }

        IList<Ubicacion> Ubicaciones { get; set; }

        IList<MobilityScm.Modelo.Entidades.Configuracion> TiposDeRecepcion { get; set; }
        IList<MobilityScm.Modelo.Entidades.Configuracion> Prioridad { get; set; }

        IList<FuenteExterna> FuenteExterna { get; set; }
        IList<Parametro> ParametrosDeSistema { get; set; }
        void LimpiarControles();

        string Usuario { get; set; }
    }
}
