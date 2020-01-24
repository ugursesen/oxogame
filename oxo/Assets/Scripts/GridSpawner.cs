using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpawner : MonoBehaviour
{
    [SerializeField] private InputField _gridSizeIF;
    [SerializeField] private GridLayoutGroup _gridLayout;
    [SerializeField] private Transform _gridTransform;
    [SerializeField] private GameObject _cellPrefab;
    [SerializeField] private Text _count;

    public CellController[,] gridArr;
    public int rowAndColumnSize;
    public int cellCount;
    public int matchCount;

    public void CreateGrid()
    {
        ClearGrid();
        
        rowAndColumnSize = int.Parse(_gridSizeIF.text);
        cellCount = rowAndColumnSize * rowAndColumnSize;
        
        _gridLayout.constraintCount = rowAndColumnSize;

        _gridLayout.cellSize = new Vector2(1000 / rowAndColumnSize, 1000 / rowAndColumnSize);

        gridArr = new CellController[rowAndColumnSize,rowAndColumnSize];

        for (int i = 0; i < rowAndColumnSize; i++)
        {
            for (int j = 0; j < rowAndColumnSize; j++)
            {
                gridArr[i,j] = Instantiate(_cellPrefab, _gridTransform).GetComponent<CellController>();
                gridArr[i, j].row = i;
                gridArr[i, j].column = j;

                gridArr[i, j].AssignGridSpawnerRef(this);
            }
        }
    }

    private void ClearGrid()
    {
        for (int i = 0; i < _gridTransform.childCount; i++)
        {
            Destroy(_gridTransform.GetChild(i).gameObject);
        }
    }

    public void CheckAllCells()
    {
        for (int i = 0; i < rowAndColumnSize; i++)
        {
            for (int j = 0; j < rowAndColumnSize; j++)
            {
                gridArr[i, j].CheckPossibleMatch();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _count.text = "Match Count: " + matchCount.ToString();
    }
}
