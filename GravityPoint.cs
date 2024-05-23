using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace particles
{
    public class GravityPoint : IImpactPoint
    {
        public float Power = 100; 

        public override bool ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            double r = Math.Sqrt(gX * gX + gY * gY);

            if (r + particle.Radius < Power / 2) // если частица оказалось внутри окружности
            {
                // то притягиваем ее
                float r2 = (float)Math.Max(100, gX * gX + gY * gY);
                particle.SpeedX += gX * Power / r2;
                particle.SpeedY += gY * Power / r2;
            }
            return true;
        }

        public override void Render(Graphics g)
        {
            g.DrawEllipse(
                   new Pen(Color.Red),
                   X - Power / 2,
                   Y - Power / 2,
                   Power,
                   Power
               );
            
            var stringFormat = new StringFormat(); 
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            var text = $"Я гравитон\nc силой {Power}";
            var font = new Font("Verdana", 10);

            var size = g.MeasureString(text, font);


            g.FillRectangle(
                new SolidBrush(Color.Red),
                X - size.Width / 2, 
                Y - size.Height / 2,
                size.Width,
                size.Height
            );

            g.DrawString(
                text,
                font,
                new SolidBrush(Color.White),
                X,
                Y,
                stringFormat
            );
        }
    }
}
