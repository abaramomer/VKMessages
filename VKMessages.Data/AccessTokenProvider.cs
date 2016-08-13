using System.Configuration;
using System.Data.SQLite;

namespace VKMessages.Data
{
    public class AccessTokenProvider
    {
        public void Save(string accessToken)
        {
            var token = GetAccessToken();

            using (var connection = GetConnection().OpenAndReturn())
            {
                var script = string.IsNullOrEmpty(token) 
                    ? Scripts.InsertAccessToken 
                    : Scripts.UpdateAccessToken;
                var command = new SQLiteCommand(string.Format(script, accessToken), connection);

                command.ExecuteNonQuery();
            }
        }

        public string GetAccessToken()
        {
            using (var connection = GetConnection().OpenAndReturn())
            {
                var command = new SQLiteCommand(Scripts.SelectAccessToken, connection);

                using (var reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        return null;
                    }

                    reader.Read();

                    return reader["AccessToken"].ToString();
                }
            }
        }

        private SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(ConfigurationManager.AppSettings["dbConnectionString"]);
        }
    }
}