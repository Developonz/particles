using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace particles
{
    public class PaintCirlce : IImpactPoint
    {
        public int D = 100;
        public Color pen = Color.Red;
        public override void Render(Graphics g)
        {
            g.DrawEllipse(new Pen(pen, 4), X - D / 2, Y - D / 2, D, D);
        }

        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            double r = Math.Sqrt(gX * gX + gY * gY);


            if (r + particle.Radius < D / 2)
            {
                particle.FromColor = pen;
            }
        }
    }
}
