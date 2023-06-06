using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyDoorController : MonoBehaviour
    {
        private Animator doorAnimator;
        private bool doorOpen = false;

        [Header("Animation Name")]
        [SerializeField] private string openAnimation = "DoorOpen";

        [SerializeField] private int showUITime = 1;
        [SerializeField] private GameObject showDoorLockedUI = null;

        [SerializeField] private int waitTimer = 1;
        [SerializeField] private bool pauseInteraction = false;

        private void Awake()
        {
            doorAnimator = gameObject.GetComponent<Animator>();
        }

        private IEnumerator PauseDoorInteraction()
        {
            pauseInteraction = true;
            yield return new WaitForSeconds(waitTimer);
            pauseInteraction = false;
        }

        public void PlayAnimation()
        {
            if (ObjectiveManager.Manager.GetCurrentObjectiveNumber() >= 6)
            {
                if (!doorOpen && !pauseInteraction)
                {
                    doorAnimator.Play(openAnimation, 0, 0.0f);
                    doorOpen = true;
                    StartCoroutine(PauseDoorInteraction());
                }
            }
            else
            {
                StartCoroutine(ShowDoorLocked());
            }
        }

        IEnumerator ShowDoorLocked()
        {
            showDoorLockedUI.SetActive(true);
            yield return new WaitForSeconds(showUITime);
            showDoorLockedUI.SetActive(false);
        }
    }
}

