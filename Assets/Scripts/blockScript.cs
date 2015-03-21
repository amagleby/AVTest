using UnityEngine;
using System.Collections;

public class blockScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//move the block to a position
	public IEnumerator MoveToPosition(Vector3 start, Vector3 end, float time){
	
		float elapsedTime = 0.0f;
		Vector3 startingPos = start;
		
		while( elapsedTime < time ){
		
			transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / time));
        	elapsedTime += Time.deltaTime;
        	yield return null;
			
		}
		DestroyObject(this.gameObject);
	}
}
