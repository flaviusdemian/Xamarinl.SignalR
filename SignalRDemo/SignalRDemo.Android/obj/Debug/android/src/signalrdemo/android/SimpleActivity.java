package signalrdemo.android;


public class SimpleActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("SignalRDemo.Android.SimpleActivity, SignalRDemo.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", SimpleActivity.class, __md_methods);
	}


	public SimpleActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == SimpleActivity.class)
			mono.android.TypeManager.Activate ("SignalRDemo.Android.SimpleActivity, SignalRDemo.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
