using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController17 : MonoBehaviour {

	//Declaração dos Sliders e botões
	public Slider A1; //A1,A2... Sliders do controle das senoides
	public Slider A2; 
	public Slider A3; 
	public Slider A4; 



	//Declaração dos Textos
	public Text AMP1; //Textos das Senoides
	public Text AMP2;
	public Text AMP3;
	public Text AMP4;
	public Text Timer; //Texto do TIMER
	public Text TimerRegister; //Registro de tempo de conclusão da fase

	//Declaração de variáveis importantes para o Algorítimo
	enum StateGame {Inicio = 1, Jogando, Acertou, Errou, DiagramadeBlocos, Fourier,Verificando};
	private float StartTime;
	private float StartVerifingTime;
	private float TimerResul;

	//Declaraçãode GameObjects
	public GameObject WIN; //Tela de WIN
	public GameObject LOOSE; //Tela de Loose
	public GameObject WINCANVAS; //Tela de WIN(Canvas)
	public GameObject LOOSECANVAS; //Tela de Loose(Canvas)
	public GameObject Controle; //Sliders de Controle para serem desabilitados
	public GameObject ResultadoEsperado;
	public GameObject SinalControlado;
	public GameObject Inicio;
	public GameObject InicioCANVAS;
	public GameObject DiagramadeBlocosSprite;
	public GameObject DiagramadeBlocosCanvas;
	public GameObject FourierSprite;
	public GameObject FourierCanvas;

	//BOTÕES
	public Button Iniciar;
	public Button RetryWIN;
	public Button RetryLOOSE;
	public Button ProximoLevel;
	public Button QUIT;
	public Button Diagrama;
	public Button CloseDiagrama;
	public Button Fourier;
	public Button CloseFourier;
	public Button Verificar;
	public Button Quit; //QUIT DO HUB
	public Button Menu; //VOLTA AO MENU PRINCIPAL
	
	
	// Use this for initialization
	StateGame GameState;
	void Start () {
		//AchandoGameObjects
		A1 = GameObject.Find("Sinal1").GetComponent<Slider>();
		A2 = GameObject.Find("Sinal2").GetComponent<Slider>();
		A3 = GameObject.Find("Sinal3").GetComponent<Slider>();
		A4 = GameObject.Find("Sinal4").GetComponent<Slider>();
		
		AMP1 = GameObject.Find("Sin1").GetComponent<Text>();
		AMP2 = GameObject.Find("Sin2").GetComponent<Text>();
		AMP3 = GameObject.Find("Sin3").GetComponent<Text>();
		AMP4 = GameObject.Find("Sin4").GetComponent<Text>();
		Timer =	GameObject.Find("Timer").GetComponent<Text>();
		TimerRegister = GameObject.Find("TempoResultado").GetComponent<Text>();
		WIN = GameObject.Find("GameMenuWin");
		LOOSE = GameObject.Find("GameMenuLoose");
		WINCANVAS = GameObject.Find("WINCANVAS");
		LOOSECANVAS = GameObject.Find("LOOSECANVAS");
		Controle = GameObject.Find("HUB");
		ResultadoEsperado = GameObject.Find("ResultadoEsperado");
		SinalControlado = GameObject.Find("ControleDeSinais");
		Inicio = GameObject.Find("StageInicio");
		InicioCANVAS = GameObject.Find("INICIOCANVAS");
		DiagramadeBlocosSprite = GameObject.Find("DiagramaSprite");
		DiagramadeBlocosCanvas = GameObject.Find("DiagramaCanvas");
		FourierSprite = GameObject.Find("FourierSprite");
		
		Iniciar = GameObject.Find("Iniciar").GetComponent<Button>();
		RetryWIN = GameObject.Find("/WINCANVAS/Retry").GetComponent<Button>();
		RetryLOOSE = GameObject.Find("/LOOSECANVAS/Retry").GetComponent<Button>();
		ProximoLevel = GameObject.Find("Próximo Level").GetComponent<Button>();
		QUIT =  GameObject.Find("qUIT").GetComponent<Button>();
		Diagrama = GameObject.Find("Diagrama").GetComponent<Button>();
		CloseDiagrama = GameObject.Find("/DiagramaCanvas/Fechar").GetComponent<Button>();
		Fourier = GameObject.Find("Fourier").GetComponent<Button>();
		CloseFourier = GameObject.Find("/FourierCanvas/Fechar").GetComponent<Button>();
		Verificar = GameObject.Find("Verificar").GetComponent<Button>();
		Menu = GameObject.Find("MenuPrincipal").GetComponent<Button>();
		Quit = GameObject.Find("Quit").GetComponent<Button>();
	
		
		//VARIAVEIS INICIAIS
		StartTime = Time.time;
		//ESTADOS INICIAIS
		GameState = StateGame.Inicio;
		WIN.gameObject.SetActive (false);
		WINCANVAS.gameObject.SetActive (false);
		Controle.gameObject.SetActive (false);
		LOOSE.gameObject.SetActive (false);
		LOOSECANVAS.gameObject.SetActive (false);
		ResultadoEsperado.gameObject.SetActive (false);
		Inicio.gameObject.SetActive (false);
		InicioCANVAS.gameObject.SetActive (false);
		SinalControlado.gameObject.SetActive (false);
		DiagramadeBlocosSprite.gameObject.SetActive (false);
		DiagramadeBlocosCanvas.gameObject.SetActive (false);
		FourierSprite.gameObject.SetActive (false);
		FourierCanvas.gameObject.SetActive (false);


		//SCRIPT DE BOTÕES
		Button btn = Iniciar.GetComponent<Button>();
		btn.onClick.AddListener(AoClicarIniciar);

		Button btn1 = RetryWIN.GetComponent<Button>();
		btn1.onClick.AddListener(AoClicarRetryWin);

		Button btn2 = RetryLOOSE.GetComponent<Button>();
		btn2.onClick.AddListener(AoClicarRetryLoose);

		Button btn3 = ProximoLevel.GetComponent<Button>();
		btn3.onClick.AddListener(AoClicarProximoLevel);

		Button btn4 = QUIT.GetComponent<Button>();
		btn4.onClick.AddListener(AoClicarSair);

		Button btn5 = Diagrama.GetComponent<Button>();
		btn5.onClick.AddListener(AoClicarDiagramaDeBlocos);

		Button btn6 = CloseDiagrama.GetComponent<Button>();
		btn6.onClick.AddListener(AoClicarFecharDiagramaDeBlocos);

		Button btn7 = Fourier.GetComponent<Button>();
		btn7.onClick.AddListener(AoClicarFourier);

		Button btn8 = CloseFourier.GetComponent<Button>();
		btn8.onClick.AddListener(AoClicarFecharFourier);
		
		Button btn9 = Verificar.GetComponent<Button>();
		btn9.onClick.AddListener(AoClicarVerificar);
		
		Button btn10 = Menu.GetComponent<Button>();
		btn10.onClick.AddListener(AoClicarMainMenu);
		
		Button btn11 = Quit.GetComponent<Button>();
		btn11.onClick.AddListener(AoClicarQuitEnquantoJoga);
		
	}
	
	void AoClicarMainMenu(){
		SceneManager.LoadScene ("Menu", LoadSceneMode.Single);			
	}
	
	void AoClicarQuitEnquantoJoga(){
		Application.Quit();

	}
	void AoClicarIniciar(){
		GameState = StateGame.Jogando;
		StartTime = Time.time; //Inicio do Cronometro
	}

	void AoClicarRetryWin(){
		GameState = StateGame.Inicio;
	}

	void AoClicarRetryLoose(){
		GameState = StateGame.Inicio;
	}

	void AoClicarProximoLevel(){
		SceneManager.LoadScene ("11", LoadSceneMode.Single);
	
	}

	void AoClicarSair(){
		Application.Quit();

	}

	void AoClicarDiagramaDeBlocos(){

		DiagramadeBlocosSprite.gameObject.SetActive (true);
		DiagramadeBlocosCanvas.gameObject.SetActive (true);

	}

	void AoClicarFecharDiagramaDeBlocos(){
		DiagramadeBlocosSprite.gameObject.SetActive (false);
		DiagramadeBlocosCanvas.gameObject.SetActive (false);

	}

	void AoClicarFourier(){

		FourierSprite.gameObject.SetActive (true);
		FourierCanvas.gameObject.SetActive (true);

	}

	void AoClicarFecharFourier(){
		FourierSprite.gameObject.SetActive (false);
		FourierCanvas.gameObject.SetActive (false);

	}
	
	void AoClicarVerificar(){
		GameState = StateGame.Verificando;
	}
	
	// Update is called once per frame
	void Update () {


		//TIMER
		float TIMER = 90 - (Time.time - StartTime); //Inicia o Timer, X - Time.time (X é o valor de tempo a ser decrescido).
		Timer.text = "TEMPO:" + TIMER.ToString ("f0"); //Atualizao Texto do Timer

		switch (GameState) 
		{
		case StateGame.Inicio:
			{
				WIN.gameObject.SetActive (false);
				WINCANVAS.gameObject.SetActive (false);
				Controle.gameObject.SetActive (false);
				LOOSE.gameObject.SetActive (false);
				LOOSECANVAS.gameObject.SetActive (false);
				ResultadoEsperado.gameObject.SetActive (false);
				Inicio.gameObject.SetActive (true);
				InicioCANVAS.gameObject.SetActive (true);
				SinalControlado.gameObject.SetActive (false);
				//Estado Inicial dos Sliders
				A1.value = 0;
				A2.value = 0;
				A3.value = 0;
				A4.value = 0;


				break;
			}
		case StateGame.Jogando:
			{

				WIN.gameObject.SetActive (false);
				WINCANVAS.gameObject.SetActive (false);
				Controle.gameObject.SetActive (true);
				LOOSE.gameObject.SetActive (false);
				LOOSECANVAS.gameObject.SetActive (false);
				ResultadoEsperado.gameObject.SetActive (true);
				Inicio.gameObject.SetActive (false);
				InicioCANVAS.gameObject.SetActive (false);
				SinalControlado.gameObject.SetActive (true);


				

				if (TIMER <= 0.001f) {
					GameState = StateGame.Errou;
				}

				break;
			}
		case StateGame.Acertou:
			{
				WIN.gameObject.SetActive (true);
				WINCANVAS.gameObject.SetActive (true);
				Controle.gameObject.SetActive (false);
				LOOSE.gameObject.SetActive (false);
				LOOSECANVAS.gameObject.SetActive (false);
				ResultadoEsperado.gameObject.SetActive (true);
				Inicio.gameObject.SetActive (false);
				InicioCANVAS.gameObject.SetActive (false);
				SinalControlado.gameObject.SetActive (true);

				TimerRegister.text = "Tempo: " + TimerResul.ToString ("f2") + "s";
				break;
			}
		case StateGame.Errou:
			{
				WIN.gameObject.SetActive (false);
				WINCANVAS.gameObject.SetActive (false);
				Controle.gameObject.SetActive (false);
				LOOSE.gameObject.SetActive (true);
				LOOSECANVAS.gameObject.SetActive (true);
				ResultadoEsperado.gameObject.SetActive (true);
				Inicio.gameObject.SetActive (false);
				InicioCANVAS.gameObject.SetActive (false);
				SinalControlado.gameObject.SetActive (true);
				break;	
			
			
			}
		case StateGame.Verificando:
		{
			
				//Resultado
				if ((A2.value <= 0.12f && A2.value >= 0.10f)&&(A3.value <= 0.045f && A3.value >= 0.035f)&&(A4.value <= 0.03f && A4.value >= 0.02f)&&A1.value == 1) {
						GameState = StateGame.Acertou;
					TimerResul = 90f - TIMER;
				}else{
						GameState = StateGame.Jogando;
				}
				
				break;
		}
		}


		//TEXT (Atualiza o texto dos sinais com a variação dos A1,A2....)
		AMP1.text = "S1 =" + A1.value.ToString("f4") + "*Cos(pi*t/2)";
		AMP2.text = "S2 =" + A2.value.ToString("f4") + "*Cos(3*pi*t/2)";
		AMP3.text = "S3 =" + A3.value.ToString("f4") + "*Cos(5*pi*t/2)";
		AMP4.text = "S4 =" + A4.value.ToString("f4") + "*Cos(7*pi*t/2)";


	
	}
}
