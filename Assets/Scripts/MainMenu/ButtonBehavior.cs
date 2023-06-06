using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ButtonBehavior : MonoBehaviour
{

    public TMP_Text line;

    // Start is called before the first frame update
    void Start()
    {
        line.CrossFadeAlpha(0f,0f, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseOver()
    {
        line.CrossFadeAlpha(1.0f, 0.3f, false);
    }

    public void OnMouseExit()
    {
        line.CrossFadeAlpha(0.0f, 0.1f, false);
    }
}
