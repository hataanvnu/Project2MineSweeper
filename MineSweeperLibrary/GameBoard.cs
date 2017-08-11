using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperLibrary
{
    public class GameBoard
    {
        public Tile[,] Tiles { get; set; }

        public int NumBombs { get; set; }

        public bool GameOver { get; set; }

        public int AmountOfTilesClicked { get; set; }

        public int RemainingMoves { get { return Tiles.Length - NumBombs - AmountOfTilesClicked; }}

        public int dimension = 10;

        public int ClickCounter { get; set; } = 0;

        public GameBoard(int difficulty)
        {
            NumBombs = difficulty;
            GameOver = false;
            AmountOfTilesClicked = 0;

            Tiles = new Tile[dimension, dimension];

            for (int y = 0; y < dimension; y++)
            {
                for (int x = 0; x < dimension; x++)
                {
                    Tiles[x, y] = new Tile();
                }
            }

        }
    }
}
