using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private CellController[,] _gridArr;

    
    
    public void AssignGridArray(CellController[,] tempArr)
    {
        _gridArr = tempArr;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
