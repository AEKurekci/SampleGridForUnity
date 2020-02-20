using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cube : MonoBehaviour
{
    [SerializeField] Sprite whiteCubeWithX;
    [SerializeField] Sprite whiteCube;
    public bool X = false;

    public void Sign()
    {
        GetComponent<Image>().sprite = whiteCubeWithX;
        X = true;
    }

    public void NoSign()
    {
        GetComponent<Image>().sprite = whiteCube;
        X = false;
    }
}
