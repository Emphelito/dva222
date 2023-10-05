using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Bounce
{
	public class Engine
	{
		MainForm Form = new MainForm();
		Timer Timer = new Timer();
		List<Ball> Balls = new List<Ball>();	
		Random Random = new Random();
        List<Ishapes> Ishapes = new List<Ishapes>(); //List for all shapes
        
		public Engine()
		{
			addObs(); // To add obs only once.
		}
        void addObs() //All shapes used
        {
			//Box shapes
            Ishapes.Add(new fastBox(300, 100, 300, 50));
            Ishapes.Add(new fastBox(100, 400, 300, 50));

            Ishapes.Add(new slowBox(150, 100, 50, 50));

			//Line shapes
			Ishapes.Add(new xLine(400, 75, 700, 75));
			Ishapes.Add(new xLine(20, 500, 520, 500));
			Ishapes.Add(new xLine(500, 420, 700, 420));

			Ishapes.Add(new yLine(750, 50, 750, 550));
			Ishapes.Add(new yLine(30, 10, 30, 530));
			Ishapes.Add(new yLine(75, 100, 75, 300));

        }
        public void Run()
		{
            Form.BackColor = Color.Black;
            Form.Paint += Draw;
            Timer.Tick += TimerEventHandler;
			Timer.Interval = 1000/25;
			Timer.Start();

			Application.Run(Form);
		}

		void TimerEventHandler(Object obj, EventArgs args)
		{
			PointF tmp= new PointF(20, 20);
			if (Random.Next(100) < 25)
            {
				var ball = new Ball(400, 300, 10);
				Balls.Add(ball);
			}

			foreach (var ball in Balls)
			{
				ball.Move();

                foreach (Ishapes shape in Ishapes) //Checks every ball against every shape.
                { 
                    shape.intersects(ball);
                }
            }
            Form.Refresh();
		}
		void Draw(Object obj, PaintEventArgs args)
		{
			foreach (var ball in Balls) ball.Draw(args.Graphics);
            foreach (Ishapes shape in Ishapes) shape.Draw(args.Graphics); 
        }
    }
}
