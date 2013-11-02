using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace WP8.Views
{
    public partial class ViewCard : PhoneApplicationPage
    {
        public ViewCard()
        {
            InitializeComponent();
        }

        private void ApplicationBarCheckButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Actioned. Added to Deck.");
        }

        private void ApplicationBarShareButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Shared to Twitter.");
        }
    }
}