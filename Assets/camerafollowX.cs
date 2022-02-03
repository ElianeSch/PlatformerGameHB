using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollowX : MonoBehaviour
{
    public GameObject player;
    public float timeOffset;
    public Vector3 posOffset;

    private Vector3 velocity;


    void Update()
    {
        Vector3 newPos = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);
        transform.position = new Vector3(newPos.x, transform.position.y, transform.position.z);
        //transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);
    }
}
