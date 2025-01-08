using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlaneScript : MonoBehaviour
{
    public Material Mat;
   
    private void Start()
    {
        Destroy(this.gameObject, 6f);
    }
    private void ChangeMatColor()
    {
        float R;
        float G;
        float B;
        R = UnityEngine.Random.Range(0f, 1f);
        G = UnityEngine.Random.Range(0f, 1f);
        B = UnityEngine.Random.Range(0f, 1f);
        Mat.SetColor("_Color", new Color(R, G, B));
    }

    
}
