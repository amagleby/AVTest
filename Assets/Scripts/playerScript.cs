using UnityEngine;
using System.Collections;

public class playerScript : MonoBehaviour {
	
	public GameObject AVObject;
	public GameObject[] points = new GameObject[8];
	public Vector3 currentPos;
	public Quaternion currentRot;
	private int arrayInt = 0;
	
	private int score;
	// Use this for initialization
	void Start () {
		/*
		currentPos = points[arrayInt].transform.position;
		
		for(int i = 0; i < points.Length; i++){
			print(points[i].transform.position);
		}
		
		print (arrayInt);
		*/
		
		score = 0;
	}
	
	// Update is called once per frame because it is cool like that.
	void Update () {
		
		if(Input.GetKeyDown ("a") || Input.GetKeyDown ("left")){
			arrayInt++;
			//print ("arrayInt: " + arrayInt);
		}
		
		else if (Input.GetKeyDown ("d") || Input.GetKeyDown ("right")){
			arrayInt--;
			//print ("arrayInt: " + arrayInt);
		}
		
		else if (Input.GetKeyDown ("space")){
			//print ("SPACE BAR PRESSED!!!");
			arrayInt = arrayInt + 4;
			if(arrayInt > 7){
				//print ("Re-adjust the index!! DO IT LOSER!!");
				arrayInt = arrayInt - 8;
			}
		}
		
		if(arrayInt < 0){
			arrayInt = 7;
		}
		else if(arrayInt > 7){
			arrayInt = 0;
		}
		
		currentPos = points[arrayInt].transform.position;
		this.transform.position = currentPos;
		this.transform.rotation = currentRot;

		/*
		if(AVObject.GetComponent<AudioSource>().volume > .15){
			AVObject.GetComponent<AudioSource>().volume -= .005f;
		}
		*/
	
	}
	
	void OnTriggerEnter(Collider other){
		//print("player Collided with: " + other.gameObject.name + " tag: " + other.gameObject.tag);
		if(other.gameObject.tag == "block"){
			score++;
			/*
			if(AVObject.GetComponent<AudioSource>().volume < 1.0f){
				AVObject.GetComponent<AudioSource>().volume += .1f;
			}
			*/
			print ("Score: " + score);
		}
		
	}
	
	public int GetScore(){
		return score;
	}
}
