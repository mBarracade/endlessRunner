using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

   

    // Things we need
    /*
		Main code - on the camera object
		===========
        Obstacles
            -spawn function 
                    - it will randomly pic 1 of 3 lanes after spawning it will run animation on a track, and destroy off screen 
                      Unless it hits a player.
        collectables 
        
        scrolling texture for the road
        trees
			-spawn function 
			-destroy function
			
        background




		Player code - the player object
		==============
        Hit function
            - when player gets hit on collision we will test the tags 
            - it will deduct a life

		
     */

    public List<GameObject> Obstacles;
	public List<GameObject> trees;
	public List<GameObject> collectables;


    // variables we need to key track of
    float currentObstacleTime = 0;
    float timeBetweenObstacles = .8f; //change this the value to  change how often Obstacles come out .8f seems to work.
    float currentCollectableTime = 0;
    float timeBetweenCollectables = 2f;//change this value to change how often collectables come out i put 2f to begin with.
	float currentTreeTime = 0;
    float timeBetweenTrees = .3f; //change this the value to  change how often Obstacles come out .8f seems to work.
    float numLives = 3;
    float score = 0;
	float destroyThreshold = -40f;

    public static bool gameOver = false; //public and static mean we can read and manipulate the true or false value in other code files

    void Start()
    {
        //set up things like what the gameobjects are

    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == false)
        {
            currentObstacleTime += Time.deltaTime;
            if (currentObstacleTime > timeBetweenObstacles)
            {
                spawnObstacle();
                currentObstacleTime = 0;
            }
            currentCollectableTime += Time.deltaTime;
            if (currentCollectableTime > timeBetweenCollectables)
            {
                spawnCollectable();
                currentCollectableTime = 0;
            }
			
			
			currentTreeTime += Time.deltaTime;
            if (currentTreeTime > timeBetweenTrees)
            {
                spawnTree();
                currentTreeTime = 0;
            }
        }

		destroyItemsOffScreen();
    }

    void spawnObstacle()
    {
        Debug.Log("ill spawn an Obstacle");
    }
    void spawnCollectable()
    {
        Debug.Log("ill spawn a collectable");
    }
	void spawnTree(){
		Debug.Log("ill spawn a tree");
	}

	void destroyItemsOffScreen(){
		// go through the current list of objects 
		// if they are past a certain point 
		// destroy them and delete from list

		foreach(GameObject tree in trees){
			if(tree.transform.position.z < destroyThreshold){
				//destroy tree and delete from list
			}
		}
		foreach(GameObject Obstacle in Obstacles){
			if(Obstacle.transform.position.z < destroyThreshold){
				//destroy obstucle and delete from list
			}
		}
		foreach(GameObject collectable in collectables){
			if(collectable.transform.position.z < destroyThreshold){
				//destroy collectable and delete from list
			}
		}

	}
    
}
