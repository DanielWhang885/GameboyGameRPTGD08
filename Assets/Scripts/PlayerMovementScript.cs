using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject attackHitbox;
    public int health = 12;
    private Rigidbody2D playerRigidBody; 
    private Vector3 change; 
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        attackHitbox.gameObject.SetActive(false);
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
       if (Input.GetKeyDown(KeyCode.Space))
        {
            attackHitbox.gameObject.SetActive(true);
        }
    }

    void MoveCharacter()
    {
            playerRigidBody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }

    void Attack()
    {

    }
}
