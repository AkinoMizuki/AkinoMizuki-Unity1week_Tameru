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
            //一旦ログに出力
            audioSource.PlayOneShot(SE);
            bool Hp = HP.GetComponent<PlayerHPBar>().HpValue(10);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            RecursiveSetActive(this.gameObject, false);


        }
    }
    private void RecursiveSetActive(GameObject a_CheckObject, bool a_OnOff)
    {
        // 対象オブジェクトの子オブジェクトをチェックする
        foreach (Transform child in a_CheckObject.transform)
        {
            // 子オブジェクトのアクティブを切り替える
            GameObject childObject = child.gameObject;
            childObject.SetActive(a_OnOff);

            // 再帰的に全ての子オブジェクトを処理する
            RecursiveSetActive(childObject, a_OnOff);
        }
    }

}