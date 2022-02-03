using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newpos = new Vector3(transform.position.x + 3* Time.deltaTime, transform.position.y, transform.position.z);
        transform.position = newpos;
    }
}
