namespace Snakegame_Lab
{
    public class Candy
    {
        Random rand = new Random();

        List<typesCandy> candyList = new List<typesCandy>();

        public Candy() { }
        public void addCandy()
        {
            int rCandy = rand.Next(100);
            PointF rPos = new PointF(rand.Next(28) * 50, rand.Next(19) * 50);

            if(rCandy < 20) //Diet 20%
            {
                dietCandy candy = new dietCandy(rPos);
                candyList.Add(candy);
            }
            else if(rCandy > 80) //Valuable 20%
            {
                valuableCandy candy = new valuableCandy(rPos);
                candyList.Add(candy);
            }
            else if(rCandy > 30 && rCandy < 80) //Normal, 50%
            {
                standardCandy candy = new standardCandy(rPos);
                candyList.Add(candy);
            }
            else //should give a 10% chance
            {
                moveCandy candy = new moveCandy(rPos);
                candyList.Add(candy);
            }

        }
        public void checkCandy(Player p)
        {
            foreach(typesCandy candy in candyList)
            {
                if(candy.Position == p.startPoints)
                {
                    candy.Effect(p);
                    candyList.Remove(candy);
                    addCandy();
                    break;
                }
            }
        }
        public void draw(Graphics e)
        {
            foreach(typesCandy candy in candyList)
            {
                
                candy.Draw(e);  
            }
        }

    }

    internal abstract class typesCandy
    {
        internal PointF Position;

        internal SolidBrush solidBrush;

        public int time;

        internal typesCandy(PointF position)
        {
            this.Position = position;
        }

        public void Draw(Graphics g)
        {
            g.FillRectangle(solidBrush, new Rectangle((int)Position.X, (int)Position.Y, 50, 50));

            time++;
        }
        public abstract void Effect(Player p);
    }
    internal class standardCandy : typesCandy
    {
        public standardCandy(PointF pos) : base(pos)
        {
            solidBrush= new SolidBrush(Color.Purple);
        }
        public override void Effect(Player p)
        {
            p.points += 1;
            p.addPart();
        }
    }
    internal class valuableCandy : typesCandy 
    { 
        public valuableCandy(PointF pos) : base(pos) 
        {
            solidBrush = new SolidBrush(Color.Pink);
        }
        public override void Effect(Player p)
        {
            p.points += 5;
            p.addPart();
            p.addPart();
        }
    }
    internal class dietCandy : typesCandy 
    {
        public dietCandy(PointF pos) : base(pos)
        {
            solidBrush = new SolidBrush(Color.Green);
        }
        public override void Effect(Player p)
        {
            p.points += 1;
            p.removePart();
        }

    }
    internal class moveCandy : typesCandy
    {
        public moveCandy(PointF pos) : base(pos)
        {
            solidBrush = new SolidBrush(Color.Gray);
        }
        public override void Effect(Player p)
        {
            p.candyAfterEffect = true;
            p.timeCandyEffect = 0;
        }

    }
}
