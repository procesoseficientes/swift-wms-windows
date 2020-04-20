using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MobilityScm.Louncher
{
    public static class Louncher
    {
        public static Form FormularioPrincipal { get; set; }
        public static double factorX { get; set; }
        public static double factorY { get; set; }

        public static Stack<UserControl> pila { get; set; }
        public static UserControl ControlActual { get; set; }
        public static void ShowPane(this UserControl userControl)
        {
            if (pila == null)
            {
                pila = new Stack<UserControl>();
            }

            if (FormularioPrincipal == null)
            {
                throw new Exception("Debe inicializar el formulario.");
            }

            FormularioPrincipal.SuspendLayout();
            var u = userControl as IControl;

            foreach (UserControl item in FormularioPrincipal.Controls)
            {
                if (item.Visible)
                {
                    if (pila == null)
                    {
                        pila = new Stack<UserControl>();
                    }
                    pila.Push(item);
                    item.Visible = false;                    
                }
            }

            if (ControlActual != null)
            {
                var actual = ControlActual as IControl;
                if (actual != null) actual.UnLoad();
            }

            if (u != null)
            {
                if (u.IsNew)
                {
                    FormularioPrincipal.Controls.Add(userControl);
                    ResizePanel(userControl);
                    u.IsNew = false;
                }
                u.Load(); 
                userControl.Visible = true;
                userControl.Focus();
                userControl.BringToFront();
                ControlActual = userControl;
            }
            else
            {
                throw new Exception("Debe implementar la interfaz IControl");
            }
            FormularioPrincipal.ResumeLayout();
        }

        public static void Back(this UserControl userControl)
        {
            if (FormularioPrincipal == null)
            {
                throw new Exception("Debe inicializar el formulario.");
            }
            userControl.Visible = false;
            var actual = userControl as IControl;
            if (actual != null) actual.UnLoad();

            var u = pila.Pop();
            u.Visible = true;
            u.Focus();
            var nuevo = u as IControl;
            if (nuevo != null) nuevo.Load();
            ControlActual = u;

        }

        public static void Back(this UserControl userControl, int posiciones)
        {
            if (FormularioPrincipal == null)
            {
                throw new Exception("Debe inicializar el formulario.");
            }
            userControl.Visible = false;
            var actual = userControl as IControl;
            if (actual != null) actual.UnLoad();

            var u =  new UserControl();
            for (int i = 0; i < posiciones; i++)
            {
                u = pila.Pop();
            }
            u.Visible = true;
            u.Focus();
            var nuevo = u as IControl;
            if (nuevo != null) nuevo.Load();
            ControlActual = u;

        }


        private static void ResizePanel(Control panel)
        {
            panel.Height = Convert.ToInt32(panel.Height * factorX);
            panel.Top = Convert.ToInt32(panel.Location.Y * factorY);
            try
            {
                // panel.Font = New Font(panel.Name, panel.Font.Size * factor, panel.Font.Style)
            }
            catch
            {
            }

            for (int index = 0; index <= panel.Controls.Count - 1; index++)
            {
                ResizePanel(panel.Controls[index]);
            }
        }

    }

    public interface IControl
    {
        bool IsNew { get; set; }

        void UnLoad();

        void Load();
    }


}
