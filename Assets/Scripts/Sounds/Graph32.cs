using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Graph32 : MonoBehaviour {
	int pos = 0; //Pos é o indice do vetor de pontos a serem traçadas as retas
	float yvalue; // Valor em y da função y = f(x)
	Vector3[] positions = new Vector3[512]; //Vetor de posições
	private LineRenderer lr; //LineRenderer lr
	public Slider F1; //Slider F1 para Fequência de corte do FPB
	public Slider F2; //Slider F2 para FrequÊncia de corte do FPA
	public Text FPBFC;
	public Text FPAFC;
	public float Amp;

	AudioSource audio;

	void Start () {
		lr = GetComponent<LineRenderer>(); //lr recebe a componente LindeRenderer do GameObject que contém o Script
		audio = GetComponent<AudioSource>();
		//AudioSource aud = GetComponent<AudioSource>();
		//aud.clip = Microphone.Start("Built-in Microphone", true, 10, 44100);
		audio.Play();
		FPBFC.text = "0";
		FPAFC.text = "0";
		F1.ToString ();
		F2.ToString ();
		foreach (string device in Microphone.devices) {
			Debug.Log("Name: " + device);
		}
	}
		
	void Update () {
		float[] spectrum = new float[512]; //Declaração do Vetor para coletar os valores de Espectro
		AudioListener.GetSpectrumData( spectrum, 0, FFTWindow.Rectangular ); //A função Coleta os valores de magnetude do Espectro e aloca no Vetor Spectrum
		//AudioListener.GetOutputData(spectrum, 0);
		GetComponent<AudioLowPassFilter>().cutoffFrequency = (float)F1.value; //Filtro Passa baixa recebe como frequência de corte o Slider F1
		GetComponent<AudioHighPassFilter>().cutoffFrequency = (float)F2.value; //Idem para o FPA
		FPBFC.text = F1.value.ToString() + "Hz"; //Printa os valores das frequências
		FPAFC.text = F2.value.ToString() + "Hz";

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