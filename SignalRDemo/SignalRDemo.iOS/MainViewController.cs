
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Microsoft.AspNet.SignalR.Client;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using SignalRDemo.iOS.TableHelpers;

namespace SignalRDemo.iOS
{
    public partial class MainViewController : UIViewController
    {
        private IHubProxy loungeProxy;
        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public MainViewController(IntPtr handle)
            : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        #region View lifecycle

        public override void ViewDidLoad()
        {
            try
            {
                base.ViewDidLoad();
                InitializeUI();
                // Perform any additional setup after loading the view, typically from a nib.
                var hubConnection = new HubConnection("http://signalrmeetupdemo.azurewebsites.net/signalr");
                // create proxy
                loungeProxy = hubConnection.CreateHubProxy("Lounge");

                loungeProxy.On<string>("pongHello", data =>
                {
                    try
                    {
                        InvokeOnMainThread(() =>
                        {
                            TableSource.tableItems.Add(data);
                            tblv_message.Source = new TableSource(TableSource.tableItems);
                            tblv_message.ReloadData();
                        });
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                });
                hubConnection.Start().Wait();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void InitializeUI()
        {
            tblv_message.Source = new TableSource(new List<string>());
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        #endregion

        partial void btn_Send_TouchUpInside(UIButton sender)
        {
            string message = et_content.Text;
            if (string.IsNullOrWhiteSpace(message) == false)
            {
                loungeProxy.Invoke<string>("pingHello", message);
                et_content.Text = "";
            }
        }
    }
}