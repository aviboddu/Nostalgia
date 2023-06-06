using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KeySystem
{
    public class KeyRaycast : MonoBehaviour
    {
        [SerializeField] private int rayLength = 5;
        [SerializeField] private LayerMask layerMaskInteract;
        [SerializeField] private string excluseLayerName = null;

        private KeyItemController raycastedObj;

        // open door on mouse click
        [SerializeField] private KeyCode openDoorKey = KeyCode.Mouse0;

        private string interactableTag = "BathDoorInteract";
        private bool doOnce;

        private void Update()
        {
            RaycastHit hit;
            Vector3 fwd = transform.TransformDirection(Vector3.forward);

            int mask = 1 << LayerMask.NameToLayer(excluseLayerName) | layerMaskInteract.value;

            if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
            {
                if (hit.collider.CompareTag(interactableTag))
                {
                    Debug.Log("collided");
                    if (!doOnce)
                    {
                        raycastedObj = hit.collider.gameObject.GetComponent<KeyItemController>();
                        Debug.Log("picked up key");
                    }
                    doOnce = true;
                    if (Input.GetKeyDown(openDoorKey))
                    {
                        raycastedObj.ObjectInteraction();
                    }
                }
            }
        }
    }
}

