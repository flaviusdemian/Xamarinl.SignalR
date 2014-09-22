using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SignalRDemo.WindowsStore
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private IHubProxy loungeProxy;

        public MainPage()
        {
            this.InitializeComponent();

            // create connection
            var hubConnection = new HubConnection("http://localhost:5678/signalr");
            //var hubConnection = new HubConnection("http://signalrtictactoe.azurewebsites.net/signalr");

            // create proxy
            loungeProxy = hubConnection.CreateHubProxy("Lounge");

            loungeProxy.On<string>("pongHello",
                data => Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        pongTxt.Text += Environment.NewLine + data;
                    })
            );

            hubConnection.Start().Wait();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            loungeProxy.Invoke<string>("pingHello", pingTxt.Text);
            pingTxt.Text = "";
        }
    }
}
