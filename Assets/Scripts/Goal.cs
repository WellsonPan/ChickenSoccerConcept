using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool chickenEntered;

    // Start is called before the first frame update
    void Start()
    {
        chickenEntered = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Chicken")
        {
            chickenEntered = true;
        }
    }
}
