using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
       
        int comment = Random.Range(1, 5);
        switch (comment)
        {
            case 1:
                timeText.GetComponent<Text>().text = "まだまだです。もう一度やりませんか";
                break;
            case 2:
                timeText.GetComponent<Text>().text = "もう少し頑張りましょう";
                break;
            case 3:
                timeText.GetComponent<Text>().text = "その調子です";
                break;
            case 4:
                timeText.GetComponent<Text>().text = "中々やりますねぇ";
                break;
            case 5:
                timeText.GetComponent<Text>().text = "おめでとうございます";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
