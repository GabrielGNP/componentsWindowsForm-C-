using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace GestorDeProductosApp.FormElements
{
    public class GradientPanel : Panel
    {
        private int borderWidth = 2; // Tamaño de borde predeterminado
        private Color borderColor = Color.Black; // Color de borde predeterminado
        private Color gradientColorStart = Color.White; // Color de inicio del degradado predeterminado
        private Color gradientColorEnd = Color.Gray; // Color de final del degradado predeterminado
        private LinearGradientMode gradientMode = LinearGradientMode.Vertical; // Modo de degradado predeterminado

        public int BorderWidth
        {
            get { return borderWidth; }
            set
            {
                if (value >= 0)
                {
                    borderWidth = value;
                    Invalidate(); // Vuelve a dibujar el panel cuando cambia el tamaño del borde
                }
            }
        }

        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Invalidate(); // Vuelve a dibujar el panel cuando cambia el color del borde
            }
        }

        public Color GradientColorStart
        {
            get { return gradientColorStart; }
            set
            {
                gradientColorStart = value;
                Invalidate(); // Vuelve a dibujar el panel cuando cambia el color de inicio del degradado
            }
        }

        public Color GradientColorEnd
        {
            get { return gradientColorEnd; }
            set
            {
                gradientColorEnd = value;
                Invalidate(); // Vuelve a dibujar el panel cuando cambia el color de final del degradado
            }
        }

        public LinearGradientMode GradientMode
        {
            get { return gradientMode; }
            set
            {
                gradientMode = value;
                Invalidate(); // Vuelve a dibujar el panel cuando cambia el modo de degradado
            }
        }

        public GradientPanel()
        {
            // Asegura que el panel se redibuje cuando cambian las propiedades
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Dibuja el panel con las características especificadas
            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (var brush = new LinearGradientBrush(rect, gradientColorStart, gradientColorEnd, gradientMode))
            {
                e.Graphics.FillRectangle(brush, rect);
            }

            using (var pen = new Pen(borderColor, borderWidth))
            {
                e.Graphics.DrawRectangle(pen, rect);
            }
        }
    }
}
