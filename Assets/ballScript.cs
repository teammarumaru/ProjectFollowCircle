using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballScript : MonoBehaviour
{
    public GameObject text;
    public GameObject canvas;
    bool flag_Select;
    public int num;

    public Sprite CircleSprite;
    public Sprite SquareSprite;
    public Sprite TriangleSprite;

    // Start is called before the first frame update
    public void StartBall(int num, GameObject canvas, Vector2 pos)
    {
        this.num = num;
        this.canvas = canvas;
        this.transform.position = pos;
        

        if(this.tag.Contains("square"))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite=SquareSprite;
        }
        if (this.tag.Contains("triangle"))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = TriangleSprite;
        }
        if (this.tag.Contains("red"))
        {
            //E06F6F
            this.GetComponent<Renderer>().material.color=new Color(0.877f, 0.434f, 0.434f, 1);
        }
        if(this.tag.Contains("blue"))
        {
            //76BFEF
            this.GetComponent<Renderer>().material.color = new Color(0.462f, 0.749f, 0.937f, 1);
        }
        if (this.tag.Contains("green"))
        {
            //AAEE77
            this.GetComponent<Renderer>().material.color = new Color(0.665f, 0.933f, 0.462f, 1);
        }

        flag_Select = false;
        GameObject p = Instantiate(text) as GameObject;
        p.transform.position = this.transform.position;
        p.transform.SetParent(canvas.transform,false);
        p.GetComponent<Text>().text = num.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GetSelect()
    {
        return this.flag_Select;
    }

    public void SetSelect(bool f)
    {
        this.flag_Select = f;
    }
}
