using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    [SerializeField] public Text x;
    [SerializeField] bool signed = false;
    public int row;
    public int col;
    List<GameObject> signedSquares;
    int fromLeft = 0;
    int fromDown = 1;
    int fromRight = 2;
    int fromUp = 3;

    RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        x = GetComponentInChildren<Text>();
        rect = (RectTransform)transform;
        signedSquares = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetText()
    {
        x.text = "X";
        x.fontSize = (int)(rect.rect.width * 0.8f);
        signed = true;
        signedSquares.Add(gameObject);
        signedSquares = CheckNeighbourhood(row, col, -1);
        if(signedSquares.Count > 2)
        {
            for ( int i = 0; i < signedSquares.Count; i++)
            {
                signedSquares[i].gameObject.GetComponentInChildren<Text>().text = "";
                signedSquares[i].gameObject.GetComponent<Sign>().signed = false;
                string score = FindObjectOfType<Score>().gameObject.GetComponent<Text>().text;
                int scoreInt= int.Parse(score);
                scoreInt += 1;
                FindObjectOfType<Score>().gameObject.GetComponent<Text>().text = scoreInt.ToString();
            }
            signedSquares.Clear();  
        }
        else
        {
            signedSquares.Clear();
        }
    }

    private List<GameObject> CheckNeighbourhood(int r, int c, int fromSide)
    {
        if (FindObjectOfType<GridScript>().allSquares[r].Count > c + 1)
        {
            if (FindObjectOfType<GridScript>().allSquares[r][c + 1].GetComponent<Sign>().signed == true && fromSide != 2)
            {
                signedSquares.Add(FindObjectOfType<GridScript>().allSquares[r][c + 1]);
                signedSquares = CheckNeighbourhood(r, c + 1, fromLeft);
            }
        }
        if (0 <= r - 1)
        {
            if (FindObjectOfType<GridScript>().allSquares[r - 1][c].GetComponent<Sign>().signed == true && fromSide != 3)
            {
                signedSquares.Add(FindObjectOfType<GridScript>().allSquares[r - 1][c]);
                signedSquares = CheckNeighbourhood(r - 1, c, fromDown);
            }
        } 
        if(0 <= c - 1)
        {
            if (FindObjectOfType<GridScript>().allSquares[r][c - 1].GetComponent<Sign>().signed == true && fromSide != 0)
            {
                signedSquares.Add(FindObjectOfType<GridScript>().allSquares[r][c - 1]);
                signedSquares = CheckNeighbourhood(r, c - 1, fromRight);
            }
        }
        if (FindObjectOfType<GridScript>().allSquares.Count > r + 1)
        {
            if (FindObjectOfType<GridScript>().allSquares[r + 1][c].GetComponent<Sign>().signed == true && fromSide != 1)
            {
                signedSquares.Add(FindObjectOfType<GridScript>().allSquares[r + 1][c]);
                signedSquares = CheckNeighbourhood(r + 1, c, fromUp);
            }
        }
        return signedSquares;
    }
}
