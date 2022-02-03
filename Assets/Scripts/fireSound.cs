using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireSound : MonoBehaviour
{
    public AudioClip firesound;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayClipAt(firesound, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
