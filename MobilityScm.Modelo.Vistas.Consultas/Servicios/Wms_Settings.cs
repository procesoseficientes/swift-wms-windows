using MobilityScm.Modelo.Vistas;
namespace MobilityScm.Modelo.Wms_Settings {
    
    
    public partial class WMS_Settings 
    {
        public WMS_Settings(bool UseDinamicHost)
        {
            this.Url = VariablesDeAmbienteParaConsulta.WsHost + "/Catalogues/WMS_Settings" +
                ".asmx";
        }
    }
}
