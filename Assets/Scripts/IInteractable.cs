using UnityEngine;

namespace OHGJ515.Interfaces
{
    public interface IInteractable
    {
        public Vector3 PromptPositionOffset { get; set; }
        public bool OnlyInteractWhenInFront { get; set; }
        public void Interact();
        public void OnHoverEnter();
        public void OnHoverExit();
    }
}