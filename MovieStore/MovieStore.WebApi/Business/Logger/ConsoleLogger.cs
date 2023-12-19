namespace MovieStore.WebApi.Business.Logger
{
    public class ConsoleLogger : ILoggerService
    {
        public void WriteLog(string message)
        {
            Console.WriteLine($"Message:{message}");
        }
    }
}
