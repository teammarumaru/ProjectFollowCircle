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
    // Start is called before the first frame update
    void Start()
    {
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
