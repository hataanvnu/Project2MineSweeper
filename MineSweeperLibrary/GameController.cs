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

        public static bool WinCondition(GameBoard currentGame)
        {
            return currentGame.AmountOfTilesClicked == currentGame.Tiles.Length - currentGame.NumBombs;
        }

        private static void SetNumberOfAdjacentBombs(GameBoard gameBoard, BombCoordinate[] bombCoordinates)
        {
            Tile[,] map = gameBoard.Tiles;

            foreach (var bomb in bombCoordinates)
            {
                int x = bomb.xCoordinate;
                int y = bomb.yCoordinate;

                #region bombräkning

                try
                {
                map[x + 1, y + 1].NumAdjacentBombs++;
                }
                catch (Exception)
                {}
                try
                {
                map[x, y - 1].NumAdjacentBombs++;
                }
                catch (Exception)
                {

                }
                try
                {
                    map[x, y + 1].NumAdjacentBombs++;
                }
                catch (Exception)
                {

                }
                try
                {
                    map[x - 1, y + 1].NumAdjacentBombs++;

                }
                catch (Exception)
                {

                }
                try
                {
                    map[x + 1, y - 1].NumAdjacentBombs++;

                }
                catch (Exception)
                {

                }
                try
                {
                    map[x + 1, y].NumAdjacentBombs++;

                }
                catch (Exception)
                {

                }
                try
                {
                    map[x - 1, y - 1].NumAdjacentBombs++;

                }
                catch (Exception)
                {

                }
                try
                {
                    map[x - 1, y].NumAdjacentBombs++;

                }
                catch (Exception)
                {

                }
                #endregion

                #region bombräkning Kopia
                //if (x == 0)
                //{
                //    if (y == 0)
                //    {
                //        map[x, y + 1].NumAdjacentBombs++;
                //        map[x + 1, y + 1].NumAdjacentBombs++;
                //        map[x + 1, y].NumAdjacentBombs++;

                //    }
                //    else if (y == map.GetLength(0) - 1)
                //    {
                //        map[x + 1, y - 1].NumAdjacentBombs++;
                //        map[x, y - 1].NumAdjacentBombs++;
                //        map[x + 1, y].NumAdjacentBombs++;
                //    }
                //    else
                //    {
                //        map[x, y + 1].NumAdjacentBombs++;
                //        map[x + 1, y + 1].NumAdjacentBombs++;
                //        map[x + 1, y].NumAdjacentBombs++;
                //        map[x, y - 1].NumAdjacentBombs++;
                //        map[x + 1, y - 1].NumAdjacentBombs++;

                //    }
                //}
                //else if (x == map.GetLength(0) - 1)
                //{
                //    if (y == 0)
                //    {
                //        map[x, y + 1].NumAdjacentBombs++;
                //        map[x - 1, y + 1].NumAdjacentBombs++;
                //        map[x - 1, y].NumAdjacentBombs++;
                //    }
                //    else if (y == map.GetLength(0) - 1)
                //    {
                //        map[x - 1, y].NumAdjacentBombs++;
                //        map[x, y - 1].NumAdjacentBombs++;
                //        map[x - 1, y - 1].NumAdjacentBombs++;
                //    }
                //    else
                //    {
                //        map[x, y + 1].NumAdjacentBombs++;
                //        map[x - 1, y + 1].NumAdjacentBombs++;
                //        map[x - 1, y].NumAdjacentBombs++;
                //        map[x, y - 1].NumAdjacentBombs++;
                //        map[x - 1, y - 1].NumAdjacentBombs++;
                //    }


                //}
                //else if (y == 0)
                //{
                //    map[x, y + 1].NumAdjacentBombs++;
                //    map[x + 1, y + 1].NumAdjacentBombs++;
                //    map[x + 1, y].NumAdjacentBombs++;
                //    map[x - 1, y + 1].NumAdjacentBombs++;
                //    map[x - 1, y].NumAdjacentBombs++;
                //}
                //else if (y == map.GetLength(0) - 1)
                //{
                //    map[x, y - 1].NumAdjacentBombs++;
                //    map[x + 1, y - 1].NumAdjacentBombs++;
                //    map[x + 1, y].NumAdjacentBombs++;
                //    map[x - 1, y - 1].NumAdjacentBombs++;
                //    map[x - 1, y].NumAdjacentBombs++;
                //}
                //else
                //{
                //    map[x + 1, y + 1].NumAdjacentBombs++;
                //    map[x, y - 1].NumAdjacentBombs++;
                //    map[x, y + 1].NumAdjacentBombs++;
                //    map[x - 1, y + 1].NumAdjacentBombs++;
                //    map[x + 1, y - 1].NumAdjacentBombs++;
                //    map[x + 1, y].NumAdjacentBombs++;
                //    map[x - 1, y - 1].NumAdjacentBombs++;
                //    map[x - 1, y].NumAdjacentBombs++;
                //}
                #endregion //bortkommenterad

            }
        }

        public static void HandleClick(int x, int y, GameBoard gameBoard)
        {
            if (!(x < 0 || y < 0 || x >= gameBoard.dimension || y >= gameBoard.dimension))
            {
                Tile tileClicked = gameBoard.Tiles[x, y];
                if (!(tileClicked.IsClicked || tileClicked.IsFlagged || tileClicked.IsBomb))
                {
                    tileClicked.IsClicked = true;
                    gameBoard.AmountOfTilesClicked++;
                    if (tileClicked.NumAdjacentBombs == 0)
                    {
                        HandleClick(x + 1, y, gameBoard);
                        HandleClick(x + 1, y - 1, gameBoard);
                        HandleClick(x + 1, y + 1, gameBoard);
                        HandleClick(x - 1, y - 1, gameBoard);
                        HandleClick(x - 1, y + 1, gameBoard);
                        HandleClick(x - 1, y, gameBoard);
                        HandleClick(x, y + 1, gameBoard);
                        HandleClick(x, y - 1, gameBoard);
                    }
                }
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

        public static void DisplayAll(GameBoard gameBoard)
        {
            foreach (var tile in gameBoard.Tiles)
            {

                tile.IsClicked = true;
            }
        }
    }
}
