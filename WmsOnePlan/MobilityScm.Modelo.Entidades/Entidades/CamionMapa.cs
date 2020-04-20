using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using DevExpress.XtraMap;

namespace MobilityScm.Modelo.Entidades
{
    public class CamionMapa : MapCustomElement
    {
        public CamionMapa()
        {
            var data = Convert.FromBase64String(Modelo.Configuracion.Configuracion.ImagenCamion);

            using (var stream = new MemoryStream(data, 0, data.Length))
            {
                var image = Image.FromStream(stream);
                Image = image;
            }
        }

        public TareaDeCumplimientoDeEntrega TareaActual { get; set; }
        public double DistanciaRecorrida { get; set; }
        public double Distancia { get; set; }
    }
}
