using UnityEngine;


/// <summary>
/// By pressing a key, spawn an object from a collection of objects
/// within a certain range (radial distance) from the player's position.
/// </summary>

public class Spawner : MonoBehaviour
{
    [SerializeField]
    KeyCode spawnKey = KeyCode.G;       // User-defined keyboard input

    [SerializeField, Range(1f, 50f)]
    float spawnRange = 5f;              // User-defined range for spawning

    /* What else do we need as user-defined inputs? 
     * And do we need a Start() function?
     */

    // Your code here



    // Update is called once per frame
    void Update()
    {
        /* When spawnKey is pressed, 
         * an object is created around the player within spawnRange.
         */

        // Your code here

    }
}
