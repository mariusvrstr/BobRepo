using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Phone.Controls;

namespace WP8.BusinessLayer.Common
{
    public class Navigate
    {
        /// <summary>
        /// Navigates to the given page url
        /// </summary>
        /// <param name="pageUrl">The page to navigate to. Include full path.</param>
        public static void ToPage(string uri)
        {
            ToPage(uri, null);
        }

        /// <summary>
        /// Navigates to the given page url
        /// </summary>
        /// <param name="uri">The page to navigate to. Include full path.</param>
        /// <param name="parameters">Key and value pairs of parameters.</param>
        public static void ToPage(string uri, IDictionary<string, string> parameters)
        {
            PhoneApplicationFrame frame = Application.Current.RootVisual as PhoneApplicationFrame;
            if (frame == null)
            {
                return;
            }

            StringBuilder uriBuilder = new StringBuilder();
            uriBuilder.Append(uri);
            if (parameters != null && parameters.Count > 0)
            {
                uriBuilder.Append("?");
                bool prependAmp = false;
                foreach (KeyValuePair<string, string> parameterPair in parameters)
                {
                    if (prependAmp)
                    {
                        uriBuilder.Append("&");
                    }
                    uriBuilder.AppendFormat("{0}={1}", parameterPair.Key, parameterPair.Value);
                    prependAmp = true;
                }
            }

            uri = uriBuilder.ToString();
            frame.Navigate(new Uri(uri, UriKind.RelativeOrAbsolute));
        }

        public static void GoBack()
        {
            var frame = Application.Current.RootVisual as PhoneApplicationFrame;
            if (frame != null && frame.CanGoBack)
            {
                frame.GoBack();
            }
        }

        public static void PauseNavigatingBack()
        {
            var frame = Application.Current.RootVisual as PhoneApplicationFrame;
            if (frame != null)
            {
                frame.BackKeyPress += (sender, args) => { args.Cancel = true; };
            }
        }

        public static void ResumeNavigatingBack()
        {
            var frame = Application.Current.RootVisual as PhoneApplicationFrame;
            if (frame != null)
            {
                frame.BackKeyPress += (sender, args) => { args.Cancel = false; };
            }
        }
    }
}
