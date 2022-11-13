using UnityEngine;

public class AvatarSet : MonoBehaviour
{
    public GameObject Avatar;
    public GameObject PlayerArmature;


    // Start is called before the first frame update
    void Start()
    {
        Avatar = GameObject.Find("VRM1");

        Transform AvatarCount = PlayerArmature.GetComponentInChildren<Transform>();
        
        if (Avatar != null)
        {
            //子要素を全て消去
            if (AvatarCount.childCount != 0)
            {
                //子オブジェクトを一つずつ取得
                foreach (Transform child in AvatarCount.transform)
                {
                    if (child.gameObject.name != "PlayerCameraRoot")
                    {
                        //削除する
                        Destroy(child.gameObject);
                    }
                }
        
            }
        
            //アバターのゲームオブジェクトを取得
            var root = Avatar.gameObject;
            //アバターの位置を移動
            root.transform.position = new Vector3(0, 0, 0);
            //Avatarの子にVRM1(アバター本体を入れる)
            root.gameObject.transform.parent = PlayerArmature.transform;
            Destroy(GameObject.Find("Avatar"));

            Animator root_animator = root.gameObject.GetComponent<Animator>();
            Animator animator = PlayerArmature.gameObject.GetComponent<Animator>();
            animator.avatar = root_animator.avatar;

        }

    }



}
