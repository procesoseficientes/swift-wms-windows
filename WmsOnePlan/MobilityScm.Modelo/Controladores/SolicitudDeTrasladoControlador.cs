﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Modelo.Vistas;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Servicios;
using MobilityScm.Modelo.Estados;

namespace MobilityScm.Modelo.Controladores
{
    public class SolicitudDeTrasladoControlador : ISolicitudDeTrasladoControlador
    {
        private readonly ISolicitudDeTrasladoVista _vista;

        public ISolicitudDeTrasladoServicio SolicitudDeTrasladoServicio { get; set; }

        public IConfiguracionServicio ConfiguracionServicio { get; set; }
        public IClienteServicio ClienteServicio { get; set; }
        public IBodegaServicio BodegaServicio { get; set; }
        public IMaterialServicio MaterialServicio { get; set; }
        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }
        public ISeguridadServicio SeguridadServicio { get; set; }

        public SolicitudDeTrasladoControlador(ISolicitudDeTrasladoVista vista)
        {
            _vista = vista;
            SuscribirEventos();
        }

        private void SuscribirEventos()
        {
            _vista.VistaCargandosePorPrimeraVez += _vista_VistaCargandosePorPrimeraVez;

            _vista.UsuarioSeleccionoCentroDeDistribucionOrigen += _vista_UsuarioSeleccionoCentroDeDistribucionOrigen;
            _vista.UsuarioSeleccionoCentroDeDistribucionDestino += _vista_UsuarioSeleccionoCentroDeDistribucionDestino;
            _vista.UsuarioSeleccionoCliente += _vista_UsuarioSeleccionoCliente;

            _vista.UsuarioDeseaGuardarSolicitudDeTraslado += _vista_UsuarioDeseaGuardarSolicitudDeTraslado;
            _vista.UsuarioDeseaBuscarSolicitudDeTraslado += _vista_UsuarioDeseaBuscarSolicitudDeTraslado;

            _vista.UsuarioDeseaRefrescarCentrosDeDistribucionOrigen += _vista_UsuarioDeseaRefrescarCentrosDeDistribucionOrigen;
            _vista.UsuarioDeseaRefrescarCentrosDeDistribucionDestino += _vista_UsuarioDeseaRefrescarCentrosDeDistribucionDestino;
            _vista.UsuarioDeseaRefrescarClientes += _vista_UsuarioDeseaRefrescarClientes;
            _vista.UsuarioDeseaRefrescarTipos += _vista_UsuarioDeseaRefrescarTipos;
        }

        private void _vista_UsuarioDeseaRefrescarTipos(object sender, EventArgs e)
        {
            _vista.TiposSolicitudDeTraslado = ConfiguracionServicio.ObtenerTiposSolicitudDeTraslado(new Entidades.Configuracion());
        }

        private void _vista_UsuarioDeseaRefrescarClientes(object sender, EventArgs e)
        {
            _vista.Clientes = ClienteServicio.ObtenerClientes();
        }

        private void _vista_UsuarioDeseaRefrescarCentrosDeDistribucionDestino(object sender, EventArgs e)
        {
            _vista.CentrosDeDistribucionDestino = ConfiguracionServicio.ObtenerCentrosDeDistribucionPorLogin(new Entidades.Configuracion { LOGIN = InteraccionConUsuarioServicio.ObtenerUsuario() });
        }

        private void _vista_UsuarioDeseaRefrescarCentrosDeDistribucionOrigen(object sender, EventArgs e)
        {
            _vista.CentrosDeDistribucionOrigen = ConfiguracionServicio.ObtenerCentrosDeDistribucion(new Entidades.Configuracion());
        }

        private void _vista_VistaCargandosePorPrimeraVez(object sender, EventArgs e)
        {
            try
            {
                var login = InteraccionConUsuarioServicio.ObtenerUsuario();
                _vista.CentrosDeDistribucionDestino = ConfiguracionServicio.ObtenerCentrosDeDistribucionPorLogin(new Entidades.Configuracion { LOGIN = login });
                _vista.CentrosDeDistribucionOrigen = ConfiguracionServicio.ObtenerCentrosDeDistribucion(new Entidades.Configuracion());
                _vista.Clientes = ClienteServicio.ObtenerClientes();
                _vista.TiposSolicitudDeTraslado = ConfiguracionServicio.ObtenerTiposSolicitudDeTraslado(new Entidades.Configuracion());
                _vista.ListaDeSeguridad =
                    SeguridadServicio.ObtenerPermisosDeSeguridad(new SeguridadArgumento
                    {
                        Seguridad =
                            new Seguridad
                            {
                                PARENT = Enums.GetStringValue(Tipos.PadreDePrivilegio.SolicitudDeTraslado),
                                CATEGORY = Enums.GetStringValue(Tipos.CategorigaDePrivilegio.Seguridad),
                                LOGIN = login
                            }
                    });
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioDeseaGuardarSolicitudDeTraslado(object sender, SolicitudDeTrasladoArgumento e)
        {
            try
            {
                var op = SolicitudDeTrasladoServicio.AgregarSolicitudDeTrasladoEncabezado(e);
                if (op.Resultado == ResultadoOperacionTipo.Error)
                {
                    InteraccionConUsuarioServicio.Mensaje(op.Mensaje);
                }
                else
                {
                    _vista.IdSolicitudDeTraslado = int.Parse(op.DbData);
                    var detalle = e.ListadoMateriales.Select(mt => new SolicitudDeTrasladoDetalle
                    {
                        TRANSFER_REQUEST_ID = int.Parse(op.DbData),
                        MATERIAL_ID = mt.MATERIAL_ID,
                        MATERIAL_NAME = mt.MATERIAL_NAME,
                        IS_MASTERPACK = mt.IS_MASTER_PACK,
                        QTY = (decimal)mt.QTY,
                        STATUS = EstadoSolicitudDeTraslado.OPEN.ToString()
                    }).ToList();

                    op = SolicitudDeTrasladoServicio.AgregarSolicitudDeTrasladoDetalle(new SolicitudDeTrasladoArgumento {
                        SolicitudDeTrasladoDetalles = detalle
                    });

                    if (op.Resultado == ResultadoOperacionTipo.Error)
                    {
                        InteraccionConUsuarioServicio.Mensaje(op.Mensaje);
                    }
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioSeleccionoCliente(object sender, ConteoFisicoArgumento e)
        {
            try
            {
                _vista.Materiales = MaterialServicio.ObtenerMaterialesPorBodegaClienteUbicacionOZona(e);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioSeleccionoCentroDeDistribucionDestino(object sender, SolicitudDeTrasladoArgumento e)
        {
            try
            {
                _vista.BodegasDestino = BodegaServicio.ObtenerBodegaPorCentroDeDistribucionYUsuario(new Bodega {
                    DISTRIBUTION_CENTER_ID = e.CentroDeDistribucion,
                    LOGIN = InteraccionConUsuarioServicio.ObtenerUsuario(),
                    IS_WAREHOUSE_FROM = (int)SiNo.No
                });
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }

        private void _vista_UsuarioSeleccionoCentroDeDistribucionOrigen(object sender, SolicitudDeTrasladoArgumento e)
        {
            try
            {
                _vista.BodegasOrigen = BodegaServicio.ObtenerBodegaPorCentroDeDistribucionYUsuario(new Bodega {
                    DISTRIBUTION_CENTER_ID = e.CentroDeDistribucion,
                    LOGIN = InteraccionConUsuarioServicio.ObtenerUsuario(),
                    IS_WAREHOUSE_FROM = (int)SiNo.Si
                });
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }
        
        private void _vista_UsuarioDeseaBuscarSolicitudDeTraslado(object sender, SolicitudDeTrasladoArgumento e)
        {
            try
            {
                _vista.SolicitudDeTrasladoEncabezado = SolicitudDeTrasladoServicio.ObtenerSolicitudDeTrasladoEncabezado(e);
                if (_vista.SolicitudDeTrasladoEncabezado == null) return;

                _vista.SolicitudDeTrasladoDetalle = SolicitudDeTrasladoServicio.ObtenerSolicitudDeTrasladoDetalle(e);

                _vista.CentrosDeDistribucionOrigen = ConfiguracionServicio.ObtenerCentrosDeDistribucion(new Entidades.Configuracion());
                _vista.CentrosDeDistribucionDestino = ConfiguracionServicio.ObtenerCentrosDeDistribucion(new Entidades.Configuracion());

                _vista.BodegasOrigen = BodegaServicio.ObtenerBodegaPorCentroDeDistribucionYUsuario(new Bodega
                {
                    DISTRIBUTION_CENTER_ID = _vista.SolicitudDeTrasladoEncabezado.DISTRIBUTION_CENTER_FROM,
                    LOGIN = InteraccionConUsuarioServicio.ObtenerUsuario(),
                    IS_WAREHOUSE_FROM = (int)SiNo.Si
                });
                _vista.BodegasDestino = BodegaServicio.ObtenerBodegaPorCentroDeDistribucionYUsuario(new Bodega
                {
                    DISTRIBUTION_CENTER_ID = _vista.SolicitudDeTrasladoEncabezado.DISTRIBUTION_CENTER_TO,
                    LOGIN = InteraccionConUsuarioServicio.ObtenerUsuario(),
                    IS_WAREHOUSE_FROM = (int)SiNo.Si
                });
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje(ex.Message);
            }
        }
    }
}
