using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{


    [SerializeField]
    public GameObject player;
    public GameObject Result_obj;
    public GameObject HP_obj;
    public GameObject Teme_obj;
    public TextMeshProUGUI TimeText;
    public Animation ResultAnimation;
    public float limit = 120.0f;
    public Button RetryButton;
    public Button TitleButton;
    private Animation anim;
    public GameObject PlayerHPBar;
    public GameObject ButtonSE;
    public AudioClip SE;
    AudioSource audioSource;

    public bool OneFlag = true;

    void Start()
    {
        RetryButton.onClick.AddListener(On_RetryButton);
        TitleButton.onClick.AddListener(On_TitleButton);
        TimeText.text = "残り時間：000.0";
        OneFlag = true;
        anim = ResultAnimation.gameObject.GetComponent<Animation>();
        sleep(1f);
        player.GetComponent<StarterAssetsInputs>().cursorLocked = false;
        player.GetComponent<StarterAssetsInputs>().cursorInputForLook = false;
        audioSource = ButtonSE.GetComponent<AudioSource>();
        gameObject.GetComponent<AudioSource>().Play();
    }

    void Update()
    {

        if (OneFlag == true)
        {
            sleep(3f);
            player.GetComponent<StarterAssetsInputs>().cursorLocked = true;
            player.GetComponent<StarterAssetsInputs>().cursorInputForLook = true;

        }

        if (OneFlag == false)
        {

            if (Input.GetKeyDown(KeyCode.Return))
            {
                On_TitleButton();
            }
        
        }


        if (PlayerHPBar.GetComponent<PlayerHPBar>().currentHp == 0)
        {
            if (OneFlag == true)
            {
                PrintGameOver();
            }
        }

        if (player.transform.position.y < -5)
        {
            if (OneFlag == true)
            {
                PrintGameOver();
            }
        }

        if (limit < 0)
        {
            if (OneFlag == true)
            {
                PrintGameOver();
            }

            return;
        }

        limit -= Time.deltaTime;
        TimeText.text = "残り時間：" + limit.ToString("f1");

    }

    IEnumerator sleep(float sec)
    {

        yield return new WaitForSeconds(sec);  //10秒待つ
    }

    public void PrintGameOver()
    {

        OneFlag = false;
        player.GetComponent<ThirdPersonController>().enabled = false;
        player.GetComponent<Animator>().enabled = false;
        player.GetComponent<StarterAssetsInputs>().move.x = 0;
        player.GetComponent<StarterAssetsInputs>().move.y = 0;
        player.GetComponent<StarterAssetsInputs>().look.x = 0;
        player.GetComponent<StarterAssetsInputs>().look.y = 0;
        player.GetComponent<StarterAssetsInputs>().cursorLocked = false;
        player.GetComponent<StarterAssetsInputs>().cursorInputForLook = false;
        Teme_obj.gameObject.SetActive(false);
        Result_obj.gameObject.SetActive(true);
        HP_obj.transform.localPosition = new Vector3(0, 0, 0);
        HP_obj.transform.localScale = new Vector3(2.5f , 2.5f, 0);

        //アニメーションを再生
        //anim.Play();

    }

    public void On_RetryButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void On_TitleButton()
    {
        player.GetComponent<StarterAssetsInputs>().cursorLocked = false;
        player.GetComponent<StarterAssetsInputs>().cursorInputForLook = false;
        audioSource.PlayOneShot(SE);
        Invoke("SetBool", 0.5f);

    }

    void SetBool()
    {
        Destroy(player);
        SceneManager.LoadScene("StartScene");
    }

}
