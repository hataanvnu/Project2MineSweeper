using SQLLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project2MineSweeper
{
    public partial class HighScorePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HighScore[] highScore = MySql.LoadHighScore();

            string highScoreBody = "";

            for (int i = 0; i < highScore.Length; i++)
            {
                highScoreBody += "<tr>";
                highScoreBody += $"<td>{i+1}</td>";
                highScoreBody += $"<td>{highScore[i].PlayerName}</td>";
                highScoreBody += $"<td>{highScore[i].Score}</td>";
                highScoreBody += "</tr>";
            }


            LiteralHighScore.Text = highScoreBody;
        }
    }
}