using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1.componentes
{
    public class GradientLabel : Label
    {
        public Color GradientColorStart { get; set; }
        public Color GradientColorEnd { get; set; }
        public Color GradientColorBack { get; set; }

        public GradientLabel()
        {
            // Colores predeterminados o puedes establecerlos según tus preferencias
            GradientColorStart = Color.Blue;
            GradientColorEnd = Color.Red;
            GradientColorBack = Color.White;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Obtén el objeto Graphics del Label
            Graphics g = e.Graphics;

            // Rectángulo donde se dibujará el fondo con degradado
            Rectangle rect = new Rectangle(0, 0, Width, Height);

            // Crea un pincel con degradado lineal
            LinearGradientBrush brush = new LinearGradientBrush(rect, GradientColorBack, GradientColorBack, LinearGradientMode.Horizontal);

            // Rellena el fondo del Label con el pincel de degradado
            g.FillRectangle(brush, rect);

            // Configura el pincel para el texto con degradado
            brush = new LinearGradientBrush(rect, GradientColorStart, GradientColorEnd, LinearGradientMode.Horizontal);

            // Configura la fuente y el formato del texto
            Font font = Font;
            StringFormat stringFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            // Dibuja el texto con el pincel de degradado
            g.DrawString(Text, font, brush, rect, stringFormat);
        }
    }
}
