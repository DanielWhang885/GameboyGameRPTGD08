using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float speed;
    [SerializeField] private float closestDistance;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) > closestDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
