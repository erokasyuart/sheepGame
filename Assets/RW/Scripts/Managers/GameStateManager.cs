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

    //ADVANCED ASSESSMENT TASK
    public float speedInc; //counter used to increase speed of sheep over time
    public static int highScore;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }
        UIManager.Instance.UpdateHighScore();
        speedInc += Time.deltaTime / 4; //increases over time. divided so it doesnt increase too fast
    }

    public void SavedSheep()
    {
        sheepSaved++;
        UIManager.Instance.UpdateSheepSaved(); //calls the method
    }

    private void GameOver()
    {
        if (sheepSaved > highScore)
        {
            highScore = sheepSaved;
            Debug.Log(highScore);
        }
        sheepSpawner.canSpawn = false;
        sheepSpawner.DestroyAllSheep();
    }

    public void DroppedSheep()
    {
        sheepDropped++;
        UIManager.Instance.UpdateSheepDropped();
        if (sheepDropped == sheepDroppedBeforeGameOver)
        {
            GameOver();
            UIManager.Instance.ShowGameOverWindow();
        }
    }
}
