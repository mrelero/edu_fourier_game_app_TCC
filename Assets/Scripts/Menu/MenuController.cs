using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public GameObject CanvasMainMenu;
	public GameObject LevelSelectMenu;
	public GameObject LevelSelect1;
	
	public Button Iniciar;
	public Button LevelSelect;
	public Button Quit;
	public Button Select1;
	public Button Select2;
	public Button Select11;
	public Button Select12;
	public Button Select13;
	public Button Select14;
	public Button Select15;
	public Button Select16;
	public Button Select17;
	public Button MainMenu1;
	public Button MainMenu2;
	public Button Voltar1;
	public Button Voltar2;
	
	
	enum StateMenu {Main = 1, LevelSelectState, Select1State, Select2State, Inicio};
	
	
	
	
	StateMenu Menu;
	// Use this for initialization
	void Start () {
		//GAME OBJECTS
		CanvasMainMenu = GameObject.Find("MenuCANVAS");
		LevelSelectMenu = GameObject.Find("LevelSelectCanvas");
		LevelSelect1 = GameObject.Find("LevelSelect1");
		//MAIN MENU
		Iniciar = GameObject.Find("Inicio").GetComponent<Button>();
		LevelSelect = GameObject.Find("LevelSelect").GetComponent<Button>();
		Quit = GameObject.Find("Quit").GetComponent<Button>();
		//SELECT LEVEL
		Select1 = GameObject.Find("FourierGroup").GetComponent<Button>();
		Select2 = GameObject.Find("AudioGroup").GetComponent<Button>();
		Voltar1 = GameObject.Find("Voltar1").GetComponent<Button>();
		MainMenu1 = GameObject.Find("MenuPrincipal").GetComponent<Button>();
		//FOURIER LEVEL SELECT1
		Select11 = GameObject.Find("1_1").GetComponent<Button>();
		Select12 = GameObject.Find("1_2").GetComponent<Button>();
		Select13 = GameObject.Find("1_3").GetComponent<Button>();
		Select14 = GameObject.Find("1_4").GetComponent<Button>();
		Select15 = GameObject.Find("1_5").GetComponent<Button>();
		Select16 = GameObject.Find("1_6").GetComponent<Button>();
		Select17 = GameObject.Find("1_7").GetComponent<Button>();
		Voltar2 = GameObject.Find("Voltar2").GetComponent<Button>();
		MainMenu2 = GameObject.Find("MenuPrincipal2").GetComponent<Button>();
		
		CanvasMainMenu.gameObject.SetActive(true);
		LevelSelectMenu.gameObject.SetActive(false);
		LevelSelect1.gameObject.SetActive(false);
		
		
		Menu = StateMenu.Main;
		
		//SCRIPT DE BOTÕES
		Button btn = Iniciar.GetComponent<Button>();
		btn.onClick.AddListener(AoClicarIniciar);
		
		Button btn1 = LevelSelect.GetComponent<Button>();
		btn1.onClick.AddListener(AoClicarLevelSelect);
		
		Button btn2 = Quit.GetComponent<Button>();
		btn2.onClick.AddListener(AoClicarQuit);
		
		Button btn3 = Select1.GetComponent<Button>();
		btn3.onClick.AddListener(AoClicarSelect1);
		
		Button btn4 = Select2.GetComponent<Button>();
		btn4.onClick.AddListener(AoClicarSelect2);
		
		Button btn5 = MainMenu1.GetComponent<Button>();
		btn5.onClick.AddListener(AoClicarMainMenu1);
		
		Button btn6 = Voltar1.GetComponent<Button>();
		btn6.onClick.AddListener(AoClicarVoltar1);
		
		Button btn7 = Select11.GetComponent<Button>();
		btn7.onClick.AddListener(AoClicarSelect11);
		
		Button btn8 = Select12.GetComponent<Button>();
		btn8.onClick.AddListener(AoClicarSelect12);
		
		Button btn9 = Select13.GetComponent<Button>();
		btn9.onClick.AddListener(AoClicarSelect13);
		
		Button btn10 = Select14.GetComponent<Button>();
		btn10.onClick.AddListener(AoClicarSelect14);
		
		Button btn11 = Select15.GetComponent<Button>();
		btn11.onClick.AddListener(AoClicarSelect15);
		
		Button btn12 = Select16.GetComponent<Button>();
		btn12.onClick.AddListener(AoClicarSelect16);
		
		Button btn13 = Select17.GetComponent<Button>();
		btn13.onClick.AddListener(AoClicarSelect17);
			
		Button btn14 = Voltar2.GetComponent<Button>();
		btn14.onClick.AddListener(AoClicarVoltar2);
		
		Button btn15 = MainMenu2.GetComponent<Button>();
		btn15.onClick.AddListener(AoClicarMainMenu2);
		
	}
	
	void AoClicarIniciar(){
		Menu = StateMenu.Inicio;
		print("Clicou Iniciar");
	}
	
	void AoClicarLevelSelect(){
		Menu = StateMenu.LevelSelectState;
		print("Clicou LevelSelect");
	}
	
	void AoClicarQuit(){
		Application.Quit();
		print("Clicou Iniciar");
	}
	
	void AoClicarSelect1(){
		Menu = StateMenu.Select1State;
		print("Clicou Select1");
	}
	
	void AoClicarSelect2(){
		SceneManager.LoadScene ("Efeitos", LoadSceneMode.Single);			
		print("Clicou Select4");
	}
	void AoClicarSelect11(){
		SceneManager.LoadScene ("11", LoadSceneMode.Single);			
		print("Clicou 1_1");
	}
	
	void AoClicarSelect12(){
		SceneManager.LoadScene ("12", LoadSceneMode.Single);
		print("Clicou 1_2");
	}
	
	void AoClicarSelect13(){
		SceneManager.LoadScene ("13", LoadSceneMode.Single);
		print("Clicou 13");
	}
	
	void AoClicarSelect14(){
		SceneManager.LoadScene ("14", LoadSceneMode.Single);
		print("Clicou 14");
	}
	
	void AoClicarSelect15(){
		SceneManager.LoadScene ("15", LoadSceneMode.Single);
		print("Clicou 15");
	}
	
	void AoClicarSelect16(){
		SceneManager.LoadScene ("16", LoadSceneMode.Single);
		print("Clicou 16");
	}
	
	void AoClicarSelect17(){
		SceneManager.LoadScene ("17", LoadSceneMode.Single);
		print("Clicou 17");
	}
	
	void AoClicarVoltar1(){
		Menu = StateMenu.Main;
		print("Clicou Voltar1");
	}
	
	void AoClicarVoltar2(){
		Menu = StateMenu.LevelSelectState;
		print("Clicou Voltar2");
	}
	

	void AoClicarMainMenu1(){
		Menu = StateMenu.Main;
		
		print("Clicou Iniciar");
	}
	
	void AoClicarMainMenu2(){
		Menu = StateMenu.Main;
		
		print("Clicou Iniciar");
	}
	
	
	
	
	// Update is called once per frame
	void Update () {
		switch(Menu)
		{
			case StateMenu.Main:{
				CanvasMainMenu.gameObject.SetActive(true);
				LevelSelectMenu.gameObject.SetActive(false);
				LevelSelect1.gameObject.SetActive(false);

				break;
			}
			
			case StateMenu.LevelSelectState:
			{
				CanvasMainMenu.gameObject.SetActive(false);
				LevelSelectMenu.gameObject.SetActive(true);
				LevelSelect1.gameObject.SetActive(false);
	
				break;
			}
			
			case StateMenu.Select1State:
			{
				CanvasMainMenu.gameObject.SetActive(false);
				LevelSelectMenu.gameObject.SetActive(false);
				LevelSelect1.gameObject.SetActive(true);

				break;
			}
			
			case StateMenu.Select2State:
			{
				break;
			}
			case StateMenu.Inicio:
			{
				SceneManager.LoadScene ("11", LoadSceneMode.Single);
				break;
			}
			
		}
	}
}
