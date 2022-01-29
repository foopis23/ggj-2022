using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    public Transform cameraLocation;
    public float maxInteractionDistance = 2.0f;

    private IInteractable _lastLookedAt;
    
    private void Update()
    {
        if (Physics.Raycast(cameraLocation.position, cameraLocation.forward, out var hit, maxInteractionDistance))
        {
            var interactable = hit.collider.gameObject.GetComponent<IInteractable>();

            if (!interactable.IsInteractable()) return;
            
            if (interactable != _lastLookedAt)
            {
                _lastLookedAt?.OnLookStop();
                interactable?.OnLookStart();
            }
            
            interactable?.OnLook();

            if (Input.GetButtonDown("Interact"))
            {
                interactable?.OnInteract();
            }

            _lastLookedAt = interactable;
        }
        else
        {
            _lastLookedAt?.OnLookStop();
            _lastLookedAt = null;
        }
    }
}
