using System.Threading;

namespace Logging
{
    public class Calculator
    {
        //private static log4net.ILog log = log4net.LogManager.GetLogger(typeof(Calculator));
        public int CalculateExpensiveResult()
        {
            //log.Info("Beginning expensive calculation..");
            Thread.Sleep(3000);
            //log.Info("End expensive calculation...");
            return 100;
        }
    }
}