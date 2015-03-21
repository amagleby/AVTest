using UnityEngine;
using System.Collections;

public class AVCollision : MonoBehaviour {
	
	public GameObject cube;
	public GameObject track;
	
	
	// Use this for initialization
	void Start () {
		
		//print (cube);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other) {
		//print ("Collision Detected through OnTriggerEnter!!!");
		//print (this.gameObject.name);
		
		//print (other.gameObject.tag);
		
		if(other.gameObject.tag == "cube"){
			if(other.GetComponent<TriggerScript>().triggered == false){
				track.GetComponent<SpawnBlock>().spawnBlock();
			}
			other.GetComponent<TriggerScript>().flagSwitch();
		}
		
		/*	
		if(cube.GetComponent<TriggerScript>().triggered == false){
			track.GetComponent<SpawnBlock>().spawnBlock();
		}
		
		cube.GetComponent<TriggerScript>().flagSwitch();
		*/
    }
	
}
