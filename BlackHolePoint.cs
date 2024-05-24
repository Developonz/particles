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
        private const float EXTER_POWER = 100;
        private const float INTER_POWER = 40;
        public float Power;
        public float internalPower;
        public float weight = 1;
        public float speed = 0.02f;
        public float angle = 0;
        private float maxPower = 150;
        private int countFood = 0;

        public BlackHolePoint() { }

        public BlackHolePoint(float maxPower) 
        {
            this.maxPower = maxPower;
        }

        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            double r = Math.Sqrt(gX * gX + gY * gY);
            if (Power <= maxPower)
            {
                Power = EXTER_POWER * weight;
                internalPower = INTER_POWER * weight;
            }            

            if (r + particle.Radius < internalPower / 2)
            {
                weight += 0.0005f;
                particle.access = false;
                ++countFood;
            } else if (r + particle.Radius < Power / 2) 
            {
                float r2 = (float)Math.Max(Power, gX * gX + gY * gY);
                particle.SpeedX += gX * Power / r2;
                particle.SpeedY += gY * Power / r2;
            }

        }

        public override void Render(Graphics g)
        {
            g.FillEllipse(
                new SolidBrush(Color.Black),
                X - internalPower / 2,
                Y - internalPower / 2,
                internalPower,
                internalPower
            ); ;

            g.DrawEllipse(
                new Pen(Color.Blue),
                X - Power / 2,
                Y - Power / 2,
                Power,
                Power
            );

            var stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            var text = $"Я пожиратель\nЯ съел {countFood}";
            var font = new Font("Verdana", 10);

            var size = g.MeasureString(text, font);

            g.FillRectangle(
                new SolidBrush(Color.Gray),
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
