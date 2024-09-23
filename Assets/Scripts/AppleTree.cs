using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    // Prefab for instantiating apples
    public GameObject applePrefab;
    public GameObject branchPrefab;

    // Speed at which the AppleTree moves
    public float speed = 1f;

    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    // Chance that the AppleTree will change directions
    public float changeDirChance = 0.1f;

    // Seconds between Apples instantiations
    public float appleDropDelay = 1f;
    public float branchDropDelay = 5f;

    
    void Start()
    {
        // Start dropping apples
        Invoke("DropApple", 2f);
        Invoke("DropBranch", 2f);// a
    }
    void DropBranch()
    {
        GameObject branch = Instantiate<GameObject>(branchPrefab);  // b
        branch.transform.position = transform.position;  // d
        Invoke("DropBranch", branchDropDelay);  // e
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);  // b
        apple.transform.position = transform.position;  // d
        Invoke("DropApple", appleDropDelay);  // e
    }
    void Update()
    {
        // Basic Movement
        Vector3 pos = transform.position;  // Get the current position
        pos.x += speed * Time.deltaTime;  // Modify the x position based on speed
        transform.position = pos;
        // Basic Movement
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);  // Move right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);  // Move left
        }
        else if (Random.value < changeDirChance)
        {
            speed *= -1;  // Change direction
        }
    }
        // Changing Direction
    void FixedUpdate()
     {
        // Random direction changes are now time-based due to FixedUpdate()  // b
        if (Random.value < changeDirChance)
        {
            speed *= -1;  // Change direction  // b
        }
     }

}
