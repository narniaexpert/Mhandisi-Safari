package com.p2papi.jni;


public class NativeCaller {
    /** Called when the activity is first created. */
	
	static {		
		System.loadLibrary("ffmpeg");
		System.loadLibrary("p2papi_jni");		
	}
		
	private static final String LOG_TAG = "NativeCaller" ;	
	
	public native static void Init();
	public native static void Free();	
	public native static int StartP2P();
	public native static int StopP2P();
	public native static int StartVideo();
	public native static int StopVideo();
	public native static int StartAudio();
	public native static int StopAudio();	
    
}