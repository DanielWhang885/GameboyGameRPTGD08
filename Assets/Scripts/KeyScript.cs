using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    [SerializeField] private PlayerMovementScript player;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GetComponent<PlayerMovementScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.keyCount++;
            Debug.Log(player.keyCount);
            this.gameObject.SetActive(false);
        }
    }
}
