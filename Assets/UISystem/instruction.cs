using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class instruction : MonoBehaviour
{
    // Start is called before the first frame update

    // レベル
    int category = 1;
    Text Message;
    void Start()
    {
        Message = GetComponent<Text>();

        // システムマネージャーからレベルを取得
        GameObject SystemManager = GameObject.Find("SystemManager");
        category = SystemManager.GetComponent<SystemManager>().GetLevel();

        // レベルによってスイッチ
        switch (category)
        {
            case 1:
                Message.text = "数字順になぞれ！";
                break;
            case 2:
                Message.text = "最も多い形をなぞれ！";
                break;
            case 3:
                Message.text = "最も多い色をなぞれ！";
                break;
        }
    }
}
