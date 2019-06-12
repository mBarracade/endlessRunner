using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	float Speed =40;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		checkControls();
		
	}
	void checkControls(){
		Vector3 pos = transform.position;
		  if(Input.GetKeyDown(KeyCode.LeftArrow))
      {
           pos = new Vector3(transform.position.x- 1.0f , transform.position.y , transform.position.z );
      }
 
      if(Input.GetKeyDown(KeyCode.RightArrow))
      {
         pos = new Vector3(transform.position.x  + 1.0f, transform.position.y , transform.position.z);
      }
      transform.position = Vector3.Lerp(transform.position, pos, Speed * Time.deltaTime);

	}

	 void OnTriggerExit(Collider col)
 {
	
     if(col.tag == "Obstacle"){
		 
		 Game.gameOver = true;
		 
	 }
	 if(col.tag == "Collectable"){
		 Game.score += 500;

		 Destroy(col.gameObject,0);
	 }
 }
}
