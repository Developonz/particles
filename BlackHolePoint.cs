using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace particles
{
    public class BlackHolePoint : IImpactPoint
    {
        private const float EXTER_POWER = 200;
        private const float INTER_POWER = 75;
        public float Power;
        public float internalPower;
        public float weight = 1;

        public override bool ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            double r = Math.Sqrt(gX * gX + gY * gY);
            Power = EXTER_POWER * weight;
            internalPower = INTER_POWER * weight;

            if (r + particle.Radius < internalPower / 2)
            {
                weight += 0.00002f;
                return false;
            } else if (r + particle.Radius < Power / 2) 
            {
                float r2 = (float)Math.Max(Power, gX * gX + gY * gY);
                particle.SpeedX += gX * Power / r2;
                particle.SpeedY += gY * Power / r2;
            }

            return true;
        }

        public override void Render(Graphics g)
        {
            g.DrawEllipse(
                new Pen(Color.Red),
                X - internalPower / 2,
                Y - internalPower / 2,
                internalPower,
                internalPower
            );

            g.DrawEllipse(
                new Pen(Color.Red),
                X - Power / 2,
                Y - Power / 2,
                Power,
                Power
            );
        }
    }
}
