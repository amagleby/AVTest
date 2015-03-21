using UnityEngine;
using System.Collections;

public class RotationX : MonoBehaviour {
 
 public float rotateSpeed = 5f;
 
 void Update () {
  transform.Rotate (new Vector3(rotateSpeed*Time.deltaTime,0,0));
 }
}