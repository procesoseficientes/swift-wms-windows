using System;
using System.Collections.Generic;
using System.Linq;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Servicios;
using Telerik.OpenAccess.Util;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Estados;
using MobilityScm.Vertical.Entidades;

namespace MobilityScm.Modelo.Controladores
{
    public class ZonaDePosicionamientoControlador : IZonaDePosicionamientoControlador
    {
        private readonly IZonaDePosicionamientoVista _vista;

        public IParametroServicio ParametroServicio { get; set; }

        public IPosicionamientoServicio PosicionamientoServicio { get; set; }

        public IBodegaServicio BodegaServicio { get; set; }

        public IClaseServicio ClaseServicio { get; set; }
        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        public ZonaDePosicionamientoControlador(IZonaDePosicionamientoVista vista)
        {
            _vista = vista;
            SuscribirEventos();
        }

        private void SuscribirEventos()
        {
            _vista.UsuarioDeseaObtenerBodegas += _vista_UsuarioDeseaObtenerBodegas;
            _vista.UsuarioDeseaObtenerZonasDePosicionamiento += _vista_UsuarioDeseaObtenerZonasDePosicionamiento;
            _vista.UsuarioDeseaGrabarZonasDePosicionamiento += _vista_UsuarioDeseaGrabarZonasDePosicionamiento;
            _vista.UsuarioDeseaObtenerClasesDisponibles += _vista_UsuarioDeseaObtenerClasesDisponibles;
            _vista.UsuarioDeseaObtenerClasesAsociadas += _vista_UsuarioDeseaObtenerClasesAsociadas;
            _vista.UsuarioDeseaQuitarClases += _vista_UsuarioDeseaQuitarClases;
            _vista.UsuarioDeseaAgregarClases += _vista_UsuarioDeseaAgregarClases;
            _vista.VistaCargandosePorPrimeraVez += _vista_VistaCargandosePorPrimeraVez;
            _vista.UsuarioDeseaCargarPlantilla += _vista_UsuarioDeseaCargarPlantilla;
        }

        private void _vista_UsuarioDeseaCargarPlantilla(object sender, PosicionamientoArgumento e)
        {
            try
            {
                var operaciones = PosicionamientoServicio.ProcessarXmlObtenidoExcel(e);if (operaciones.Count > 0)
                {
                    var listaDeErrores = operaciones.Select(registro => registro.Mensaje).ToList();

                    InteraccionConUsuarioServicio.MensajeListaDeErrorDialogo(listaDeErrores);
                }
                else
                {
                    _vista_UsuarioDeseaObtenerBodegas(null, null);
                    _vista_UsuarioDeseaObtenerZonasDePosicionamiento(null, null);
                    _vista_UsuarioDeseaObtenerClasesAsociadas(null, null);
                    _vista_UsuarioDeseaObtenerClasesDisponibles(null, null);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void _vista_VistaCargandosePorPrimeraVez(object sender, EventArgs e)
        {
            try
            {
                _vista.Parametros = new List<Parametro>();
                ObtenerParametros();
                _vista_UsuarioDeseaObtenerBodegas(null, null);
                _vista_UsuarioDeseaObtenerZonasDePosicionamiento(null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void ObtenerParametros()
        {
            _vista.Parametros = ParametroServicio.ObtenerParametro(new ConsultaArgumento
            {
                GrupoParametro = Enums.GetStringValue(GrupoParametro.MaterialSubFamily),
                IdParametro = Enums.GetStringValue(IdParametro.UseMaterialSubFamily)
            });
        }

        private void _vista_UsuarioDeseaAgregarClases(object sender, PosicionamientoArgumento e)
        {
            try
            {
                if ((_vista.ZonasDePosicionamientoSeleccionado.ZONE_ID > 0) && !_vista.ClasesDisponibles.ToList().Exists(z => z.IS_SELECTED)) return;
                var arg = new PosicionamientoArgumento
                {
                    ZonaDePosicionamiento = _vista.ZonasDePosicionamientoSeleccionado,
                    Login = InteraccionConUsuarioServicio.ObtenerUsuario()
                    ,
                    XmlClases = Xml.ConvertListToXml(_vista.ClasesDisponibles.Where(b => b.IS_SELECTED).ToList())
                };

                Operacion operacion;

                var parametroUseSubFamily = _vista.Parametros.FirstOrDefault(p => p.PARAMETER_ID == Enums.GetStringValue(IdParametro.UseMaterialSubFamily) && p.GROUP_ID == Enums.GetStringValue(GrupoParametro.MaterialSubFamily));
                if (parametroUseSubFamily == null || int.Parse(parametroUseSubFamily.VALUE) == (int)SiNo.No)
                {
                    operacion = PosicionamientoServicio.AgregarClasesParaZonaDePosicionamiento(arg);
                }
                else
                {
                    operacion = PosicionamientoServicio.AgregarSubClasesParaZonaDePosicionamiento(arg);
                }
                
                if (operacion.Resultado == ResultadoOperacionTipo.Exito)
                {
                    if (!string.IsNullOrEmpty(operacion.DbData))
                        _vista.ZonasDePosicionamientoSeleccionado.ID = Guid.Parse(operacion.DbData);
                    _vista_UsuarioDeseaObtenerClasesAsociadas(null, null);
                    _vista_UsuarioDeseaObtenerClasesDisponibles(null, null);
                }
                else
                {
                    throw new Exception(operacion.Mensaje);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaQuitarClases(object sender, PosicionamientoArgumento e)
        {
            try
            {
                if ((_vista.ZonasDePosicionamientoSeleccionado.ZONE_ID > 0) && !_vista.ClasesAsociadas.ToList().Exists(z => z.IS_SELECTED)) return;
                var arg = new PosicionamientoArgumento
                {
                    ZonaDePosicionamiento = _vista.ZonasDePosicionamientoSeleccionado,
                    Login = InteraccionConUsuarioServicio.ObtenerUsuario()
                    ,
                    XmlClases = Xml.ConvertListToXml(_vista.ClasesAsociadas.Where(b => b.IS_SELECTED).ToList())
                };

                Operacion operacion;

                var parametroUseSubFamily = _vista.Parametros.FirstOrDefault(p => p.PARAMETER_ID == Enums.GetStringValue(IdParametro.UseMaterialSubFamily) && p.GROUP_ID == Enums.GetStringValue(GrupoParametro.MaterialSubFamily));
                if (parametroUseSubFamily == null || int.Parse(parametroUseSubFamily.VALUE) == (int)SiNo.No)
                {
                    operacion = PosicionamientoServicio.QuitarClasesParaZonaDePosicionamiento(arg);
                }
                else
                {
                    operacion = PosicionamientoServicio.QuitarSubClasesParaZonaDePosicionamiento(arg);
                }

                if (operacion.Resultado == ResultadoOperacionTipo.Exito)
                {
                    _vista_UsuarioDeseaObtenerClasesAsociadas(null, null);
                    _vista_UsuarioDeseaObtenerClasesDisponibles(null, null);
                }
                else
                {
                    throw new Exception(operacion.Mensaje);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerClasesAsociadas(object sender, PosicionamientoArgumento e)
        {
            try
            {
                var arg = new PosicionamientoArgumento
                {
                    ZonaDePosicionamiento = _vista.ZonasDePosicionamientoSeleccionado
                };
                var listaTemporal = _vista.ClasesAsociadas.Where(z => z.IS_SELECTED).ToList();

                IList<Clase> listaResultado;

                var parametroUseSubFamily = _vista.Parametros.FirstOrDefault(p => p.PARAMETER_ID == Enums.GetStringValue(IdParametro.UseMaterialSubFamily) && p.GROUP_ID == Enums.GetStringValue(GrupoParametro.MaterialSubFamily));
                if (parametroUseSubFamily == null || int.Parse(parametroUseSubFamily.VALUE) == (int)SiNo.No)
                {
                    listaResultado = ClaseServicio.ObtenerClasesAsignadasParaZonasDePosicionamiento(arg);
                }
                else
                {
                    listaResultado = ClaseServicio.ObtenerSubClasesAsignadasParaZonasDePosicionamiento(arg);
                }

                if (listaTemporal.Count > 0)
                {
                    foreach (var registro in listaResultado)
                    {
                        registro.IS_SELECTED = listaTemporal.Exists(lt => lt.IS_SELECTED && lt.CLASS_ID == registro.CLASS_ID);
                    }
                }
                _vista.ClasesAsociadas = listaResultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerClasesDisponibles(object sender, PosicionamientoArgumento e)
        {
            try
            {
                var arg = new PosicionamientoArgumento
                {
                    ZonaDePosicionamiento = _vista.ZonasDePosicionamientoSeleccionado
                };

                var listaTemporal = _vista.ClasesDisponibles.Where(z => z.IS_SELECTED).ToList();

                IList<Clase> listaResultado;

                var parametroUseSubFamily = _vista.Parametros.FirstOrDefault(p => p.PARAMETER_ID == Enums.GetStringValue(IdParametro.UseMaterialSubFamily) && p.GROUP_ID == Enums.GetStringValue(GrupoParametro.MaterialSubFamily));
                if (parametroUseSubFamily == null || int.Parse(parametroUseSubFamily.VALUE) == (int)SiNo.No)
                {
                    listaResultado = ClaseServicio.ObtenerClasesDisponbilesParaZonasDePosicionamiento(arg);
                }
                else
                {
                    listaResultado = ClaseServicio.ObtenerSubClasesDisponbilesParaZonasDePosicionamiento(arg);
                }

                if (listaTemporal.Count > 0)
                {
                    foreach (var registro in listaResultado)
                    {
                        registro.IS_SELECTED = listaTemporal.Exists(lt => lt.IS_SELECTED && lt.CLASS_ID == registro.CLASS_ID);
                    }
                }

                _vista.ClasesDisponibles = listaResultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaGrabarZonasDePosicionamiento(object sender, PosicionamientoArgumento e)
        {
            try
            {
                var operacion = PosicionamientoServicio.GrabarZonaDePosicionamiento(e);
                if (operacion.Resultado == ResultadoOperacionTipo.Exito)
                {
                    _vista_UsuarioDeseaObtenerZonasDePosicionamiento(null, null);
                }
                else
                {
                    InteraccionConUsuarioServicio.Mensaje(operacion.Mensaje);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerZonasDePosicionamiento(object sender, PosicionamientoArgumento e)
        {
            try
            {
                var arg = new PosicionamientoArgumento
                {
                    Login = InteraccionConUsuarioServicio.ObtenerUsuario()
                    ,
                    XmlBodegas = Xml.ConvertListToXml(_vista.Bodegas.Where(b => b.IS_SELECTED).ToList())
                };

                var parametroUseSubFamily = _vista.Parametros.FirstOrDefault(p => p.PARAMETER_ID == Enums.GetStringValue(IdParametro.UseMaterialSubFamily) && p.GROUP_ID == Enums.GetStringValue(GrupoParametro.MaterialSubFamily));

                if (parametroUseSubFamily == null || int.Parse(parametroUseSubFamily.VALUE) == (int)SiNo.No) {
                    _vista.ZonasDePosicionamientos = PosicionamientoServicio.ObtenerZonaDePosicionamientos(arg);
                } else
                {
                    _vista.ZonasDePosicionamientos = PosicionamientoServicio.ObtenerZonaDePosicionamientosSubClase(arg);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerBodegas(object sender, PosicionamientoArgumento e)
        {
            try
            {
                var listaTemporal = _vista.Bodegas.Where(z => z.IS_SELECTED).ToList();

                var listaResultado = BodegaServicio.ObtenerBodegaAsignadaAUsuario(InteraccionConUsuarioServicio.ObtenerUsuario());

                if (listaTemporal.Count > 0)
                {
                    foreach (var registro in listaResultado)
                    {
                        registro.IS_SELECTED = listaTemporal.Exists(lt => lt.IS_SELECTED && lt.WAREHOUSE_ID == registro.WAREHOUSE_ID);
                    }
                }

                _vista.Bodegas = listaResultado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
