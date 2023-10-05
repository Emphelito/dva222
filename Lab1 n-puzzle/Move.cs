using System;
namespace Lab1
{
    public class Moving
    {
        private int playerPos;
        private int nrMoves;
        private int[] gameBord;
        public Moving(int size, Bord bord)
        {
            this.gameBord = bord.returnBord();
            
            this.playerPos = 0;
            
            this.gameBord = bord.shuffle(this);

            this.nrMoves = 0;
        }
        
        private bool legalMove (int pos, int move, Bord bord)
        {
            switch (move)
            {
                case 0:
                    int x = playerPos - bord.getSqrt();
                    if (pos - bord.getSqrt() < 0 ) return false;
                    break;
                case 1:
                    if (pos + bord.getSqrt() > bord.getSize()-1) return false;
                    break;
                case 2:
                    if (bord.getRightIndex().Contains(pos)) return false;
                    break;
                case 3:
                    if (bord.getLeftIndex().Contains(pos)) return false;
                    break;
            }

            return true;
        }

        public void moveUp(Bord bord)
        {
            if (!legalMove(playerPos, 0, bord)) return;

            int tmp = this.gameBord[playerPos - bord.getSqrt()];
            this.gameBord[playerPos - bord.getSqrt()] = 0;
            this.gameBord[playerPos] = tmp;
            playerPos = (playerPos - bord.getSqrt());

            this.nrMoves++;
        }
        public void moveDown(Bord bord)
        {
            if (!legalMove(playerPos, 1, bord)) return;

            int tmp = this.gameBord[playerPos + bord.getSqrt()];
            this.gameBord[playerPos + bord.getSqrt()] = 0;
            this.gameBord[playerPos] = tmp;
            playerPos = (playerPos + bord.getSqrt());

            this.nrMoves++;
        }
        public void moveRight(Bord bord)
        {
            if (!legalMove(playerPos, 2, bord)) return;

            int tmp = this.gameBord[playerPos + 1];
            this.gameBord[playerPos+1] = 0;
            this.gameBord[playerPos] = tmp;
            playerPos = (playerPos + 1);

            this.nrMoves++;
        }
        public void moveLeft(Bord bord)
        {
            if (!legalMove(playerPos, 3, bord)) return;

            int tmp = this.gameBord[playerPos - 1];
            this.gameBord[playerPos - 1] = 0;
            this.gameBord[playerPos] = tmp;
            playerPos = (playerPos - 1);

            this.nrMoves++;
        }

        public int getNrMoves()
        {
            return this.nrMoves;
        }

        public int[] getBord()
        {
            return this.gameBord;
        }

    }
}

