using System;
using System.Windows;

namespace WP8.BusinessLayer.Common
{
    public class MessageDialog
    {
        public static MessageBoxResult ShowMessage(string message)
        {
            return ShowMessage(message, String.Empty, MessageBoxButton.OK);
        }

        public static MessageBoxResult ShowMessage(string message, string title)
        {
            return ShowMessage(message, title, MessageBoxButton.OK);
        }

        public static MessageBoxResult ShowMessage(string message, string title, MessageBoxButton buttons)
        {
            return MessageBox.Show(message, title, buttons);
        }
    }
}
