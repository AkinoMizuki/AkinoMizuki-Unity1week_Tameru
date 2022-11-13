using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DestroyOnLoad : MonoBehaviour
{
	public static DestroyOnLoad singleton;

    //void Awake()
    private void Start()
	{

		DontDestroyOnLoad(gameObject);
		//スクリプトが設定されていなければゲームオブジェクトを残しつつスクリプトを設定
		if (singleton == null)
		{
			DontDestroyOnLoad(gameObject);
			singleton = this;
			//　既にGameStartスクリプトがあればこのシーンの同じゲームオブジェクトを削除
		}
		else
		{
			//Destroy(gameObject);
		}
	}

}
