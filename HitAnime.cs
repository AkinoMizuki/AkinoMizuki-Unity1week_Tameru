using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAnime : MonoBehaviour
{
    public GameObject player;
    public Animator anim;

    //ìñÇΩÇËîªíËä÷êî
    private void OnTriggerEnter(Collider other)
    {

        if (other.name == player.name)
        {
            anim.SetBool("Karasu", true);

        }
    }

    void Update()
    {
        if(anim.GetBool("Karasu") == true)
        {
            Invoke("SetBool", 4);

        }
    }

    void SetBool()
    {
        anim.SetBool("Karasu", false);
    }

}
