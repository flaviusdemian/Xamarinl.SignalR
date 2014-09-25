using System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Microsoft.AspNet.SignalR.Client;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SignalRDemo.WindowsStore
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly IHubProxy loungeProxy;

        public MainPage()
        {
            InitializeComponent();

            // create connection
            var hubConnection = new HubConnection("http://signalrmeetupdemo.azurewebsites.net/signalr");

            // create proxy
            loungeProxy = hubConnection.CreateHubProxy("Lounge");

            loungeProxy.On<string>("pongHello",
                data =>
                    Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                        () => { pongTxt.Text += Environment.NewLine + data; })
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