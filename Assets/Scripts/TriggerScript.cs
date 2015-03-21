using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour {
	
	public bool triggered = false;
	
	//A script attached to each of the cube prefads so as to keep track of the state of that cube.
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	public void flagSwitch() {
		if(triggered == false){
			//print ("it was false; set to true");
			triggered = true;
		}
		else{
			//print ("it was true; set to false");
			triggered = false;
		}
    }
	
}
