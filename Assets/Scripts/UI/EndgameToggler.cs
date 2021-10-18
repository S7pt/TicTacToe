using UnityEngine;
using UnityEngine.UI;

public class EndgameToggler : MonoBehaviour
{
    [SerializeField] private GameObject _gameEndPanel;
    [SerializeField] private Text _gameEndText;

    private void Awake()
    {
        _gameEndText.gameObject.SetActive(false);
        _gameEndPanel.gameObject.SetActive(false);
    }

    private void Start()
    {
        WinningConditionChecker.OnGameEnded += EnableGameWinScreen;
    }

    //Toggles the game end panel and updates the text according to the game outcome
    private void EnableGameWinScreen(CellType winner)
    {
        _gameEndPanel.SetActive(true);
        _gameEndText.gameObject.SetActive(true);
        if (winner != CellType.NONE)
        {
            _gameEndText.text = EnumConverter.ConvertToString(winner) + " has won!";
        }
        else
        {
            _gameEndText.text = "It's a tie!";
        }
    }
    private void OnDestroy()
    {
        WinningConditionChecker.OnGameEnded -= EnableGameWinScreen;
    }
}
