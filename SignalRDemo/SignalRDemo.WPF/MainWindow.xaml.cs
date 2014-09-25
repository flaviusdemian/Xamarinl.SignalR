using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.AspNet.SignalR.Client;

namespace SignalRDemo.WPF
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string currentPlayerName;
        private readonly IHubProxy gameProxy;
        private readonly IHubProxy loungeProxy;
        private string currentOpponentName;
        private bool gameStarted;
        private bool isMyTurn;

        public MainWindow()
        {
            InitializeComponent();

            // create connection
            var hubConnection = new HubConnection("http://signalrmeetupdemo.azurewebsites.net/signalr");

            // create proxy
            loungeProxy = hubConnection.CreateHubProxy("Lounge");
            gameProxy = hubConnection.CreateHubProxy("gameHub");

            // set random name
            currentPlayerName = Guid.NewGuid().ToString();

            loungeProxy.On<string>("pongHello",
                data => pongTxt.Dispatcher.BeginInvoke(
                    new Action(() => { pongTxt.Text += Environment.NewLine + data; })
                    )
                );

            loungeProxy.On<string[]>("getPlayersForCurrentRoom",
                players => availablePlayers.Dispatcher.BeginInvoke(
                    new Action(() =>
                    {
                        availablePlayers.Items.Clear();
                        if (players != null && players.Count() > 0)
                        {
                            foreach (string player in players)
                            {
                                if (player != currentPlayerName)
                                {
                                    availablePlayers.Items.Add(player);
                                }
                            }
                        }
                    })
                    )
                );

            loungeProxy.On<string>("removePlayerFromCurrentRoom",
                player => availablePlayers.Dispatcher.BeginInvoke(
                    new Action(() =>
                    {
                        if (!string.IsNullOrEmpty(player))
                        {
                            availablePlayers.Items.Remove(player);
                        }
                    })
                    )
                );

            loungeProxy.On<string>("addPlayerToCurrentRoom",
                player => availablePlayers.Dispatcher.BeginInvoke(
                    new Action(() =>
                    {
                        if (!string.IsNullOrEmpty(player) && player != currentPlayerName)
                        {
                            availablePlayers.Items.Add(player);
                        }
                    })
                    )
                );

            loungeProxy.On<string>("goToGame",
                opponent => nonGameStuff.Dispatcher.BeginInvoke(
                    new Action(() =>
                    {
                        nonGameStuff.Visibility = Visibility.Hidden;
                        currentOpponentName = opponent;
                        opponentName.Text = opponent;
                        gameBox.Visibility = Visibility.Visible;
                        gameStarted = false;

                        gameProxy.Invoke("connectToOpponent", currentOpponentName, currentPlayerName);
                    })
                    )
                );


            gameProxy.On<string>("startGame",
                xPlayerName => gameStatus.Dispatcher.BeginInvoke(new Action(() =>
                {
                    if (xPlayerName == currentPlayerName)
                    {
                        turnLbl.Text = "your";
                        isMyTurn = true;
                    }
                    else
                    {
                        turnLbl.Text = "opponent's";
                        isMyTurn = false;
                    }

                    gameStarted = true;
                    gameStatus.Text = "started";
                    MessageBox.Show("Best of luck!", "Game started");
                })
                    )
                );


            gameProxy.On<string>("gameOver",
                winner => gameStatus.Dispatcher.BeginInvoke(new Action(() =>
                {
                    if (!string.IsNullOrEmpty(winner))
                    {
                        if (winner == currentPlayerName)
                        {
                            gameStatus.Text = "finished. You won! Congratulations!";
                            MessageBox.Show("You won! Congratulations!", "Game over!");
                        }
                        else
                        {
                            gameStatus.Text = "finished. " + currentOpponentName + " won. Better luck next time!";
                            MessageBox.Show(currentOpponentName + " won. Better luck next time!", "Game over!");
                        }
                    }
                    else
                    {
                        gameStatus.Text = "finished. It's a tie.";
                        MessageBox.Show("It's a tie.", "Game over!");
                    }

                    gameStarted = false;
                    loungeProxy.Invoke("connectToRoom", "General", currentPlayerName);
                    currentRoomName.Text = "General";
                    nonGameStuff.Visibility = Visibility.Visible;
                    gameBox.Visibility = Visibility.Hidden;

                    gameBtn_0.Content = " ";
                    gameBtn_1.Content = " ";
                    gameBtn_2.Content = " ";
                    gameBtn_3.Content = " ";
                    gameBtn_4.Content = " ";
                    gameBtn_5.Content = " ";
                    gameBtn_6.Content = " ";
                    gameBtn_7.Content = " ";
                    gameBtn_8.Content = " ";
                }))
                );


            gameProxy.On<int, bool>("moveAccepted",
                (position, player) => turnLbl.Dispatcher.BeginInvoke(new Action(() =>
                {
                    string buttonName = "gameBtn_" + position;
                    var buttonToChange = gameBox.FindName(buttonName) as Button;
                    if (buttonToChange != null)
                    {
                        if (player)
                        {
                            buttonToChange.Content = "X";
                        }
                        else
                        {
                            buttonToChange.Content = "0";
                        }
                        isMyTurn = !isMyTurn;
                        if (turnLbl.Text == "your")
                        {
                            turnLbl.Text = "opponent's";
                        }
                        else
                        {
                            turnLbl.Text = "your";
                        }
                    }
                })));

            hubConnection.Start().Wait();

            // connect to the default room
            loungeProxy.Invoke("connectToRoom", "General", currentPlayerName);
            currentRoomName.Text = "General";
            playerName.Text = currentPlayerName;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            loungeProxy.Invoke<string>("pingHello", pingTxt.Text);
            pingTxt.Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            loungeProxy.Invoke("connectToRoom", roomTxt.Text, currentPlayerName);
            currentRoomName.Text = roomTxt.Text;
            roomTxt.Text = "";
        }

        private void connectBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (string) availablePlayers.SelectedItem;
            if (!string.IsNullOrEmpty(selectedItem))
            {
                loungeProxy.Invoke("startNewGame", selectedItem, currentPlayerName);
            }
            else
            {
                MessageBox.Show("You must select an opponet first from the list!", "Eh-eh!");
            }
        }

        private void gameBtn_0_Click(object sender, RoutedEventArgs e)
        {
            // this is a big coding NO NO!
            string buttonName = (sender as Button).Name;
            int position = int.Parse(buttonName.Substring(buttonName.IndexOf('_') + 1, 1));
                // uhhhh it hurts to see this :)

            if (gameStarted && isMyTurn)
            {
                gameProxy.Invoke<int>("addMove", position);
            }
            else
            {
                MessageBox.Show("Game is not started or it's not your turn!", "Wait a sec");
            }
        }
    }
}