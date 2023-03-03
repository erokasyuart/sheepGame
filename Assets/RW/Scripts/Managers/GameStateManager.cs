using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance; //reference to script
    
    [HideInInspector]
    public int sheepSaved; //# of saved sheep

    [HideInInspector]
    public int sheepDropped;//# of dropped sheep

    public int sheepDroppedBeforeGameOver; //amount of losses before game ends
    public SheepSpawn sheepSpawner; //sheep spawner component
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene("Title");
        }
    }

    public void SavedSheep()
    {
        sheepSaved++;
    }

    private void GameOver(){
        sheepSpawner.canSpawn = false;
        sheepSpawner.DestroyAllSheep();
    }

    public void DroppedSheep(){
        sheepDropped++;
        if (sheepDropped == sheepDroppedBeforeGameOver){
            GameOver();
        }
    }
}
