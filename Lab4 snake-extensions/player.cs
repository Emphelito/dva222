using static Snakegame_Lab.Player;

namespace Snakegame_Lab
{
    public class Player
    {
        public int points;
        public bool lost = false;

        private List<snakePart> snakeParts;

        public bool candyAfterEffect; //Used to check if a timed effect is active for player
        public int timeCandyEffect; //Time effect 

        public PointF startPoints; //head, public since its used in candy.cs
        private PointF endPoints; //tail

        private Color snakeColor;

        private List<breakPoint> breakPointList = new List<breakPoint>();
        
        public enum Direction { Left, Right, Up, Down };
        
        public Player(PointF startPosition, Color color) 
        {
            snakeParts = new List<snakePart>();

            startPoints = startPosition;
            endPoints = startPoints;
            
            snakeParts.Add(new snakePart((int)startPoints.X, (int)startPoints.Y, Direction.Up, new PointF(0,-50)));

            snakeColor = color;

            timeCandyEffect = 0;
            candyAfterEffect = false;
        }
        public void addPart()
        {
            if(snakeParts.Last().direction == Direction.Left)
            {
                snakeParts.Add(new snakePart((int)endPoints.X + 50, (int)endPoints.Y, Direction.Left, snakeParts.Last().speed));
                endPoints.X += 50;
            }
            else if(snakeParts.Last().direction == Direction.Right)
            {
                snakeParts.Add(new snakePart((int)endPoints.X - 50, (int)endPoints.Y, Direction.Right, snakeParts.Last().speed));
                endPoints.X -= 50;
            }
            else if(snakeParts.Last().direction == Direction.Up)
            {
                snakeParts.Add(new snakePart((int)endPoints.X, (int)endPoints.Y + 50, Direction.Up, snakeParts.Last().speed));
                endPoints.Y += 50;
            }
            else if(snakeParts.Last().direction == Direction.Down)
            {
                snakeParts.Add(new snakePart((int)endPoints.X, (int)endPoints.Y - 50, Direction.Down, snakeParts.Last().speed));
                endPoints.Y -= 50;
            }    
        }
        public void removePart()
        {
            snakeParts.Remove(snakeParts.Last());
        }

        public void changeDir(Direction dir)
        {
            lost = moveIlegality(dir);
            if (snakeParts.Count() == 0) lost = true;

            if (!lost)
            {
                if (dir == Direction.Left && snakeParts[0].direction != Direction.Right)
                {
                    snakeParts.First().speed.X = -50;
                    snakeParts.First().speed.Y = 0;
                    snakeParts.First().direction = dir;
                }
                else if (dir == Direction.Right && snakeParts[0].direction != Direction.Left)
                {
                    snakeParts.First().speed.X = 50;
                    snakeParts.First().speed.Y = 0;
                    snakeParts.First().direction = dir;
                }
                else if (dir == Direction.Up && snakeParts[0].direction != Direction.Down)
                {
                    snakeParts.First().speed.X = 0;
                    snakeParts.First().speed.Y = -50;
                    snakeParts.First().direction = dir;
                }
                else if (dir == Direction.Down && snakeParts[0].direction != Direction.Up)
                {
                    snakeParts.First().speed.X = 0;
                    snakeParts.First().speed.Y = 50;
                    snakeParts.First().direction = dir;
                }

                if(snakeParts.Count > 1)
                    breakPointList.Add(new breakPoint(snakeParts[0].speed, snakeParts[0].direction, snakeParts[0].Position));
            }
        }
        public void candyEffect()
        {
            if(candyAfterEffect == false) return;

            Random random = new Random();
            timeCandyEffect++;

            if(random.Next(100) > 90)
            {
                int randDir = random.Next(100);

                if(randDir > 75 && snakeParts[0].direction != Direction.Up)
                {
                    changeDir(Direction.Up);
                }
                else if(randDir > 50 && snakeParts[0].direction != Direction.Left)
                {
                    changeDir(Direction.Left);
                }
                else if(randDir > 25 && snakeParts[0].direction != Direction.Right)
                {
                    changeDir(Direction.Right);
                }
                else if(randDir > 0 && snakeParts[0].direction != Direction.Down)
                {
                    changeDir(Direction.Down);
                }
            }
            if(timeCandyEffect >= 120) //120 * 250ms = 30.000 = 30s
            {                          //250ms is the time between each tick(se timer in engine.cs)
                candyAfterEffect = false;
                timeCandyEffect = 0;
            }
            
        }
        public void Move()
        {
            lost = moveIlegality();
            if (lost == false)
                lost = moveIlegality(snakeParts[0].direction);
            if (snakeParts.Count() == 0) lost = true;

            if (lost == true) return;

            candyEffect(); 

            for (int i = 0; i < snakeParts.Count(); i++) 
            {
                snakeParts[i].Position.X += snakeParts[i].speed.X;
                snakeParts[i].Position.Y += snakeParts[i].speed.Y;

                foreach (var bp in breakPointList)
                {
                    if (snakeParts[i].Position == bp.bpPosition)
                    {
                        snakeParts[i].speed = bp.bpSpeed;
                        snakeParts[i].direction = bp.bpDir;

                        if (snakeParts[i] == snakeParts.Last())
                        {
                            breakPointList.Remove(bp); 
                            break;
                        }
                    }
                }
            }

            checkLocation();

            startPoints.X += snakeParts[0].speed.X;
            startPoints.Y += snakeParts[0].speed.Y;
            endPoints.X = snakeParts.Last().Position.X;
            endPoints.Y = snakeParts.Last().Position.Y;
        }
        private void checkLocation()
        {
            if (snakeParts.Count() == 1) return;
            for(int i = 1; i < snakeParts.Count(); i++)
            {
                if (snakeParts[i].Position.X == snakeParts[i - 1].Position.X + 50) return;
                else if (snakeParts[i].Position.X == snakeParts[i - 1].Position.X - 50) return;
                else if (snakeParts[i].Position.Y == snakeParts[i - 1].Position.Y + 50) return;
                else if (snakeParts[i].Position.Y == snakeParts[i - 1].Position.Y - 50) return;
                else
                {
                    snakeParts.Remove(snakeParts[i]);
                    addPart();
                }
                
            }
        }
        private bool moveIlegality() //Used to check out of bounds
        {
            if (snakeParts.Count() == 0) lost = true;
            if (lost == true) return true;
            
            if (snakeParts[0].Position.X < 0 
                || snakeParts[0].Position.X > 1400)
            {
                lost = true;
                snakeDeath();
                return true;
            }
            else if (snakeParts[0].Position.Y > 1000
                || snakeParts[0].Position.Y < 0)
            {
                lost = true;
                snakeDeath();
                return true;
            }
            return false;
        }
        private bool moveIlegality(Direction dir) //Used to check collision with itself
        {
            if (lost == true) return true;

            if ((dir == Direction.Down && snakeParts[0].direction == Direction.Up)
                || dir == Direction.Up && snakeParts[0].direction == Direction.Down)
                return false;
            
            else if ((dir == Direction.Right && snakeParts[0].direction == Direction.Left)
                || dir == Direction.Left && snakeParts[0].direction == Direction.Right)
                return false;

            for(int i = 4; i < snakeParts.Count(); i++)
            {
                if (startPoints.X == snakeParts[i].Position.X && startPoints.Y == snakeParts[i].Position.Y) {
                    snakeDeath();
                    return true;
                }
            }
            return false;
        }
        public void moveIlegality(Player otherPlayer) //Used to check collison with other player
        {
            if(lost == true) return;
            foreach(var otherPart in otherPlayer.snakeParts)
            {
                if (snakeParts[0].Position == otherPart.Position)
                {
                    if (otherPart != otherPlayer.snakeParts[0])
                    {   
                        snakeDeath();
                        lost = true;
                        otherPlayer.snakeDeath();
                        otherPlayer.lost = true;
                        return;
                    }
                    else
                    {
                        otherPlayer.points += 5;

                        snakeDeath();
                        lost = true;
                        return;
                    }
                }
            }
            return;
        }

        private void snakeDeath()
        {
            snakeParts.Clear();
        }
        public void Draw(Graphics g)
        {
            foreach(var part in snakeParts) 
            {
                if (part == snakeParts.Last()) part.Draw(g, snakeColor);
                else part.Draw(g, snakeColor);
            }
        }

    }

    internal class snakePart
    {
        internal PointF Position;
        int width = 50; int height = 50;

        internal PointF speed; //Speed changed by input from user
        internal Direction direction;

        internal snakePart(int x, int y, Direction dir , PointF s) 
        { 
            Position.X = x; Position.Y = y;
            direction = dir;
            speed = s;
        }

        internal void Draw(Graphics g, Color snakeColor) 
        {
            g.FillRectangle(new SolidBrush(snakeColor), new Rectangle((int)Position.X, (int)Position.Y, width, height));
        }
    }
    internal class breakPoint
    {
        internal readonly PointF bpPosition; //Poistion of the breakpoint
        internal readonly PointF bpSpeed; //New speed
        internal readonly Direction bpDir; //New dir

        internal breakPoint(PointF bpSpeed, Direction bpDir, PointF bpPosition)
        {
            this.bpSpeed = bpSpeed;
            this.bpDir = bpDir;
            this.bpPosition = bpPosition;
        }
    }
}
