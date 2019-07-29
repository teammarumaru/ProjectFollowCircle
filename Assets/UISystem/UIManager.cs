using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // スタートカウントダウンの最大値
    const int STARTCOUNTMAX = 3;
    
    // ゲームオブジェクト取得
    [SerializeField]
    GameObject Instruction = null;
    [SerializeField]
    GameObject StartCountDown = null;
    [SerializeField]
    GameObject Timer = null;
    [SerializeField]
    GameObject SuccessIcon = null;
    [SerializeField]
    GameObject ScoreManager = null;

    // スタートカウントダウンからの遷移用
    bool isCountOut = false;

    // スタートカウントダウン用
    int startcount = STARTCOUNTMAX;

    // 実際の秒数カウント
    float count = 0;

    // 最終的なタイムスコアを保存
    float timeScore = 0;


    // Start is called before the first frame update
    void Start()
    {
        // オブジェクトの不可視化
        Instruction.SetActive(false);
        Timer.SetActive(false);
        SuccessIcon.SetActive(false);
        // オブジェクトの可視化
        StartCountDown.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // スタートカウントダウン処理
        if (count >= 0.5f)
        {
            startcount--;
            if (startcount == 0)
            {
                StartCountDown.SetActive(false);
                Instruction.SetActive(true);
                Timer.SetActive(true);
                isCountOut = true;
                count = 0;
            }
            count = 0;
        }
        else
        {
            count += Time.deltaTime;
        }
        // 文字出力
        if(!isCountOut)
        {
            StartCountDown.GetComponent<Text>().text = "" + startcount.ToString();
        }

        // ゲームクリアを検出
        {

            timeScore = Timer.GetComponent<TimeScript>().GetTime();

            // スコアマネージャーにセット

            // ウェイト
            if (count >= 10.0f)
            {
                count = 0;
                // シーンの再読み込み

            }
            else
            {
                count += Time.deltaTime;
            }

        }
        //// アニメーションテスト(表示の瞬間にアニメーションが始まるOK)
        //if(Input.GetKeyDown(KeyCode.Z))
        //{
        //    Instruction.SetActive(true);
        //}
    }
}
