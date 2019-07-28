using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    bool  pushflag = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        pushflag = false;
    }
    
    public bool GetFlug()
    {
        return pushflag;
    }
    public void SetFlug()
    {
        pushflag = true;
    }
}
