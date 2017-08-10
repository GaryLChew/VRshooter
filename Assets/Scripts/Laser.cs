using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
    
    public Transform origin;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        GetComponent<LineRenderer>().SetPosition(0, origin.position);

        RaycastHit hit;
        
        
        if (Physics.Raycast(transform.position,transform.forward,out hit))
        {
            if (hit.collider)
            {
                GetComponent<LineRenderer>().SetPosition(1, new Vector3(0, 0, hit.distance));
            }
            else
            {
                GetComponent<LineRenderer>().SetPosition(1, new Vector3(0, 0, 5000));
            }
        }
        
        
	}
}
