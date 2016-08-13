namespace VKMessages.Data
{
    public static class Scripts
    {
        public const string CreateDatabase = 
            @"CREATE TABLE AccessTokens (
                AccessToken STRING NOT NULL
               );";

        public const string UpdateAccessToken = @"UPDATE AccessTokens SET AccessToken = '{0}'";
        
        public const string SelectAccessToken = @"SELECT AccessToken FROM AccessTokens;";

        public const string InsertAccessToken = @"INSERT INTO AccessTokens (
                           AccessToken
                       )
                       VALUES (
                           '{0}'
                       );
";
    }
}