using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System;
using UniGLTF;
using TMPro;
using UnityEngine.Networking;
using System.Runtime.InteropServices;

namespace UniVRM10.VRM10Viewer
{/*=== VRM10Viewer ===*/


    public class ViewImport : MonoBehaviour
    {/*=== ViewImport ===*/

        [SerializeField]
        UniHumanoid.HumanPoseTransfer m_target;

        public Button DefaultButton;
        public GameObject AvatarPos;
        public Button LoadButton;
        public Button StartButton;
        public AudioClip SE;
        AudioSource audioSource;

        public static string path { get; internal set; }

        private int length;
        private int index;
        private List<byte> byteContent = new List<byte>();

        public void ByteLength(int length)
        {
            this.length = length;
            index = 0;
            byteContent.Clear();
        }

        public void AddRange(string byteString)
        {
            var decode = Convert.FromBase64String(byteString);
            byteContent.AddRange(decode);
            index += 1;
            if (length != index) return;
            Spawn();
        }
        public void Spawn()
        {
            var vrmBytes = byteContent.ToArray();
            //var context = new VRMImporterContext();
            //context.ParseGlb(vrmBytes);
            //context.Load();
            //context.ShowMeshes();
            //context.EnableUpdateWhenOffscreen();
        }

        void Start()
        {//Start

            //Componentを扱えるようにする
            DefaultButton.onClick.AddListener(On_FileSelect);
            LoadButton.onClick.AddListener(On_LoadFileSelect);
            StartButton.onClick.AddListener(OnClickGameStart);
            audioSource = gameObject.GetComponent<AudioSource>();

        }//END_Start


        void Update()
        {

            if (Input.GetKeyDown(KeyCode.Return))
            {
                OnClickGameStart();
            }

        }



        void On_FileSelect()
        {//VRMファイルを選択する

            //StartCoroutine(LoadJson(Application.streamingAssetsPath + "/AliciaSolid_vrm-0.51.vrm"));
            //StartCoroutine(LoadJson("http://hyoudoukan.info/Portfolio/Game/GameDebug/StreamingAssets/AliciaSolid_vrm-0.51.vrm"));

        }//EDN_VRMファイルを選択する

        void On_LoadFileSelect()
        {//VRMファイルを選択する

            //StartCoroutine(LoadJson(Application.streamingAssetsPath + "/Akino.vrm"));
            //StartCoroutine(LoadJson("http://hyoudoukan.info/Portfolio/Game/GameDebug/StreamingAssets/Akino.vrm"));

        }//EDN_VRMファイルを選択する

        private IEnumerator LoadJson(string url)
        {

            UnityWebRequest webRequest = UnityWebRequest.Get(url);
            yield return webRequest.SendWebRequest();
            if (webRequest.isNetworkError)
            {
                // エラー処理
                yield break;
            }
            Debug.Log(webRequest.responseCode);
            LoadVRMClicked(webRequest.downloadHandler.data);

            //WWW www = new WWW(url);
            //
            //while (!www.isDone)
            //{
            //    yield return null;
            //}
            //if (www.error == null)
            //{
            //    LoadVRMClicked(www.bytes);
            //}
            //else
            //{
            //    print(www.error);
            //}
        }

        public async void LoadVRMClicked(Byte[] url)
        {

            var path = url;

            //アバター読み込み
            var instance = await LoadAsync(path, new VRMShaders.RuntimeOnlyAwaitCaller());

            Transform AvatarCount = AvatarPos.GetComponentInChildren<Transform>();

            //子要素を全て消去
            if (AvatarCount.childCount != 0)
            {
                //子オブジェクトを一つずつ取得
                foreach (Transform child in AvatarCount.transform)
                {
                    //削除する
                    Destroy(child.gameObject);
                }
            
            }

            //アバターのゲームオブジェクトを取得
            var root = instance.gameObject;
            //アバターの位置を移動
            root.transform.position = new Vector3(0, 0, 0);
            //Avatarの子にVRM1(アバター本体を入れる)
            root.gameObject.transform.parent = AvatarPos.transform;

        }

        async Task<Vrm10Instance> LoadAsync(Byte[] path, VRMShaders.IAwaitCaller awaitCaller)
        {
            var instance = await Vrm10.LoadBytesAsync(path, awaitCaller: awaitCaller);
            // VR用 FirstPerson 設定
            await instance.Vrm.FirstPerson.SetupAsync(instance.gameObject, awaitCaller);

            return instance;
        }
        
        public void OnClickGameStart()
        {
            audioSource.PlayOneShot(SE);
            Invoke("SetBool", 0.5f);
        }
        void SetBool()
        {
            SceneManager.LoadScene("MainScene");
        }
    }/*=== END_ViewImport ===*/



}/*=== END_VRM10Viewer ===*/