using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace GestorDeProductosApp.FormElements
{
    public class CircularButton : Button
    {
        private int borderWidth = 2; // Valor predeterminado para el ancho del borde
        private Color borderColor = Color.Black; // Valor predeterminado para el color del borde

        public int BorderWidth
        {
            get { return borderWidth; }
            set
            {
                // Asegurarse de que el ancho del borde sea mayor o igual a cero
                if (value >= 0)
                {
                    borderWidth = value;
                    Refresh(); // Redibujar el botón cuando cambia el ancho del borde
                }
            }
        }

        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Refresh(); // Redibujar el botón cuando cambia el color del borde
            }
        }

        public CircularButton()
        {
            // Establece el tamaño predeterminado para el botón redondo
            this.Size = new Size(50, 50);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            // Dibuja el botón redondo con el tamaño y color de borde personalizados
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using (var path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                path.AddEllipse(rect);
                this.Region = new Region(path);

                using (var brush = new SolidBrush(this.BackColor))
                {
                    g.FillEllipse(brush, rect);
                }

                using (var pen = new Pen(borderColor, borderWidth))
                {
                    g.DrawEllipse(pen, rect);
                }
            }
        }
    }
}