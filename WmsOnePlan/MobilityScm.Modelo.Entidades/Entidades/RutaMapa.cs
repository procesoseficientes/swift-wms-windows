using System.Drawing;
using DevExpress.XtraMap;

namespace MobilityScm.Modelo.Entidades
{
    public sealed class RutaMapa : MapLine
    {
        public RutaMapa(TareaDeCumplimientoDeEntrega tareaDesde, TareaDeCumplimientoDeEntrega tareaHasta)
        {
            TareaDesde = tareaDesde;
            TareaHasta = tareaHasta;

            Stroke = Color.Red;
            StrokeWidth = 4;
            HighlightedStroke = Color.Red;
            HighlightedStrokeWidth = 4;
            SelectedStroke = Color.Red;
            SelectedStrokeWidth = 4;

            Point1 = tareaDesde.Location;
            Point2 = tareaHasta.Location;
        }

        public TareaDeCumplimientoDeEntrega TareaDesde { get; set; }
        public TareaDeCumplimientoDeEntrega TareaHasta { get; set; }
    }
}
