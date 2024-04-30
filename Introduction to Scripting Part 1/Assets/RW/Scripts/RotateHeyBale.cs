using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHeyBale : MonoBehaviour
{
    public float x;
    public float y;
    public float z;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(x*Time.deltaTime,y*Time.deltaTime,z*Time.deltaTime);
        
    }
}
