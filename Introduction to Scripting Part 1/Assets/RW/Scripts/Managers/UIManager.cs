using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    public static UIManager Instance; // 1

    public Text sheepSavedText; // 2
    public Text sheepDroppedText; // 3
    public GameObject gameOverWindow; // 4

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    public void UpdateSheepSaved() // 1
    {
        sheepSavedText.text = GameStateManager.Instance.sheepSaved.ToString();
    }

    public void UpdateSheepDropped() // 2
    {
        sheepDroppedText.text = GameStateManager.Instance.sheepDropped.ToString();
    }
    
    public void ShowGameOverWindow()
    {
        gameOverWindow.SetActive(true);
    }
}
