package plugin.LocalNotification;


public class GeofenceTransitionsIntentReceiver
	extends android.content.BroadcastReceiver
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onReceive:(Landroid/content/Context;Landroid/content/Intent;)V:GetOnReceive_Landroid_content_Context_Landroid_content_Intent_Handler\n" +
			"";
		mono.android.Runtime.register ("Plugin.LocalNotification.Platforms.GeofenceTransitionsIntentReceiver, Plugin.LocalNotification", GeofenceTransitionsIntentReceiver.class, __md_methods);
	}


	public GeofenceTransitionsIntentReceiver ()
	{
		super ();
		if (getClass () == GeofenceTransitionsIntentReceiver.class) {
			mono.android.TypeManager.Activate ("Plugin.LocalNotification.Platforms.GeofenceTransitionsIntentReceiver, Plugin.LocalNotification", "", this, new java.lang.Object[] {  });
		}
	}


	public void onReceive (android.content.Context p0, android.content.Intent p1)
	{
		n_onReceive (p0, p1);
	}

	private native void n_onReceive (android.content.Context p0, android.content.Intent p1);

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
