using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovementScript : MonoBehaviour
{
    public static PlayerMovementScript _instance;

    [SerializeField] private float speed;
    [SerializeField] private GameObject attackHitbox;
    [SerializeField] private float attackUptime;
    [SerializeField] private GameObject healthPanel;
    [SerializeField] TextMeshProUGUI healthText;
    public int health;
    public int maxHealth;

    public string deadText;

    public bool canMove;
    private bool canAttack = true;
    public bool invincible = false;

    [HideInInspector] public bool dead;

    //if there are multiple keys. Registers twice though, not sure how to fix that so it's
    //probably best to just have one

    private Rigidbody2D playerRigidBody; 
    private Vector3 change;
    private float moveLimiter = 0.7f;

    public GameObject levelEndSceen;

    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        playerRigidBody = GetComponent<Rigidbody2D>();
        attackHitbox.gameObject.SetActive(false);
        levelEndSceen.SetActive(false);
        //attackActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
            return;

        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        healthText.text = health.ToString();
        if (Input.GetKeyDown(KeyCode.Space) && canMove == true && canAttack == true)
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
        if (dead)
            return;

        if (canMove == true)
        {
            if (change.x != 0 && change.y != 0)
            {
                change.x *= moveLimiter;
                change.y *= moveLimiter;
            }

            playerRigidBody.velocity = new Vector2(change.x * speed, change.y * speed);
        }
    }

   void Attack()
    {
        canAttack = false;
        attackHitbox.gameObject.SetActive(true);
        Invoke("AttackDisable", attackUptime);
    }
    //probably not the optimal way
    private void AttackDisable()
    {
        canAttack = true;
        attackHitbox.gameObject.SetActive(false );
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (dead)
            return;

        if (collision.CompareTag("Enemy") && invincible == false)
        {
            invincible = true;
            health = health - 1;
            new WaitForSeconds(2);
            invincible = false;
        }
    }
    private void Die()
    {
        Debug.Log("You died");
        dead = true;
        playerRigidBody.velocity = Vector2.zero;
        CanvasManager._instance.SetEndScreenTitle("YOU DIED!!!");
        CanvasManager._instance.SetEndScreenText(deadText);
        healthPanel.SetActive(false);
        levelEndSceen.SetActive(true);
    }
}
