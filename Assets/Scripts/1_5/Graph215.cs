using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Graph215 : MonoBehaviour {
	private LineRenderer lr;

	float i = -7;
	float angle;
	int pos = 0;
	Vector3[] positions = new Vector3[300];

	void Start () {
		lr = GetComponent<LineRenderer>();

		for(pos = 0 ; pos <300;pos++)
		{
			positions[pos] = new Vector3(i, 0.6f*3*Mathf.Cos(i*Mathf.PI) + 2, 0.0f);
			i = i + 0.05f;
		}
		lr.SetPositions(positions);

	}

	// Update is called once per frame
	void Update () {
	
	}
}
