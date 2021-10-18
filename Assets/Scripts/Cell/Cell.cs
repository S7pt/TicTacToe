using System;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public static Action<CellType> OnCellClicked;
    private Image _cellImage;
    private bool isSet = false;
    private CellType _type;

    public CellType Type
    {
        get
        {
            return _type;
        }
    }

    private void Awake()
    {
        _cellImage = GetComponent<Image>();
        _type = CellType.NONE;
    }

    private void OnMouseDown()
    {
        if (!isSet)
        {
            isSet = true;
            SetCellState();
            OnCellClicked?.Invoke(_type);
        }
    }
    //Updates the cell data according to current turn(these weird color manipulations exist solely for changing opacity)
    private void SetCellState()
    {
        (_type, _cellImage.sprite) = GameTurnState.State.GetCurrentTurnState();
        Color opaque = new Color(_cellImage.color.r, _cellImage.color.g, _cellImage.color.b, 1);
        _cellImage.color = opaque;
    }
}
