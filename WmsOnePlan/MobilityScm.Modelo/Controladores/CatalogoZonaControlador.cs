using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Vertical.Entidades;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.Controladores
{
    public class CatalogoZonaControlador : ICatalogoZonaControlador
    {
        private readonly ICatalogoZonaVista _vista;

        public ICatalogoZonaServicio CatalogoZonaServicio { get; set; }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        public IBodegaServicio BodegaServicio { get; set; }

        public IConfiguracionServicio ConfiguracionServicio { get; set; }

        public CatalogoZonaControlador(ICatalogoZonaVista vista)
        {
            _vista = vista;
            SuscribirEventos();
        }

        private void SuscribirEventos()
        {
            _vista.UsuarioDeseaActualizarZona += _vista_UsuarioDeseaActualizarZona;
            _vista.UsuarioDeseaAgregarZona += _vista_UsuarioDeseaAgregarZona;
            _vista.UsuarioDeseaAsociarZonaDeReabastecimiento += _vista_UsuarioDeseaAsociarZonaDeReabastecimiento;
            _vista.UsuarioDeseaConsultarZonas += _vista_UsuarioDeseaConsultarZonas;
            _vista.UsuarioDeseaDesasociarZonaDeReabastecimiento += _vista_UsuarioDeseaDesasociarZonaDeReabastecimiento;
            _vista.UsuarioDeseaConsultarZonasAsociadas += _vista_UsuarioDeseaConsultarZonasAsociadas;
            _vista.UsuarioDeseaEliminarZona += _vista_UsuarioDeseaEliminarZona;
            _vista.UsuarioDeseaConsultarZonasParaAsociar += _vista_UsuarioDeseaConsultarZonasParaAsociar;
            _vista.UsuarioDeseaCargarBodegas += _vista_UsuarioDeseaCargarBodegas;
            _vista.UsuarioDeseaCargarLineasDePicking += _vista_UsuarioDeseaCargarLineasDePicking;
        }

        private void _vista_UsuarioDeseaCargarLineasDePicking(object sender, EventArgs e)
        {
            try
            {
                _vista.Bodegas = BodegaServicio.ObtenerBodegaAsignadaAUsuario(InteraccionConUsuarioServicio.ObtenerUsuario());
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }

        }

        private void _vista_UsuarioDeseaCargarBodegas(object sender, ConsultaArgumento e)
        {
            try
            {
                _vista.LineasDePicking =
                    ConfiguracionServicio.ObtenerConfiguracionesGrupoYTipo(new Entidades.Configuracion
                    {
                        PARAM_TYPE = "SISTEMA",
                        PARAM_GROUP = "LINEAS_PICKING"
                    });
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaAgregarZona(object sender, ZonaArgumento e)
        {
            try
            {
                Operacion operacion = CatalogoZonaServicio.AgregarZona(e);

                if (operacion.Resultado == ResultadoOperacionTipo.Error)
                    throw new Exception($"Ocurrió un error al agregar zona: {operacion.Mensaje}");

                _vista_UsuarioDeseaConsultarZonas(sender, e);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaEliminarZona(object sender, ZonaArgumento e)
        {
            try
            {
                Operacion operacion = CatalogoZonaServicio.EliminarZona(e);

                if (operacion.Resultado == ResultadoOperacionTipo.Error)
                    throw new Exception($"Ocurrió un error al eliminar zona: {operacion.Mensaje}");

                _vista_UsuarioDeseaConsultarZonas(sender, e);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaAsociarZonaDeReabastecimiento(object sender, ZonaArgumento e)
        {
            try
            {
                Operacion operacion = CatalogoZonaServicio.AsociarZonaDeReabastecimiento(e);

                if (operacion.Resultado == ResultadoOperacionTipo.Error)
                    throw new Exception($"Ocurrió un error al asociar zonas: {operacion.Mensaje}");
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaDesasociarZonaDeReabastecimiento(object sender, ZonaArgumento e)
        {
            try
            {
                Operacion operacion = CatalogoZonaServicio.DesAsociarZonaDeReabastecimiento(e);

                if (operacion.Resultado == ResultadoOperacionTipo.Error)
                    throw new Exception($"Ocurrió un error al desasociar zonas: {operacion.Mensaje}");
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaActualizarZona(object sender, ZonaArgumento e)
        {
            try
            {
                Operacion operacion = CatalogoZonaServicio.ActualizarZona(e);

                if (operacion.Resultado == ResultadoOperacionTipo.Error)
                    throw new Exception($"Ocurrió un error al actualizar zona: {operacion.Mensaje}");

                _vista_UsuarioDeseaConsultarZonas(sender, e);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaConsultarZonasAsociadas(object sender, ZonaArgumento e)
        {
            try
            {
                _vista.ZonaAsociadas = CatalogoZonaServicio.ConsultarZonasAsociadas(e);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaConsultarZonasParaAsociar(object sender, ZonaArgumento e)
        {
            try
            {
                _vista.ZonaAAsociar = CatalogoZonaServicio.ConsultarZonasParaAsociar(e);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaConsultarZonas(object sender, EventArgs e)
        {
            try
            {
                _vista.Zonas = CatalogoZonaServicio.ConsultarZonas();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }


    }
}
