using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    private static Building _instance = null;

    public static Building instance { get { return _instance; } set { _instance = value; } }
    [System.Serializable]
    public class Level
    {
        public int level = 1;
        public Sprite icon;
        public GameObject mesh;
    }

    private GridScript grid;

    [SerializeField] private int _rows = 1, _cols = 1; 
    public int rows { get { return _rows; } }
    public int cols { get { return _cols; } }

    [SerializeField] private MeshRenderer baseRenderer;
    public Level[] levels;

    private int currentX = 0; public int _currentX { get { return currentX; } }
    private int currentY = 0; public int _currentY { get { return currentY; } }
    private int X =0;
    private int Y =0;


    public void PlaceOnGrid(int x, int y)
    {
        currentX = x;
        currentY = y;
        X = x;
        Y = y;
        Vector3 position = UIMain.Instance.grid.GetCenterPosition(x,y,_rows,_cols);
        transform.position = position;
    }
    public void StartMovingOnGrid()
    {
        X = currentX;
        Y = currentY;

    }
    public void RemoveFromGrid()
    {
        _instance = null;
        Destroy(gameObject);
        CameraControll.Instance.isPlacingBuilding = false;
    }

    public void UpdateGridPosition(Vector3 basePos, Vector3 currentPosition)
    {
        Vector3 dir = UIMain.Instance.grid.transform.TransformPoint(currentPosition) - UIMain.Instance.grid.transform.TransformPoint(basePos);
        int xDis = Mathf.RoundToInt(dir.x / UIMain.Instance.grid.cellSizseValue);
        int yDis = Mathf.RoundToInt(dir.z / UIMain.Instance.grid.cellSizseValue);

        currentX = X + xDis;
        currentY = Y + yDis;

        Vector3 position = UIMain.Instance.grid.GetCenterPosition(currentX,currentY, _rows, _cols);
        transform.position = position;
    }
}
