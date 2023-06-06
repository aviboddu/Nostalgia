using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace InteractionScripts
{
    public class EndingInteraction : Interactable
    {
        public Image endingScreen;

        private bool _canInteract;
        // Start is called before the first frame update
        void Start()
        {
            ObjectiveManager.Manager.ObjectiveChange += AllowInteract;
        }
        
        public override bool CanInteract()
        {
            return _canInteract;
        }

        public override void OnInteract()
        {
            _canInteract = false;
            StartCoroutine(fadeIn(2));
        }

        private void AllowInteract(int objective)
        {
            if (objective >= 13)
            {
                _canInteract = true;
                ObjectiveManager.Manager.ObjectiveChange -= AllowInteract;
            }
        }

        private IEnumerator fadeIn(float time)
        {
            for (float t = 0; t <= time; t += Time.deltaTime)
            {
                endingScreen.color = new Color(endingScreen.color.r, endingScreen.color.g, endingScreen.color.b, t / time);
                yield return null;
            }

            SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
        }
    }
}
