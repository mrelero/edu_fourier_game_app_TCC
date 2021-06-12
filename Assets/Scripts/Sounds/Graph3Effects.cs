using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Graph3Effects : MonoBehaviour {
	int pos = -12; //Pos é o indice do vetor de pontos a serem traçadas as retas
	float yvalue; // Valor em y da função y = f(x)
	Vector3[] positions = new Vector3[512]; //Vetor de posições
	private LineRenderer lr; //LineRenderer lr
	enum StateAudio {Freq = 1, Tempo};
	int i = 0;
	//Botões
	public Button Temp;
	public Button Frquencia;
	public Button Play;
	public Button Stop;
	public Slider Volume;
	public Dropdown ListadeMusicas;
	public Button MainMenu;
	
	//CHORUS
	public Slider DepthSlider;
	public Slider RateSlider;
	public Slider DelaySlider;
	public Slider DryMix;
	public Toggle EnableChorus;
	
	//Tremolo
	public Slider FTremolo;
	public Toggle EnableTremolo;
	
	//Distortion
	public Slider LevelDistSlider;
	public Toggle EnableDistortion;
	
	//FPB
	public Slider FPB;
	public Toggle EnableFPB;
	
	//Distortion
	public Slider FPA;
	public Toggle EnableFPA;
	
	
	//AudiosClips
	public AudioClip[] Clips;
	StateAudio Estado;

	//TESTES
	
	AudioSource audio;
	int indiceAudio = 0;
	float[] samples ;
	float[] samples2;
	float[] samples3;
	
	void Start () {
		Estado = StateAudio.Freq;
		lr = GetComponent<LineRenderer>(); //lr recebe a componente LindeRenderer do GameObject que contém o Script
		audio = GetComponent<AudioSource>();
		
		Button btn = Temp.GetComponent<Button>();
		btn.onClick.AddListener(AoClicarTempo);
		
		Button btn1 = Frquencia.GetComponent<Button>();
		btn1.onClick.AddListener(AoClicarFrequencia);

		Button btn2 = Play.GetComponent<Button>();
		btn2.onClick.AddListener(AoClicarPlay);

		Button btn3 = Stop.GetComponent<Button>();
		btn3.onClick.AddListener(AoClicarStop);
		
		Button btn4 = MainMenu.GetComponent<Button>();
		btn4.onClick.AddListener(AoClicarMainMenu);
		///OnValueChange Dropdown
		ListadeMusicas.onValueChanged.AddListener(delegate
        {
            selectvalue(ListadeMusicas);
        });
		
		///INICIAL AUDIOS
		samples = new float[audio.clip.samples * audio.clip.channels];
		samples2 = new float[audio.clip.samples * audio.clip.channels];
		samples3 = new float[audio.clip.samples * audio.clip.channels];
		
		audio.clip.GetData(samples, 0); //Armazena os valores das amostras em Samples, com OffSet = 0
	}
	  private void selectvalue(Dropdown gdropdown)
    {
		
		audio.clip = Clips[ListadeMusicas.value];
		samples = new float[audio.clip.samples * audio.clip.channels];
		samples2 = new float[audio.clip.samples * audio.clip.channels];
		samples3 = new float[audio.clip.samples * audio.clip.channels];
		audio.clip.GetData(samples, 0); //Armazena os valores das amostras em Samples, com OffSet = 0
	
		print ("Oi");
    }
	void AoClicarTempo(){
		Estado = StateAudio.Tempo;
		print("Clicou Tempo");
	}
	
	void AoClicarFrequencia(){
		Estado = StateAudio.Freq;
		print("ClicouFreq");
	}
	
	void AoClicarPlay(){
		audio.Play();
		print("ClicouPlay");
	}
	
	void AoClicarStop(){
		audio.Pause();
		print("ClicouPause");
	}
	
	void AoClicarMainMenu(){
		SceneManager.LoadScene ("Menu", LoadSceneMode.Single);			
		print("ClicouMainMenu");
	}
	

void Update () {
		float[] spectrum = new float[512]; //Declaração do Vetor para coletar os valores de Espectro
		float[] spectrum2 = new float[512];

		//print (ListadeMusicas.value);
		switch(Estado){
			case StateAudio.Freq:
			{
				PlotarAudioNaFrequencia(spectrum2,pos,yvalue,positions,10,0,0.05f);
				break;
			}
			case StateAudio.Tempo:
			{
				PlotarAudioNoTempo(spectrum,pos,yvalue,positions,0,0);
				break;
			}
		}
	/*
	if(EnableChorus.isOn == true){
		GetComponent<AudioChorusFilter>().enabled = true;
		print("EnableChorus");
	}else{
		GetComponent<AudioChorusFilter>().enabled = false;
		print("NotEnable");
	}
	*/
	if(EnableDistortion.isOn == true){
		GetComponent<AudioDistortionFilter>().enabled = true;
	//	print("EnableChorus");
	}else{
		GetComponent<AudioDistortionFilter>().enabled = false;
	//	print("NotEnable");
	}
	
	if(EnableFPB.isOn == true){
		GetComponent<AudioLowPassFilter>().enabled = true;
	//	print("EnableFPB");
	}else{
		GetComponent<AudioLowPassFilter>().enabled = false;
	//	print("NotEnable");
	}
	
	if(EnableFPA.isOn == true){
		GetComponent<AudioHighPassFilter>().enabled = true;
		print("EnableFPA");
	}else{
		GetComponent<AudioHighPassFilter>().enabled = false;
	//	print("NotEnable");
	}
	
	if(EnableTremolo.isOn == true){
		TremoloEffect(samples2,samples,FTremolo.value,indiceAudio);
	}else{
		CleanAudio(samples2,samples,indiceAudio);
	}
	if(EnableChorus.isOn == true){
		ChorusEffect(samples3,samples2,DryMix.value,(int) DelaySlider.value,DepthSlider.value,RateSlider.value,indiceAudio);
	}else{
		CleanAudio(samples3,samples2,indiceAudio);
	}
	audio.clip.SetData(samples3, 0);
	
	audio.volume = Volume.value;
	//GetComponent<AudioChorusFilter>().delay = DelaySlider.value;
	//GetComponent<AudioChorusFilter>().depth = DepthSlider.value;
	//GetComponent<AudioChorusFilter>().rate = RateSlider.value;
	GetComponent<AudioDistortionFilter>().distortionLevel = LevelDistSlider.value;
	GetComponent<AudioLowPassFilter>().cutoffFrequency = (float)FPB.value; //Filtro Passa baixa recebe como frequência de corte o Slider F1
	GetComponent<AudioHighPassFilter>().cutoffFrequency = (float)FPA.value; //Idem para o FPA
		
}
void PlotarAudioNoTempo(float[] spectrum, int pos, float yvalue, Vector3[] positions, int AjusteX, int AjusteY)
{
		//AudioListener.GetSpectrumData( spectrum, 0, FFTWindow.Rectangular ); //A função Coleta os valores de magnetude do Espectro e aloca no Vetor Spectrum
		AudioListener.GetOutputData(spectrum, 0);
		
		/////Printa o gráfico com os valores do Vetor Espectro
	for( pos = 0; pos < spectrum.Length; pos++ )
	{	
		yvalue = spectrum[pos];
		positions[pos] = new Vector3(pos*0.1f + AjusteX, 7*yvalue + AjusteY,0);
		lr.SetPositions (positions);	
	}
}

void PlotarAudioNaFrequencia(float[] spectrum, int pos, float yvalue, Vector3[] positions, int AjusteX, int AjusteY, float RangeX)
{
		AudioListener.GetSpectrumData( spectrum, 0, FFTWindow.Rectangular ); //A função Coleta os valores de magnetude do Espectro e aloca no Vetor Spectrum
		
	/////Printa o gráfico com os valores do Vetor Espectro
	for( pos = 1; pos < spectrum.Length ; pos++ )
	{	
		yvalue = spectrum[pos];
		positions[pos] = new Vector3(pos*RangeX + AjusteX, 7*yvalue + AjusteY,0);
	//	positions[pos] = new Vector3(Mathf.Log10(pos)*RangeX+ AjusteX, 7*yvalue + AjusteY,0);
		lr.SetPositions (positions);	
	}
}

///////////////Tremolo

void TremoloEffect(float[] SamplesEffect, float[] SamplesAudio, float LFOFrequency, int Indice)
{	
	
	
	while (Indice < SamplesAudio.Length) {
            //SamplesEffect[Indice] = SamplesAudio[Indice] * Mathf.Cos(2f*Mathf.PI*Indice*LFOFrequency/audio.clip.samples); //Tremolo - Versão Antiga
			SamplesEffect[Indice] = SamplesAudio[Indice] * Mathf.Cos(2f*Mathf.PI*Indice*LFOFrequency/audio.clip.frequency);
			++Indice;
	}
	//Indice = 0;
     //   audio.clip.SetData(SamplesEffect, 0);
}


////////////////////CHORUS
void ChorusEffect(float[] SamplesEffect, float[] SamplesAudio,float DryMixGain ,int DELAY, float DEPTH, float RATE, int Indice)
{	
	float DryMix1;
	float DryMix2;
	float DryMix3;
	
	while (Indice < SamplesAudio.Length - (DELAY+DEPTH)) {
		//	DryMix1 =  (float) DELAY + DEPTH*Mathf.Sin(2f*Mathf.PI*Indice*RATE/audio.clip.samples );
		//	DryMix2 =  (float) DELAY + DEPTH*Mathf.Sin(2f*Mathf.PI*Indice*RATE/audio.clip.samples  - (Mathf.PI/2f));
		//	DryMix3 =  (float) DELAY + DEPTH*Mathf.Sin(2f*Mathf.PI*Indice*RATE/audio.clip.samples  + (Mathf.PI/2f));
			
			DryMix1 =  (float) DELAY + DEPTH*Mathf.Sin(2f*Mathf.PI*Indice*RATE/audio.clip.frequency );
			DryMix2 =  (float) DELAY + DEPTH*Mathf.Sin(2f*Mathf.PI*Indice*RATE/audio.clip.frequency  - (Mathf.PI/2f));
			DryMix3 =  (float) DELAY + DEPTH*Mathf.Sin(2f*Mathf.PI*Indice*RATE/audio.clip.frequency  + (Mathf.PI/2f));
		
			
			SamplesEffect[Indice] = DryMixGain*SamplesAudio[Indice] + DryMixGain*SamplesAudio[Indice + (int) DryMix1] + DryMixGain*SamplesAudio[Indice + (int) DryMix2] + DryMixGain*SamplesAudio[Indice + (int) DryMix3]; //DELAY
		//	SamplesEffect[Indice] = SamplesAudio[Indice] + SamplesAudio[Indice + (int) DryMix1] + SamplesAudio[Indice + (int) DryMix2] + SamplesAudio[Indice + (int) DryMix3]; //DELAY
			
			++Indice;
	}
	print(Indice);
		
	//Indice = 0;
        audio.clip.SetData(SamplesEffect, 0);
}
	
void CleanAudio(float[] SamplesEffect, float[] SamplesAudio, int Indice)
{	
	
	
	while (Indice < SamplesAudio.Length) {
            SamplesEffect[Indice] = SamplesAudio[Indice];
			++Indice;
	}
	//Indice = 0;
     //   audio.clip.SetData(SamplesEffect, 0);
}	

}

///O que tem de ferra Mercado de PLUG-IN's - para processamento de áudio HOME STUDIO - Nomes:  Pro Tools - Cubase - Ableton - Waves
/// 
/// 
/// 