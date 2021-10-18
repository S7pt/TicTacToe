using UnityEditor;
using UnityEngine;

public class GameTurnState : MonoBehaviour
{
    [SerializeField] private Sprite _cross;
    [SerializeField] private Sprite _nought;
    private static bool _isCrossTurn = true;
    //Singleton because I need only one instance of an object to correctly return current game turn state;
    private static GameTurnState _state;

    public static GameTurnState State
    {
        get
        {
            return _state;
        }
    }

    private void Awake()
    {
        if (_state != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _state = this;
        }
    }

    //Ensures the game always starts with X
    private void OnEnable()
    {
        _isCrossTurn = true;
    }

    //Returns current object according to the turn
    public (CellType,Sprite) GetCurrentTurnState()
    {
        if (_isCrossTurn)
        {
            _isCrossTurn = !_isCrossTurn;
            return (CellType.CROSS, _cross);
        }
        else
        {
            _isCrossTurn = !_isCrossTurn;
            return (CellType.NOUGHT, _nought);
        }
    }
}
