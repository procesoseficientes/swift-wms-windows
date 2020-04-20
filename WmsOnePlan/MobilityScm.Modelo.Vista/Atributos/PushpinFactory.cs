using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using DevExpress.XtraMap;
using MobilityScm.Modelo.Entidades;

namespace MobilityScm.Modelo.Atributos
{
    public class PushpinFactory : IMapItemFactory
    {
        Image baseImage;
        Color baseColor;
        public PushpinFactory(Image baseImage, Color baseColor)
        {
            this.baseImage = baseImage;
            this.baseColor = baseColor;
        }
        #region IMapItemFactory Members

        public MapItem CreateMapItem(MapItemType type, object obj)
        {
            var tarea = (TareaDeCumplimientoDeEntrega)obj;
            var newColor = (Color)tarea.Color;
            var image = (Image)baseImage.Clone();
            var imageAttributes = GetImageAttributes(newColor);

            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);
            Graphics g = Graphics.FromImage(image);
            g.DrawImage(image, rect, 0, 0, rect.Width, rect.Height, GraphicsUnit.Pixel, imageAttributes);


            MapPushpin pushpin = new MapPushpin();
            pushpin.Image = image;
            pushpin.RenderOrigin = new MapPoint(0.5, 0.8);
            pushpin.TextOrigin = new Point(22, 14);
            return pushpin;

        }

        private ImageAttributes GetImageAttributes(Color newColor)
        {
            ImageAttributes imageAttributes = new ImageAttributes();
            float[][] colorMatrixElements = {
               new float[] {(float)newColor.R / 255f + 0.5f,  (float)newColor.G / 255f + 0.5f,  (float)newColor.B / 255f + 0.5f,  0, 0},        // red scaling factor
               new float[] {0.5f, 0.5f,  0.5f,  0, 0},        // green scaling factor
               new float[] {0.5f,  0.5f,  0.5f,  0, 0},        // blue scaling factor
               new float[] {0,  0,  0,  1, 0},        // alpha scaling factor
               new float[] {-0.5f,  -0.5f,  -0.5f,  0, 1}};    // three translations

            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

            imageAttributes.SetColorMatrix(
               colorMatrix,
               ColorMatrixFlag.Default,
               ColorAdjustType.Bitmap);
            return imageAttributes;
        }

        #endregion
    }

}
