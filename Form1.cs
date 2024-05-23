using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace particles
{
    public partial class Form1 : Form
    {
        List<Particle> particles = new List<Particle>();

        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter;

        private int MousePositionX = 0;
        private int MousePositionY = 0;

        
        private CollisionCircle point1;

        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            this.emitter = new Emitter // создаю эмиттер и привязываю его к полю emitter
            {
                Direction = 0,
                Spreading = 1,
                SpeedMin = 5,
                SpeedMax = 10,
                ColorFrom = Color.Gold,
                ColorTo = Color.FromArgb(0, Color.Red),
                ParticlesPerTick = 10,
                X = picDisplay.Width / 4,
                Y = picDisplay.Height / 4,
            };

            emitters.Add(this.emitter);
            point1 = new CollisionCircle { X = picDisplay.Width / 2, Y = picDisplay.Height / 4 * 3 };
            emitter.impactPoints.Add(point1);
     


            lblDirection.Text = $"{tbDirection.Value}°";
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState(); // тут теперь обновляем эмиттер

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black);
                emitter.Render(g); // а тут теперь рендерим через эмиттер
            }

            picDisplay.Invalidate();
        }



        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            point1.X = e.X;
            point1.Y = e.Y;
        }

        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            emitter.Direction = tbDirection.Value;
            lblDirection.Text = $"{tbDirection.Value}°";
        }

        private void tbGraviton_Scroll(object sender, EventArgs e)
        {
            
        }

        private void tbGraviton2_Scroll(object sender, EventArgs e)
        {
            
        }
    }
}
