using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{

    public Text pnjNameText;
    public Animator animator;
    public static ShopManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Plus d'une instance de ShopManager dans la scène");
        }
        instance = this;
    }



    public void EndDialogue()
    {
        animator.SetBool("isOpen", false);
    }

}
