namespace Domain.Base
{
    public class Config
    {
        private static Config instance;

        private Config()
        {

        }

        public string ConnectionString { get; private set; }

        public static Config Instance()
        {
            if (instance == null) instance = new Config();
            return instance;
        }
    }
}