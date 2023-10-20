using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float speed;
    [SerializeField] private float closestDistance;
    [SerializeField] private float maxDistance;
    [SerializeField] private GameObject triggerBeforeAttacking;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerBeforeAttacking != null)
            return;

        if (Vector3.Distance(target.position, transform.position) <= maxDistance)
        {
            if (Vector3.Distance(target.position, transform.position) > closestDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //supposed to make the enemy stand stil after dealing damage, not sure how to actually do that
        //if (collision.CompareTag("Player"))
        //{
        //    target = this.transform;
        //    new WaitForSeconds(2);
        //    target = GameObject.FindWithTag("Player").transform;
        //}
        if (collision.CompareTag("Attack"))
        {
            Die();
        }
    }

    void Die()
    {
        PlayerMovementScript._instance.canMove = true;
        this.gameObject.SetActive(false);
    }
}
