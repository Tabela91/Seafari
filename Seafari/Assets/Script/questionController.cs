using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class questionController : MonoBehaviour {

	public Text scoreUIText; // assign it from inspector
	public Text globalUIText;

	public float timeLimit = 100f;
	float startTime;

	public string[] questions;

	// Use this for initialization
	void Start () {
		startTime = Time.time;//start time
	}

	void Update()
	{
		if (timeLimit == 10) 
		{
			float remaining = timeLimit - (Time.time - startTime); // redusing the current time to the remaining time.
			globalUIText.text = remaining.ToString ("#0");
		} 

		if (this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("questionIntro"))
		{
			GetComponent<Animator>().SetBool("toOutro1",false);
		}
			
	}

	public void answers(){
		GetComponent<Animator>().SetBool("toOutro1",true);
	}

	public void ans1Button () {
		
		answers ();

	}

	public void ans2Button () {

		answers ();
	}

	public void ans3Button () {

		answers ();
	}

	public void ans4Button () {

		answers ();
	}
}
