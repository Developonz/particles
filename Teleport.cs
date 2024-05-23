using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace particles
{
    public class Teleport : IImpactPoint
    {
        public int R, X2, Y2;

        public override void Render(Graphics g)
        {
            g.DrawEllipse(new Pen(Color.Blue, 4), X - R / 2, Y - R / 2, R, R);
            g.DrawEllipse(new Pen(Color.Red, 4), X2 - R / 2, Y2 - R / 2, R, R);
            Pen pen = new Pen(Color.Green, 4);
            Point[] points =
                     {
                 new Point((int)(X),(int)(Y)),
                 new Point((int)(X2),(int)(Y2)),
             };
            g.DrawLines(pen, points);

        }

        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            double r = Math.Sqrt(gX * gX + gY * gY);

            if (r + particle.Radius < R / 2)
            {
                particle.X = X2;
                particle.Y = Y2;

                particle.SpeedX = -particle.SpeedX;
                particle.SpeedY = -particle.SpeedY;

            }
        }
    }
}
