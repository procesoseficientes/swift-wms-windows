using System;
using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.Controladores
{
    public class PilotoControlador: IPilotoControlador
    {
        private readonly IPilotoVista _vista;

        public IPilotoServicio PilotoServicio { get; set; }

        public IUsuarioServicio UsuarioServicio { get; set; }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        public IParametroServicio ParametroServicio { get; set; }
        public PilotoControlador(IPilotoVista vista)
        {
            _vista = vista;
            SubscribirEventos();
        }

        private void SubscribirEventos()
        {
            _vista.VistaCargandosePorPrimeraVez += _vista_VistaCargandosePorPrimeraVez;
            _vista.UsuarioDeseaCrearPiloto += _vista_UsuarioDeseaCrearPiloto;
            _vista.UsuarioDeseaActualizarPiloto += _vista_UsuarioDeseaActualizarPiloto;
            _vista.UsuarioDeseaEliminarPiloto += _vista_UsuarioDeseaEliminarPiloto;
            _vista.UsuarioDeseaObtenerPilotos += _vista_UsuarioDeseaObtenerPilotos;

            _vista.UsuarioDeseaObtenerRoles += _vista_UsuarioDeseaObtenerRoles;
            _vista.UsuarioDeseaObtenerUsuariosPorRol += _vista_UsuarioDeseaObtenerUsuariosPorRol;

            _vista.UsuarioDeseaAsociarPilotoAUsuarioDelSistema += _vista_UsuarioDeseaAsociarPilotoAUsuarioDelSistema;
            _vista.UsuarioDeseaDesasociarPilotoDeUsuarioDelSistema += _vista_UsuarioDeseaDesasociarPilotoDeUsuarioDelSistema;

        }

        private void _vista_UsuarioDeseaDesasociarPilotoDeUsuarioDelSistema(object sender, PilotoArgumento e)
        {
            try
            {
                var op = PilotoServicio.DesasociarPilotoDeUsuarioDelSistema(e);
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

        private void _vista_UsuarioDeseaAsociarPilotoAUsuarioDelSistema(object sender, PilotoArgumento e)
        {
            try
            {
                var op = PilotoServicio.DesasociarPilotoDeUsuarioDelSistema(e);
                if (op.Resultado == ResultadoOperacionTipo.Error)
                {
                    throw new Exception(op.Mensaje);
                }
                op = PilotoServicio.AsociarPilotoAUsuarioDelSistema(e);
                if (op.Resultado == ResultadoOperacionTipo.Error)
                {
                    throw new Exception(op.Mensaje);
                }
                _vista_VistaCargandosePorPrimeraVez(sender,e);
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerUsuariosPorRol(object sender, PilotoArgumento e)
        {
            try
            {
                //_vista.UsuariosPorRol = UsuarioServicio.ObtenerUsuariosPorRol(e.RolDeUsuario);
                _vista.UsuariosExternos = UsuarioServicio.ObtenerUsuariosSonda();
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerRoles(object sender, EventArgs e)
        {
            try
            {
                _vista.RolesDeUsuario = UsuarioServicio.ObtenerRolesDeUsuario();
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerPilotos(object sender, PilotoArgumento e)
        {
            try
            {
                _vista.Pilotos = PilotoServicio.ObtenerPilotos(e);
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaEliminarPiloto(object sender, PilotoArgumento e)
        {
            try
            {
                var op = PilotoServicio.EliminarPiloto(e);
                if (op.Resultado == ResultadoOperacionTipo.Error)
                {
                    throw new Exception(op.Mensaje);
                }
                _vista_VistaCargandosePorPrimeraVez(sender,e);
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaActualizarPiloto(object sender, PilotoArgumento e)
        {
            try
            {
                var op = PilotoServicio.ActualizarPiloto(e);
                if (op.Resultado == ResultadoOperacionTipo.Error)
                {
                    throw new Exception(op.Mensaje);
                }

                if (VieneUsuarioParaAsociarAlPiloto(e.UsuarioPorPiloto))
                {
                    op = PilotoServicio.DesasociarPilotoDeUsuarioDelSistema(e);
                    if (op.Resultado == ResultadoOperacionTipo.Error)
                    {
                        throw new Exception(op.Mensaje);
                    }
                    _vista_UsuarioDeseaAsociarPilotoAUsuarioDelSistema(sender, e);
                }
                
                _vista.Pilotos = PilotoServicio.ObtenerPilotos(new PilotoArgumento { Piloto = new Piloto() });
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaCrearPiloto(object sender, PilotoArgumento e)
        {
            try
            {
                var op = PilotoServicio.CrearPiloto(e);
                if (op.Resultado == ResultadoOperacionTipo.Error)
                {
                    throw new Exception(op.Mensaje);
                }
                _vista.Piloto.PILOT_CODE = int.Parse(op.DbData);
                _vista.Piloto.LAST_UPDATE = DateTime.Now;
                e.Piloto.PILOT_CODE = _vista.Piloto.PILOT_CODE;
                e.UsuarioPorPiloto.PILOT_CODE = _vista.Piloto.PILOT_CODE;
                if (VieneUsuarioParaAsociarAlPiloto(e.UsuarioPorPiloto))
                {
                    _vista_UsuarioDeseaAsociarPilotoAUsuarioDelSistema(sender,e);
                }
                _vista.Pilotos = PilotoServicio.ObtenerPilotos(new PilotoArgumento { Piloto = new Piloto() });
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private static bool VieneUsuarioParaAsociarAlPiloto(UsuarioPorPiloto usuario)
        {
            return !string.IsNullOrEmpty(usuario.USER_CODE);
        }

        private void _vista_VistaCargandosePorPrimeraVez(object sender, EventArgs e)
        {
            try
            {
                _vista.Piloto = new Piloto();
                //_vista.UsuariosPorRol = new List<Usuario>();
                _vista.UsuariosExternos = new List<Usuario>();
                _vista.Pilotos = PilotoServicio.ObtenerPilotos(new PilotoArgumento {Piloto = new Piloto()});
                _vista.RolesDeUsuario = UsuarioServicio.ObtenerRolesDeUsuario();
                ObtenerParametros();
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void ObtenerParametros()
        {
            try
            {
                _vista.Parametros = ParametroServicio.ObtenerParametro(new ConsultaArgumento
                {
                    GrupoParametro = Enums.GetStringValue(GrupoParametro.Next),
                    IdParametro = Enums.GetStringValue(IdParametro.IntegracionNEXT)
                });
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }
    }
}