using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//For Testing Random ideas that might not work with an existing script that is active
public class TestScript : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
