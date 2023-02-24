using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    public float speed;
    public float destroyDelay;
    private bool hayHit;
    private bool dropped;

    public float dropDestroyDelay; //the delay before sheep is destroyed by the dropper
    private Collider myCollider;
    private Rigidbody myRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();
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
        else if (other.CompareTag("DropSheep") && !dropped)
        Drop();
    }

    private void Drop(){
        dropped = true;
        myRigidbody.isKinematic = false;
        myCollider.isTrigger = false;
        Destroy(gameObject, dropDestroyDelay);
    }
}