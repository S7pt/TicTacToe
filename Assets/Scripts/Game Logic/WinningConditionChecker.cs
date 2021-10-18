using System;
using UnityEngine;

public class WinningConditionChecker : MonoBehaviour
{
    public static Action<CellType> OnGameEnded;
    private Cell[] _cells;
    private void Start()
    {
        _cells = GetComponentsInChildren<Cell>();
        Cell.OnCellClicked += CheckForWinner;
    }
    //Checks if the current move lead to a win
    //(I am sure there are more optimized algorithm for that, but i couldn't come up with one)
    private void CheckForWinner(CellType type)
    {
        for(int i = 0; i < 9; i += 3)
        {
            if(_cells[i]?.Type == type && _cells[i+1]?.Type == type && _cells[i + 2]?.Type == type)
            {
                OnGameEnded(type);
            }
        }
        for(int i = 0; i < 3; i++)
        {
            if (_cells[i]?.Type == type && _cells[i + 3]?.Type == type && _cells[i + 6]?.Type == type)
            {
                OnGameEnded(type);
            }
        }
        if(_cells[0]?.Type == type && _cells[4]?.Type == type && _cells[8]?.Type == type)
        {
            OnGameEnded(type);
        }
        else if(_cells[2]?.Type == type && _cells[4]?.Type == type && _cells[6]?.Type == type)
        {
            OnGameEnded(type);
        }
        if (CheckForTie())
        {
            OnGameEnded(CellType.NONE);
        }
    }
    //Checks if the game ended as tie(no empty cells left)
    private bool CheckForTie()
    {
        int emptyCells = 0;
        foreach (Cell cell in _cells)
        {
            if (cell.Type == CellType.NONE)
            {
                emptyCells++;
            }
        }
        return emptyCells == 0;
    }
    private void OnDestroy()
    {
        Cell.OnCellClicked -= CheckForWinner;
    }
}
