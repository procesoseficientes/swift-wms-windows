using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Vistas;
using System;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.Controladores
{
    public class MasterPackControlador : IMasterPackControlador
    {
        private readonly IMasterPackVista _vista;
        public IMasterPackServicio MasterPackServicio { get; set; }
        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        public MasterPackControlador(IMasterPackVista vista)
        {
            _vista = vista;
            SuscribirEventos();
        }

        private void SuscribirEventos()
        {
            _vista.UsuarioDeseaAutorizarMasterPackERP += _vista_UsuarioDeseaAutorizarMasterPackERP;
            _vista.UsuarioDeseaObtenerDetallesDeMasterPacks += _vista_UsuarioDeseaObtenerDetallesDeMasterPacks;
            _vista.UsuarioDeseaObtenerMaestroDetalleDeMasterPack += _vista_UsuarioDeseaObtenerMaestroDetalleDeMasterPack;
            _vista.UsuarioDeseaObtenerMasterPacksPorFechaDeExplocion += _vista_UsuarioDeseaObtenerMasterPacksPorFechaDeExplocion;
            _vista.VistaCargandosePorPrimeraVez += _vista_VistaCargandosePorPrimeraVez;
        }

        private void _vista_VistaCargandosePorPrimeraVez(object sender, EventArgs e)
        {
            _vista.Usuario = InteraccionConUsuarioServicio.ObtenerUsuario();
            _vista.MaestroDetalles = MasterPackServicio.ObtenerMaestroDetalleDeMasterPack(new Argumentos.MasterPackArgumento {Login = InteraccionConUsuarioServicio.ObtenerUsuario()});
        }

        private void _vista_UsuarioDeseaObtenerMasterPacksPorFechaDeExplocion(object sender, Argumentos.MasterPackArgumento e)
        {
            try
            {
                e.FechaInicial = new DateTime(e.FechaInicial.Year, e.FechaInicial.Month, e.FechaInicial.Day, 0, 0, 0);
                e.FechaFinal = new DateTime(e.FechaFinal.Year, e.FechaFinal.Month, e.FechaFinal.Day, 23, 59, 59);
                if (e.FechaInicial > e.FechaFinal)
                {
                    InteraccionConUsuarioServicio.Mensaje("La fecha de inicio es mayor a la fecha final.");
                }
                else
                {
                    _vista.MasterPackEncabezados = MasterPackServicio.ObtenerMasterPacksPorFechaDeExplocion(e);
                }
                
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerMaestroDetalleDeMasterPack(object sender, Argumentos.MasterPackArgumento e)
        {
            try
            {
                _vista.MaestroDetalles = MasterPackServicio.ObtenerMaestroDetalleDeMasterPack(e);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerDetallesDeMasterPacks(object sender, Argumentos.MasterPackArgumento e)
        {
            try
            {
                _vista.MasterPackDetalles = MasterPackServicio.ObtenerDetallesDeMasterPacks(e);

            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaAutorizarMasterPackERP(object sender, Argumentos.MasterPackArgumento e)
        {
            try
            {
                var operacion = MasterPackServicio.AutorizarMasterPackERP(e);
                if (operacion.Resultado == ResultadoOperacionTipo.Error)
                {
                    InteraccionConUsuarioServicio.Mensaje(operacion.Mensaje);
                    //throw new Exception(operacion.Mensaje);
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }
    }
}
