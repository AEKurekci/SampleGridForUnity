using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenX : MonoBehaviour
{
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
    public void Active()
    {
        Debug.Log("active");
        FindObjectOfType<Cube>().Sign();
    }

    public void Inactive()
    {
        FindObjectOfType<Cube>().NoSign();
    }
}
