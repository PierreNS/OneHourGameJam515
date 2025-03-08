using OHGJ515.Interfaces;
using UnityEngine;

namespace OHGJ515.Interactables
{
    public class ChangeColor : MonoBehaviour, IInteractable
    {
        public Vector3 PromptPositionOffset { get; set; }
        public bool OnlyInteractWhenInFront { get; set; }

        [SerializeField] private Renderer _renderer;

        [SerializeField] private Color _interactColor;

        public void Interact()
        {
            _renderer.material.color = _interactColor;
        }

        public void OnHoverEnter()
        {
            Debug.Log($"Hovering {gameObject.name}");
        }

        public void OnHoverExit()
        {
            Debug.Log($"Not Hovering {gameObject.name}");

        }

        private void Awake()
        {
            OnlyInteractWhenInFront = false;
        }
    }
}