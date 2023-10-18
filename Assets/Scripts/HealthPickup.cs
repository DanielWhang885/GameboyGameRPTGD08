using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private int healAmount;
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
            player.health = player.health + healAmount;
            if (player.health > player.maxHealth)
            {
                player.health = player.maxHealth;
            }
            Debug.Log("Healed to " + player.health + " health!");
            this.gameObject.SetActive(false);
        }
    }
}
