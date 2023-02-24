using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    public float speed;
    public float destroyDelay;
    private bool hayHit;
    private bool dropped;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void HitByHay(){
        hayHit = true;
        speed = 0;
        Destroy(gameObject, destroyDelay);
    }

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Hay") && !hayHit){
            Destroy(other);
            HitByHay();
        }
    }
}
