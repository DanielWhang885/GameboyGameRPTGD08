using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    [SerializeField] private PlayerMovementScript player;
    [SerializeField] bool openOnCollision;
    [SerializeField] private GameObject canvas;
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OpenGate();
    }

    void OpenGate()
    {
        if(player.keyCount >= 1)
        {
            canvas.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
