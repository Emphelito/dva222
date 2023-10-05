using Bounce;
using System;
using System.Drawing;

namespace Bounce
{

    interface Ishapes
    {
        void Draw(Graphics g);
        void intersects(Ball ball);
    }

    abstract class shapeLine : Ishapes
    {
        //Different ends/sides of a line
        protected PointF position2; 
        protected PointF position1;
        public Pen penColor;

        public shapeLine(int x1 , int y1, int x2, int y2) 
        {
            position1.X = x1;
            position1.Y = y1;
            position2.X = x2;
            position2.Y = y2;
        }
        public void Draw(Graphics g)
        {
            g.DrawLine(penColor, position1, position2); //Depending on given axis diff color
        }
        public void intersects(Ball ball) 
        {
            PointF closestPoint = new PointF();

            float dx = position2.X - position1.X; //dx = difference between x
            float dy = position2.Y - position1.Y;
            float t = ((ball.getX() - position1.X) * dx + (ball.getY() - position1.Y) * dy) / (dx * dx + dy * dy); //Closest point on the line to the ball
            t = Math.Max(0, Math.Min(1, t)); //Clamping value between 0 and 1

            closestPoint.X = position1.X + t * dx; //Closest x point to the ball
            closestPoint.Y = position1.Y + t * dy;

            float distanceSquared = (ball.getX() - closestPoint.X) * (ball.getX() - closestPoint.X) +
                                    (ball.getY() - closestPoint.Y) * (ball.getY() - closestPoint.Y);

            if (distanceSquared <= (ball.getRadius() * ball.getRadius()))
            {
                speedChange(ball);
            }
        }
        abstract public void speedChange(Ball ball);
     }

    class xLine : shapeLine
    {
        public xLine(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2) 
        { 
            penColor = new Pen(Color.Green); 
        }
        public override void speedChange(Ball ball)
        {
            ball.setSpeed(1, -1);
        }
    }

    class yLine : shapeLine
    {
        public yLine(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2) { penColor = new Pen(Color.Yellow);  }

        public override void speedChange(Ball ball)
        {
            ball.setSpeed(-1, 1);
        }
    }

    abstract class shapeBox : Ishapes
    {
        protected PointF position;
        protected int W, H;
        public Pen penColor;
        public shapeBox(int x, int y, int w, int h) 
        {
            position.X = x; 
            position.Y = y;
            W = w; H = h;
        }
        public void Draw(Graphics g)
        {
            g.DrawRectangle(penColor, position.X, position.Y, W, H);
        }
        public void intersects(Ball ball) //Shared function between boxes
        {
            PointF closestPoint = new PointF();
            closestPoint.X = Math.Max(position.X, Math.Min(ball.getX(), position.X + W)); //Closest point between x-axis of box and ball
            closestPoint.Y = Math.Max(position.Y, Math.Min(ball.getY(), position.Y + H));

            float distanceSquared = (ball.getX() - closestPoint.X) * (ball.getX() - closestPoint.X) +
                                    (ball.getY() - closestPoint.Y) * (ball.getY() - closestPoint.Y);

            if (distanceSquared <= (ball.getRadius() * ball.getRadius()))
            {
                speedChange(ball);
            }
        }
        abstract public void speedChange(Ball ball); //Gets overriden in individual type of box

    }

    class fastBox : shapeBox
    {
        public fastBox(int x, int y, int w, int h) : base(x, y, w, h) 
        { 
            penColor = new Pen(Color.Blue);
        }
        public override void speedChange(Ball ball)
        {
            ball.setSpeed((float)1.05, (float)1.05);
        }
    }

    class slowBox : shapeBox
    {
        public slowBox(int x, int y, int w, int h) : base(x, y, w, h) 
        { 
            penColor = new Pen(Color.Red); 
        }
        public override void speedChange(Ball ball)
        {
            ball.setSpeed((float)0.95, (float)0.95);
        }
    }
}