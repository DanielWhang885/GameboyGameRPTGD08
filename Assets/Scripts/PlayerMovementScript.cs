using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] private float speed;
<<<<<<< Updated upstream
    public int health = 12;
=======
    [SerializeField] private GameObject attackHitbox;
    [SerializeField] private float attackUptime;
    public int health;
    public int maxHealth;
>>>>>>> Stashed changes
    private Rigidbody2D playerRigidBody; 
    private Vector3 change;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
<<<<<<< Updated upstream
=======
        attackHitbox.gameObject.SetActive(false);
        //attackActive = false;
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (change != Vector3.zero)
        {
            MoveCharacter();
        }
<<<<<<< Updated upstream
=======
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        if(health <= 0) 
        {
            Die();
        }
>>>>>>> Stashed changes
    }

    void MoveCharacter()
    {
            playerRigidBody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }
<<<<<<< Updated upstream
=======

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
    private void OnTriggerEnter2D(Collider2D collision)
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
        gameObject.SetActive(false);
    }
>>>>>>> Stashed changes
}
