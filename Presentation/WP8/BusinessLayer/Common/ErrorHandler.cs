using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP8.Resources;

namespace WP8.BusinessLayer.Common
{
    public class ErrorHandler
    {
        public static void HandleError(Exception exception)
        {
            HandleError(exception, string.Empty, true);
        }

        public static void HandleError(Exception exception, bool showMessage)
        {
            HandleError(exception, string.Empty, showMessage);
        }

        public static void HandleError(Exception exception, string title)
        {
            HandleError(exception, title, true);
        }

        public static void HandleError(Exception exception, string title, bool showMessage)
        {
            string errorTitle = AppResources.ErrorDefaultTitle;
            string errorMessage = AppResources.ErrorDefaultMessage;

            if (!string.IsNullOrEmpty(title))
            {
                errorTitle = title;
            }

            if (showMessage)
            {
                MessageDialog.ShowMessage(errorMessage, errorTitle);
            }

#if DEBUG
            WriteExceptionsToOutputWindow(exception);
#endif
        }

        private static void WriteExceptionsToOutputWindow(Exception exception)
        {
            WriteToOutputDebugWindow("EXCEPTION: {0} {1} STACK TRACE: {2}", exception.Message, exception.InnerException != null ? " HAS INNER EXCEPTION" : "", exception.StackTrace);

            while (exception.InnerException != null)
            {
                WriteToOutputDebugWindow("EXCEPTION -> INNER EXCEPTION: {0}", exception.InnerException);
                exception = exception.InnerException;
            }
        }

        private static void WriteToOutputDebugWindow(string format, params object[] args)
        {
            string s = string.Format(format, args);
            System.Diagnostics.Debug.WriteLine("---Logger--- " + DateTime.Now.ToString("yyyyMMdd hh:mm:ss:ffff") + s);
        }
    }
}
