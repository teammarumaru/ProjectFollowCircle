using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // スタートカウントダウンの最大値
    const int STARTCOUNTMAX = 3;

    [SerializeField]
    GameObject Instruction = null;
    [SerializeField]
    GameObject StartCountDown = null;
    [SerializeField]
    GameObject timer = null;

    // スタートカウントダウンからの遷移用
    bool isCountOut = false;

    // スタートカウントダウン用
    int startcount = STARTCOUNTMAX;

    // 実際の秒数カウント
    float count = 0;
    // Start is called before the first frame update
    void Start()
    {
        // 最初指示は見えないようにする。
        Instruction.SetActive(false);
        timer.SetActive(false);
        // 念のため
        StartCountDown.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        if (count >= 1.0f)
        {
            startcount--;
            if (startcount == 0)
            {
                StartCountDown.SetActive(false);
                Instruction.SetActive(true);
                timer.SetActive(true);
                isCountOut = true;
            }
            count = 0;
        }
        else
        {
            count += Time.deltaTime;
        }

        if(!isCountOut)
        {
            StartCountDown.GetComponent<Text>().text = "" + startcount.ToString();
        }
        //// アニメーションテスト(表示の瞬間にアニメーションが始まるOK)
        //if(Input.GetKeyDown(KeyCode.Z))
        //{
        //    Instruction.SetActive(true);
        //}
    }
}
