using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitHP : MonoBehaviour
{

    public GameObject player;
    public GameObject HP;
    public AudioClip SE;
    AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    //ìñÇΩÇËîªíËä÷êî
    private void OnTriggerEnter(Collider other)
    {

        if (other.name == player.name)
        {
            bool Hp = HP.GetComponent<PlayerHPBar>().HpValue(-20);
            audioSource.PlayOneShot(SE);
        }
    }
}
