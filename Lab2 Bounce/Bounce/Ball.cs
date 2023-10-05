using System;
using System.Drawing;

namespace Bounce
{
	public class Ball
	{
	    Pen Pen = new Pen(Color.White);

		PointF Position;
		PointF Speed;

        float Radius;

		static Random Random = new Random();

		public Ball(float x, float y, float radius)
		{
			Position = new PointF(x,y);
			var xd = Random.Next(1, 6);
			var yd = Random.Next(1, 6);
			if (Random.Next(0, 2) == 0) xd = -xd;
			if (Random.Next(0, 2) == 0) yd = -yd;

			Speed = new PointF(xd,yd);
			Radius = radius;
		}

		public void Draw(Graphics g)
		{
			g.DrawEllipse(Pen,Position.X - Radius, Position.Y - Radius, 2 * Radius, 2 * Radius);
		}

		public void Move()
		{
			Position.X += Speed.X;
			Position.Y += Speed.Y;
		}
        //all 4 functions  used in intersection in shapes.cs
        public void setSpeed(float xDir, float yDir)
		{
			Speed.X = Speed.X * xDir; //Multiplication
			Speed.Y = Speed.Y * yDir; 
		}
        public int getY()
        {
            return Convert.ToInt32(Position.Y);
        }

        public int getX()
		{
			return Convert.ToInt32(Position.X);
		} 

		public double getRadius()
		{
			return Radius;
		}
	}
}
