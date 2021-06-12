using UnityEngine;
using System.Collections;

public class WaVesForms : MonoBehaviour {

	public float Ganho = 50;
	AudioSource audio;

	void Start(){
		audio = GetComponent<AudioSource>();
	}

	void Update( )
	{
		float[] spectrum = new float[512];
		float[] Amplitude = new float[512];

		AudioListener.GetSpectrumData( spectrum, 0, FFTWindow.Rectangular);
		AudioListener.GetOutputData( Amplitude, 0);

	for( int i = 1; i < spectrum.Length-1; i++ )
		{
			Debug.DrawLine( new Vector3( i - 1, spectrum[i] + 10, 0 ), new Vector3( i, spectrum[i + 1] + 10, 0 ), Color.red );
			Debug.DrawLine( new Vector3( i - 1, Mathf.Log( spectrum[i - 1] ), 0 ), new Vector3( i, Mathf.Log( spectrum[i] ), 0 ), Color.cyan ); //Em db
			Debug.DrawLine( new Vector3( Mathf.Log( i - 1 ), spectrum[i - 1] - 10, 1 ), new Vector3( Mathf.Log( i ), spectrum[i] - 10, 1 ), Color.green ); //Frequencia em Escala Log
			Debug.DrawLine( new Vector3( Mathf.Log( i - 1 ), Mathf.Log( spectrum[i - 1] ), 3 ), new Vector3( Mathf.Log( i ), Mathf.Log( spectrum[i] ), 3 ), Color.blue ); //Bode

			Debug.DrawLine( new Vector3( i - 1, Ganho*(Amplitude[i])-20, 0 ), new Vector3( i, Ganho*(Amplitude[i + 1])-20, 0 ), Color.red );

		}
	}
}
