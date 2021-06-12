using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GraphRecord : MonoBehaviour {
	int pos = 0; //Pos é o indice do vetor de pontos a serem traçadas as retas
	float yvalue; // Valor em y da função y = f(x)
	Vector3[] positions = new Vector3[512]; //Vetor de posições
	private LineRenderer lr; //LineRenderer lr
	public float Amp;
	public Button StartRecord;
	public Button Stop;
	public Button Play1;
	AudioSource aud;
	public float RecordTime = 1f;
	public float StartTime;
	public Text TimeText;
	public float TimeAux;
	int i = 0;
	
	void Start () {
		lr = GetComponent<LineRenderer>(); //lr recebe a componente LindeRenderer do GameObject que contém o Script
		//audio = GetComponent<AudioSource>();
		aud = GetComponent<AudioSource>();
		//aud.clip = Microphone.Start("Built-in Microphone", false, 10, 44100);
		//aud.clip = Microphone.End("Built-in Microphone");
		//aud.Play();

		//Record = StateRecording.NaoGravando;
		
		Button btn = StartRecord.GetComponent<Button>();
		btn.onClick.AddListener(AoApertarStartRecord);

		Button btn1 = Stop.GetComponent<Button>();
		btn1.onClick.AddListener(AoApertarStop);

		Button btn2 = Play1.GetComponent<Button>();
		btn2.onClick.AddListener(AoApertarPlay);


		/*	foreach (string device in Microphone.devices) {
			Debug.Log("Name: " + device);
		}*/
	}
		

	void AoApertarStartRecord(){
		aud.clip = Microphone.Start("Built-in Microphone", false, (int) RecordTime, 44100);
		StartTime = Time.time;
	//	i = i+1;
	//	print(i);
		//RecordTime = StartTime;
			
		//Record = StateRecording.Gravando;
	}
	void AoApertarStop(){
		//aud.clip = Microphone.Start("Built-in Microphone", false, 10, 44100);
		Microphone.End("Built-in Microphone");
		TimeAux = RecordTime;
		//RecordTime = Time.time;
		//Record = StateRecording.SalvandoAudio;
		
	}
	void AoApertarPlay(){
		//Record = StateRecording.Play;
		aud.Play();
	}


	void Update () {
		if(Microphone.IsRecording("Built-in Microphone") == true){
			RecordTime =  Time.time - StartTime;
			TimeAux = RecordTime;
		//	print("Esta Gravando");
		}else{
			
		//	RecordTime = TimeAux;
			//print("Não Esta Gravando");
		}
		TimeText.text = "Tempo: "+ TimeAux.ToString("f2");
		RecordTime =  Time.time - StartTime;
				
		float[] spectrum = new float[512]; //Declaração do Vetor para coletar os valores de Espectro
		AudioListener.GetSpectrumData( spectrum, 0, FFTWindow.Rectangular ); //A função Coleta os valores de magnetude do Espectro e aloca no Vetor Spectrum
		//AudioListener.GetOutputData(spectrum, 0);
		/////Printa o gráfico com os valores do Vetor Espectro
	for( pos = 0; pos < spectrum.Length; pos++ )
	{	
			spectrum [pos] = Amp * spectrum [pos];
		yvalue = spectrum[pos];
		positions[pos] = new Vector3(pos*0.1f, 10*yvalue,0);
		lr.SetPositions (positions);	
	}


}


}

///O que tem de ferra Mercado de PLUG-IN's - para processamento de áudio HOME STUDIO - Nomes:  Pro Tools - Cubase - Ableton - Waves
/// 
/// 
/// 