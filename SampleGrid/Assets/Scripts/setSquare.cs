using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setSquare : MonoBehaviour
{
    [SerializeField] InputField squareNumber;
    private int n;

    public void SetGrid()
    {
        squareNumber = FindObjectOfType<InputField>();
        string theText = squareNumber.text;
        n = int.Parse(theText);
        if(n > 0)
        {
            FindObjectOfType<GridScript>().rows = n;
            FindObjectOfType<GridScript>().cols = n;
        }
        FindObjectOfType<GridScript>().ClearGridField();
        FindObjectOfType<GridScript>().InitializeCells();
    }
}
