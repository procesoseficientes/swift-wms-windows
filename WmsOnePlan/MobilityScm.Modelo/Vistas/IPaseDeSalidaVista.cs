using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Servicios;

namespace MobilityScm.Modelo.Vistas
{
    public interface IPaseDeSalidaVista
    {
        event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaObtenerClientes;
        event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaObtenerTipos;
        event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaObtenerVehiculos;
        event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaObtenerBodegas;
        event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaObtnerAutorizados;
        event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaObtenerEntregas;
        event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaObtenerDespachos;
        event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaObtnerPaseDeSalida;
        event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaGrabar;
        event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaAnularPaseDeSalida;
        event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaObtenerDetalleDeDespachos;
        event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaObtenerPaseDeSalida;
        event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaCambiarEstadoAlPase;
        event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaObtenerPaseParaReporte;
        event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaObtenerSoloVehiculos;
        event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaGrabarVehiculo;
        event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaObtenerPilotos;
        event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaGrabarPiloto;
        event EventHandler<PaseDeSalidaArgumento> UsuarioDeseaObtenerTipoSalida;
        event EventHandler VistaCargandosePorPrimeraVez;

        IList<Cliente> Clientes { get; set; }
        IList<Vehiculo> Vehiculos { get; set; }
        IList<Usuario> UsuariosParaAutorizar { get; set; }
        IList<Usuario> UsuariosParaEntrega { get; set; }
        IList<DemandaDespachoHeader> DespachoEncabezados { get; set; }
        IList<DemandaDespachoDetalle> DespachosDetalles { get; set; }
        IList<Bodega> Bodegas { get; set; }
        IList<PaseDeSalida>  PaseDeSalidas { get; set; }
        IList<Parametro> Parametros { get; set; }
        IList<Vehiculo> SoloVehiculos { get; set; }
        IList<Piloto> Pilotos { get; set; }
        IList<Entidades.Configuracion> TipoSalida { get; set; }
        void TerminoDeGrabar(int paseDeSalida);
        void TerminoDeActualizarEstado(int paseDeSalida, string estado);
        void CargarControlesEncabezado( PaseDeSalidaEncabezado paseDeSalidaEncabezado);
        
        void TerminoDeGrabarPiloto(int? codigoPiloto);
        void TerminoDeGrabarVehiculo(int? codigoVehiculo);
    }
}
