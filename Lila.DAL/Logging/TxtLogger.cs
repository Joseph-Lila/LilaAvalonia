namespace Lila.DAL.Logging
{
    public class TxtLogger : BaseLogger
    {
        private readonly string _path;

        public TxtLogger(string path)
        {
            _path = path;
        }

        public override void LogSmth(string logItself)
        {
            base.LogSmth(logItself);
            using (StreamWriter writer = new StreamWriter(_path, true))
            {
                writer.WriteLine($"---> {DateTime.Now} : {logItself}");
            }
        }
    }
}