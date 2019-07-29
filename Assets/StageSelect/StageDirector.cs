using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageDirector : MonoBehaviour
{
    const int MAX_LEVEL = 3;
    const int MIN_LEVEL = 1;
    [SerializeField]
    GameObject StartButton = null;
    [SerializeField]
    GameObject leftArrow = null;
    [SerializeField]
    GameObject rightArrow = null;
    [SerializeField]
    GameObject TitleButton = null;
    [SerializeField]
    GameObject Level = null;

    int nowLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        Level.GetComponent<Text>().text = "レベル" + nowLevel.ToString();
    }

    // Update is called once per frame
    void Update()
    {
       

        // 左はマイナス
        if (leftArrow.GetComponent<Button>().GetFlug())
            nowLevel--;

        // 右はプラス
        if (rightArrow.GetComponent<Button>().GetFlug())
            nowLevel++;

        if (nowLevel <= MIN_LEVEL)
            nowLevel = MIN_LEVEL;
        if (nowLevel >= MAX_LEVEL)
            nowLevel = MAX_LEVEL;

        

        // UI反映
        Level.GetComponent<Text>().text = "レベル" + nowLevel.ToString();

        // スタートボタンが押された時シーン遷移する
        if (StartButton.GetComponent<Button>().GetFlug())
        {
            // システムマネージャーさんにレベルを渡す
            GameObject SystemManager = GameObject.Find("SystemManager");
            SystemManager.GetComponent<SystemManager>().SetLevel(nowLevel);
            // シーン遷移処理(ちゃんとプレイシーンに変更してください)
            SceneManager.LoadScene("Follow");
        }
    }
    public void BackTitle()
    {
        GameObject SystemManager = GameObject.Find("SystemManager");
        Destroy(SystemManager);
        SceneManager.LoadScene("TitleScene");
    }
}


