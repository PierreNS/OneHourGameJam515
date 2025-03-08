using UnityEngine;

public class Flag : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Material _capturedColor;
    private bool _isCaptured = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //We need to change the color and increment the falg amount in the manager...
            if (_isCaptured == false)
            {
                GameManager.Instance.IncrementFlagAmount();
                _renderer.material = _capturedColor;
                _isCaptured = true;
            }
        }
    }
}
