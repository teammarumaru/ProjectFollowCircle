using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Director : MonoBehaviour
{
    // GameObject取得
    [SerializeField]
    GameObject Success;
    [SerializeField]
    GameObject Failed;
    [SerializeField]
    GameObject GameScript;

    // ゲームの結果を取得するため
    bool isResult;

    // Start is called before the first frame update
    void Start()
    {
        // メッセージを見えないようにする
        Success.SetActive(false);
        Failed.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
