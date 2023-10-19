using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Canvas : MonoBehaviour
{
    [SerializeField] private Object nextLevel;
    [SerializeField] private GameObject endLevelScreen;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && endLevelScreen == true) 
        {
            StartGame();
        }
    }

    public void StartGame() 
    {
        SceneManager.LoadScene(nextLevel.name);
    }
}
