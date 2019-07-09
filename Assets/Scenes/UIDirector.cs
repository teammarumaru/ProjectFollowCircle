using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDirector : MonoBehaviour
{
    [SerializeField]
    GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ディレクターかそのへんからスコアを取得
        // 一時的に0代入
        float score = 0;
        // 反映
        this.text.GetComponent<Text>().text =
            "スコア：" + score.ToString("F1"); 
    }
}
