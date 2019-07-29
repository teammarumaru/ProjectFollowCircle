using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // スタートカウントダウンの最大値
    const int STARTCOUNTMAX = 3;

    [SerializeField]
    GameObject Instruction = null;
    [SerializeField]
    GameObject StartCountDown = null;
    [SerializeField]
    GameObject Timer = null;
    [SerializeField]
    GameObject SuccessIcon = null;
    [SerializeField]
    GameObject GameSystem = null;
    [SerializeField]
    GameObject GameDirector = null;
    
    // スタートカウントダウンからの遷移用
    bool isCountOut = false;

    // スタートカウントダウン用
    int startcount = STARTCOUNTMAX;

    // 実際の秒数カウント
    float count = 0.0f;

    // クリア時のタイム
    float cleartime = 0.0f;

    void Awake()
    {
        // 不可視化処理
        Instruction.SetActive(false);
        Timer.SetActive(false);
        GameSystem.SetActive(false);
        SuccessIcon.SetActive(false);
        // 可視化処理
        StartCountDown.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ゲームの成功を取得
        if (GameDirector.GetComponent<GameScript>().GetClear())
        {
            SuccessIcon.SetActive(true);
            cleartime = Timer.GetComponent<TimeScript>().GetTime();
            // ウェイト
            if (count >= 2.0f)
            {
                // システムを不可視化
                GameSystem.SetActive(false);
                // 回数が5回に満たない場合、再読み込みする
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else
            {
                count += Time.deltaTime;
            }

        }
        else
        {
            if (count >= 1.0f)
            {
                startcount--;
                if (startcount == 0)
                {
                    StartCountDown.SetActive(false);
                    Instruction.SetActive(true);
                    Timer.SetActive(true);
                    GameSystem.SetActive(true);
                    isCountOut = true;
                    count = 0;
                }
                count = 0;
            }
            else
            {
                count += Time.deltaTime;
            }

            if (!isCountOut)
            {
                StartCountDown.GetComponent<Text>().text = "" + startcount.ToString();
            }
        }

       


        //// アニメーションテスト(表示の瞬間にアニメーションが始まるOK)
        //if(Input.GetKeyDown(KeyCode.Z))
        //{
        //    Instruction.SetActive(true);
        //}
    }
}
