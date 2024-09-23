using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;  // a

    void Start()
    {
        // Find a GameObject named ScoreCounter in the Scene Hierarchy
        GameObject scoreGO = GameObject.Find("ScoreCounter");  // b
        // Get the ScoreCounter (Script) component of scoreGO
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();  // c
    }

    void Update()
    {
        // Get the current screen position of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition;  // a

        // The Camera's position sets how far to push the mouse into 3D space
        mousePos2D.z = -Camera.main.transform.position.z;  // b

        // Convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);  // c

        // Move the x position of this Basket to the x position of the Mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;

    }


    void OnCollisionEnter(Collision coll)
    {
        // Find out what hit this basket
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Apple"))
        {
            Destroy(collidedWith);
            // Increase the score
            scoreCounter.score += 100;
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);
            
        }
        
    }
}