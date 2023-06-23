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

    private SheepSpawn sheepSpawner;

    //heart
    public float heartOffset;
    public GameObject heartPrefab;

    // Start is called before the first frame update
    void Start()
    {
        speed += GameStateManager.Instance.speedInc; //takes the incrementing value from GameStateManager and adds it to speed so the speed doesnt reset when instantiated
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    //When the sheep are hit by the hay
    private void HitByHay(){
        hayHit = true;
        speed = 0; //sheep stops moving
        Destroy(gameObject, destroyDelay);//(object, time)
        Instantiate(heartPrefab, transform.position + new Vector3(0, heartOffset, 0), Quaternion.identity);
        TweenScale tweenScale = gameObject.AddComponent<TweenScale>();
        tweenScale.targetScale = 0;
        tweenScale.timeToReachTarget = destroyDelay;
        GameStateManager.Instance.SavedSheep();//script.var.method telling GSM that sheep was saved
    }

    //When the sheep and the hay enter the collider
    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Hay") && !hayHit){
            Destroy(other.gameObject);
            HitByHay();
        }
        else if (other.CompareTag("DropSheep") && !dropped)
        {
            Drop();
        }
    }

    //What happens when a sheep falls off
    private void Drop(){
        GameStateManager.Instance.DroppedSheep();
        sheepSpawner.RemoveSheep(gameObject);
        dropped = true;
        myRigidbody.isKinematic = false;
        myCollider.isTrigger = false;
        Destroy(gameObject, dropDestroyDelay);
        SoundManager.Instance.PlaySheepDroppedClip();
    }

    public void SetSpawner(SheepSpawn spawner){
        sheepSpawner = spawner;
    }
}
