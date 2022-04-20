namespace Lila.DAL.Logging
{
    public class BaseLogger
    {
        public virtual void LogSmth(string logItself)
        {
            Console.WriteLine($"---> {DateTime.Now} : {logItself}");
        }
    }
}