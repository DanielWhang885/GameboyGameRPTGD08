using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackScript : MonoBehaviour
{
    [SerializeField] private float thrust;
    [SerializeField] private float knocktime;
    private PlayerMovementScript player;
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerMovementScript._instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.gameObject.CompareTag("Player") && player.invincible == false)
        {
            Rigidbody2D Enemy = other.GetComponent<Rigidbody2D>();
            if (Enemy != null)
            {
                player.canMove = false;
                Vector2 difference = Enemy.transform.position - transform.position;
                difference = difference.normalized * thrust;
                Enemy.AddForce(difference, ForceMode2D.Impulse);
                if (gameObject.activeSelf)
                    StartCoroutine(KnockCo(Enemy));
            }
        }
    }

    private IEnumerator KnockCo(Rigidbody2D enemy)
    {
        if (enemy != null)
        {
            yield return new WaitForSeconds(knocktime);
            enemy.velocity = Vector2.zero;
            StopKnockback();
        }
    }

    public void StopKnockback()
    {
        player.canMove = true;
    }
}
