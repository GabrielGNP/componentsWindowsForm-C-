
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace GestorDeProductosApp.FormElements
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class RoundButton : Button
    {
        private int borderRadius = 10;
        private int borderWidth = 2;
        private Color borderColor = Color.Black;
        private Color gradientColorStart = Color.White;
        private Color gradientColorEnd = Color.Gray;
        private LinearGradientMode gradientMode = LinearGradientMode.Vertical;





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

        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                Refresh();
            }
        }

        public Color GradientColorStart
        {
            get { return gradientColorStart; }
            set
            {
                gradientColorStart = value;
                Refresh();
            }
        }

        public Color GradientColorEnd
        {
            get { return gradientColorEnd; }
            set
            {
                gradientColorEnd = value;
                Refresh();
            }
        }

        public LinearGradientMode GradientMode
        {
            get { return gradientMode; }
            set
            {
                gradientMode = value;
                Refresh();
            }
        }

        public RoundButton()
        {
            this.MinimumSize = new Size(0, 0);
            this.FlatStyle = FlatStyle.Flat;
            this.Paint += new PaintEventHandler(RoundButton_Paint);
        }

        private void RoundButton_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (var path = new GraphicsPath())
            {
                path.AddArc(rect.X, rect.Y, borderRadius, borderRadius, 180, 90);
                path.AddArc(rect.Width - borderRadius, rect.Y, borderRadius, borderRadius, 270, 90);
                path.AddArc(rect.Width - borderRadius, rect.Height - borderRadius, borderRadius, borderRadius, 0, 90);
                path.AddArc(rect.X, rect.Height - borderRadius, borderRadius, borderRadius, 90, 90);
                path.CloseAllFigures();

                this.Region = new Region(path);

                // Configurar el color de fondo según si el puntero está sobre el botón
                Color gradientStart = gradientColorStart;
                Color gradientEnd = gradientColorEnd;


                using (var brush = new LinearGradientBrush(rect, gradientStart, gradientEnd, gradientMode))
                {
                    g.FillPath(brush, path);
                }

                using (var pen = new Pen(borderColor, borderWidth))
                {
                    g.DrawPath(pen, path);
                }

                TextRenderer.DrawText(g, this.Text, this.Font, this.ClientRectangle, this.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }
    }
}