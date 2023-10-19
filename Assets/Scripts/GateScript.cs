using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] bool openOnCollision;
    //private float currentKeyCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!openOnCollision)
        {
            OpenGate();
        }
        //currentKeyCount = GameObject.FindGameObjectsWithTag("Key").Length;
        //if (player.keyCount != currentKeyCount)
        //{

        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OpenGate();
    }

    void OpenGate()
    {
        if (gameManager.collectedKeyCount == gameManager.initialKeyCount)
        {
            
            this.gameObject.SetActive(false);
        }
    }
}
