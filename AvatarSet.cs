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
            //�q�v�f��S�ď���
            if (AvatarCount.childCount != 0)
            {
                //�q�I�u�W�F�N�g������擾
                foreach (Transform child in AvatarCount.transform)
                {
                    if (child.gameObject.name != "PlayerCameraRoot")
                    {
                        //�폜����
                        Destroy(child.gameObject);
                    }
                }
        
            }
        
            //�A�o�^�[�̃Q�[���I�u�W�F�N�g���擾
            var root = Avatar.gameObject;
            //�A�o�^�[�̈ʒu���ړ�
            root.transform.position = new Vector3(0, 0, 0);
            //Avatar�̎q��VRM1(�A�o�^�[�{�̂�����)
            root.gameObject.transform.parent = PlayerArmature.transform;
            Destroy(GameObject.Find("Avatar"));

            Animator root_animator = root.gameObject.GetComponent<Animator>();
            Animator animator = PlayerArmature.gameObject.GetComponent<Animator>();
            animator.avatar = root_animator.avatar;

        }

    }



}
