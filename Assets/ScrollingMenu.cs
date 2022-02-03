using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingMenu : MonoBehaviour
{
    public Animator anim;

    private void Awake()
    {
        
    }



    void Start()
    {
        
    }

    void Update()
    {
        anim.SetFloat("Speed", 6);
        transform.Translate(3f*Time.deltaTime, 0, 0);
    }
}
