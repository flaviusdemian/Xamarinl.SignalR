using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.AspNet.SignalR.Client;

namespace SignalRDemo.Android
{
    [Application(Debuggable = true)]
    public class MyApplication : Application
    {

        public string currentPlayerName;
        public IHubProxy gameProxy;
        public IHubProxy loungeProxy;
        public string currentOpponentName;
        public bool gameStarted;
        public bool isMyTurn;
        public MyApplication(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            try
            {
                base.OnCreate();
                // do application specific things here
                InitializeGameLogic();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void InitializeGameLogic()
        {
            try
            {
                // create connection
                var hubConnection = new HubConnection("http://localhost:99/signalr");

                // create proxy
                loungeProxy = hubConnection.CreateHubProxy("Lounge");
                gameProxy = hubConnection.CreateHubProxy("gameHub");

                // set random name
                currentPlayerName = Guid.NewGuid().ToString();

                //loungeProxy.On<string>("pongHello",
                //    data => pongTxt.Dispatcher.BeginInvoke(
                //        new Action(() => { pongTxt.Text += Environment.NewLine + data; })
                //        )
                //    );

                //loungeProxy.On<string[]>("getPlayersForCurrentRoom",
                //    players => availablePlayers.Dispatcher.BeginInvoke(
                //        new Action(() =>
                //        {
                //            MainActivity.lv_players..Items.Clear();
                //            if (players != null && players.Count() > 0)
                //            {
                //                foreach (string player in players)
                //                {
                //                    if (player != currentPlayerName)
                //                    {
                //                        availablePlayers.Items.Add(player);
                //                    }
                //                }
                //            }
                //        })
                //        )
                //    );

                //loungeProxy.On<string>("removePlayerFromCurrentRoom",
                //    player => availablePlayers.Dispatcher.BeginInvoke(
                //        new Action(() =>
                //        {
                //            if (!string.IsNullOrEmpty(player))
                //            {
                //                availablePlayers.Items.Remove(player);
                //            }
                //        })
                //        )
                //    );

                //loungeProxy.On<string>("addPlayerToCurrentRoom",
                //    player => availablePlayers.Dispatcher.BeginInvoke(
                //        new Action(() =>
                //        {
                //            if (!string.IsNullOrEmpty(player) && player != currentPlayerName)
                //            {
                //                availablePlayers.Items.Add(player);
                //            }
                //        })
                //        )
                //    );

                //loungeProxy.On<string>("goToGame",
                //    opponent => nonGameStuff.Dispatcher.BeginInvoke(
                //        new Action(() =>
                //        {
                //            //nonGameStuff.Visibility = Visibility.Hidden;
                //            currentOpponentName = opponent;
                //            opponentName.Text = opponent;
                //            //gameBox.Visibility = Visibility.Visible;
                //            gameStarted = false;

                //            gameProxy.Invoke("connectToOpponent", currentOpponentName, currentPlayerName);
                //        })
                //        )
                //    );


                //gameProxy.On<string>("startGame",
                //    xPlayerName => gameStatus.Dispatcher.BeginInvoke(new Action(() =>
                //    {
                //        if (xPlayerName == currentPlayerName)
                //        {
                //            turnLbl.Text = "your";
                //            isMyTurn = true;
                //        }
                //        else
                //        {
                //            turnLbl.Text = "opponent's";
                //            isMyTurn = false;
                //        }

                //        gameStarted = true;
                //        gameStatus.Text = "started";
                //        MessageBox.Show("Best of luck!", "Game started");
                //    })
                //        )
                //    );


                //gameProxy.On<string>("gameOver",
                //    winner => gameStatus.Dispatcher.BeginInvoke(new Action(() =>
                //    {
                //        if (!string.IsNullOrEmpty(winner))
                //        {
                //            if (winner == currentPlayerName)
                //            {
                //                gameStatus.Text = "finished. You won! Congratulations!";
                //                MessageBox.Show("You won! Congratulations!", "Game over!");
                //            }
                //            else
                //            {
                //                gameStatus.Text = "finished. " + currentOpponentName + " won. Better luck next time!";
                //                MessageBox.Show(currentOpponentName + " won. Better luck next time!", "Game over!");
                //            }
                //        }
                //        else
                //        {
                //            gameStatus.Text = "finished. It's a tie.";
                //            MessageBox.Show("It's a tie.", "Game over!");
                //        }

                //        gameStarted = false;
                //        loungeProxy.Invoke("connectToRoom", "General", currentPlayerName);
                //        currentRoomName.Text = "General";
                //        nonGameStuff.Visibility = Visibility.Visible;
                //        gameBox.Visibility = Visibility.Hidden;

                //        gameBtn_0.Content = " ";
                //        gameBtn_1.Content = " ";
                //        gameBtn_2.Content = " ";
                //        gameBtn_3.Content = " ";
                //        gameBtn_4.Content = " ";
                //        gameBtn_5.Content = " ";
                //        gameBtn_6.Content = " ";
                //        gameBtn_7.Content = " ";
                //        gameBtn_8.Content = " ";
                //    }))
                //    );


                //gameProxy.On<int, bool>("moveAccepted",
                //    (position, player) => turnLbl.Dispatcher.BeginInvoke(new Action(() =>
                //    {
                //        string buttonName = "gameBtn_" + position;
                //        var buttonToChange = gameBox.FindName(buttonName) as Button;
                //        if (buttonToChange != null)
                //        {
                //            if (player)
                //            {
                //                buttonToChange.Content = "X";
                //            }
                //            else
                //            {
                //                buttonToChange.Content = "0";
                //            }
                //            isMyTurn = !isMyTurn;
                //            if (turnLbl.Text == "your")
                //            {
                //                turnLbl.Text = "opponent's";
                //            }
                //            else
                //            {
                //                turnLbl.Text = "your";
                //            }
                //        }
                //    })));

                //hubConnection.Start().Wait();

                //// connect to the default room
                //loungeProxy.Invoke("connectToRoom", "General", currentPlayerName);
                //currentRoomName.Text = "General";
                //playerName.Text = currentPlayerName;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Toast.MakeText(this, ex.ToString(), ToastLength.Long);
            }
        }
    }
}