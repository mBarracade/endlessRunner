using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{

    /*
		Main code - on the camera object
		===========
		Player code - the player object
		==============
        movingItems - script on the obstacle , collectable, tree
		
     */

    public List<GameObject> obstacles;
	public List<GameObject> trees;
	public List<GameObject> collectables;

    GameObject tree;
    GameObject player;
    GameObject collectable;
    GameObject obstacle;
    GameObject Score;
    GameObject title;
    

    //change how many spawn smaller number = more items on screen at once 
    float timeBetweenObstacles = .5f; 
    float timeBetweenCollectables = 2f;
    float timeBetweenTrees = .3f; 

    float numLives = 3;
    float gameSpeed = 0.3f;


    //no need to touch these
    float currentCollectableTime = 0;
    float currentObstacleTime = 0;
    float currentTreeTime = 0;
    float destroyThreshold = 4f; 
    public static float score = 0;
    public static bool gameOver = false; //public and static mean we can read and manipulate the true or false value in other code files
    bool right = true;
    Text scoreBoard;
    Text titleMsg;
    void Start()
    {
        //set up things like what the gameobjects are
        tree = GameObject.Find("Tree");
        collectable = GameObject.Find("Collectable");
        obstacle = GameObject.Find("Obstacle");
        gameOver = false;
        Score= GameObject.Find("Canvas/Score");
        title= GameObject.Find("Canvas/Title");
        scoreBoard = Score.GetComponent<Text>();
        titleMsg = title.GetComponent<Text>();
        titleMsg.enabled = false;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (Game.gameOver == false)
        {
            scoreBoard.text = "Score : "+ score;
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
        }else{
            titleMsg.enabled = true;
            if(Input.GetKeyDown(KeyCode.Return)){
                Debug.Log("reload");
                 
                   int scene = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(scene, LoadSceneMode.Single);
                
            }
        }
        

    }

    void spawnObstacle()
    {
        float xpos= pickLane();
           GameObject newObstacle = (GameObject)Instantiate(obstacle,new Vector3(0,-20,0),new Quaternion());
        
        newObstacle.GetComponent<movingItem>().xPos = xpos;
        newObstacle.GetComponent<movingItem>().speed = gameSpeed;
        newObstacle.GetComponent<movingItem>().ableToMove = true;
    }
    void spawnCollectable()
    {
        float xpos= pickLane();
           GameObject newCollectable = (GameObject)Instantiate(collectable,new Vector3(0,-20,0),new Quaternion());
        
        newCollectable.GetComponent<movingItem>().xPos = xpos;
        newCollectable.GetComponent<movingItem>().speed = gameSpeed;
        newCollectable.GetComponent<movingItem>().ableToMove = true;
    }
	void spawnTree(){
        right = !right;
        float xpos=0.78f;
        if(right){
            xpos=Random.Range(-4.67f,-11.07f);
        }else{
            xpos=Random.Range(4.26f,11.04f);
        }
        GameObject newTree = (GameObject)Instantiate(tree,new Vector3(0,-20,0),new Quaternion());
        
        newTree.GetComponent<movingItem>().xPos = xpos;
        newTree.GetComponent<movingItem>().speed = gameSpeed;
        newTree.GetComponent<movingItem>().ableToMove = true;
		
	}
	
    float pickLane(){
        int pickOne = (int)Random.Range(1,4);
        float chosen = 0f;
        switch(pickOne){
            case 1:
                chosen =  -2f;
                break;
            case 3:
                 chosen =  2f;
                break;

        }


        return chosen;
    }
    
}
