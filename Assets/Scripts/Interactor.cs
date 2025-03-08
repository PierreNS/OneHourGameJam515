using OHGJ515.Interfaces;
using UnityEngine;

namespace OHGJ515.Interaction
{
    public class Interactor : MonoBehaviour
    {
        public Vector3 RaycastOffset;
        public float RaycastDistance;
        public LayerMask InteractableMask;

        [field: SerializeField] public IInteractable Interactable;

        public void CheckForInteractable(Vector3 origin, Vector3 direction, float distance, LayerMask mask, bool showDebugRay)
        {
            if (showDebugRay == true)
                Debug.DrawRay(origin, direction, Color.red, Time.deltaTime);

            RaycastHit hit;

            if (Physics.Raycast(origin, direction, out hit, distance, mask))
            {
                var newInteractable = hit.collider.GetComponent<IInteractable>();

                if (newInteractable.OnlyInteractWhenInFront == true)
                {
                    if (Vector3.Dot(transform.forward, hit.collider.transform.forward) > 0)
                    {
                        if (Interactable != null)
                            Interactable.OnHoverExit();

                        Interactable = null;
                        return;
                    }
                }

                if (newInteractable == Interactable) return;

                if (Interactable != null)
                    Interactable.OnHoverExit();

                Interactable = newInteractable;
                Interactable.OnHoverEnter();
            }
            else
            {
                if (Interactable != null)
                    Interactable.OnHoverExit();

                Interactable = null;
            }
        }
    }
}