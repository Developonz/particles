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
        public Color[] pens = { Color.Red, Color.Blue, Color.Black, Color.Green, Color.Pink, Color.Yellow };
        private int idx = 0;
        public override void Render(Graphics g)
        {
            g.DrawEllipse(new Pen(pens[idx], 4), X - D / 2, Y - D / 2, D, D);
        }

        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            double r = Math.Sqrt(gX * gX + gY * gY);


            if (r + particle.Radius < D / 2)
            {
                particle.FromColor = pens[idx];
            }
        }

        public void changeColor(bool b)
        {
            if (b)
            {
                if (idx == pens.Length - 1) {
                    idx = 0;
                    return;
                }
                idx++;
            } else
            {
                if (idx == 0)
                {
                    idx = pens.Length - 1;
                    return;
                }
                idx--;
            }
        }
    }
}
