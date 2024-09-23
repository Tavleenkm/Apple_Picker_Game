using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour
{
    public static float bottomY = -20f;  // The Y position where the branch is considered missed

    void Update()
    {
        // Check if the branch has fallen below the bottomY
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);  // Destroy the branch when it falls below bottomY
            // Handle branch missed logic if needed (optional)
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // Check if the object it collides with is tagged as "Basket"
        if (coll.gameObject.tag == "Basket")
        {
            // Get a reference to the ApplePicker component of Main Camera
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            // Call BranchPicked() method to remove a basket when branch is picked
            apScript.BranchPicked(this.gameObject);  // Pass the branch that collided
        }
    }
}
