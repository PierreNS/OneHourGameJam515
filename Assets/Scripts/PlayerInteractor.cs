using OHGJ515.Interaction;
using OHGJ515.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace OHGJ515.Player
{
    public class PlayerInteractor : Interactor
    {
        public bool IsInFocus {  get; private set; }

        public void OnInteract(InputValue value)
        {
            Debug.Log("Pew pew");
            Interact();
        }

        public void UpdateInteractable()
        {
            CheckForInteractable(transform.position + RaycastOffset, transform.forward, RaycastDistance, InteractableMask,true);

            UpdateFocusState();
        }

        public void Interact()
        {
            //Debug.Log($"Interacting with: {Interactable}");
            if (Interactable != null)
            {
                Interactable.Interact();
                UpdateFocusState();
            }
        }

        private void UpdateFocusState() 
        {
            if (Interactable is IFocusable focusedObject)
            {
                IsInFocus = focusedObject.IsInFocus;
            }
        }

        private void Update()
        {
            UpdateInteractable();
        }
    }
}