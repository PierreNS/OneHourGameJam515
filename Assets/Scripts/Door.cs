using UnityEngine;
using DG.Tweening;

namespace Assets.Scripts
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private Transform _doorTransform;
        public void OpenDoor() 
        {
            Debug.Log("Open door");
            _doorTransform.DOLocalRotate(new Vector3(0, -90, 0), 1.5f);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                GameManager.Instance.WonGame();
            }
        }
    }
}
