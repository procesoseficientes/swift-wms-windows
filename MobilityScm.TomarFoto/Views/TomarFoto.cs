using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using MobilityScm.Vertical.Servicios;
using OpenNETCF.Windows.Forms;

namespace MobilityScm.Views
{
    public partial class TomarFoto : UserControl
    {
        private readonly string _dirAplicacion;
        private readonly string _direccionAplicacionCamara;
        private readonly UtileriasServicio _utileriasServicio;
        private string _direccionFotoActual;

        public byte[][] Fotos { get; set; }
        public int NumeroDeFotos { get; set; }
        public byte[] FotoNumeroUno { get { return Fotos[0]; } }
        public byte[] FotoNumeroDos { get { return Fotos[1]; } }
        public byte[] FotoNumeroTres { get { return Fotos[2]; } }
        public string Handheld = "";
        

        public TomarFoto()
        {
            InitializeComponent();
            _dirAplicacion =
                Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            _direccionAplicacionCamara = Path.Combine(_dirAplicacion, "DirectShow.exe");
            _utileriasServicio = new UtileriasServicio();
            Fotos = new byte[3][];
        }


        internal void HacerFotografiaPa400()
        {
            var ccd = new Microsoft.WindowsMobile.Forms.CameraCaptureDialog();

            try
            {
                if (NumeroDeFotos == 3)
                {
                    MessageBox.Show("No puede tomar mas de 3 fotos");
                    return;
                }
                NumeroDeFotos += 1;
                ccd.Resolution = new Size(100, 200);
                ccd.Mode = Microsoft.WindowsMobile.Forms.CameraCaptureMode.Still;
                ccd.InitialDirectory = _dirAplicacion;
                var direccionFotoActual = Path.Combine(_dirAplicacion, "FotoNo" + NumeroDeFotos + ".jpg");
                if (File.Exists(direccionFotoActual))
                {
                    File.Delete(direccionFotoActual);
                }

                string name = "FotoNo" + NumeroDeFotos + ".jpg";
                ccd.DefaultFileName = name;
                var res = ccd.ShowDialog();
                if (res == DialogResult.OK)
                {
                    _imagenVista.Image = new Bitmap(direccionFotoActual);
                    _imagenVista.BringToFront();
                    Fotos[NumeroDeFotos - 1] =
                        _utileriasServicio.ConvertirEnArregloBytes(direccionFotoActual).ObtenerDato<byte[]>();
                }
                else
                {
                    NumeroDeFotos -= 1;

                }
            }
            catch (Exception ex)
            {
                NumeroDeFotos -= 1;
                Fotos[NumeroDeFotos] = null;
                MessageBox.Show("Error al tomar fotografia: " + ex.Message);
            }
            finally
            {
                ccd.Dispose();
            }
        }


        internal void HacerFotografia()
        {
            try
            {
                if (NumeroDeFotos == 3)
                {
                    MessageBox.Show("No puede tomar mas de 3 fotos");
                    return;
                }
                NumeroDeFotos += 1;
                _direccionFotoActual = Path.Combine(_dirAplicacion, "FotoNo" + NumeroDeFotos + ".jpg");
                if (File.Exists(_direccionFotoActual))
                {
                    File.Delete(_direccionFotoActual);
                }



                var proceso = new Process();
                var infoProceso = new ProcessStartInfo
                {
                    FileName = _direccionAplicacionCamara,
                    Arguments = "\"" + _direccionFotoActual + "\""
                };
                proceso.StartInfo = infoProceso;


                var inicio = new ThreadStart(() =>
                {
                    proceso.Start();
                    proceso.WaitForExit();
                    CargarImagen();


                });
                var hilo = new Thread(inicio);
                hilo.Start();
            }
            catch (Exception ex)
            {
                NumeroDeFotos -= 1;
                Fotos[NumeroDeFotos] = null;
                MessageBox.Show("Error al tomar fotografia: " + ex.Message);
            }
        }

        private void CargarImagen()
        {
            Invoke(new MethodInvoker(delegate
            {
                try
                {
                    _imagenVista.Image = new Bitmap(_direccionFotoActual);
                    _imagenVista.BringToFront();
                    Fotos[NumeroDeFotos - 1] =
                        _utileriasServicio.ConvertirEnArregloBytes(_direccionFotoActual).ObtenerDato<byte[]>();
                }
                catch (Exception exception)
                {
                    NumeroDeFotos -= 1;
                    Fotos[NumeroDeFotos] = null;
                    MessageBox.Show("Error al tomar fotografia: " + exception.Message);
                }
            }));
        }

        private void btnTakePic_Click(object sender, EventArgs e)
        {
            switch (Handheld)
            {
                case "PA692":
                    HacerFotografia();
                    break;
                case "PA400":
                    HacerFotografiaPa400();
                    break;
            }
            //Rudy aca tendria que preguntar si llama a HacerFotografiaPa490(); o  a HacerFotografia
            //HacerFotografia();
        }

        private void btnDeletePic_Click(object sender, EventArgs e)
        {
            if (NumeroDeFotos == 0)
                MessageBox.Show("No se ha tomado ninguna fotografia", "MobilityScm", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            else
            {
                if (MessageBox.Show("Desea Eliminar la fotografia actual", "MobilitySCM", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    return;
                try
                {
                    var direccionFotoActual = Path.Combine(_dirAplicacion, "FotoNo" + NumeroDeFotos + ".jpg");

                    File.Delete(direccionFotoActual);
                    NumeroDeFotos -= 1;
                    if (NumeroDeFotos != 0)
                    {
                        direccionFotoActual = Path.Combine(_dirAplicacion, "FotoNo" + NumeroDeFotos + ".jpg");
                        _imagenVista.Image = new Bitmap(direccionFotoActual);
                    }
                    else
                    {
                        _imagenVista.Image = null;
                    }

                    MessageBox.Show("Imagen borrada", "MobilitySCM", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al borrar imagen: " + ex.Message, "MobilityScm", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
        }

        public void LimpiarImgVista()
        {
            _imagenVista.Image = null;
        }

        private void btnPhoto_Click(object sender, EventArgs e)
        {

        }


    }
}
