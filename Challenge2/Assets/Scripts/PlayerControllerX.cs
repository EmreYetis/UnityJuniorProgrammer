using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    // Saniyede 2 tane
    public float timeBetweenShots = 0.5f;
    private float timestamp;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Time.time>= timestamp && (Input.GetKeyDown(KeyCode.Space)))
        {
           
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);

            timestamp = Time.time + timeBetweenShots;
        }
    }
}
