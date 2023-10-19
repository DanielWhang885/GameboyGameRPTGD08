using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject attackHitbox;
    [SerializeField] private float attackUptime;
    public int health;
    public int maxHealth;
    //if there are multiple keys. Registers twice though, not sure how to fix that so it's
    //probably best to just have one
    public float keyCount;
    private Rigidbody2D playerRigidBody; 
    private Vector3 change;
    private float moveLimiter = 0.7f;

    public GameObject canvas;
    public Text restartText;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        attackHitbox.gameObject.SetActive(false);
        //attackActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        if(health <= 0) 
        {
            Die();
        }
    }

    void FixedUpdate()
    {
        if (change.x != 0 && change.y != 0)
        {
            change.x *= moveLimiter;
            change.y *= moveLimiter;
        }

        playerRigidBody.velocity = new Vector2(change.x * speed, change.y * speed);
    }

   void Attack()
    {
        attackHitbox.gameObject.SetActive(true);
        Invoke("AttackDisable", attackUptime);
    }
    //probably not the optimal way
    private void AttackDisable()
    {
        attackHitbox.gameObject.SetActive(false );
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            health = health - 1;
        }
    }
    private void Die()
    {
        //temporary
        Debug.Log("You died");
        restartText.text = "YOU LOSE";
        canvas.SetActive(true);
        
    }
}
