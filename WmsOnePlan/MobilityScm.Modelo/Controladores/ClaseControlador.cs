using System;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Vertical.Entidades;
using MobilityScm.Vertical.Servicios;
using Enums = MobilityScm.Modelo.Configuracion.Enums;

namespace MobilityScm.Modelo.Controladores
{
    public class ClaseControlador : IClaseControlador
    {
        private readonly IClaseVista _vista;

        public IClaseServicio ClaseServicio { get; set; }

        public IConfiguracionServicio ConfiguracionServicio { get; set; }

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        public ClaseControlador(IClaseVista vista)
        {
            _vista = vista;
            SuscribirEventos();
        }

        private void SuscribirEventos()
        {
            _vista.VistaCargandosePorPrimeraVez += _vista_VistaCargandosePorPrimeraVez;
            _vista.VistaTerminoDeCargar += _vista_VistaTerminoDeCargar;
            _vista.UsuarioDeseaGuardarClase += _vista_UsuarioDeseaGuardarClase;
            _vista.UsuarioDeseaEliminarClase += _vista_UsuarioDeseaEliminarClase;
            _vista.UsuarioDeseaAsociarClases += _vista_UsuarioDeseaAsociarClases;
            _vista.UsuarioDeseaDesasociarClases += _vista_UsuarioDeseaDesasociarClases;
            _vista.UsuarioDeseaObtenerClase += _vista_UsuarioDeseaObtenerClase;
            _vista.UsuarioDeseaObtenerClases += _vista_UsuarioDeseaObtenerClases;
            _vista.UsuarioDeseaObtenerClasesDisponiblesAAsociar += _vista_UsuarioDeseaObtenerClasesDisponiblesAAsociar;
            _vista.UsuarioDeseaObtenerTiposDeClases += _vista_UsuarioDeseaObtenerTiposDeClases;
            _vista.UsuarioDeseaCargarClasesPorXml += _vista_UsuarioDeseaCargarClasesPorXml;
        }

        private void _vista_UsuarioDeseaCargarClasesPorXml(object sender, ClaseArgumento e)
        {
            try
            {
                var operacion = ClaseServicio.CargarClasesPorXml(e);
                if (operacion.Resultado == ResultadoOperacionTipo.Exito)
                {
                    _vista.TerminoProceso("Se cargó correctamente la plantilla", sender);
                    _vista.Clases = ClaseServicio.ObtenerClases();
                }
                else
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al cargar la plantilla: {operacion.Mensaje}");
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al cargar clases por plantilla: {ex.Message}");
            }
        }

        private void _vista_UsuarioDeseaObtenerTiposDeClases(object sender, ClaseArgumento e)
        {
            try
            {
                _vista.Tipos =
                        ConfiguracionServicio.ObtenerConfiguracionesGrupoYTipo(new Entidades.Configuracion
                        {
                            PARAM_TYPE = Enums.GetStringValue(TipoDeClasificaciones.Sistema),
                            PARAM_GROUP = Enums.GetStringValue(GrupoDeClasificaciones.TipoDeClase)
                        });
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al obtener los tipos de clases : {ex.Message}");
            }
        }

        private void _vista_UsuarioDeseaObtenerClasesDisponiblesAAsociar(object sender, ClaseArgumento e)
        {
            try
            {
                _vista.ClasesNoAsociadas = ClaseServicio.ObtenerClasesNoAsociadas(e.Clase);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al obtener las clases disponibles para asociar: {ex.Message}");
            }
        }

        private void _vista_UsuarioDeseaObtenerClases(object sender, ClaseArgumento e)
        {
            try
            {
                _vista.Clases = ClaseServicio.ObtenerClases();
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al clases: {ex.Message}");
            }
        }

        private void _vista_UsuarioDeseaObtenerClase(object sender, ClaseArgumento e)
        {
            try
            {
                _vista.Clase = ClaseServicio.ObtenerClasePorId(e.Clase);
                _vista.ClasesAsociadas = ClaseServicio.ObtenerClasesAsociadas(e.Clase);
                _vista.ClasesNoAsociadas = ClaseServicio.ObtenerClasesNoAsociadas(e.Clase);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al obtener la clase seleccionada: {ex.Message}");
            }
        }

        private void _vista_UsuarioDeseaDesasociarClases(object sender, ClaseArgumento e)
        {
            try
            {
                var operacion = ClaseServicio.DesasociarClases(e);
                if (operacion.Resultado == ResultadoOperacionTipo.Exito)
                {
                    _vista.ClasesAsociadas = ClaseServicio.ObtenerClasesAsociadas(e.Clase);
                    _vista.ClasesNoAsociadas = ClaseServicio.ObtenerClasesNoAsociadas(e.Clase);
                }
                else
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al desasociar las clases: {operacion.Mensaje}");
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al desasociar clases: {ex.Message}");
            }

        }

        private void _vista_UsuarioDeseaAsociarClases(object sender, ClaseArgumento e)
        {
            try
            {
                var operacion = ClaseServicio.AsociarClases(e);
                if (operacion.Resultado == ResultadoOperacionTipo.Exito)
                {
                    _vista.ClasesAsociadas = ClaseServicio.ObtenerClasesAsociadas(e.Clase);
                    _vista.ClasesNoAsociadas = ClaseServicio.ObtenerClasesNoAsociadas(e.Clase);
                }
                else
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al asociar las clases: {operacion.Mensaje}");
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al asociar clases: {ex.Message}");
            }
        }

        private void _vista_UsuarioDeseaEliminarClase(object sender, ClaseArgumento e)
        {
            try
            {
                var operacion = ClaseServicio.EliminarClase(e.Clase);
                if (operacion.Resultado == ResultadoOperacionTipo.Exito)
                {
                    _vista.TerminoProceso("Se elimino correctamente la clase", sender);
                    _vista.Clases = ClaseServicio.ObtenerClases();
                }
                else
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al eliminar la clase: {operacion.Mensaje}");
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al eliminar clase: {ex.Message}");
            }
        }

        private void _vista_UsuarioDeseaGuardarClase(object sender, ClaseArgumento e)
        {
            try
            {
                Operacion operacion;
                var clase = new Clase();

                if (e.Clase.CLASS_ID == 0)
                {
                    operacion = ClaseServicio.CrearClase(e.Clase);
                    clase.CLASS_ID = Convert.ToInt32(operacion.DbData);
                }
                else
                {
                    operacion = ClaseServicio.ActualizarClase(e.Clase);
                    clase.CLASS_ID = e.Clase.CLASS_ID;
                }

                if (operacion.Resultado == ResultadoOperacionTipo.Exito)
                {
                    _vista.Clases = ClaseServicio.ObtenerClases();
                    _vista.Clase = ClaseServicio.ObtenerClasePorId(clase);
                    _vista.ClasesAsociadas = ClaseServicio.ObtenerClasesAsociadas(clase);
                    _vista.ClasesNoAsociadas = ClaseServicio.ObtenerClasesNoAsociadas(clase);
                }
                else
                {
                    InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al guardar la clase: {operacion.Mensaje}");
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al guardar clase: {ex.Message}");
            }
        }

        private void _vista_VistaTerminoDeCargar(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _vista_VistaCargandosePorPrimeraVez(object sender, EventArgs e)
        {
            try
            {
                _vista.Clases = ClaseServicio.ObtenerClases();
                _vista.Tipos =
                    ConfiguracionServicio.ObtenerConfiguracionesGrupoYTipo(new Entidades.Configuracion
                    {
                        PARAM_TYPE = Enums.GetStringValue(TipoDeClasificaciones.Sistema),
                        PARAM_GROUP = Enums.GetStringValue(GrupoDeClasificaciones.TipoDeClase)
                    });
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo($"Error al cargar la vista: {ex.Message}");
            }
        }
    }
}