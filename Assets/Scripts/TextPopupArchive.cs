using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using InteractionScripts;

public class TextPopup : MonoBehaviour
{

    public EmptyInteractable interactable;
    public GameObject panel;
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;   // Ciel: time duration(second) between letters displayed, the slower the faster
    
    private int index;
    
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartText();
    }

    // Update is called once per frame
    void Update()
    {
/*        bool onInteract = interactable._onInteract;
        if (onInteract)
        {
            print("On interact");   // !!! Ciel: debug line
            StartText();
        }*/
        if(Input.GetMouseButtonDown(0))
        {
            if(textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }


    }

    void StartText()
    {
        index = 0;
        panel.SetActive(true);
        textComponent.gameObject.SetActive(true);
        StartCoroutine(TypeLine());
    }

    // This enumerator types out each character in a line one by one
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray()) {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            textComponent.gameObject.SetActive(false);
            panel.SetActive(false);
        }
    }
}
