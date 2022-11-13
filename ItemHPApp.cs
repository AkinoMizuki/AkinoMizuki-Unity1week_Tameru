using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHPApp : MonoBehaviour
{

    public GameObject player;
    public GameObject HP;
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
            //��U���O�ɏo��
            audioSource.PlayOneShot(SE);
            bool Hp = HP.GetComponent<PlayerHPBar>().HpValue(10);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            RecursiveSetActive(this.gameObject, false);


        }
    }
    private void RecursiveSetActive(GameObject a_CheckObject, bool a_OnOff)
    {
        // �ΏۃI�u�W�F�N�g�̎q�I�u�W�F�N�g���`�F�b�N����
        foreach (Transform child in a_CheckObject.transform)
        {
            // �q�I�u�W�F�N�g�̃A�N�e�B�u��؂�ւ���
            GameObject childObject = child.gameObject;
            childObject.SetActive(a_OnOff);

            // �ċA�I�ɑS�Ă̎q�I�u�W�F�N�g����������
            RecursiveSetActive(childObject, a_OnOff);
        }
    }

}