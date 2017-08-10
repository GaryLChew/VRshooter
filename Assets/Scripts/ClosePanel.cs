using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanel : MonoBehaviour {
	public GameObject p;
	void Update(){
		if(Input.GetKeyDown("space")){
			p.SetActive (!p.active)  ;
		}
	}

}
