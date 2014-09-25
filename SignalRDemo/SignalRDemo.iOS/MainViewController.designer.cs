// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace SignalRDemo.iOS
{
	[Register ("MainViewController")]
	partial class MainViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btn_Send { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField et_content { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView tblv_message { get; set; }

		[Action ("btn_Send_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void btn_Send_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (btn_Send != null) {
				btn_Send.Dispose ();
				btn_Send = null;
			}
			if (et_content != null) {
				et_content.Dispose ();
				et_content = null;
			}
			if (tblv_message != null) {
				tblv_message.Dispose ();
				tblv_message = null;
			}
		}
	}
}
