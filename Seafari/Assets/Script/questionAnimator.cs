using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class questionAnimator : MonoBehaviour {

	 void Update()
	{
         if (this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("questionIntro"))
		{
			GetComponent<Animator>().SetBool("toOutro1",false);
		}
			
	}

	public void answers(){
		GetComponent<Animator>().SetBool("toOutro1",true);
	}

	public void ansButton () {
		answers ();
	}
	
}
