using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance; //instance of this script

    public Text sheepSavedText;
    public Text sheepDroppedText;
    public GameObject gameOverWindow;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    public void UpdateSheepSaved(){
        sheepSavedText.text = GameStateManager.Instance.sheepSaved.ToString(); //ui text is saved as whatever the sheepsaved value is
    }

    public void UpdateSheepDropped(){
        sheepDroppedText.text = GameStateManager.Instance.sheepDropped.ToString();
    }

    public void ShowGameOverWindow(){
        gameOverWindow.SetActive(true);
    }
}
