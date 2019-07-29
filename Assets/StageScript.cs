using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageScript : MonoBehaviour
{
    public int stage;
    public int level;

    public GameObject ball;
    public GameObject canbas;

    public string successTag;

    // Start is called before the first frame update
    void Start()
    {
        int num = stage;    // 各ステージごとのボールの総数　なんかうまいこと計算する
        if(num<3)
            num = 3;

        // level2以上の違う色だったりするやつたち
        int wrongNum = Random.Range(0, num);
        int wrongNum2 = Random.Range(0, num); 
        while(wrongNum == wrongNum2)
        {
            wrongNum2 = Random.Range(0, num);
        }

        // その他乱数たち
        int r1 = Random.Range(1, 4);
        int r2 = Random.Range(1, 4);
        while(r1==r2)
        {
            r2 = Random.Range(1, 4);
        }
        int r3 = Random.Range(1, 4);
        int r4 = Random.Range(1, 4);
        while (r3 == r4)
        {
            r4 = Random.Range(1, 4);
        }

        if (level == 2)
        {
            switch (r1)
            {
                case 1:
                    successTag = "circle";
                    break;
                case 2:
                    successTag = "triangle";
                    break;
                case 3:
                    successTag = "square";
                    break;
            }
        }
        else if(level==3)
        {
            switch(r1)
            {
                case 1:
                    successTag = "green";
                    break;
                case 2:
                    successTag = "red";
                    break;
                case 3:
                    successTag = "blue";
                    break;
            }
        }
        else
        {
            successTag = "circle";
        }


        List<GameObject> b;
        b = new List<GameObject>();
        for (int i = 0; i < num; i++)
        {
            b.Add(Instantiate<GameObject>(ball) as GameObject);
            int bx = Random.Range(-113, 113);
            int by = Random.Range(-55, 40);
            Vector2 bPos = new Vector2(bx, by);
            for (int j = i-1; j >= 0; j--) 
            {
                if (b[j])
                {
                    while (Vector2.Distance(bPos, b[j].transform.position) <= 50)
                    {
                        bx = Random.Range(-113, 113);
                        by = Random.Range(-55, 40);
                        bPos = new Vector2(bx, by);
                    }
                }
            }

            switch(level)
            {
                case 1:
                    successTag = "white";
                    b[i].tag = "white_circle";
                    break;
                case 2:
                    int a = r1;
                    if(i==wrongNum)
                    {
                        a = r2;
                    }
                    switch (a)
                    {
                        case 1:
                            b[i].tag = "white_circle";
                            break;
                        case 2:
                            b[i].tag = "white_triangle";
                            break;
                        case 3:
                            b[i].tag = "white_square";
                            break;
                    }
                    break;
                case 3:
                    int a2 = r1;
                    if (i == wrongNum)
                    {
                        a2 = r2;
                    }
                    switch (a2)
                    {
                        case 1:
                            b[i].tag = "green_circle";
                            break;
                        case 2:
                            b[i].tag = "red_circle";
                            break;
                        case 3:
                            b[i].tag = "blue_circle";
                            break;
                        default:
                            print("(´・ω・`)");
                            break;
                    }
                    break;
            }
            b[i].GetComponent<ballScript>().StartBall(i + 1, canbas, bPos);
        }

        GameObject m=GameObject.Find("GameObject");
        m.GetComponent<GameScript>().ball = b;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
