using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        // ef að beinið snertir hundana þá er eytt hundinum og beinið
        Destroy(gameObject);
        Destroy(other.gameObject);    
    }
}
