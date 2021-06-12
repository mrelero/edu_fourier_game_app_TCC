using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControleSinais : MonoBehaviour {


	float i = -7;//i é o equivalente ao valor de x inicial, no caso do display, o gráfico dai de -12 < x < 12 no Plano Cartesiano
	int pos = 0; //Pos é o indice do vetor de pontos a serem traçadas as retas
	float yvalue; // Valor em y da função y = f(x)
	public float L; //L da série de Fourier

	Vector3[] positions = new Vector3[200]; //Vetor de posições
	private LineRenderer lr; //LineRenderer lr
	public Slider A1; //Slider A1, A2...
	public Slider A2;
	public Slider A3;
	public Slider A4;


	void Start () {
		lr = GetComponent<LineRenderer>(); //lr recebe a componente LindeRenderer do GameObject que contém o Script
	}

	// Update is called once per frame
	void Update () {
	//A função calcula o valor de y para cada número de x(i), que começa em -12 e incrementa 0.1 até completar 300 pontos no total.
		if (pos <= 200) {
		//A1.valeu é o valor retornado de cada Slider
			//yvalue = L/2f + (A1.value*Mathf.Sin(Mathf.PI*i/L)+A2.value*Mathf.Sin(3f*Mathf.PI*i/L)+A3.value*Mathf.Sin(5f*Mathf.PI*i/L)+A4.value*Mathf.Sin(7f*Mathf.PI*i/L));
			yvalue = L/2f + (A1.value*Mathf.Sin(Mathf.PI*i)+A2.value*Mathf.Sin(Mathf.PI*i)+A3.value*Mathf.Sin(Mathf.PI*i)+A4.value*Mathf.Sin(Mathf.PI*i));
			//Positions é um vetor de Vector3, onde cada um de seu valor consta um Vector3 com posições de i e yvalue (y=f(x))	
			positions [pos] = new Vector3 (i, yvalue, 0.0f);
			//Incremento de i e posições
			i = i + 0.1f;
			pos++;
			//Caso pos for igual a 300 ele é reiniciado para que o Gráfico seja sempre plotado na Tela
			if (pos == 200) {
				pos=0;
				i = -7;
			}
		}
		//lr.SetPositions seta as posições do vetor de pontos do LineRenderer
		lr.SetPositions (positions);	
	
}

}
