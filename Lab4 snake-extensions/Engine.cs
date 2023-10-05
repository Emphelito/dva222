using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Snakegame_Lab
{
    public class gameChoice
    {
        MainForm Form = new MainForm();
        public void Choice()
        {
            Form.BackColor = Color.Black;

            Button onePlayerButton = new Button();
            onePlayerButton.BackColor = Color.White;
            onePlayerButton.Text = "1 Player";
            onePlayerButton.Location = new Point(600, 500); 
            onePlayerButton.Click += new EventHandler(onePlayer_Click); 
            Form.Controls.Add(onePlayerButton);

            Button twoPlayerButton = new Button();
            twoPlayerButton.BackColor = Color.White;
            twoPlayerButton.Text = "2 Players";
            twoPlayerButton.Location = new Point(700, 500); 
            twoPlayerButton.Click += new EventHandler(twoPlayer_Click); 
            Form.Controls.Add(twoPlayerButton);

            Button threePlayerButton = new Button();
            threePlayerButton.BackColor = Color.White;
            threePlayerButton.Text = "3 Players";
            threePlayerButton.Location = new Point(650, 550);
            threePlayerButton.Click += new EventHandler(threePlayer_Click);
            Form.Controls.Add(threePlayerButton);

            Application.Run(Form);
        }
        void onePlayer_Click(object sender, EventArgs e)
        {
            Player p1 = new Player(new PointF(550, 250), Color.Yellow);
            Engine engine = new Engine(Form, p1);

            Form.Controls.Clear();
            engine.Run();
        }

        void twoPlayer_Click(object sender, EventArgs e)
        {
            Player p1 = new Player(new PointF(550, 250), Color.Yellow);
            Player p2 = new Player(new PointF(250, 250), Color.White);
            Engine engine = new Engine(Form, p1, p2);

            Form.Controls.Clear();
            engine.Run();
        }
        void threePlayer_Click(object sender, EventArgs e)
        {
            Player p1 = new Player(new PointF(550, 250), Color.Yellow);
            Player p2 = new Player(new PointF(250, 250), Color.White);
            Player p3 = new Player(new PointF(250, 550), Color.Brown);
            Engine engine = new Engine(Form, p1, p2, p3);

            Form.Controls.Clear();
            engine.Run();
        }
    }
    internal class Engine
    {
        MainForm Form;
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        Player p1, p2, p3;
        List<Player> playerList = new List<Player>();
        bool p1_move = true;
        bool p2_move = true;
        bool p3_move = true;

        Candy candy;

        internal Engine(MainForm form, Player p1)
        {
            this.Form = form;

            candy = new Candy();

            this.p1 = p1;
            playerList.Add(p1);
            candy.addCandy();

        }
        internal Engine(MainForm form, Player p1, Player p2)
        {
            this.Form = form;

            candy = new Candy();

            this.p1 = p1;
            this.p2 = p2;
            playerList.Add(p1);
            playerList.Add(p2);
            candy.addCandy();
            candy.addCandy();
        }
        internal Engine(MainForm form, Player p1, Player p2, Player p3)
        {
            this.Form = form;

            candy = new Candy();

            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            playerList.Add(p1);
            playerList.Add(p2);
            playerList.Add(p3);
            candy.addCandy();
            candy.addCandy();
            candy.addCandy();
        }

        internal void Run()
        {
            Form.BackColor = Color.Black;
            Form.Paint += Draw;
            Form.KeyDown += userInput;
            timer.Tick += TimerEventHandler;
            timer.Interval = 250;
            timer.Start();            
        }

        void TimerEventHandler(Object obj, EventArgs args)
        {
            p1_move = true;
            p2_move = true;
            p3_move = true;
            int i = 0;
            foreach (Player p in playerList)
            {
                if (p.lost == true) i++;
                if (i == playerList.Count) endGame();
            }

            Move();

            foreach(Player p in playerList)
            {
                candy.checkCandy(p);
            } 

            Form.Refresh();
        }
        void Draw(Object obj, PaintEventArgs args)
        {
            candy.draw(args.Graphics);

            foreach (Player p in playerList)
            {
                p.Draw(args.Graphics);
            }
        }
        void Move()
        {
            foreach(Player p in playerList)
            {
                p.Move();
            }

            for(int i = 0; i < playerList.Count; i++)
            {
                foreach(var p in playerList)
                {
                    if (playerList[i] != p)
                    {
                        playerList[i].moveIlegality(p);
                    }   
                }
            }

        }
        void userInput(Object sender, KeyEventArgs e)
        {   
            if (p1_move)
            {
                if (e.KeyCode == Keys.Left) 
                {
                    p1.changeDir(Player.Direction.Left);
                    p1_move = false;
                }  

                if (e.KeyCode == Keys.Right) 
                {
                    p1.changeDir(Player.Direction.Right);
                    p1_move = false;
                }
                if (e.KeyCode == Keys.Up) 
                {
                    p1.changeDir(Player.Direction.Up);
                    p1_move = false;
                }
                if (e.KeyCode == Keys.Down) 
                {
                    p1.changeDir(Player.Direction.Down);
                    p1_move = false;
                }
            }
            if (p2_move)
            {
                if(playerList.Count > 1)
                {
                    if (e.KeyCode == Keys.A) 
                    {
                        p2.changeDir(Player.Direction.Left);
                        p2_move = false;
                    }
                    if (e.KeyCode == Keys.D) 
                    {
                        p2.changeDir(Player.Direction.Right);
                        p2_move = false;
                    }
                    if (e.KeyCode == Keys.W) 
                    {
                        p2.changeDir(Player.Direction.Up);
                        p2_move = false;
                    }
                    if (e.KeyCode == Keys.S) 
                    {
                        p2.changeDir(Player.Direction.Down);
                        p2_move = false;
                    }
                }
            }
            if (p3_move)
            {
                if(playerList.Count > 2)
                {
                    if (e.KeyCode == Keys.H) 
                    {
                        p3.changeDir(Player.Direction.Left);
                        p3_move = false;
                    }
                    if (e.KeyCode == Keys.L) 
                    {
                        p3.changeDir(Player.Direction.Right);
                        p3_move = false;
                    }
                    if (e.KeyCode == Keys.K) 
                    {
                        p3.changeDir(Player.Direction.Up);
                        p3_move = false;
                    }
                    if (e.KeyCode == Keys.J) 
                    {
                        p3.changeDir(Player.Direction.Down);
                        p3_move = false;
                    }
                }
            }
        }
        void endGame()
        {
            string endMes = "";
            Label endScreen = new Label();
            endScreen.Location = new Point(400, 400);
            for(int i = 0; i < playerList.Count; i++)
            {
                 endMes = endMes + "P" + (i + 1) + " Points = " + playerList[i].points + "\n";
            }
            endScreen.Text = endMes;
            endScreen.Size = new Size(500, 250);
            endScreen.BackColor= Color.White;
            endScreen.Font = new Font("Arial", 34);
            endScreen.TextAlign = ContentAlignment.MiddleCenter;

            Form.Controls.Add(endScreen);
        }
    }
}
