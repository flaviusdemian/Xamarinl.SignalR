package signalrdemo.android.adapters;


public class MessagesAdapter
	extends android.widget.ArrayAdapter
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_getCount:()I:GetGetCountHandler\n" +
			"n_getView:(ILandroid/view/View;Landroid/view/ViewGroup;)Landroid/view/View;:GetGetView_ILandroid_view_View_Landroid_view_ViewGroup_Handler\n" +
			"";
		mono.android.Runtime.register ("SignalRDemo.Android.Adapters.MessagesAdapter, SignalRDemo.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MessagesAdapter.class, __md_methods);
	}


	public MessagesAdapter (android.content.Context p0, int p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == MessagesAdapter.class)
			mono.android.TypeManager.Activate ("SignalRDemo.Android.Adapters.MessagesAdapter, SignalRDemo.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1 });
	}


	public MessagesAdapter (android.content.Context p0, int p1, int p2) throws java.lang.Throwable
	{
		super (p0, p1, p2);
		if (getClass () == MessagesAdapter.class)
			mono.android.TypeManager.Activate ("SignalRDemo.Android.Adapters.MessagesAdapter, SignalRDemo.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public MessagesAdapter (android.content.Context p0, int p1, java.lang.Object[] p2) throws java.lang.Throwable
	{
		super (p0, p1, p2);
		if (getClass () == MessagesAdapter.class)
			mono.android.TypeManager.Activate ("SignalRDemo.Android.Adapters.MessagesAdapter, SignalRDemo.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:T[], Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public MessagesAdapter (android.content.Context p0, int p1, int p2, java.lang.Object[] p3) throws java.lang.Throwable
	{
		super (p0, p1, p2, p3);
		if (getClass () == MessagesAdapter.class)
			mono.android.TypeManager.Activate ("SignalRDemo.Android.Adapters.MessagesAdapter, SignalRDemo.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:T[], Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public MessagesAdapter (android.content.Context p0, int p1, java.util.List p2) throws java.lang.Throwable
	{
		super (p0, p1, p2);
		if (getClass () == MessagesAdapter.class)
			mono.android.TypeManager.Activate ("SignalRDemo.Android.Adapters.MessagesAdapter, SignalRDemo.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.Collections.Generic.IList`1<T>, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public MessagesAdapter (android.content.Context p0, int p1, int p2, java.util.List p3) throws java.lang.Throwable
	{
		super (p0, p1, p2, p3);
		if (getClass () == MessagesAdapter.class)
			mono.android.TypeManager.Activate ("SignalRDemo.Android.Adapters.MessagesAdapter, SignalRDemo.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.Collections.Generic.IList`1<T>, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public int getCount ()
	{
		return n_getCount ();
	}

	private native int n_getCount ();


	public android.view.View getView (int p0, android.view.View p1, android.view.ViewGroup p2)
	{
		return n_getView (p0, p1, p2);
	}

	private native android.view.View n_getView (int p0, android.view.View p1, android.view.ViewGroup p2);

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
