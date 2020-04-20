using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Device.Location;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Map;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraMap;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Modelo.Atributos;
using MobilityScm.Modelo.Controladores;
using MobilityScm.Modelo.Entidades;
using MobilityScm.Modelo.Interfaces.Controladores;
using MobilityScm.Modelo.Interfaces.Servicios;
using MobilityScm.Modelo.Servicios;
using MobilityScm.Modelo.Tipos;
using MobilityScm.Utilerias;
using MobilityScm.Vertical.Servicios;
using MobilityScm.Modelo.Estados;
using System.IO;
using System.Text.RegularExpressions;

namespace MobilityScm.Modelo.Vistas
{
    public partial class CumplimientoDeEntregaVista : VistaBase, ICumplimientoDeEntregaVista
    {
        #region Eventos

        public event EventHandler VistaCargandosePorPrimeraVez;
        public event EventHandler UsuarioDeseaObtenerPilotos;
        public event EventHandler UsuarioDeseaObtenerVehiculos;
        public event EventHandler<CumplimientoDeEntregaArgumento> UsuarioDeseaConsultarCumplimientoDeEntrega;
        public event EventHandler<CumplimientoDeEntregaArgumento> UsuarioSeleccionoManifiestoDeCarga;
        public event EventHandler<CumplimientoDeEntregaArgumento> UsuarioDeseaObtenerImagenesDeEntrega;

        #endregion

        #region Propiedades

        public IInteraccionConUsuarioServicio InteraccionConUsuarioServicio { get; set; }

        public IList<Piloto> Pilotos
        {
            get { return (IList<Piloto>)UiListaPilotos.Properties.DataSource; }
            set
            {
                UiListaPilotos.Properties.DataSource = value;
            }
        }

        public IList<Vehiculo> Vehiculos
        {
            get { return (IList<Vehiculo>)UiListaVehiculos.Properties.DataSource; }
            set
            {
                UiListaVehiculos.Properties.DataSource = value;
            }
        }

        public Vehiculo Vehiculo { get; set; }

        public IList<CumplimientoDeEntrega> CumplimientoDeEntregas
        {
            get { return (IList<CumplimientoDeEntrega>)UiGridVistaCumpimientoDeEntrega.DataSource; }
            set
            {
                UiGridVistaCumpimientoDeEntrega.DataSource = value;
                UiVistaCumplimientoDeEntrega.ExpandAllGroups();
            }
        }
        public IList<TareaDeCumplimientoDeEntrega> TareasCumplimientodeEntregas { get; set; }

        public bool UsuarioSeleccionoListaCompletaDeVehiculos { get; set; }

        public bool UsuarioSeleccionoListaCompletaDePilotos { get; set; }

        private CamionMapa Camion { get; set; }

        public int TicksReinicio { get; set; }

        public IList<CumplimientoDeEntrega> ImagenesDeEntrega{get; set; }

        public bool DoubleClikMapaTraking { get; set; }

        #endregion

        #region Constructor E Inicializacion

        public CumplimientoDeEntregaVista()
        {
            InitializeComponent();

            InteraccionConUsuarioServicio = Mvx.Ioc.Resolve<IInteraccionConUsuarioServicio>();
            Mvx.Ioc.RegisterType<IBaseDeDatosServicio, BaseDeDatosServicio>();
            Mvx.Ioc.Resolve<IConfiguracionDeConexion>();
            Mvx.Ioc.RegisterType<ICumplimientoDeEntregaServicio, CumplimientoDeEntregaServicio>();
            Mvx.Ioc.RegisterType<IPilotoServicio, PilotoServicio>();
            Mvx.Ioc.RegisterType<IVehiculoServicio, VehiculoServicio>();
            Mvx.Ioc.RegisterType<ICumplimientoDeEntregaControlador, CumplimientoDeEntregaControlador>();
            Mvx.Ioc.RegisterSingleton<ICumplimientoDeEntregaVista, CumplimientoDeEntregaVista>(this);
            Mvx.Ioc.Resolve<ICumplimientoDeEntregaControlador>();
        }

        private void CumplimientoDeEntregaVista_Load(object sender, EventArgs e)
        {
            UiFechaInicial.EditValue = DateTime.Now.AddDays(-1);
            UiFechaFinal.EditValue = DateTime.Now;
            TicksReinicio = int.MinValue;

            VistaCargandosePorPrimeraVez?.Invoke(sender, e);
            CargarOGuardarDisenios(UiGridVistaCumpimientoDeEntrega, false,
                InteraccionConUsuarioServicio.ObtenerUsuario(), GetType().Name);

        }

        #endregion

        #region Metodos

        private void ValidarCamposDeUsuario()
        {
            if (string.IsNullOrEmpty(UiFechaInicial.EditValue.ToString()))
            {
                throw new Exception("Por favor ingrese la fecha inicial para el reporte.");
            }

            if (string.IsNullOrEmpty(UiFechaFinal.EditValue.ToString()))
            {
                throw new Exception("Por favor ingrese la fecha final para el reporte.");
            }

            if (CantidadDePilotosSeleccionados() == 0 && CantidadDeVehiculosSeleccionados() == 0)
            {
                throw new Exception("Debe seleccionar por lo menos un piloto o vehiculo.");
            }

            if (UiFechaInicial.EditValue.ToString() == UiFechaFinal.EditValue.ToString())
            {
                throw new Exception("La fecha inicial es igual a la fecha final.");
            }

            if (DateTime.Parse(UiFechaInicial.EditValue.ToString()) > DateTime.Parse(UiFechaFinal.EditValue.ToString()))
            {
                throw new Exception("La fecha inicial no debe ser mayor a la fecha final.");
            }

        }

        private int CantidadDeVehiculosSeleccionados()
        {
            return Vehiculos.Count(ve => ve.IS_SELECTED);
        }

        private int CantidadDePilotosSeleccionados()
        {
            return Pilotos.Count(pi => pi.IS_SELECTED);
        }

        private string ObtenerCodigosDeVehiculosSeleccionados()
        {
            return string.Join("|",
                Vehiculos.Where(ve => ve.IS_SELECTED).Select(v => v.VEHICLE_CODE).ToList());
        }

        private string ObtenerCodigosDePilotosSeleccionados()
        {
            return string.Join("|", Pilotos.Where(pi => pi.IS_SELECTED).Select(p => p.PILOT_CODE).ToList());
        }

        private IList<GeoCoordinate> ObtenerCoordenadas(IList<TareaDeCumplimientoDeEntrega> tareas)
        {
            return tareas.Select(tarea => new GeoCoordinate(tarea.Latitude, tarea.Longitude)).ToList();
        }

        private GeoPoint ObtenerPuntoMedio(IList<GeoCoordinate> coordenadas)
        {
            if (coordenadas.Count == 1)
            {
                return new GeoPoint(coordenadas.Single().Latitude, coordenadas.Single().Longitude);
            }

            double x = 0;
            double y = 0;
            double z = 0;

            foreach (var geoCoordinate in coordenadas)
            {
                var latitude = geoCoordinate.Latitude * Math.PI / 180;
                var longitude = geoCoordinate.Longitude * Math.PI / 180;

                x += Math.Cos(latitude) * Math.Cos(longitude);
                y += Math.Cos(latitude) * Math.Sin(longitude);
                z += Math.Sin(latitude);
            }

            var total = coordenadas.Count;

            x = x / total;
            y = y / total;
            z = z / total;

            var centralLongitude = Math.Atan2(y, x);
            var centralSquareRoot = Math.Sqrt(x * x + y * y);
            var centralLatitude = Math.Atan2(z, centralSquareRoot);

            return new GeoPoint(centralLatitude * 180 / Math.PI, centralLongitude * 180 / Math.PI);
        }

        private void CargarCapasDeMapa()
        {
            try
            {
                var capaRutas = new VectorItemsLayer()
                {
                    Name = CapaMapaTracking.Rutas.ToString()
                };

                var capaTareas = new VectorItemsLayer()
                {
                    Name = CapaMapaTracking.Tareas.ToString()
                };

                var capaCamion = new VectorItemsLayer()
                {
                    Name = CapaMapaTracking.Camion.ToString()
                };

                UiMapaTracking.Layers.Add(capaRutas);
                UiMapaTracking.Layers.Add(capaTareas);
                UiMapaTracking.Layers.Add(capaCamion);

                
                capaRutas.Data = ObtenerRutas();
                capaTareas.Data = ObtenerTareas();
                capaCamion.Data = ObtenerCamion();

                //----

                var capaRutasMapaYFoto = new VectorItemsLayer()
                {
                    Name = CapaMapaTracking.Rutas.ToString()
                };

                var capaTareasMapaYFoto = new VectorItemsLayer()
                {
                    Name = CapaMapaTracking.Tareas.ToString()
                };

                var capaCamionMapaYFoto = new VectorItemsLayer()
                {
                    Name = CapaMapaTracking.Camion.ToString()
                };

                UiMapaTrackingMapaYFoto.Layers.Add(capaRutasMapaYFoto);
                UiMapaTrackingMapaYFoto.Layers.Add(capaTareasMapaYFoto);
                UiMapaTrackingMapaYFoto.Layers.Add(capaCamionMapaYFoto);

                capaRutasMapaYFoto.Data = ObtenerRutas();
                capaTareasMapaYFoto.Data = ObtenerTareas();
                capaCamionMapaYFoto.Data = ObtenerCamion();


                //UiMapaTracking.CenterPoint = ObtenerPuntoMedio(ObtenerCoordenadas(TareasCumplimientodeEntregas));
                var puntos = ObtenerPuntoMedio(ObtenerCoordenadas(TareasCumplimientodeEntregas));
                UiMapaTracking.CenterPoint = puntos;
                UiMapaTrackingMapaYFoto.CenterPoint = puntos;

                UiMapaTracking.ZoomToFitLayerItems();
                UiMapaTrackingMapaYFoto.ZoomToFitLayerItems();
            }
            catch (Exception e)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(e.Message);
                throw;
            }
        }

        private MapItemStorage ObtenerRutas()
        {
            var storage = new MapItemStorage();
            var rutas = new List<RutaMapa>();

            for (var i = 0; i < TareasCumplimientodeEntregas.Count - 1; i++)
            {
                var r = new RutaMapa(TareasCumplimientodeEntregas[i], TareasCumplimientodeEntregas[i + 1]);
                rutas.Add(r);
            }

            storage.Items.AddRange(rutas.ToArray());
            return storage;
        }

        private ListSourceDataAdapter ObtenerTareas()
        {
            var lsD = new ListSourceDataAdapter
            {
                DefaultMapItemType = MapItemType.Pushpin,
                Mappings = { Latitude = "Latitude", Longitude = "Longitude", Text = "SEQUENCE" },
                DataSource = TareasCumplimientodeEntregas.ToList()
            };

            Image image = (Image)Properties.Resources.ResourceManager.GetObject("pushpin_red");

            lsD.SetMapItemFactory(new PushpinFactory(image, Color.Red));

            return lsD;
        }

        private MapItemStorage ObtenerCamion()
        {
            if (TareasCumplimientodeEntregas.Count <= 1) return null;
            var storage = new MapItemStorage();
            var primeraTarea = TareasCumplimientodeEntregas[0];
            var segundaTarea = TareasCumplimientodeEntregas[1];

            var puntoPrimeraTarea = new GeoCoordinate(primeraTarea.Latitude, primeraTarea.Longitude);
            var puntoSegundaTarea = new GeoCoordinate(segundaTarea.Latitude, segundaTarea.Longitude);
            var distancia = puntoPrimeraTarea.GetDistanceTo(puntoSegundaTarea);

            Camion = new CamionMapa()
            {
                TareaActual = TareasCumplimientodeEntregas.FirstOrDefault(),
                DistanciaRecorrida = 0,
                Distancia = distancia,
                Location = TareasCumplimientodeEntregas.FirstOrDefault().Location
            };

            storage.Items.Add(Camion);
            return storage;
        }
        #endregion

        #region MetodosDeControles

        private void UiBtnExportarVistaAExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                UiDialogoExportarExcel.DefaultExt = "xlsx";
                UiDialogoExportarExcel.Filter = @"Archivos de excel (*.xlsx)|*.xlsx";
                UiDialogoExportarExcel.FilterIndex = 2;
                UiDialogoExportarExcel.RestoreDirectory = true;
                UiDialogoExportarExcel.Title = @"Guardar Cumplimiento De Entrega";

                if (UiDialogoExportarExcel.ShowDialog() == DialogResult.OK)
                {
                    UiGridVistaCumpimientoDeEntrega.ExportToXlsx(UiDialogoExportarExcel.FileName);
                }
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Alerta(ex.Message);
            }
        }

        private void UiBtnExpandirGrupos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                UiVistaCumplimientoDeEntrega.ExpandAllGroups();
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }

        }

        private void UiBtnContraerGrupos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                UiVistaCumplimientoDeEntrega.CollapseAllGroups();
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void UiBtnRefrescarVista_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                ValidarCamposDeUsuario();

                UiMapaTracking.Overlays.Clear();
                var layerBing = UiMapaTracking.Layers[CapaMapaTracking.Bing.ToString()];
                UiMapaTracking.Layers.Clear();
                UiMapaTracking.Layers.Add(layerBing);

                UiMapaTrackingMapaYFoto.Overlays.Clear();
                var layerBingMap = UiMapaTrackingMapaYFoto.Layers[CapaMapaTracking.Bing.ToString()];
                UiMapaTrackingMapaYFoto.Layers.Clear();
                UiMapaTrackingMapaYFoto.Layers.Add(layerBingMap);

                UiTimerCamion.Enabled = false;

                UsuarioDeseaConsultarCumplimientoDeEntrega?.Invoke(sender,
                    new CumplimientoDeEntregaArgumento
                    {
                        CodigosDePilotos = ObtenerCodigosDePilotosSeleccionados(),
                        CodigosDeVehiculos = ObtenerCodigosDeVehiculosSeleccionados(),
                        FechaInicial =
                            DateTime.Parse(UiFechaInicial.EditValue.ToString()),
                        FechaFinal =
                            DateTime.Parse(UiFechaFinal.EditValue.ToString())
                    });
            }
            catch (Exception exception)
            {
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }

        private void UiListaVehiculos_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == null) return;
            switch (e.Button.Tag.ToString())
            {
                case "UiBtnRefrescarListaPilotos":
                    UsuarioDeseaObtenerPilotos?.Invoke(sender, new PilotoArgumento { Piloto = new Piloto() });
                    break;
                case "UiBtnRefrescarListaVehiculos":
                    UsuarioDeseaObtenerVehiculos?.Invoke(sender, e);
                    break;
            }
        }

        private void LimpiarMapa()
        {
            var overlays = UiMapaTracking.Overlays.Where(o => o.Alignment != ContentAlignment.TopRight).ToArray();
            UiMapaTracking.Overlays.Clear();
            UiMapaTracking.Overlays.AddRange(overlays);

            var overlaysMap = UiMapaTrackingMapaYFoto.Overlays.Where(o => o.Alignment != ContentAlignment.TopRight).ToArray();
            UiMapaTrackingMapaYFoto.Overlays.Clear();
            UiMapaTrackingMapaYFoto.Overlays.AddRange(overlaysMap);
        }

        private void MostrarInformacionDeLaTarea(TareaDeCumplimientoDeEntrega tarea)
        {
            var overlayWithText = new MapOverlay
            {
                Alignment = ContentAlignment.TopRight,
                JoiningOrientation = Orientation.Vertical,
                Margin = new Padding(10),
                Padding = new Padding(7),
            };

            overlayWithText.Items.Add(new MapOverlayTextItem
            {
                Text = "Codigo de Cliente: " + tarea.CLIENT_CODE + "\n" +
                       "Nombre del Cliente: " + tarea.CLIENT_NAME + "\n" +
                       "Tarea de Entrega: " + tarea.TASK_ID + "\n" +
                       "Estado de la Entrega: " + tarea.PICKING_DEMAND_STATUS.ToString() + "\n" +
                       "Demora: " + tarea.Demora + "\n" +
                       "Cantidad de documentos: " + tarea.DOCUMENT_QTY + ""
                       + (tarea.PICKING_DEMAND_STATUS == EstadoTareaDeEntrega.Parcial 
                            || tarea.PICKING_DEMAND_STATUS == EstadoTareaDeEntrega.Cancelada ?
                       "\nRazón: " + tarea.REASON : string.Empty)

            });

            UiMapaTracking.Overlays.Add(overlayWithText);
            if (DoubleClikMapaTraking)
            {
                CargarFotos(tarea.DELIVERY_NOTE_ID);
                DoubleClikMapaTraking = false;
            }
            
        }

        private void MostrarInformacionDelDocumento()
        {
            var tarea = TareasCumplimientodeEntregas.FirstOrDefault();
            if (tarea == null) return;

            var overlayWithText = new MapOverlay
            {
                Alignment = ContentAlignment.BottomCenter,
                JoiningOrientation = Orientation.Horizontal,
                Margin = new Padding(10),
                Padding = new Padding(7)
            };

            overlayWithText.Items.Add(new MapOverlayTextItem()
            {
                TextAlignment = ContentAlignment.MiddleCenter,
                Text = "Piloto - " + tarea.PILOT_NAME +
                        "\nFecha de Inicio - " + tarea.ACCEPTED_STAMP +
                        "\nPorcentaje de Cumplimiento - " + tarea.PERCENTAGE
            });

            UiMapaTracking.Overlays.Add(overlayWithText);
        }

        private void ExpandirNavegacionPaginas(object sender)
        {
            try
            {
                ((NavigationPane)sender).State = NavigationPaneState.Expanded;
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje("Navegación cambia de estado: " + ex.Message);
            }
        }
        #endregion

        #region EventosControlListaVehiculo

        private void UiListaVehiculo_MouseUp(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;

            GridHitInfo hi = view.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) &&
                hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoListaCompletaDeVehiculos = true;
            }
        }

        private void UiListaVehiculo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.ControllerRow >= 0)
            {
                var registro = (Vehiculo)UiListaVehiculo.GetRow(e.ControllerRow);
                registro.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (UsuarioSeleccionoListaCompletaDeVehiculos)
                {
                    for (var i = 0; i < UiListaVehiculo.RowCount; i++)
                    {
                        var registro = (Vehiculo)UiListaVehiculo.GetRow(i);
                        if (registro == null) continue;
                        registro.IS_SELECTED = (UiListaVehiculo.SelectedRowsCount != 0);
                    }
                    UsuarioSeleccionoListaCompletaDeVehiculos = false;
                }
            }
            var edit = UiListaVehiculos;
            if (edit == null) return;
            edit.Text = ObtenerTextoAMostrarEnListaDeVehiculos();
        }

        private void UiListaVehiculo_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            for (var i = 0; i < UiListaVehiculo.RowCount; i++)
            {
                var registro = (Vehiculo)UiListaVehiculo.GetRow(i);
                if (registro == null) continue;
                if (registro.IS_SELECTED)
                {
                    UiListaVehiculo.SelectRow(i);
                }
            }
        }

        private void UiListaVehiculos_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = ObtenerTextoAMostrarEnListaDeVehiculos();
        }

        private string ObtenerTextoAMostrarEnListaDeVehiculos()
        {
            if (Vehiculos == null) return "";

            return string.Join(",",
                Vehiculos.Where(ve => ve.IS_SELECTED).Select(v => v.VEHICLE_CODE + "|" + v.PLATE_NUMBER).ToList());

        }

        #endregion

        #region EventosControlListaPiloto

        private void UiListaPiloto_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            for (var i = 0; i < UiListaPiloto.RowCount; i++)
            {
                var registro = (Piloto)UiListaPiloto.GetRow(i);
                if (registro == null) continue;
                if (registro.IS_SELECTED)
                {
                    UiListaPiloto.SelectRow(i);
                }
            }
        }

        private void UiListaPiloto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.ControllerRow >= 0)
            {
                var registro = (Piloto)UiListaPiloto.GetRow(e.ControllerRow);
                registro.IS_SELECTED = (e.Action == CollectionChangeAction.Add);
            }
            else
            {
                if (UsuarioSeleccionoListaCompletaDePilotos)
                {
                    for (var i = 0; i < UiListaPiloto.RowCount; i++)
                    {
                        var registro = (Piloto)UiListaPiloto.GetRow(i);
                        if (registro == null) continue;
                        registro.IS_SELECTED = (UiListaPiloto.SelectedRowsCount != 0);
                    }
                    UsuarioSeleccionoListaCompletaDePilotos = false;
                }
            }
            var edit = UiListaPilotos;
            if (edit == null) return;
            edit.Text = ObtenerTextoAMostrarEnListaDePilotos();
        }

        private void UiListaPiloto_MouseUp(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null)
                return;

            GridHitInfo hi = view.CalcHitInfo(new System.Drawing.Point(e.X, e.Y));
            if ((hi.HitTest == GridHitTest.Column || hi.HitTest == GridHitTest.GroupPanelColumn) &&
                hi.Column.Name.Equals("DX$CheckboxSelectorColumn"))
            {
                UsuarioSeleccionoListaCompletaDePilotos = true;
            }
        }

        private void UiListaPilotos_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            e.DisplayText = ObtenerTextoAMostrarEnListaDePilotos();
        }


        private string ObtenerTextoAMostrarEnListaDePilotos()
        {
            if (Vehiculos == null) return "";
            return string.Join(",",
                Pilotos.Where(pi => pi.IS_SELECTED).Select(p => p.PILOT_CODE + "|" + p.NAME + "|" + p.LAST_NAME));
        }




        #endregion

        #region EventosDeControlesParaMapa
        private void UiMapaTracking_SelectionChanged(object sender, MapSelectionChangedEventArgs e)
        {

        }


        private void UiVistaCumplimientoDeEntrega_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.RowHandle < 0) return;
            if (UiVistaCumplimientoDeEntrega.GetRow(e.RowHandle).GetType() != typeof(CumplimientoDeEntrega)) return;
            var manifiesto = (CumplimientoDeEntrega)UiVistaCumplimientoDeEntrega.GetRow(e.RowHandle);
            if (manifiesto == null) return;

            UsuarioSeleccionoManifiestoDeCarga?.Invoke(sender, new CumplimientoDeEntregaArgumento() { IdManifiestoCarga = manifiesto.MANIFEST_HEADER_ID, CumplimientosDeEntregas = CumplimientoDeEntregas });

            UiMapaTracking.Overlays.Clear();
            MostrarInformacionDelDocumento();
            var layerBing = UiMapaTracking.Layers[CapaMapaTracking.Bing.ToString()];
            UiMapaTracking.Layers.Clear();
            UiMapaTracking.Layers.Add(layerBing);

            UiMapaTrackingMapaYFoto.Overlays.Clear();
            MostrarInformacionDelDocumentoMapaYFoto();
            var layerBingMap = UiMapaTrackingMapaYFoto.Layers[CapaMapaTracking.Bing.ToString()];
            UiMapaTrackingMapaYFoto.Layers.Clear();
            UiMapaTrackingMapaYFoto.Layers.Add(layerBingMap);

            CargarCapasDeMapa();
            if (TareasCumplimientodeEntregas.Count <= 1) return;
            UiTimerCamion.Enabled = true;
        }

        private void UiTimerCamion_Tick(object sender, EventArgs e)
        {
            try
            {
                if (TareasCumplimientodeEntregas.Count <= 1)
                {
                    UiTimerCamion.Enabled = false;
                    return;
                }

                if (TicksReinicio > 0)
                {
                    TicksReinicio--;
                    return;
                }

                var truckLayer = (VectorItemsLayer)UiMapaTracking.Layers[CapaMapaTracking.Camion.ToString()];
                var camiones = truckLayer.Data as MapItemStorage;
                var camion = (CamionMapa)camiones.Items.FirstOrDefault();
                var totalTareas = TareasCumplimientodeEntregas.Count;

                var tareaActual = camion.TareaActual;

                var nuevaTarea = totalTareas == tareaActual.SEQUENCE ? TareasCumplimientodeEntregas.FirstOrDefault() : TareasCumplimientodeEntregas[tareaActual.SEQUENCE];
                var nuevoDestino = totalTareas == nuevaTarea.SEQUENCE ? TareasCumplimientodeEntregas[1] : TareasCumplimientodeEntregas[nuevaTarea.SEQUENCE];

                CoordPoint nuevaUbicacion;

                camion.DistanciaRecorrida += camion.Distancia / 20;
                if (camion.DistanciaRecorrida >= camion.Distancia)
                {
                    if (nuevaTarea.SEQUENCE == totalTareas)
                    {
                        TicksReinicio = 5;
                        nuevaTarea = TareasCumplimientodeEntregas.FirstOrDefault();
                    }

                    if (!string.IsNullOrEmpty(nuevaTarea.GPS))
                    {
                        nuevaUbicacion = nuevaTarea.Location;
                        camion.TareaActual = nuevaTarea;

                        camion.DistanciaRecorrida = 0;
                        var p1 = new GeoCoordinate(nuevaTarea.Latitude, nuevaTarea.Longitude);
                        var p2 = new GeoCoordinate(nuevoDestino.Latitude, nuevoDestino.Longitude);
                        var distance = p1.GetDistanceTo(p2);

                        camion.Distancia = distance;
                        camion.Location = nuevaUbicacion;
                    }
                }
                else
                {
                    var ratio = camion.DistanciaRecorrida / camion.Distancia;
                    if (double.IsNaN(ratio)) return;
                    nuevaUbicacion = new GeoPoint(tareaActual.Latitude + ratio * (nuevaTarea.Latitude - tareaActual.Latitude), tareaActual.Longitude + ratio * (nuevaTarea.Longitude - tareaActual.Longitude));
                    camion.Location = nuevaUbicacion;
                }
                
                camiones.Items.Clear();
                camiones.Items.Add(camion);

                truckLayer.Data = camiones;

                AnimacionDeCammionMapaYFoto();

            }
            catch (Exception exception)
            {
                UiTimerCamion.Enabled = false;
                InteraccionConUsuarioServicio.MensajeErrorDialogo(exception.Message);
            }
        }
        #endregion

        private void UiNavigationPanePrincipal_StateChanged(object sender, DevExpress.XtraBars.Navigation.StateChangedEventArgs e)
        {
            ExpandirNavegacionPaginas(sender);
        }

        private void UiGridVistaCumpimientoDeEntrega_DoubleClick(object sender, EventArgs e)
        {
            UsuarioDeseaCargarFotos();
        }

        private void UsuarioDeseaCargarFotos()
        {
            try
            {
                if (UiVistaCumplimientoDeEntrega.GetFocusedRow().GetType() != typeof(CumplimientoDeEntrega)) return;
                var fila = (CumplimientoDeEntrega)UiVistaCumplimientoDeEntrega.GetFocusedRow();
                CargarFotos(fila.DELIVERY_NOTE_ID);
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje("Erro al obtener el codigo de entrega en el grid: " + ex.Message);
            }
        }

        private void CargarFotos(int deliveryNoteId)
        {
            try
            {
                UiContenedorDeImagenes.Images.Clear();
                UsuarioDeseaObtenerImagenesDeEntrega?.Invoke(null, new CumplimientoDeEntregaArgumento { DeliveryNoteId = deliveryNoteId });

                foreach (var imagen in ImagenesDeEntrega)
                {
                    if (imagen.DELIVERY_IMAGE != null)
                    {
                        imagen.DELIVERY_IMAGE = imagen.DELIVERY_IMAGE.Replace("data:image/jpeg;base64,", "");
                        if (validarImagenBase64(imagen.DELIVERY_IMAGE))
                        {                            
                            ContenedorImagenes(imagen.DELIVERY_IMAGE);
                        }
                    }

                    if (imagen.DELIVERY_IMAGE_2 != null)
                    {
                        imagen.DELIVERY_IMAGE_2 = imagen.DELIVERY_IMAGE_2.Replace("data:image/jpeg;base64,", "");
                        if (validarImagenBase64(imagen.DELIVERY_IMAGE_2))
                        {                            
                            ContenedorImagenes(imagen.DELIVERY_IMAGE_2);
                        }
                    }

                    if (imagen.DELIVERY_IMAGE_3 != null)
                    {
                        imagen.DELIVERY_IMAGE_3 = imagen.DELIVERY_IMAGE_3.Replace("data:image/jpeg;base64,", "");
                        if (validarImagenBase64(imagen.DELIVERY_IMAGE_3))
                        {                            
                            ContenedorImagenes(imagen.DELIVERY_IMAGE_3);
                        }
                    }

                    if (imagen.DELIVERY_IMAGE_4 != null)
                    {
                        imagen.DELIVERY_IMAGE_4 = imagen.DELIVERY_IMAGE_4.Replace("data:image/jpeg;base64,", "");
                        if (validarImagenBase64(imagen.DELIVERY_IMAGE_4))
                        {                            
                            ContenedorImagenes(imagen.DELIVERY_IMAGE_4);
                        }                    
                    }

                    if (imagen.DELIVERY_SIGNATURE != null)
                    {
                        imagen.DELIVERY_SIGNATURE = imagen.DELIVERY_SIGNATURE.Replace("data:image/png;base64,", "");
                        if (validarImagenBase64(imagen.DELIVERY_SIGNATURE))
                        {                            
                            ContenedorImagenes(imagen.DELIVERY_SIGNATURE);
                        }
                    }
                    
                }
                UiTabPrincipal.SelectedTabPage = UiTabPaginaMapaYFoto;
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje("Error al cargar las fotos: " + ex.Message);
            }
        }

        private Boolean validarImagenBase64(string base64)
        {
            base64 = base64.Trim();
            return (base64.Length % 4 == 0) && Regex.IsMatch(base64, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
        }

        private void ContenedorImagenes(string base64)
        {
            var bytes = Convert.FromBase64String(base64);
            Image image;
            using(var ms = new MemoryStream(bytes))
            {
                image = Image.FromStream(ms);
            }
            UiContenedorDeImagenes.Images.Add(image);
        }

        private void UiMapaTrackingMapaYFoto_SelectionChanged(object sender, MapSelectionChangedEventArgs e)
        {
            var objetoSeleccionado = e.Selection.FirstOrDefault();
            LimpiarMapa();
            if (objetoSeleccionado == null) return;
            var type = objetoSeleccionado.GetType();
            if (type != typeof(TareaDeCumplimientoDeEntrega)) return;
            var task = (TareaDeCumplimientoDeEntrega)objetoSeleccionado;

            MostrarInformacionDeLaTareaMapa(task);
        }

        private void MostrarInformacionDeLaTareaMapa(TareaDeCumplimientoDeEntrega tarea)
        {
            var overlayWithText = new MapOverlay
            {
                Alignment = ContentAlignment.TopRight,
                JoiningOrientation = Orientation.Vertical,
                Margin = new Padding(10),
                Padding = new Padding(7),
            };

            overlayWithText.Items.Add(new MapOverlayTextItem
            {
                Text = "Codigo de Cliente: " + tarea.CLIENT_CODE + "\n" +
                       "Nombre del Cliente: " + tarea.CLIENT_NAME + "\n" +
                       "Tarea de Entrega: " + tarea.TASK_ID + "\n" +
                       "Estado de la Entrega: " + tarea.PICKING_DEMAND_STATUS.ToString() + "\n" +
                       "Demora: " + tarea.Demora + "\n" +
                       "Cantidad de documentos: " + tarea.DOCUMENT_QTY + ""
                       + (tarea.PICKING_DEMAND_STATUS == EstadoTareaDeEntrega.Parcial
                            || tarea.PICKING_DEMAND_STATUS == EstadoTareaDeEntrega.Cancelada ?
                       "\nRazón: " + tarea.REASON : string.Empty)

            });

            UiMapaTrackingMapaYFoto.Overlays.Add(overlayWithText);
            CargarFotos(tarea.DELIVERY_NOTE_ID);
        }
        private void MostrarInformacionDelDocumentoMapaYFoto()
        {
            var tarea = TareasCumplimientodeEntregas.FirstOrDefault();
            if (tarea == null) return;

            var overlayWithText = new MapOverlay
            {
                Alignment = ContentAlignment.BottomCenter,
                JoiningOrientation = Orientation.Horizontal,
                Margin = new Padding(10),
                Padding = new Padding(7)
            };

            overlayWithText.Items.Add(new MapOverlayTextItem()
            {
                TextAlignment = ContentAlignment.MiddleCenter,
                Text = "Piloto - " + tarea.PILOT_NAME +
                        "\nFecha de Inicio - " + tarea.ACCEPTED_STAMP +
                        "\nPorcentaje de Cumplimiento - " + tarea.PERCENTAGE
            });

            UiMapaTrackingMapaYFoto.Overlays.Add(overlayWithText);
        }

        private void AnimacionDeCammionMapaYFoto()
        {
            try
            {
                var truckLayer = (VectorItemsLayer)UiMapaTrackingMapaYFoto.Layers[CapaMapaTracking.Camion.ToString()];
                var camiones = truckLayer.Data as MapItemStorage;
                var camion = (CamionMapa)camiones.Items.FirstOrDefault();
                var totalTareas = TareasCumplimientodeEntregas.Count;

                var tareaActual = camion.TareaActual;

                var nuevaTarea = totalTareas == tareaActual.SEQUENCE ? TareasCumplimientodeEntregas.FirstOrDefault() : TareasCumplimientodeEntregas[tareaActual.SEQUENCE];
                var nuevoDestino = totalTareas == nuevaTarea.SEQUENCE ? TareasCumplimientodeEntregas[1] : TareasCumplimientodeEntregas[nuevaTarea.SEQUENCE];

                CoordPoint nuevaUbicacion;

                camion.DistanciaRecorrida += camion.Distancia / 20;
                if (camion.DistanciaRecorrida >= camion.Distancia)
                {
                    if (nuevaTarea.SEQUENCE == totalTareas)
                    {
                        TicksReinicio = 5;
                        nuevaTarea = TareasCumplimientodeEntregas.FirstOrDefault();
                    }

                    nuevaUbicacion = nuevaTarea.Location;
                    camion.TareaActual = nuevaTarea;

                    camion.DistanciaRecorrida = 0;
                    var p1 = new GeoCoordinate(nuevaTarea.Latitude, nuevaTarea.Longitude);
                    var p2 = new GeoCoordinate(nuevoDestino.Latitude, nuevoDestino.Longitude);
                    var distance = p1.GetDistanceTo(p2);

                    camion.Distancia = distance;
                }
                else
                {
                    var ratio = camion.DistanciaRecorrida / camion.Distancia;
                    if (double.IsNaN(ratio)) return;
                    nuevaUbicacion = new GeoPoint(tareaActual.Latitude + ratio * (nuevaTarea.Latitude - tareaActual.Latitude), tareaActual.Longitude + ratio * (nuevaTarea.Longitude - tareaActual.Longitude));
                }

                camion.Location = nuevaUbicacion;
                camiones.Items.Clear();
                camiones.Items.Add(camion);

                truckLayer.Data = camiones;
            }
            catch (Exception ex)
            {
                InteraccionConUsuarioServicio.Mensaje("Error en la animacion del camion: " + ex.Message);
            }
        }

        private void UsuarioSeleccionoPing(object sender, MapSelectionChangedEventArgs e)
        {
            var objetoSeleccionado = e.Selection.FirstOrDefault();
            LimpiarMapa();
            if (objetoSeleccionado == null)
            {
                DoubleClikMapaTraking = false;
                return;
            }
            
            var type = objetoSeleccionado.GetType();
            if (type != typeof(TareaDeCumplimientoDeEntrega)) return;
            var task = (TareaDeCumplimientoDeEntrega)objetoSeleccionado;

            MostrarInformacionDeLaTarea(task);
        }

        private void UiMapaTracking_DoubleClick(object sender, EventArgs e)
        {
            DoubleClikMapaTraking = true;
        }

    }
}