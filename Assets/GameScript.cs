using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public List<ballScript> ball;
    List<GameObject> select;

    // 予定
    // ・ステージ制になるだろうからステージに応じて判別するtag名を変える
    // ・そのためにゲームマネージャーがいる
    // ・その前にレベルデザインさん
    // 

    void Start()
    {
        select = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // マウス押した瞬間
        {
            SelectBall();
        }


        if(Input.GetMouseButton(0)) //マウス押してるとき
        {
            if (select?.Count > 0)  //select(list)が空じゃないとき
            {
                SelectBall();
            }
        }


        if(Input.GetMouseButtonUp(0))   //マウス離したとき
        {
            if (select?.Count > 0)  //なんか１個でも選択してるとき
            {
                int n = 0;      // １個前の数字　これ以上だったらOK
               bool g = true;   // 成否判定　変数名思いつかなかった顔をしている
                if (select.Count == ball.Count)  //　←今はボールの総数＝答えてほしい総数だからこれでいいけど後のためにも変えような！
                {
                   
                    for (int i = 0; i < select.Count; i++)
                    {
                        if (g == true && n <= select[i].GetComponent<ballScript>().num)
                        {
                            n = select[i].GetComponent<ballScript>().num;
                            print(n);
                        }
                        else
                        {
                            g = false;
                        }
                        select[i].GetComponent<ballScript>().SetSelect(false);
                    }
                }
                else
                {
                    for (int i = 0; i < select.Count; i++)
                    {
                        select[i].GetComponent<ballScript>().SetSelect(false);
                    }
                    g = false;
                }

                // そもそもなんも選択してないときは判定されない
                if(g)
                {
                    Debug.Log("成功");
                }
                else
                {
                    Debug.Log("失敗");
                }
                select.Clear();
            }
        }
    }

    bool SelectBall()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, new Vector3(0, 0, 1), 100);

        if (hit.collider && hit.collider.gameObject.GetComponent<ballScript>().GetSelect() == false)
        {
            //既に選択中のボールは入れない
            select.Add(hit.collider.gameObject);
            hit.collider.gameObject.GetComponent<ballScript>().SetSelect(true);
            //Debug.Log(hit.collider.transform.tag);
            if(hit.collider.transform.tag.Contains("white"))    //タグ名にwhiteがあるか(テスト)
            {
                Debug.Log("white");
            }
            return true;
        }
        return false;
    }
}
