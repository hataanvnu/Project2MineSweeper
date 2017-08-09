using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperLibrary
{
    public static class GameController
    {
        public static GameBoard InitializeGame()
        {
            GameBoard board = new GameBoard(10);


            return board;
        }
    }
}
