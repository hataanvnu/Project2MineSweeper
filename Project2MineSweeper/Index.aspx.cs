using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MineSweeperLibrary;

namespace Project2MineSweeper
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request["x"] != null && Request["y"] != null && Request["click"] != null)
            {
                int y = Convert.ToInt32(Request["y"]);
                int x = Convert.ToInt32(Request["x"]);
                string click = Request["click"];

                if (Session["gameboard"] != null)
                {
                    GameBoard gameBoard = (GameBoard)Session["gameboard"];
                    if (!gameBoard.GameOver)
                    {
                        Tile tileClicked = gameBoard.Tiles[x, y];

                        if (!tileClicked.IsClicked)
                        {
                            if (Request["click"] == "left" && !tileClicked.IsFlagged)
                            {
                                GameController.HandleClick(x, y, gameBoard);
                                if (tileClicked.IsBomb)
                                {
                                    GameController.EnableBombs(gameBoard);
                                    gameBoard.GameOver = true;
                                }
                            }
                            else if (Request["click"] == "right")
                            {
                                tileClicked.IsFlagged = !tileClicked.IsFlagged;
                            }
                        }
                        if (gameBoard.HasWon)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Grattis" + "');", true);
                        }

                    }
                    else
                    {
                        GameController.DisplayAll(gameBoard);
                    }
                    PrintGameBoard(gameBoard);

                    //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + gameBoard.Tiles[x, y] + "');", true);
                }

            }
        }

        private void PrintGameBoard(GameBoard gameBoard)
        {
            string boardHtml = "";

            for (int i = 0; i < 10; i++)
            {
                boardHtml += "<tr>";
                for (int j = 0; j < 10; j++)
                {
                    Tile tileClicked = gameBoard.Tiles[j, i];

                    boardHtml += "<td>";

                    boardHtml += $"<input id='Button_{j}_{i}' class='element' type='button' style='font-weight: bold; font-size: 30px; width: 50px; height: 50px;";

                    if (tileClicked.IsClicked)
                        if (tileClicked.IsBomb)
                            boardHtml += "background-color:red; color:white;' value='B'";
                        else
                        {
                            switch (tileClicked.NumAdjacentBombs)
                            {
                                case 0:
                                    boardHtml += "background-color:darkgreen;'";
                                    break;
                                case 1:
                                    boardHtml += "color:blue;'";
                                    break;
                                case 2:
                                    boardHtml += "color:green;'";
                                    break;
                                case 3:
                                    boardHtml += "color:red;'";
                                    break;
                                case 4:
                                    boardHtml += "color:purple;'";
                                    break;
                                default:
                                    boardHtml += "color:orangered;'";
                                    break;
                            }
                            boardHtml += $"value='{tileClicked.NumAdjacentBombs}'";
                        }
                    else if (tileClicked.IsFlagged)
                        boardHtml += "'value='F'";
                    else
                        boardHtml += "'value='&nbsp;'";

                    boardHtml += "</td>";
                }
                boardHtml += "</tr>";
            }

            LiteralBoard.Text = boardHtml;
        }

        protected void BtnStartGame_Click(object sender, EventArgs e)
        {
            GameBoard gameBoard = GameController.InitializeGame();

            Session["gameboard"] = gameBoard;

            PrintGameBoard(gameBoard);

        }


    }
}