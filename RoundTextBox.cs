using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeProductosApp.FormElements
{
    public class RoundTextBox : TextBox
    {
        private int borderRadius = 10; // Radio de redondeo predeterminado
        private Color borderColor = Color.Black; // Color de borde predeterminado
        private Color backgroundColor = Color.White; // Color de fondo predeterminado
        private int borderWidth = 2; // Ancho de borde predeterminado

        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                if (value >= 0)
                {
                    borderRadius = value;
                    Refresh();
                }
            }
        }

        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Refresh();
            }
        }

        public Color BackgroundColor
        {
            get { return backgroundColor; }
            set
            {
                backgroundColor = value;
                Refresh();
            }
        }

        public int BorderWidth
        {
            get { return borderWidth; }
            set
            {
                if (value >= 0)
                {
                    borderWidth = value;
                    Refresh();
                }
            }
        }

        public RoundTextBox()
        {
            this.BorderStyle = BorderStyle.None; // Oculta el borde predeterminado
            this.AutoSize = false; // Evita que el TextBox cambie de tamaño automáticamente
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Dibuja el fondo del TextBox con el color personalizado
            e.Graphics.FillRectangle(new SolidBrush(backgroundColor), ClientRectangle);

            // Dibuja el borde redondeado con el color y el ancho personalizados
            using (var pen = new Pen(borderColor, borderWidth))
            {
                // Asegura que el borde sea visible incluso con un ancho pequeño
                pen.Alignment = PenAlignment.Inset;

                // Calcula el rectángulo interior para el borde
                Rectangle borderRect = new Rectangle(0, 0, Width - 1, Height - 1);

                // Dibuja el borde redondeado utilizando la función DrawRectangle
                for (int i = 0; i < borderWidth; i++)
                {
                    e.Graphics.DrawRectangle(pen, borderRect);
                    borderRect.Inflate(-1, -1);
                }
            }
        }
    }
}
