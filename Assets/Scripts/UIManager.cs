using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private Transform _wonScreen;
    [SerializeField] private Transform _lostScreen;
    [SerializeField] private Transform _startScreen;

    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private TextMeshProUGUI _flagCounterText;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void ShowWonScreen() 
    {
        _wonScreen.gameObject.SetActive(true);
    }

    public void ShowLostScreen()
    {
        _lostScreen.gameObject.SetActive(true);

    }

    public void UpdateTimer(float timeLeft) 
    {
        _timerText.text = timeLeft.ToString("00");
    }

    public void UpdateFlagCounter(int flagAmount)
    {
        _flagCounterText.text = $"{flagAmount.ToString()}/5";
    }

    public void HideStartScreen()
    {
        _startScreen.gameObject.SetActive(false);
        _timerText.gameObject.SetActive(true);
        _flagCounterText.gameObject.SetActive(true);
    }
}
