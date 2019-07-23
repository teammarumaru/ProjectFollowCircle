using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageScript : MonoBehaviour
{
    int stage=1;
    int level=1;

    public GameObject ball;
    public GameObject canbas;

    // Start is called before the first frame update
    void Start()
    {
        int num = stage;    // 各ステージごとのボールの総数　なんかうまいこと計算する
        if(num<3)
            num = 3;


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
                    while (Vector2.Distance(bPos, b[j].transform.position) <= 42)
                    {
                        bx = Random.Range(-113, 113);
                        by = Random.Range(-55, 40);
                        bPos = new Vector2(bx, by);
                    }
                }
            }
            b[i].tag = "white_circle";
            b[i].GetComponent<ballScript>().StartBall(i+1,canbas,bPos/*,"white_circle"*/); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
