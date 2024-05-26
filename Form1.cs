using particles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace particles
{
    public partial class Form1 : Form
    {
        private Emitter emitter;
        private List<IImpactPoint> points = new List<IImpactPoint>();
        private BlackHolePoint holo;
        private Teleport teleport;
        private IImpactPoint activePoint;

        private float centerX;
        private float centerY;

        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            holo = new BlackHolePoint(picDisplay.Height / 5 * 2) {};
            teleport = new Teleport();

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


            picDisplay.Invalidate();
        }

        private void picDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            if (rbEmitter.Checked)
            {
                emitter.X = e.X;
                emitter.Y = e.Y;
            } else if (e.Button == MouseButtons.Left)
            {
                if (rbTeleport.Checked) {
                    teleport.X = e.X;
                    teleport.Y = e.Y;
                    emitter.impactPoints.Remove(teleport);
                    emitter.impactPoints.Add(teleport);
                    activePoint = teleport;
                    return;
                }
                IImpactPoint point = null;
                if (rbMagnite.Checked) {
                    point = new GravityPoint {
                        X = e.X,
                        Y = e.Y,
                    };
                } else if (rbDeMagnite.Checked) {
                    point = new AntiGravityPoint {
                        X = e.X,
                        Y = e.Y,
                    };
                } else if (rbWall.Checked) {
                    point = new CollisionCircle {
                        X = e.X,
                        Y = e.Y,
                    };
                } else if (rbPaintCircle.Checked) {
                    point = new PaintCirlce {
                        X = e.X,
                        Y = e.Y,
                    };
                }
                emitter.impactPoints.Add(point);
                points.Add(point);
                activePoint = point;
            } else if (e.Button == MouseButtons.Right) {
                if (rbTeleport.Checked) {
                    teleport.X2 = e.X;
                    teleport.Y2 = e.Y;
                    emitter.impactPoints.Remove(teleport);
                    emitter.impactPoints.Add(teleport);
                    activePoint = teleport;
                    return;
                }
                if (activePoint != null) {
                    emitter.impactPoints.Remove(activePoint);
                    points.Remove(activePoint);
                    activePoint = null;
                }
            } else if (e.Button == MouseButtons.Middle) { 
                if (rbTeleport.Checked) {
                    emitter.impactPoints.Remove(teleport);
                    if (activePoint == teleport)
                        activePoint = null;
                    return;
                }
                foreach (var point in points) {
                    if (rbMagnite.Checked) {
                        if (point is GravityPoint) {
                            emitter.impactPoints.Remove(point);
                        }
                    }
                    else if (rbDeMagnite.Checked) {
                        if (point is AntiGravityPoint) {
                            emitter.impactPoints.Remove(point);
                        }
                    }
                    else if (rbWall.Checked) {
                        if (point is CollisionCircle) {
                            emitter.impactPoints.Remove(point);
                        }
                    }
                    else if (rbPaintCircle.Checked) {
                        if (point is PaintCirlce) {
                            emitter.impactPoints.Remove(point);
                        }
                    }
                    if (activePoint == point) 
                        activePoint = null;
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
            foreach (var point in points) 
            {
                if (point is AntiGravityPoint)
                    point.D = tbPowerDeMagnite.Value;
            }
        }

        private void tbPowerGravitone_Scroll(object sender, EventArgs e)
        {
            foreach (var point in points) {
                if (point is GravityPoint)
                    point.D = tbPowerMagnite.Value;
            }
        }



        private void picDisplay_MouseWheel(object sender, MouseEventArgs e)
        {
            if (activePoint != null) { 
                if (activePoint is PaintCirlce) {
                    if (e.Delta > 0) {
                        ((PaintCirlce)activePoint).changeColor(true);
                    } else {
                        ((PaintCirlce)activePoint).changeColor(false);
                    }
                    return;
                }
                if (e.Delta > 0) { 
                    if (activePoint.D < 200) { 
                        activePoint.D += 2;
                    }
                } else {
                    if (activePoint.D > 30) {
                        activePoint.D -= 2;
                    }
                }
            }
        }

    }
}
