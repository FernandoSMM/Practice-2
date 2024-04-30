using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenScale : MonoBehaviour
{

    public float targetScale; // 1
    public float timeToReachTarget; // 2
    private float startScale;  // 3
    private float percentScaled; // 4

    // Start is called before the first frame update
    void Start()
    {
        startScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (percentScaled < 1f) // 1
        {
            percentScaled += Time.deltaTime / timeToReachTarget; // 2
            float scale = Mathf.Lerp(startScale, targetScale, percentScaled); // 3
            transform.localScale = new Vector3(scale, scale, scale); // 4
        }
    }
}
