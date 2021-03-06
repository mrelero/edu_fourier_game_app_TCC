using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class GameController11 : MonoBehaviour {

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
	float Result;  //Sinal Resultante
	enum StateGame {Inicio = 1, Jogando, Acertou, Errou, DiagramadeBlocos, Verificando};
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

	//BOTÕES
	public Button Iniciar;
	public Button RetryWIN;
	public Button RetryLOOSE;
	public Button ProximoLevel;
	public Button QUIT;
	public Button Diagrama;
	public Button CloseDiagrama;
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
		
		Iniciar = GameObject.Find("Iniciar").GetComponent<Button>();
		RetryWIN = GameObject.Find("/WINCANVAS/Retry").GetComponent<Button>();
		RetryLOOSE = GameObject.Find("/LOOSECANVAS/Retry").GetComponent<Button>();
		ProximoLevel = GameObject.Find("Próximo Level").GetComponent<Button>();
		QUIT =  GameObject.Find("qUIT").GetComponent<Button>();
		Diagrama = GameObject.Find("Diagrama").GetComponent<Button>();
		CloseDiagrama = GameObject.Find("Fechar").GetComponent<Button>();
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
		
		Button btn7 = Verificar.GetComponent<Button>();
		btn7.onClick.AddListener(AoClicarVerificar);
		
		Button btn8 = Menu.GetComponent<Button>();
		btn8.onClick.AddListener(AoClicarMainMenu);
		
		Button btn9 = Quit.GetComponent<Button>();
		btn9.onClick.AddListener(AoClicarQuitEnquantoJoga);
		
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
		SceneManager.LoadScene ("12", LoadSceneMode.Single); //Carrega a próxima Cena - 12
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
	
	void AoClicarVerificar(){
		GameState = StateGame.Verificando;
	}
	// Update is called once per frame
	void Update () {


		//TIMER
		float TIMER = 60 - (Time.time - StartTime); //Inicia o Timer, X - Time.time (X é o valor de tempo a ser decrescido).
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
				Result = A1.value + A2.value + A3.value + A4.value; //O Sinal resultante é a somo de todos os outros, como estão com a mesma frequência, é a soma das amplitudes.
				if ((Result <= 2.1f && Result >= 1.9f) ) {
						GameState = StateGame.Acertou;
					TimerResul = 60f - TIMER;
				}else{
						GameState = StateGame.Jogando;
				}
				
				break;
		}
		}


		//TEXT (Atualiza o texto dos sinais com a variação dos A1,A2....)
		AMP1.text = "Sinal1 =" + A1.value.ToString("f2") + "*Sin(PI)";
		AMP2.text = "Sinal2 =" + A2.value.ToString("f2") + "*Sin(PI)";
		AMP3.text = "Sinal3 =" + A3.value.ToString("f2") + "*Sin(PI)";
		AMP4.text = "Sinal4 =" + A4.value.ToString("f2") + "*Sin(PI)";


	
	}
}
