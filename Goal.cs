using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject player;
    public GameObject main_obj;
    public AudioClip SE;
    AudioSource audioSource;
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.name == player.name)
        {
            audioSource.PlayOneShot(SE);
            main_obj.GetComponent<Main>().PrintGameOver();

        }
    }
}
