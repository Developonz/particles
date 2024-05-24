using particles;
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
        Emitter emitter;
        GravityPoint point1;
        AntiGravityPoint point2; 
        BlackHolePoint holo;
        Teleport teleport;
        Random rnd;

        private float centerX;
        private float centerY;

        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            holo = new BlackHolePoint(picDisplay.Height / 5 * 2) {};
            teleport = new Teleport();
            rnd = new Random();

            centerX = picDisplay.Width / 2;
            centerY = picDisplay.Height / 2;

            this.emitter = new Emitter 
            {
                Direction = 0,
                Spreading = 10,
                SpeedMin = 1,
                SpeedMax = 10,
                ColorFrom = Color.Gold,
                ColorTo = Color.FromArgb(0, Color.Red),
                ParticlesPerTick = 20,
                X = picDisplay.Width / 3,
                Y = picDisplay.Height / 3,
            };

            emitter.impactPoints.Add(holo);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState();
            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.White);
                emitter.Render(g); 
            }

            holo.angle += (float)holo.speed;
            if (holo.angle >= 2 * Math.PI)
            {
                holo.angle = 0;
            }
            holo.X = centerX + holo.internalPower * (float)Math.Cos(holo.angle);
            holo.Y = centerY + holo.internalPower * (float)Math.Sin(holo.angle);

            this.Invalidate();

            picDisplay.Invalidate();
        }

        private void picDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            if (rbEmitter.Checked)
            {
                emitter.X = e.X;
                emitter.Y = e.Y;
            }
            else if (rbTeleport.Checked)
            {
                if (e.Button == MouseButtons.Left)
                {
                    teleport.X = e.X;
                    teleport.Y = e.Y;
                    emitter.impactPoints.Remove(teleport);
                    emitter.impactPoints.Add(teleport);
                }
                else
                {
                    teleport.X2 = e.X;
                    teleport.Y2 = e.Y;
                    emitter.impactPoints.Remove(teleport);
                    emitter.impactPoints.Add(teleport);
                }
            }
            else if (rbMagnite.Checked)
            {
                emitter.impactPoints.Remove(point1);
                point1 = new GravityPoint
                {
                    X = e.X,
                    Y = e.Y,
                };
                emitter.impactPoints.Add(point1);
            }
            else if (rbDeMagnite.Checked)
            {
                emitter.impactPoints.Remove(point2);
                point2 = new AntiGravityPoint
                {
                    X = e.X,
                    Y = e.Y,
                };
                emitter.impactPoints.Add(point2);
            }
        }

        private void tbSpreading_Scroll(object sender, EventArgs e)
        {
            emitter.Spreading = tbSpreading.Value;
        }
        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            emitter.Direction = tbDirection.Value;
        }

        private void tbPowerDeMagnite_Scroll(object sender, EventArgs e)
        {
            point2.Power = tbPowerDeMagnite.Value;
        }

        private void tbPowerGravitone_Scroll(object sender, EventArgs e)
        {
            point1.Power = tbPowerMagnite.Value;
        }

        private void picDisplay_MouseMove(object sender, EventArgs e)
        {
            
        }
    }
}
