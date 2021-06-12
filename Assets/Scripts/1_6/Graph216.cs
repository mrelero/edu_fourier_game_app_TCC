using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Graph216 : MonoBehaviour {
	private LineRenderer lr;

	float i = -7;
	float angle;
	float OndaQuadrada = 0;
	int pos = 0;
	int j;
	Vector3[] positions = new Vector3[300];

	void Start () {
		lr = GetComponent<LineRenderer>();

		for(pos = 0 ; pos <300;pos++)
		{

		
			OndaQuadrada = 2 + (8 / Mathf.PI) * (Mathf.Sin (i * Mathf.PI / 4) + (1 / 3f) * Mathf.Sin (3f * i * Mathf.PI / 4f) + (1 / 5f) * Mathf.Sin (5f * i * Mathf.PI / 4f) + (1 / 7f) * Mathf.Sin (7f * i * Mathf.PI / 4f) + (1 / 9f) * Mathf.Sin (9f * i * Mathf.PI / 4f)+(1 / 11f) * Mathf.Sin (11f * i * Mathf.PI / 4f));
			positions[pos] = new Vector3(i, 0.8f*OndaQuadrada, 0.0f);
			i = i + 0.05f;
		}
		lr.SetPositions(positions);

	}

	// Update is called once per frame
	void Update () {
	
	}
}
