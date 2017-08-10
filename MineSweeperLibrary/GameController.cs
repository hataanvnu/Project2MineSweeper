using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MineSweeperLibrary
{
    public struct BombCoordinate
    {
        public int xCoordinate { get; set; }
        public int yCoordinate { get; set; }

        public BombCoordinate(int x, int y)
        {
            xCoordinate = x;
            yCoordinate = y;
        }
    }

    public static class GameController
    {

        static Random random = new Random();

        public static GameBoard InitializeGame()
        {
            GameBoard gameBoard = new GameBoard(10);

            BombCoordinate[] bombCoordinates = PlaceBombs(gameBoard);
            SetNumberOfAdjacentBombs(gameBoard, bombCoordinates);

            return gameBoard;
        }

        private static void SetNumberOfAdjacentBombs(GameBoard gameBoard, BombCoordinate[] bombCoordinates)
        {
            foreach (var tile in gameBoard.Tiles)
            {

                tile.NumAdjacentBombs++;

            }
        }

        private static BombCoordinate[] PlaceBombs(GameBoard gameBoard)
        {
            BombCoordinate[] bombCoordinates = new BombCoordinate[gameBoard.NumBombs];

            for (int i = 0; i < gameBoard.NumBombs;)
            {

                int x = random.Next(gameBoard.dimension);
                Thread.Sleep(random.Next(50, 100));
                int y = random.Next(gameBoard.dimension);

                if (!gameBoard.Tiles[x, y].IsBomb)
                {
                    gameBoard.Tiles[x, y].IsBomb = true;
                    bombCoordinates[i] = new BombCoordinate(x, y);
                    i++;
                }
            }

            return bombCoordinates;

        }

        public static void EnableBombs(GameBoard gameBoard)
        {
            foreach (var tile in gameBoard.Tiles)
            {
                if (tile.IsBomb)
                    tile.IsClicked = true;
            }
        }
    }
}
