using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridScript : MonoBehaviour
{
    [SerializeField] public int rows;
    [SerializeField] public int cols;
    [SerializeField] Vector2 gridSize;
    [SerializeField] Vector2 gridOffset;

    [SerializeField] Button square;
    Vector2 cellSize;
    public List<List<GameObject>> allSquares;
    // Start is called before the first frame update
    void Start()
    {
        InitializeCells();
    }

    public void InitializeCells()
    {
        allSquares = new List<List<GameObject>>();
        RectTransform rectTransformOfButton = (RectTransform)square.transform;
        cellSize = rectTransformOfButton.rect.size;

        Vector2 newCellSize = new Vector2(gridSize.x / (float)cols, gridSize.y / (float)rows);
        cellSize = newCellSize;
        rectTransformOfButton.sizeDelta = new Vector2(newCellSize.x, newCellSize.y);
        gridOffset.x = -(gridSize.x / 2) + cellSize.x / 2;
        gridOffset.y = -(gridSize.y / 2) + cellSize.y / 2;
        for (int row = 0; row < rows; row++)
        {
            allSquares.Add(new List<GameObject>());
            for(int col = 0; col < cols; col++)
            {
                //positions individually cells
                Vector2 position = new Vector2(col * cellSize.x + gridOffset.x,
                    row * cellSize.y + gridOffset.y);

                //instantiate all cells their own positions
                GameObject cell = Instantiate(square.gameObject, position, Quaternion.identity) as GameObject;
                cell.GetComponent<Sign>().row = row;
                cell.GetComponent<Sign>().col = col;
                allSquares[row].Add(cell);

                //set a parent for move all cells together
                cell.transform.SetParent(transform, false);
            }
        }
    }
    public void ClearGridField()
    {
        for(int i = 0; i < FindObjectsOfType<Sign>().Length; i++)
        {
            Destroy(FindObjectsOfType<Sign>()[i].gameObject);
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, gridSize);
    }
}
