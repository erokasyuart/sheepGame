using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenScale : MonoBehaviour
{
    public float targetScale;//end size
    public float timeToReachTarget;//time it takes
    private float startScale;//start size
    private float percentScaled;//between 0.0 and 1.0
    // Start is called before the first frame update
    void Start()
    {
        startScale = transform.localScale.x; //start scale is set as current size of model on start
    }

    // Update is called once per frame
    void Update()
    {
        if (percentScaled < 1f){
            percentScaled += Time.deltaTime / timeToReachTarget; //percent increases over time
            float scale = Mathf.Lerp(startScale, targetScale, percentScaled); //lerp finds two numbers based on a percent
            //(start value, end value, percent) like a graph
            transform.localScale = new Vector3(scale,scale,scale); //changes the xyz transform scale using the lerp
        }
    }
}
