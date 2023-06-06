using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyItemController : MonoBehaviour
    {
        [SerializeField] private bool door = false;
        [SerializeField] private bool key = false;

        [SerializeField] private KeyInventory _keyInventory = null;

        private KeyDoorController doorObj;

        private void Start()
        {
            if (door)
            {
                doorObj = GetComponent<KeyDoorController>();
            }
        }

        public void ObjectInteraction()
        {
            if (door)
            {
                doorObj.PlayAnimation();
            }
            else if (key)
            {
                _keyInventory.hasKey = true;
                gameObject.SetActive(false);
            }
        }
    }
}

