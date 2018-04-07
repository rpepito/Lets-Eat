package md54d6069665a4ee24d63f2a17d1f9bbbb0;


public class AddDish
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("LetsEat.Views.OwnerSide.AddDish, LetsEat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", AddDish.class, __md_methods);
	}


	public AddDish ()
	{
		super ();
		if (getClass () == AddDish.class)
			mono.android.TypeManager.Activate ("LetsEat.Views.OwnerSide.AddDish, LetsEat, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
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
