using Assets.Scripts;
using StarterAssets;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int _flagAmount;
    [SerializeField] private int _flagsToFind = 5;

    [SerializeField] private bool _haveEnoughFlag;
    [SerializeField] private Door _door;

    [SerializeField] private FirstPersonController _firstPersonController;

    private float _startCounterTime = 60;
    private bool _timerRunning = false;
    private bool _gameStarted = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.anyKeyDown)
        {
            if (_gameStarted == false)
            {
                StartGame();
            }
        }

        if (_timerRunning == true)
        {
            _startCounterTime -= Time.deltaTime;
            UIManager.Instance.UpdateTimer(_startCounterTime);

            if (_startCounterTime <= 0)
            {
                _startCounterTime = 0;
                LostGame();
            }
        }
    }

    public void IncrementFlagAmount() 
    {
        _flagAmount++;
        CheckIfEnoughFlag();
        UIManager.Instance.UpdateFlagCounter(_flagAmount);
    }

    private void CheckIfEnoughFlag()
    {
        if (_flagAmount >= _flagsToFind)
        {
            _door.OpenDoor();
        }
    }

    public void WonGame() 
    {
        _firstPersonController.MoveSpeed = 0;
        _firstPersonController.SprintSpeed = 0;

        UIManager.Instance.ShowWonScreen();
        _timerRunning = false;
    }

    public void LostGame()
    {
        _firstPersonController.MoveSpeed = 0;
        _firstPersonController.SprintSpeed = 0;

        UIManager.Instance.ShowLostScreen();
        _timerRunning = false;
    }

    public void StartGame() 
    {
        _firstPersonController.MoveSpeed = 4;
        _firstPersonController.SprintSpeed = 6;

        UIManager.Instance.HideStartScreen();

        _timerRunning = true;
        _gameStarted = true;
    }
}
