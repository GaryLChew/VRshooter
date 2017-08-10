using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    public Text ammoText, HPText, KilledText;

    public PlayerData playerData;
    public ControllerInput inputManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ammoText.text = inputManager.numBullets+"/"+playerData.ammoCount;
        HPText.text = ""+playerData.HP;
        KilledText.text = ""+inputManager.numKilled;
	}
}
