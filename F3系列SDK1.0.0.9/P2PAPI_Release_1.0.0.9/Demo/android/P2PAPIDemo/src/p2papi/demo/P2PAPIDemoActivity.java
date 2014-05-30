package p2papi.demo;

import com.p2papi.jni.NativeCaller;

import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;

public class P2PAPIDemoActivity extends Activity {
	
	private Button btnStartP2PButton = null;
	private Button btnStopP2PButton = null;
	private Button btnStartVideoButton = null;
	private Button btnStopVideoButton = null;
	private Button btnStartAudioButton = null;
	private Button btnStopAudioButton = null;
	
    /** Called when the activity is first created. */
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main);
        
        NativeCaller.Init();
        
        btnStartP2PButton = (Button)findViewById(R.id.btnStartP2P);
        btnStopP2PButton = (Button)findViewById(R.id.btnStopP2P);
        btnStartVideoButton = (Button)findViewById(R.id.btnStartVideo);
        btnStopVideoButton = (Button)findViewById(R.id.btnStopVideo);
        btnStartAudioButton = (Button)findViewById(R.id.btnStartAudio);
        btnStopAudioButton = (Button)findViewById(R.id.btnStopAudio);
        
        btnStartP2PButton.setOnClickListener(new OnClickListener(){

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub		
				NativeCaller.StartP2P();
			}        	
        });
        
        btnStopP2PButton.setOnClickListener(new OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				NativeCaller.StopP2P();
			}
		});
        
        btnStartVideoButton.setOnClickListener(new OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				NativeCaller.StartVideo();
			}
		});
        
        btnStopVideoButton.setOnClickListener(new OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				NativeCaller.StopVideo();
			}
		});
        
        btnStartAudioButton.setOnClickListener(new OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				NativeCaller.StartAudio();
			}
		});
        
        btnStopAudioButton.setOnClickListener(new OnClickListener() {
			
			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				NativeCaller.StopAudio();
			}
		});
    }
}