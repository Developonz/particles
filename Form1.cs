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
        public List<GravityPoint> point1 = new List<GravityPoint>();
        List<AntiGravityPoint> point2 = new List<AntiGravityPoint>();
        List<CollisionCircle> point3 = new List<CollisionCircle>();
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
                    emitter.impactPoints.Remove(teleport);//Зачем?????????????????????????
                    emitter.impactPoints.Add(teleport);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    teleport.X2 = e.X;
                    teleport.Y2 = e.Y;
                    emitter.impactPoints.Remove(teleport);
                    emitter.impactPoints.Add(teleport);
                } else
                {
                    emitter.impactPoints.Remove(teleport);
                }
            }
            else if (rbMagnite.Checked)
            {
                if (e.Button == MouseButtons.Left) 
                { 
                    GravityPoint point = new GravityPoint
                    {
                        X = e.X,
                        Y = e.Y,
                    };
                    emitter.impactPoints.Add(point);
                    point1.Add(point);
                } else
                {
                    foreach (var point in point1) {
                        emitter.impactPoints.Remove(point);
                    }
                }
            }
            else if (rbDeMagnite.Checked)
            {
                if (e.Button == MouseButtons.Left)
                {
                    AntiGravityPoint point = new AntiGravityPoint
                    {
                        X = e.X,
                        Y = e.Y,
                    };
                    emitter.impactPoints.Add(point);
                    point2.Add(point);
                } 
                else
                {
                    foreach (var point in point2)
                    {
                        emitter.impactPoints.Remove(point);
                    }
                }
            }
            else if (rbWall.Checked)
            {
                if (e.Button == MouseButtons.Left)
                {
                    CollisionCircle point = new CollisionCircle
                    {
                        X = e.X,
                        Y = e.Y,
                    };
                    emitter.impactPoints.Add(point);
                    point3.Add(point);
                }
                else
                {
                    foreach (var point in point3)
                    {
                        emitter.impactPoints.Remove(point);
                    }
                }
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
            foreach (var point in point2) 
            {
                point.Power = tbPowerDeMagnite.Value;
            }
        }

        private void tbPowerGravitone_Scroll(object sender, EventArgs e)
        {
            foreach (var point in point1)
            {
                point.Power = tbPowerMagnite.Value;
            }
        }

        private void picDisplay_MouseMove(object sender, EventArgs e)
        {
            
        }
    }
}
