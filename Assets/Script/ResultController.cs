using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultController : MonoBehaviour
{
    enum Rank
    {
        Arank = 1,
        Brank, Crank, Drank, Frank
    };

    GameObject timeText;
    GameObject commentText;
    // Start is called before the first frame update
    void Start()
    {
        timeText    = GameObject.Find("Time");
        commentText = GameObject.Find("Comment");

        DrawComment();
    }

    void DrawComment()
    {
        // 追加分プログラム　(追加:佐竹) ここから-------------------------------

        // システムマネージャー読み込み
        GameObject SystemManager = GameObject.Find("SystemManager");
        // スコアの受け皿　（追加:佐竹)
        float[] clearscore = new float[5];
        // 平均
        float average = 0;
        // システムマネージャーからスコアを取得
        for(int i = 0;i < 5; i++)
        {
            clearscore[i] = SystemManager.GetComponent<SystemManager>().GetScore(i);
            average += clearscore[i];
        }

        // 配列内の平均を求める
        average /= 5;

        // 仮出力
        Debug.Log(average);

        // 追加分　ここまで---------------------------------------------------

       
        float comment = Mathf.Floor(average);
        int a = (int)comment;

        switch (a)
        {
            case 5:
                timeText.GetComponent<Text>().text = "まだまだです。もう一度やりませんか";
                break;
            case 4:
                timeText.GetComponent<Text>().text = "もう少し頑張りましょう";
                break;
            case 3:
                timeText.GetComponent<Text>().text = "その調子です";
                break;
            case 2:
                timeText.GetComponent<Text>().text = "中々やりますねぇ";
                break;
            case 1:
                timeText.GetComponent<Text>().text = "おめでとうございます";
                break;
           // 超人のために(追加：佐竹)
            case 0:
                timeText.GetComponent<Text>().text = "素晴らしい";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // リトライボタン用関数 (追加：佐竹)
    public void RetryButton()
    {
        GameObject SystemManager = GameObject.Find("SystemManager");
        SystemManager.GetComponent<SystemManager>().SystemClear(false);
        SystemManager.GetComponent<SystemManager>().StopBGM();
        SystemManager.GetComponent<SystemManager>().SetPlayBGM();
        SceneManager.LoadScene("Follow");
    }
    // ステージ選択画面ボタン用関数(追加:佐竹)
    public void ReturnSelect()
    {
        GameObject SystemManager = GameObject.Find("SystemManager");
        SystemManager.GetComponent<SystemManager>().SystemClear(true);
        SceneManager.LoadScene("StageSelect");
    }
}
