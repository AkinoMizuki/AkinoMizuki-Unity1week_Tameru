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
		//�X�N���v�g���ݒ肳��Ă��Ȃ���΃Q�[���I�u�W�F�N�g���c���X�N���v�g��ݒ�
		if (singleton == null)
		{
			DontDestroyOnLoad(gameObject);
			singleton = this;
			//�@����GameStart�X�N���v�g������΂��̃V�[���̓����Q�[���I�u�W�F�N�g���폜
		}
		else
		{
			//Destroy(gameObject);
		}
	}

}
