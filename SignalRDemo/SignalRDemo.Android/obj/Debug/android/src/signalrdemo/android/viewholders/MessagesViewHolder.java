package signalrdemo.android.viewholders;


public class MessagesViewHolder
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("SignalRDemo.Android.ViewHolders.MessagesViewHolder, SignalRDemo.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MessagesViewHolder.class, __md_methods);
	}


	public MessagesViewHolder () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MessagesViewHolder.class)
			mono.android.TypeManager.Activate ("SignalRDemo.Android.ViewHolders.MessagesViewHolder, SignalRDemo.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

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
