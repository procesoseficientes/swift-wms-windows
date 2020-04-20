using System;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.Controladores
{
    public class EmpresaDeTransporteControlador: IEmpresaDeTransporteControlador
    {
        private readonly IEmpresaDeTransporteVista _vista;

        public IEmpresaDeTransporteServicio EmpresaDeTransporteServicio { get; set; }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        public EmpresaDeTransporteControlador(IEmpresaDeTransporteVista vista)
        {
            _vista = vista;
            SubscribirEventos();
        }

        private void SubscribirEventos()
        {
            _vista.VistaCargandosePorPrimeraVez += _vista_VistaCargandosePorPrimeraVez;
            _vista.UsuarioDeseaCrearEmpresaDeTransporte += _vista_UsuarioDeseaCrearEmpresaDeTransporte;
            _vista.UsuarioDeseaActualizarEmpresaDeTransporte += _vista_UsuarioDeseaActualizarEmpresaDeTransporte;
            _vista.UsuarioDeseaEliminarEmpresaDeTransporte += _vista_UsuarioDeseaEliminarEmpresaDeTransporte;
            _vista.UsuarioDeseaObtenerEmpresasDeTransporte += _vista_UsuarioDeseaObtenerEmpresasDeTransporte;
        }

        private void _vista_UsuarioDeseaObtenerEmpresasDeTransporte(object sender, EmpresaDeTransporteArgumento e)
        {
            try
            {
                _vista.EmpresasDeTransporte = EmpresaDeTransporteServicio.ObtenerEmpresasDeTransporte(e);
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaEliminarEmpresaDeTransporte(object sender, Argumentos.EmpresaDeTransporteArgumento e)
        {
            try
            {
                var op = EmpresaDeTransporteServicio.EliminarEmpresaDeTransporte(e);
                if (op.Resultado == ResultadoOperacionTipo.Error)
                {
                    throw new Exception(op.Mensaje);
                }
                _vista.EmpresaDeTransporte = new EmpresaDeTransporte();
                _vista_UsuarioDeseaObtenerEmpresasDeTransporte(sender, new EmpresaDeTransporteArgumento { EmpresaDeTransporte = new EmpresaDeTransporte() });
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaActualizarEmpresaDeTransporte(object sender, Argumentos.EmpresaDeTransporteArgumento e)
        {
            try
            {
                var op = EmpresaDeTransporteServicio.ActualizarEmpresaDeTransporte(e);
                if (op.Resultado == ResultadoOperacionTipo.Error)
                {
                    throw new Exception(op.Mensaje);
                }
                e.EmpresaDeTransporte.LAST_UPDATE = DateTime.Now;
                _vista.EmpresaDeTransporte = e.EmpresaDeTransporte;
                _vista_UsuarioDeseaObtenerEmpresasDeTransporte(sender, new EmpresaDeTransporteArgumento { EmpresaDeTransporte = new EmpresaDeTransporte() });
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaCrearEmpresaDeTransporte(object sender, Argumentos.EmpresaDeTransporteArgumento e)
        {
            try
            {
                var op = EmpresaDeTransporteServicio.CrearEmpresaDeTransporte(e);
                if (op.Resultado == ResultadoOperacionTipo.Error)
                {
                    throw new Exception(op.Mensaje);
                }
                e.EmpresaDeTransporte.TRANSPORT_COMPANY_CODE = int.Parse(op.DbData);
                e.EmpresaDeTransporte.LAST_UPDATE = DateTime.Now;
                _vista.EmpresaDeTransporte = e.EmpresaDeTransporte;
                _vista_UsuarioDeseaObtenerEmpresasDeTransporte(sender, new EmpresaDeTransporteArgumento { EmpresaDeTransporte = new EmpresaDeTransporte() });

            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }

        private void _vista_VistaCargandosePorPrimeraVez(object sender, System.EventArgs e)
        {
            try
            {
                _vista.EmpresaDeTransporte = new EmpresaDeTransporte();
                _vista_UsuarioDeseaObtenerEmpresasDeTransporte(sender, new EmpresaDeTransporteArgumento {EmpresaDeTransporte = new EmpresaDeTransporte()});
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.Mensaje(exception.Message);
            }
        }
    }
}