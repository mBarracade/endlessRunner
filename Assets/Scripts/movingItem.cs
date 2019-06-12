using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingItem : MonoBehaviour
{
    List<Vector3> animationPoints;
    int index = 0;
    public float xPos = -7f;
    public float speed = 0.3f;
	public bool ableToMove = false;
    // Use this for initialization
    void Start()
    {
        animationPoints = new List<Vector3>();
        setUpAnimations();
        //transform.position = animationPoints[index];
    }

    // Update is called once per frame
    void Update()
    {
		if(ableToMove){
        	move();
		}
    }
    void move()
    {
		if(!Game.gameOver){
        if (Vector3.Distance(transform.position, animationPoints[index]) < .1)
        {
            if (index == animationPoints.Count - 1)
            {
				Destroy(this.gameObject,0);
            }
            else
            {
                index++;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, animationPoints[index], speed*Time.deltaTime*200);
		}
    }

    void setUpAnimations()
    {
        animationPoints.Add(new Vector3(xPos, -4.41f, 73f));
        animationPoints.Add(new Vector3(xPos, 1.6f, 61f));
        animationPoints.Add(new Vector3(xPos, 4.3f, 51f));
        animationPoints.Add(new Vector3(xPos, 4.6f, 40f));
        animationPoints.Add(new Vector3(xPos, 6f, 34f));
        animationPoints.Add(new Vector3(xPos, 6f, 27f));
        animationPoints.Add(new Vector3(xPos, 6f, 11f));
        animationPoints.Add(new Vector3(xPos, 6f, -30f));
        animationPoints.Add(new Vector3(xPos, 6f, -60f));

    }
}
