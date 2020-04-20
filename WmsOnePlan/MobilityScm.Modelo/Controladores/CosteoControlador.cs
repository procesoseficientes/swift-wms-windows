using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Vertical.Servicios;

namespace MobilityScm.Modelo.Controladores
{
    public class CosteoControlador : ICosteoControlador
    {
        private readonly ICosteoVista _vista;

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }
        public ICosteoServicio CosteoServicio { get; set; }
        public IPolizaAseguradaServicio PolizaAseguradaServicio { get; set; }
        public IAcuerdoComercialServicio AcuerdoComercialServicio { get; set; }

        public CosteoControlador(ICosteoVista vista)
        {
            _vista = vista;
            SuscribirEventos();
        }

        private void SuscribirEventos()
        {
            _vista.UsuarioDeseaGrabarCosto += _vista_UsuarioDeseaGrabarCosto;
            _vista.UsuarioDeseaObtenerPolizasEncabezadoPendientes += _vista_UsuarioDeseaObtenerPolizasEncabezadoPendientes;
            _vista.UsuarioDeseaObtenerPolizaDetallePendiente += _vista_UsuarioDeseaObtenerPolizaDetallePendiente;
            _vista.UsuarioDeseaObtenerPolizaSeguro += _vista_UsuarioDeseaObtenerPolizaSeguro;
            _vista.UsuarioDeseaObtenerAcuerdosComerciales += _vista_UsuarioDeseaObtenerAcuerdosComerciales;
            _vista.VistaCargandosePorPrimeraVez += _vista_VistaCargandosePorPrimeraVez;
        }

        private void _vista_VistaCargandosePorPrimeraVez(object sender, EventArgs e)
        {
            _vista.Usuario = InteraccionConUsuarioServicio.ObtenerUsuario();
        }

        private void _vista_UsuarioDeseaObtenerAcuerdosComerciales(object sender, CosteoArgumento e)
        {
            try
            {
                _vista.AcuerdoComerciales = AcuerdoComercialServicio.ObtenerAcuerdosComercialesPorCliente(e.AcuerdoComercial);
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerPolizaSeguro(object sender, CosteoArgumento e)
        {
            try
            {
                _vista.PolizaAseguradas = PolizaAseguradaServicio.ObtenerPolizaAseguradaPorCliente(e.PolizaAsegurada);
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerPolizaDetallePendiente(object sender, CosteoArgumento e)
        {
            try
            {
                if (_vista.EsConsolidado)
                {
                    var polizas = _vista.Polizas.Where(p => p.IS_SELECTED && !_vista.PolizaDetallesParaConsolidado.ToList().Exists(pd => pd.DOC_ID == p.DOC_ID)).ToList();
                    foreach (var poliza in polizas)
                    {
                        var polizasDetalle = CosteoServicio.ObtenerPolizasDetallePendientesDeAutorizar(new CosteoArgumento { Poliza = poliza });
                        foreach (var polizaDetalle in polizasDetalle)
                        {
                            polizaDetalle.DOC_ID = poliza.DOC_ID;
                            polizaDetalle.CLIENT_CODE = poliza.CLIENT_CODE;
                            _vista.PolizaDetallesParaConsolidado.Add(polizaDetalle);
                        }
                    }

                    _vista.PolizaDetallesParaConsolidado = _vista.PolizaDetallesParaConsolidado.Where(pc => _vista.Polizas.ToList().Exists(p => p.IS_SELECTED && p.DOC_ID == pc.DOC_ID)).ToList();
                    AgruparDetallesParaConsolidado();
                }
                else
                {
                    var polizasDetalle = CosteoServicio.ObtenerPolizasDetallePendientesDeAutorizar(e);
                    foreach (var polizaDetalle in polizasDetalle)
                    {
                        polizaDetalle.DOC_ID = e.Poliza.DOC_ID;
                        polizaDetalle.CLIENT_CODE = e.Poliza.CLIENT_CODE;
                    }
                    _vista.PolizaDetalles = polizasDetalle;
                }

            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaObtenerPolizasEncabezadoPendientes(object sender, CosteoArgumento e)
        {
            try
            {
                _vista.Polizas = CosteoServicio.ObtenerPolizasEncabezadosPendientesDeAutorizar(e);
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void _vista_UsuarioDeseaGrabarCosto(object sender, CosteoArgumento e)
        {
            GrabarEncabezados();
            GrabarDetalles();
        }

        private void GrabarEncabezados()
        {
            try
            {
                foreach (var poliza in _vista.Polizas.ToList().Where(p => p.IS_SELECTED && p.TRANS_TYPE.Equals("INICIALIZACION_GENERAL")))
                {
                    var op = CosteoServicio.ActualizarPolizaEncabezado(new CosteoArgumento { Poliza = poliza, Login = InteraccionConUsuarioServicio.ObtenerUsuario() });
                    if (op.Resultado != ResultadoOperacionTipo.Error) continue;
                    InteraccionConUsuarioServicio.MensajeErrorDialogo(op.Mensaje);
                    break;
                }
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void GrabarDetalles()
        {
            try
            {
                var listaPolizasDetalle = (_vista.EsConsolidado) ? _vista.PolizaDetallesParaConsolidado : _vista.PolizaDetalles;
                foreach (var detalle in listaPolizasDetalle.ToList().Where(pd => pd.QTY > 0))
                {
                    var op = CosteoServicio.GrabarPolizaDetalle(new CosteoArgumento { PolizaDetalle = detalle, Login = InteraccionConUsuarioServicio.ObtenerUsuario() });
                    if (op.Resultado == ResultadoOperacionTipo.Error)
                    {
                        InteraccionConUsuarioServicio.MensajeErrorDialogo(op.Mensaje);
                        break;
                    }
                    if (detalle.LINE_NUMBER == 0)
                        detalle.LINE_NUMBER = int.Parse(op.DbData);
                }
                if (listaPolizasDetalle.ToList().Exists(pd => pd.QTY > 0))
                {
                    InteraccionConUsuarioServicio.MensajeExito("Se grabo exitosamente.");
                }

            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void AgruparDetallesParaConsolidado()
        {
            try
            {
                var listaDetalle = new List<PolizaDetalle>();
                foreach (var polizaDetalleNueva in _vista.PolizaDetallesParaConsolidado)
                {
                    var existePolizaDetalle = false;
                    foreach (var polizadetalleActual in listaDetalle.ToList().Where(pd => polizaDetalleNueva.MATERIAL_ID == pd.MATERIAL_ID))
                    {
                        existePolizaDetalle = true;
                        polizadetalleActual.QTY += polizaDetalleNueva.QTY;
                        polizadetalleActual.BULTOS += polizaDetalleNueva.BULTOS;
                        polizadetalleActual.UNITARY_PRICE = _vista.PolizaDetallesParaConsolidado.ToList().Where(pd => pd.MATERIAL_ID == polizadetalleActual.MATERIAL_ID).OrderByDescending(p => p.LAST_UPDATED).First().UNITARY_PRICE;
                        polizadetalleActual.CUSTOMS_AMOUNT += polizaDetalleNueva.QTY * polizadetalleActual.UNITARY_PRICE;

                    }
                    if (existePolizaDetalle) continue;
                    var nuevoDetalle = new PolizaDetalle
                    {
                        MATERIAL_ID = polizaDetalleNueva.MATERIAL_ID,
                        SKU_DESCRIPTION = polizaDetalleNueva.SKU_DESCRIPTION,
                        BULTOS = polizaDetalleNueva.BULTOS,
                        QTY = polizaDetalleNueva.QTY,
                        UNITARY_PRICE = polizaDetalleNueva.UNITARY_PRICE,
                        CUSTOMS_AMOUNT = polizaDetalleNueva.QTY * polizaDetalleNueva.UNITARY_PRICE
                    };
                    listaDetalle.Add(nuevoDetalle);
                }
                _vista.PolizaDetalles = listaDetalle;
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }
    }
}
