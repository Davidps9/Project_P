using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    [SerializeField] Transform gridTransform;
    private int rows = 45;
    private int cols = 45;
    private float cellSize = 1; public float cellSizseValue { get {  return cellSize; } }
    // Start is called before the first frame update

    public Vector3 GetStartPosition(int x, int y)
    {
        Vector3 position = transform.position;
        position += (transform.right.normalized * x * cellSize) + (transform.forward * y * cellSize); 
        return position;
    }
    public Vector3 GetCenterPosition(int x, int y, int rows, int cols)
    {
        Vector3 position =GetStartPosition(x,y);
        position += (transform.right.normalized * cols * cellSize ) + (transform.forward * rows * cellSize );
        return position;
    }
    public Vector3 GetEndPosition(int x, int y, int rows, int columns)
    {
        Vector3 position = GetStartPosition(x, y);
        position += (transform.right.normalized * columns * cellSize) + (transform.forward.normalized * rows * cellSize);
        return position;
    }
    public bool IsWorldPositionOrIsOnPlane(Vector3 pos, int x, int y, int rows, int cols)
    {
        pos = gridTransform.InverseTransformPoint(pos);
        Rect rect = new Rect(x,y,cols,rows);
        if (rect.Contains(new Vector2(pos.x, pos.z - 80)))
        {
            return true;
        }
        return false;
    }
   
#if UNITY_EDITOR
        private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        for (int i = 0; i < rows; i++)
        {
            Vector3 point = transform.position + transform.forward.normalized * cellSize * (float)i;
            Gizmos.DrawLine(point, point + transform.right.normalized * cellSize * (float)cols);
        }
        for (int j = 0; j < cols; j++)
        {
            Vector3 point = transform.position + transform.right.normalized * cellSize * (float)j;
            Gizmos.DrawLine(point, point + transform.forward.normalized * cellSize * (float)rows);
        }
    }
#endif
}
