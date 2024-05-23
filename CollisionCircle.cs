using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace particles
{
    public class CollisionCircle : IImpactPoint
    {
        public int D = 100;

        public override void Render(Graphics g)
        {
            g.DrawEllipse(
                   new Pen(Color.Red),
                   X - D / 2,
                   Y - D / 2,
                   D,
                   D
               );
        }

        public override void ImpactParticle(Particle particle)
        {
            float gX = particle.X - X;
            float gY = particle.Y - Y;
            double r = Math.Sqrt(gX * gX + gY * gY);

            if (r + particle.Radius < D / 2)
            {
                // Нормализованный вектор нормали
                float normalX = (float)(gX / r);
                float normalY = (float)(gY / r);

                // Перемещаем частицу за пределы сферы
                float overlap = (float)((D / 2) - r + particle.Radius);
                particle.X += normalX * overlap;
                particle.Y += normalY * overlap;

                // Проекция скорости на нормаль
                float dotProduct = particle.SpeedX * normalX + particle.SpeedY * normalY;

                // Отражённый вектор скорости
                particle.SpeedX = particle.SpeedX - 2 * dotProduct * normalX;
                particle.SpeedY = particle.SpeedY - 2 * dotProduct * normalY;
            }
        }



    }
}
