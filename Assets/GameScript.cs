using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public Camera camera_object; //カメラを取得
    private RaycastHit hit; //レイキャストが当たったものを取得する入れ物
    public List<ballScript> ball;
    List<GameObject> select;

    void Start()
    {
        select = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // マウス押した瞬間
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, new Vector3(0, 0, 1), 100);

            if (hit.collider && hit.collider.gameObject.GetComponent<ballScript>().GetSelect() == false)
            {
                select.Add(hit.collider.gameObject);
                hit.collider.gameObject.GetComponent<ballScript>().SetSelect(true);
                Debug.Log(hit.collider); //マウスのポジションからRayを投げて何かに当たったらhitに入れる
            }
        }
        if(Input.GetMouseButton(0))
        {
            if (select?.Count > 0)
            {
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(pos, new Vector3(0, 0, 1), 100);

                if (hit.collider && hit.collider.gameObject.GetComponent<ballScript>().GetSelect() == false)
                {
                    select.Add(hit.collider.gameObject);
                    hit.collider.gameObject.GetComponent<ballScript>().SetSelect(true);
                }
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            int n = 0;
            bool g = true;
            if (select?.Count > 0)
            {
                if (select.Count == ball.Count) // ココカエタホウガイイオモウ
                {
                    for (int i = 0; i < select.Count; i++)
                    {
                        if (g == true && n <= select[i].GetComponent<ballScript>().num)
                        {
                            n = select[i].GetComponent<ballScript>().num;
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

                if(g)
                {
                    Debug.Log("成功");
                }
                else
                {
                    Debug.Log("失敗");
                }
            }
        }
    }
}
