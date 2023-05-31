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
        public static bool isActive;                // Track if any dialogue active

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
            isActive = true;
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
            int advanceFontSize = (int)(textComponent.fontSize * 0.8f);
            string continueText = $"<size={advanceFontSize}><align=center><color=#FF0000>[press C to continue]</color></size>";     // #FF0000 is red
            string endText = $"<size={advanceFontSize}><align=center><color=#0000FF>[press E to end]</color></size>";               // #0000FF is blue
            textComponent.text = sentence + "\n" + continueText + "\n" + endText;
        }

        void EndDialogue()
        {
            isActive = false;
            Debug.Log("End of Lines.");
            SetTextComponentActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))      // Ciel: Press "C" to adavance dialogue
            {
                DisplayNextSentence();
            }
            else if (Input.GetKeyDown(KeyCode.E)) // Ciel: Press "E" to end dialogue
            {
                EndDialogue();
            }
        }
    }
}
