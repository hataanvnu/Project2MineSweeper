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
            if (Request["x"] != null && Request["y"] != null)
            {
                int y = Convert.ToInt32(Request["y"]);
                int x = Convert.ToInt32(Request["x"]);

            }
        }

        protected void BtnStartGame_Click(object sender, EventArgs e)
        {
            GameBoard board = GameController.InitializeGame();



            string boardHtml = "";

            for (int y = 0; y < 10; y++)
            {
                boardHtml += "<tr>";
                for (int x = 0; x < 10; x++)
                {
                    boardHtml += "<td>";

                    //boardHtml += $"<asp:Button ID='Button' runat='server' Text='{i}_{j}' />";
                    boardHtml += $"<input id='Button_{x}_{y}' class='element' type='button' value='{x}_{y}' style='width: 50px; height: 50px;'/>";
                    // <a href='Index.aspx?x={x}&y={y}'></a>
                    //
                    boardHtml += "</td>";
                }
                boardHtml += "</tr>";
            }

            LiteralBoard.Text = boardHtml;


        }


    }
}