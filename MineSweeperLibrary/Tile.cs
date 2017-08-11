using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperLibrary
{
    public class Tile
    {
        public bool IsFlagged { get; set; }

        public bool IsBomb { get; set; }

        public bool IsClicked { get; set; }

        public int NumAdjacentBombs { get; set; }

        public Tile(bool isBomb)
        {
            IsBomb = isBomb;
            IsFlagged = false;
            IsClicked = false;
            NumAdjacentBombs = 0;
        }

        public Tile()
        {
            IsBomb = false;
            IsFlagged = false;
            IsClicked = false;
            NumAdjacentBombs = 0;
        }
    }
}
