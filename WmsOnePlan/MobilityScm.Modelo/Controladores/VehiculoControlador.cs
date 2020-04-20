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
    public class VehiculoControlador: IVehiculoControlador
    {
        private readonly IVehiculoVista _vista;

        public IPilotoServicio PilotoServicio { get; set; }

        public IVehiculoServicio VehiculoServicio { get; set; }

        public IEmpresaDeTransporteServicio EmpresaDeTransporteServicio { get; set; }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        public IPolizaServicio PolizaServicio { get; set; }
        public IParametroServicio ParametroServicio { get; set; }

        public VehiculoControlador(IVehiculoVista vista)
        {
            _vista = vista;
            SubscribirEventos();
        }

        private void SubscribirEventos()
        {
            _vista.VistaCargandosePorPrimeraVez += _vista_VistaCargandosePorPrimeraVez;

            _vista.UsuarioDeseaCrearVehiculo += _vista_UsuarioDeseaCrearVehiculo;
            _vista.UsuarioDeseaActualizarVehiculo += _vista_UsuarioDeseaActualizarVehiculo;
            _vista.UsuarioDeseaEliminarVehiculo += _vista_UsuarioDeseaEliminarVehiculo;
            _vista.UsuarioDeseaObtenerVehiculos += _vista_UsuarioDeseaObtenerVehiculos;
            _vista.UsuarioDeseaObtenerVehiculo += _vista_UsuarioDeseaObtenerVehiculo;

            _vista.UsuarioDeseaObtenerPilotosNoAsociadosAVehiculos += _vista_UsuarioDeseaObtenerPilotosNoAsociadosAVehiculos;
            _vista.UsuarioDeseaObtenerEmpresasDeTransporte += _vista_UsuarioDeseaObtenerEmpresasDeTransporte;
            _vista.UsuarioDeseaAsociarPiloto += _vista_UsuarioDesasociarPiloto;
            _vista.UsuarioDeseaDesasociarPiloto += _vista_UsuarioDeseaDesasociarPiloto;
            _vista.UsuarioDeseaObtenerPolizas += _vista_UsuarioDeseaObtenerPolizas;
        }

        private void _vista_UsuarioDeseaObtenerPolizas(object sender, VehiculoArgumento e)
        {
            try
            {
                _vista.PolizasDeSeguro = PolizaServicio.ObtenerTodasLasPolizasDeSeguro();
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaDesasociarPiloto(object sender, VehiculoArgumento e)
        {
            try
            {
                var op = VehiculoServicio.DesasociarVehiculoDePiloto(e);
                if (op.Resultado == ResultadoOperacionTipo.Error)
                {
                    throw new Exception(op.Mensaje);
                }
                _vista_VistaCargandosePorPrimeraVez(sender, e);
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void _vista_UsuarioDesasociarPiloto(object sender, VehiculoArgumento e)
        {
            try
            {
                var op = VehiculoServicio.AsociarVehiculoAPiloto(e);
                if (op.Resultado == ResultadoOperacionTipo.Error)
                {
                    throw new Exception(op.Mensaje);
                }
                _vista_VistaCargandosePorPrimeraVez(sender, e);
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerEmpresasDeTransporte(object sender, Argumentos.EmpresaDeTransporteArgumento e)
        {
            try
            {
                _vista.EmpresasDeTransporte = EmpresaDeTransporteServicio.ObtenerEmpresasDeTransporte(e);
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerPilotosNoAsociadosAVehiculos(object sender, Argumentos.PilotoArgumento e)
        {
            try
            {
                _vista.Pilotos = PilotoServicio.ObtenerPilotosNoAsociadosAVehiculos(e);
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerVehiculo(object sender, Argumentos.VehiculoArgumento e)
        {
            try
            {
                _vista.Vehiculo = VehiculoServicio.ObtenerVehiculo(e);
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerVehiculos(object sender, Argumentos.VehiculoArgumento e)
        {
            try
            {
                _vista.Vehiculos = VehiculoServicio.ObtenerVehiculos(e);
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaEliminarVehiculo(object sender, Argumentos.VehiculoArgumento e)
        {
            try
            {
                var op = VehiculoServicio.EliminarVehiculo(e);
                if (op.Resultado == ResultadoOperacionTipo.Error)
                {
                    throw new Exception(op.Mensaje);
                }
                _vista_VistaCargandosePorPrimeraVez(sender, e);
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaActualizarVehiculo(object sender, Argumentos.VehiculoArgumento e)
        {
            try
            {
                var op = VehiculoServicio.ActualizarVehiculo(e);
                if (op.Resultado == ResultadoOperacionTipo.Error)
                {
                    throw new Exception(op.Mensaje);
                }
                e.Vehiculo.LAST_UPDATE = DateTime.Now;
                _vista.Vehiculo = e.Vehiculo;
                _vista.Vehiculos = VehiculoServicio.ObtenerVehiculos(new VehiculoArgumento { Vehiculo = new Vehiculo() });
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaCrearVehiculo(object sender, Argumentos.VehiculoArgumento e)
        {
            try
            {
                var op = VehiculoServicio.CrearVehiculo(e);
                if (op.Resultado == ResultadoOperacionTipo.Error)
                {
                    throw new Exception(op.Mensaje);
                }
                e.Vehiculo.VEHICLE_CODE = int.Parse(op.DbData);
                e.Vehiculo.LAST_UPDATE = DateTime.Now;
                _vista.Vehiculo = e.Vehiculo;
                _vista.Vehiculos = VehiculoServicio.ObtenerVehiculos(new VehiculoArgumento { Vehiculo = new Vehiculo() });
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void _vista_VistaCargandosePorPrimeraVez(object sender, EventArgs e)
        {
            try
            {
                _vista.Vehiculo = new Vehiculo();
                _vista.Vehiculos = VehiculoServicio.ObtenerVehiculos(new VehiculoArgumento {Vehiculo = new Vehiculo()});
                _vista.Pilotos = PilotoServicio.ObtenerPilotosNoAsociadosAVehiculos(new PilotoArgumento {Piloto = new Piloto()});
                _vista.EmpresasDeTransporte =
                    EmpresaDeTransporteServicio.ObtenerEmpresasDeTransporte(new EmpresaDeTransporteArgumento
                    {
                        EmpresaDeTransporte = new EmpresaDeTransporte()
                    });
                _vista.PolizasDeSeguro = PolizaServicio.ObtenerTodasLasPolizasDeSeguro();
                ObtenerParametros();
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void ObtenerParametros()
        {
            try {
                _vista.Parametros = ParametroServicio.ObtenerParametro(new ConsultaArgumento
                {
                    GrupoParametro = Enums.GetStringValue(GrupoParametro.Next),
                    IdParametro = Enums.GetStringValue(IdParametro.IntegracionNEXT)
                });
            }catch(Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

    }
}