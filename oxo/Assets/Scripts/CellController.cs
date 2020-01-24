using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CellController : MonoBehaviour
{
    public CellType cellType;
    public int row, column;

    [SerializeField] private Sprite _markedSprite, _unmarkedSprite;
    [SerializeField] private Image _imageRef;
    
    private GridSpawner _gridSpawnerRef;
     

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AssignGridSpawnerRef(GridSpawner tempRef)
    {
        _gridSpawnerRef = tempRef;
    }
    
    public void CheckPossibleMatch()
    {
        CellController[] matches = new CellController[4];
        
        int counter=0;
        
        if (_gridSpawnerRef.gridArr[row,column].cellType==CellType.Marked)
        {
            if (column+1 < _gridSpawnerRef.rowAndColumnSize && _gridSpawnerRef.gridArr[row, column].cellType == _gridSpawnerRef.gridArr[row, column+1].cellType)
            {
                matches[counter] = _gridSpawnerRef.gridArr[row, column + 1];
                counter++;
                
            }

            if (column - 1 > 0 && _gridSpawnerRef.gridArr[row, column].cellType == _gridSpawnerRef.gridArr[row, column - 1].cellType)
            {
                matches[counter] = _gridSpawnerRef.gridArr[row, column - 1];
                counter++;
                
            }

            if (row + 1 < _gridSpawnerRef.rowAndColumnSize && _gridSpawnerRef.gridArr[row, column].cellType == _gridSpawnerRef.gridArr[row+1, column].cellType)
            {
                matches[counter] = _gridSpawnerRef.gridArr[row + 1, column];
                counter++;
                
            }

            if (row - 1 > 0 && _gridSpawnerRef.gridArr[row, column].cellType == _gridSpawnerRef.gridArr[row-1, column].cellType)
            {
                matches[counter] = _gridSpawnerRef.gridArr[row - 1, column];
                counter++;
                
            }
        }

        if (counter>=2)
        {
            UnmarkCell();

            for (int i = 0; i < matches.Length; i++)
            {
                if (matches[i]!=null)
                {
                    matches[i].UnmarkCell();
                }
               
            }

            _gridSpawnerRef.matchCount++;

        }
 
    }

    public void MarkCell()
    {
        cellType = CellType.Marked;
        _imageRef.sprite = _markedSprite;
    }

    public void UnmarkCell()
    {
        cellType = CellType.Unmarked;
        _imageRef.sprite = _unmarkedSprite;
    }

    public void CellClicked()
    {
        if (cellType==CellType.Unmarked)
        {
            MarkCell();
            _gridSpawnerRef.CheckAllCells();
        }
    }


    public enum CellType
    {
       Unmarked, Marked
    }

   
}
