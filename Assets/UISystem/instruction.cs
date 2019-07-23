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
        // 指示をint型整数のカテゴリ化を求む。
        // 例：0 = 小さい順になぞれ
        //     1 = 同じ形をなぞれ

        // カテゴリを取得

        // 代入

        // レベルによってスイッチ
        switch (category)
        {
            case 0:
                Message.text = "数字の小さい順になぞれ！";
                break;
            case 1:
                Message.text = "同じ形をなぞれ！";
                break;

        }



    }
}
