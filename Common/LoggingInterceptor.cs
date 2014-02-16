using System;
using Ninject.Extensions.Interception;

namespace Common
{
    public class LoggingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            ILogger log = LogManager.GetLogger(invocation.Request.Method.DeclaringType);
            string methodName = invocation.Request.Method.Name;

            try
            {
                log.InfoFormat("===================== Entering Method: {0} =====================", methodName);
                log.InfoFormat("Arguments:");
                Array.ForEach(invocation.Request.Arguments, arg => log.Info(arg));

                log.InfoFormat("Invoking Method: {0}", methodName);
                invocation.Proceed();
            }
            catch (Exception ex)
            {
                log.Error("Exception occurred", ex);
                throw;
            }
            finally
            {
                log.InfoFormat("Return Values: ");
                if (invocation.ReturnValue != null)
                    log.Info(invocation.ReturnValue);
                else
                    log.InfoFormat("No return value");

                log.InfoFormat("===================== Exiting Method: {0} =====================", methodName);
            }
        }
    }
}
