using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager _instance;

    [SerializeField] private GameObject endLevelScreen;
    [SerializeField] private TextMeshProUGUI endLevelTitle;
    [SerializeField] private TextMeshProUGUI endLevelText;

    private void Awake()
    {
        _instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && endLevelScreen.activeSelf) 
        {
            if (PlayerMovementScript._instance.dead)
                RestartLevel();
            else if (SceneManager.GetActiveScene().buildIndex != 2)
                NextLevel();
        }
    }

    public void SetEndScreenTitle(string text)
    {
        endLevelTitle.text = text;
    }

    public void SetEndScreenText(string text)
    {
        endLevelText.text = text;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
