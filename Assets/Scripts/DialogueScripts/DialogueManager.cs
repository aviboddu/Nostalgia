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
        public GameObject pause;
        private Queue<string> sentences; // Keep track of all lines in dialogue
        private PauseMenu _pauseMenu;

        // Start is called before the first frame update
        void Start()
        {
            textComponent.text = string.Empty;
            SetTextComponentActive(false);
            sentences = new Queue<string>();
            _pauseMenu = pause.GetComponent<PauseMenu>();
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
            int continueFontSize = (int)(textComponent.fontSize * 0.8f);
            string continueText = $"<size={continueFontSize}><color=#FF0000>[press C to continue]</color></size>";     // #FF0000 is red
            textComponent.text = sentence + "\n" + continueText;
        }

        void EndDialogue()
        {
            Debug.Log("End of Lines.");
            SetTextComponentActive(false);
        }

        // Update is called once per frame
        // Fixed Update is not called during pause
        void Update()
        {
            if (_pauseMenu.IsPaused) return;
            if (Input.GetKeyDown(KeyCode.C))
            {
                DisplayNextSentence();
            }
        }
    }
}
