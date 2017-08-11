using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLLibrary
{
    public static class MySql
    {
        private static string connectionString = "Data Source = localhost; Initial Catalog = MineSweeper; Integrated Security = SSPI";
        static SqlConnection myConnection = new SqlConnection(connectionString);

        public static int AddHighScore(string playerName, string score, string difficulty)
        {
            int result;

            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;
                myCommand.CommandType = System.Data.CommandType.StoredProcedure;
                myCommand.CommandText = "sp_AddHighScore";

                SqlParameter paramPlayerName = new SqlParameter("@PlayerName", System.Data.DbType.String);
                paramPlayerName.Value = playerName;
                myCommand.Parameters.Add(paramPlayerName);

                SqlParameter paramScore = new SqlParameter("@Score", System.Data.DbType.String);
                paramScore.Value = score;
                myCommand.Parameters.Add(paramScore);

                SqlParameter paramDifficulty = new SqlParameter("@Difficulty", System.Data.DbType.String);
                paramDifficulty.Value = difficulty;
                myCommand.Parameters.Add(paramDifficulty);

                SqlParameter paramID = new SqlParameter();
                paramID.ParameterName = "@ID";
                paramID.DbType = System.Data.DbType.Int32;
                paramID.Direction = System.Data.ParameterDirection.Output;
                myCommand.Parameters.Add(paramID);

                myCommand.ExecuteNonQuery();

                result = Convert.ToInt32(paramID.Value.ToString());

            }
            catch(Exception e)
            {
                throw e;
            }
            finally
            {
                myConnection.Close();
            }

            return result;
        }
    
        public static HighScore[] LoadHighScore()
        {
            List<HighScore> highScoreList = new List<HighScore>();

            try
            {
                myConnection.Open();

                SqlCommand myCommand = new SqlCommand();
                myCommand.Connection = myConnection;
                myCommand.CommandType = System.Data.CommandType.StoredProcedure;
                myCommand.CommandText = $"sp_ReadHighScore";

                SqlParameter paramDifficulty = new SqlParameter("@Difficulty", System.Data.DbType.String);
                paramDifficulty.Value = "Hard";
                myCommand.Parameters.Add(paramDifficulty);

                SqlDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    int id = Convert.ToInt32(myReader["ID"].ToString());
                    string playerName = myReader["PlayerName"].ToString();
                    int score = Convert.ToInt32(myReader["Score"].ToString());
                    string difficulty = myReader["Difficulty"].ToString();

                    highScoreList.Add(new HighScore(id, playerName, score, difficulty));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                myConnection.Close();
            }

            return highScoreList.OrderBy(hs => hs.Score).ToArray(); // todo: ask håkanbråkan om vi behöver sortera listan
        }
    }
}
