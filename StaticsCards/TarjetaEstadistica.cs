using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace StaticsCards // Ajusta al nombre de tu proyecto
{
    public partial class TarjetaEstadistica : UserControl
    {

        // 1. Definimos el ENUM para que aparezca en el panel de propiedades
        public enum ThemeMode { Light, Dark }
        private ThemeMode currentTheme = ThemeMode.Light;

        //Para los Colores
        // 2. Colores predefinidos para el Modo Oscuro
        private Color colorFondoDark = Color.FromArgb(45, 45, 48);
        private Color colorTextoPrincipalDark = Color.White;
        private Color colorTextoSecundarioDark = Color.FromArgb(180, 180, 180);
        private Color colorHoverDark = Color.FromArgb(60, 60, 65);
        private Color colorBordeDark = Color.FromArgb(70, 70, 70);

        // 3. La propiedad que cambiarás desde Visual Studio
        [Category("Diseño Personalizado")]
        public ThemeMode ModoTema
        {
            get => currentTheme;
            set
            {
                currentTheme = value;
                AplicarTema(); // Este método lo crearemos en el Paso 2
                this.Invalidate(); // Redibuja el control
            }
        }

        // Propiedades que aparecerán en el panel de "Propiedades" de Visual Studio
        public string Titulo
        {
            get => lblTitulo.Text;
            set => lblTitulo.Text = value.ToUpper();
        }

        public string Valor
        {
            get => lblValor.Text;
            set
            {
                // Si el valor recibido es un número, iniciamos la animación
                if (double.TryParse(value, out double resultado))
                {
                    valorObjetivo = resultado;
                    animTimer.Start();
                }
                else
                {
                    lblValor.Text = value; // Si es texto (ej. "Cargando..."), lo ponemos directo
                }
            }
        }

        /*
        public string Valor
        {
            get => lblValor.Text;
            set => lblValor.Text = value;
        }
        */

        public string Subtitulo
        {
            get => lblSubtitulo.Text;
            set => lblSubtitulo.Text = value;
        }

        public Color ColorTendencia
        {
            get => lblSubtitulo.ForeColor;
            set => lblSubtitulo.ForeColor = value;
        }

        private Color colorNormal = Color.White;
        private Color colorHover = Color.FromArgb(245, 245, 245); // Un gris muy clarito

        [Category("Diseño Personalizado")]
        public Color ColorHover { get => colorHover; set => colorHover = value; }

        private int borderRadius = 20;
        private Color borderColor = Color.FromArgb(224, 224, 224);

        //Variables para animación de conteo
        private Timer animTimer;
        private double valorActual = 0;
        private double valorObjetivo = 0;
        private double velocidadAnimacion = 0.05; // Ajusta este valor (0.01 a 0.2) para más o menos velocidad


        [Category("Diseño Personalizado")]
        public int BorderRadius
        {
            get => borderRadius;
            set { borderRadius = value; this.Invalidate(); } // Invalidate fuerza el redibujado
        }

        [Category("Diseño Personalizado")]
        public Color BorderColor
        {
            get => borderColor;
            set { borderColor = value; this.Invalidate(); }
        }

        private bool conSombra = true;
        private int shadowSize = 5;
        private int shadowOpacity = 40; // 0 a 255

        [Category("Diseño Personalizado")]
        public int ShadowSize
        {
            get => shadowSize;
            set
            {
                // Aplicamos el límite: si es mayor a 20, se queda en 20. 
                // También evitamos valores negativos.
                if (value > 20) shadowSize = 20;
                else if (value < 0) shadowSize = 0;
                else shadowSize = value;

                this.Invalidate();
            }
        }

        [Category("Diseño Personalizado")]
        public int ShadowOpacity
        {
            get => shadowOpacity;
            set
            {
                // La opacidad debe estar entre 0 (invisible) y 255 (negro puro)
                if (value > 255) shadowOpacity = 255;
                else if (value < 0) shadowOpacity = 0;
                else shadowOpacity = value;

                this.Invalidate();
            }
        }


        //Método constructor
        public TarjetaEstadistica()
        {
            InitializeComponent();
            ConfigurarEstiloInicial();

            this.DoubleBuffered = true;

            //Inicializar el temporizador de animación
            animTimer = new Timer();
            animTimer.Interval = 15; // ~60 FPS
            animTimer.Tick += AnimTimer_Tick;

            this.BackColor = Color.White;

            //tamaño mínimo
            this.MinimumSize = new Size(250, 135);

            // ESTO ES LO NUEVO: 
            // Hace que los labels ignoren el mouse y se lo pasen a la tarjeta (el padre)
            lblTitulo.MouseEnter += (s, e) => OnMouseEnter(e);
            lblValor.MouseEnter += (s, e) => OnMouseEnter(e);
            lblSubtitulo.MouseEnter += (s, e) => OnMouseEnter(e);

            // Fuerza la transparencia en los controles internos
            lblTitulo.BackColor = Color.Transparent;
            lblValor.BackColor = Color.Transparent;
            lblSubtitulo.BackColor = Color.Transparent;
            picIcono.BackColor = Color.Transparent; // <-- Esto quitará el recuadro blanco

            lblTitulo.MouseLeave += (s, e) => OnMouseLeave(e);
            lblValor.MouseLeave += (s, e) => OnMouseLeave(e);
            lblSubtitulo.MouseLeave += (s, e) => OnMouseLeave(e);

            picIcono.MouseEnter += (s, e) => OnMouseEnter(e);
            picIcono.MouseLeave += (s, e) => OnMouseLeave(e);

            AplicarTema();
        }

        private void AnimTimer_Tick(object sender, EventArgs e)
        {
            if (Math.Abs(valorObjetivo - valorActual) > 0.1)
            {
                // Efecto de suavizado (Lerp)
                valorActual += (valorObjetivo - valorActual) * velocidadAnimacion;
                lblValor.Text = Math.Round(valorActual).ToString("N0"); // "N0" agrega puntos de mil
            }
            else
            {
                valorActual = valorObjetivo;
                lblValor.Text = valorObjetivo.ToString("N0");
                animTimer.Stop(); // Detenemos el reloj cuando llegamos a la meta
            }
        }

        private void AplicarTema()
        {
            if (currentTheme == ThemeMode.Dark)
            {
                this.BackColor = colorFondoDark;
                colorNormal = colorFondoDark;
                colorHover = colorHoverDark;
                borderColor = colorBordeDark;

                lblTitulo.ForeColor = colorTextoSecundarioDark;
                lblValor.ForeColor = colorTextoPrincipalDark;
            }
            else
            {
                this.BackColor = Color.White;
                colorNormal = Color.White;
                colorHover = Color.FromArgb(245, 245, 245);
                borderColor = Color.FromArgb(224, 224, 224);

                lblTitulo.ForeColor = Color.Gray; // O el color que prefieras para Light
                lblValor.ForeColor = Color.Black;
            }
        }

        // Sobrescribimos los eventos del Mouse
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.BackColor = colorHover; // Cambia al color de resalte
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.BackColor = colorNormal; // Vuelve al color original
        }

        private void ConfigurarEstiloInicial()
        {
            this.BackColor = Color.White;
            this.Size = new Size(250, 120);
            this.Padding = new Padding(15);
            this.Margin = new Padding(10);

            // Simular un borde fino gris
            this.BorderStyle = BorderStyle.None;
        }

        // Método para actualizar datos rápidamente
        public void SetData(string titulo, string valor, string sub, Color color)
        {
            Titulo = titulo;
            Valor = valor;
            Subtitulo = sub;
            ColorTendencia = color;
        }

        private void lblValor_Click(object sender, EventArgs e) => this.OnClick(e);
        private void lblTitulo_Click(object sender, EventArgs e) => this.OnClick(e);
        private void lblSubtitulo_Click(object sender, EventArgs e) => this.OnClick(e);

        /*
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Usamos el color de fondo del padre para "limpiar" las esquinas
            if (this.Parent != null)
            {
                using (SolidBrush brush = new SolidBrush(this.Parent.BackColor))
                {
                    g.FillRectangle(brush, this.ClientRectangle);
                }
            }

            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            using (System.Drawing.Drawing2D.GraphicsPath path = GetRoundPath(rect, borderRadius))
            {
                // Rellenamos el fondo de la tarjeta con blanco (o el color que elijas)
                using (SolidBrush brush = new SolidBrush(this.BackColor))
                {
                    g.FillPath(brush, path);
                }

                // Dibujamos el borde con un color gris muy suave
                using (Pen pen = new Pen(borderColor, 1.5f))
                {
                    g.DrawPath(pen, path);
                }
            }
        }
        */

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // 1. Limpiar el fondo con el color del padre para evitar basura visual en las esquinas
            if (this.Parent != null)
            {
                using (SolidBrush brush = new SolidBrush(this.Parent.BackColor))
                {
                    g.FillRectangle(brush, this.ClientRectangle);
                }
            }

            // 2. Dibujar la sombra degradada (si está activa)
            if (conSombra)
            {
                // Si es modo oscuro, bajamos la intensidad de la sombra a la mitad
                int baseOpacity = (currentTheme == ThemeMode.Dark) ? shadowOpacity / 2 : shadowOpacity;

                for (int i = 0; i <= shadowSize; i++)
                {
                    int alpha = shadowOpacity - (i * (shadowOpacity / shadowSize));
                    if (alpha < 0) alpha = 0;

                    // El rectángulo de la sombra se va encogiendo para crear el efecto blur
                    Rectangle shadowRect = new Rectangle(i, i, (this.Width - 1) - (i * 2), (this.Height - 1) - (i * 2));

                    using (System.Drawing.Drawing2D.GraphicsPath shadowPath = GetRoundPath(shadowRect, borderRadius))
                    {
                        using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(alpha, Color.Black)))
                        {
                            g.FillPath(shadowBrush, shadowPath);
                        }
                    }
                }
            }

            // 3. Dibujar la Tarjeta (El cuerpo blanco)
            // Dejamos un pequeño margen (offset) para que la sombra respire y no se corte en los bordes
            int offset = shadowSize;
            Rectangle rectCard = new Rectangle(offset / 2, offset / 2, (this.Width - 1) - offset, (this.Height - 1) - offset);

            using (System.Drawing.Drawing2D.GraphicsPath path = GetRoundPath(rectCard, borderRadius))
            {
                // Fondo blanco de la tarjeta
                using (SolidBrush brush = new SolidBrush(this.BackColor))
                {
                    g.FillPath(brush, path);
                }

                // Borde sutil
                using (Pen pen = new Pen(borderColor, 1.5f))
                {
                    g.DrawPath(pen, path);
                }
            }
        }

        private System.Drawing.Drawing2D.GraphicsPath GetRoundPath(Rectangle rect, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            float r = radius;
            path.AddArc(rect.X, rect.Y, r, r, 180, 90);
            path.AddArc(rect.Right - r, rect.Y, r, r, 270, 90);
            path.AddArc(rect.Right - r, rect.Bottom - r, r, r, 0, 90);
            path.AddArc(rect.X, rect.Bottom - r, r, r, 90, 90);
            path.CloseFigure();
            return path;
        }

        [Category("Contenido")]
        public Image Icono
        {
            get => picIcono.Image; // Asegúrate de que tu PictureBox se llame picIcono
            set => picIcono.Image = value;
        }
    }
}
