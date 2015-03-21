using UnityEngine;
using System.Collections;

public class SpawnBlock : MonoBehaviour {

	public GameObject block;
	public GameObject track;
	public GameObject endPoint;
	
	// Use this for initialization
	void Start () {
	
		//print (this.gameObject.name);
		//print (this.gameObject.transform);
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void spawnBlock(){
		//print ("spawnBlock was called"); 
		GameObject cube = (GameObject) Instantiate(block, new Vector3(track.transform.position.x - 35, track.transform.position.y - 1, track.transform.position.z), Quaternion.identity);
		StartCoroutine (cube.GetComponent<blockScript>().MoveToPosition(cube.transform.position, endPoint.transform.position, 1));
				
	}
	
}
