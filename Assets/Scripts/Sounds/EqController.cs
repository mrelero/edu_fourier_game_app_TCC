using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine;

public class EqController : MonoBehaviour {

	public Slider LowEq;
	public Slider MedEq;
	public Slider HighEq;
	public AudioMixer Master;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Master.SetFloat ("EqLow", LowEq.value);
		Master.SetFloat ("EqMedium", MedEq.value);
		Master.SetFloat ("EqHigh", HighEq.value);

	}
}
