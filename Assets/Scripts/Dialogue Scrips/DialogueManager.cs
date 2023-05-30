using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DialogueScripts
{
    public class DialogueManager : MonoBehaviour
    {
        public TextMeshProUGUI textComponent;
        public GameObject panel;
        private Queue<string> sentences;            // Keep track of all lines in dialogue

        // Start is called before the first frame update
        void Start()
        {
            textComponent.text = string.Empty;
            SetTextComponentActive(false);
            sentences = new Queue<string>();
        }

        void SetTextComponentActive(bool ifActive)
        {
            textComponent.gameObject.SetActive(ifActive);
            panel.SetActive(ifActive);
        }

        public void StartDialogue(Dialogue dialogue)
        {
            SetTextComponentActive(true);
            sentences.Clear();
            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }
            DisplayNextSentence();
        }

        public void DisplayNextSentence()
        {
            Debug.Log("number of lines left: " + sentences.Count);
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }
            string sentence = sentences.Dequeue();
            textComponent.text = sentence;
        }

        void EndDialogue()
        {
            Debug.Log("End of Lines.");
            SetTextComponentActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                DisplayNextSentence();
            }
        }
    }
}
