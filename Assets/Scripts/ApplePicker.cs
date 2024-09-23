using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numBaskets = 4;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;  // c
    //public static event Action onBasketZero;
  

    void Start()
    {
        basketList = new List<GameObject>();  // d
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);  // e
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // Check if the object colliding is tagged as "Branch"
        if (coll.gameObject.tag == "Branch")
        {
            // If a branch is picked (i.e., collides with the basket), lose a basket
            BranchPicked(coll.gameObject);  // Pass the colliding object (the branch) to BranchPicked
        }
    }

    public void BranchPicked(GameObject branch)
    {
        // Destroy the branch that was picked
        Destroy(branch);

        // Destroy one of the Baskets
        int basketIndex = basketList.Count - 1;
        GameObject basketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);

        // If there are no Baskets left, restart the game or load Game Over
        if (basketList.Count == 0)
        {
            SceneManager.LoadScene(5);  // Load the game over scene
        }
    }

    public void AppleMissed()
    {
        // Destroy all of the falling Apples
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tempGO in appleArray)
        {
            Destroy(tempGO);
        }

        // Destroy one of the Baskets
        // Get the index of the last Basket in basketList
        int basketIndex = basketList.Count - 1;
        // Get a reference to that Basket GameObject
        GameObject basketGO = basketList[basketIndex];
        // Remove the Basket from the list and destroy the GameObject
        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);  // f

        // If there are no Baskets left, restart the game
        if (basketList.Count == 0)
        {
            SceneManager.LoadScene(5); 
                        
        }
    }
}

