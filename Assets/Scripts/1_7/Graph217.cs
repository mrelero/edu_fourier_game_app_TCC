using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Graph217 : MonoBehaviour {
	private LineRenderer lr;

	float i = -7;
	float angle;
	float OndaTriangular = 0;
	int pos = 0;
	int j;
	Vector3[] positions = new Vector3[300];

	void Start () {
		lr = GetComponent<LineRenderer>();

		for(pos = 0 ; pos <300;pos++)
		{

		
			OndaTriangular = 1 - (8 / (Mathf.PI*Mathf.PI)) * (Mathf.Cos (i * Mathf.PI / 2f) + (1 / (3f*3f)) * Mathf.Cos (3f * i * Mathf.PI / 2f) + (1 / (5f*5f)) * Mathf.Cos (5f * i * Mathf.PI / 2f) + (1 / (7f*7f)) * Mathf.Cos (7f * i * Mathf.PI / 2f) + (1 / (9f*9f)) * Mathf.Cos (9f * i * Mathf.PI / 2f)+(1 / (11f*11f)) * Mathf.Cos (11f * i * Mathf.PI / 2f));
			positions[pos] = new Vector3(i, OndaTriangular, 0.0f);
			i = i + 0.05f;
		}
		lr.SetPositions(positions);

	}

	// Update is called once per frame
	void Update () {
	
	}
}
