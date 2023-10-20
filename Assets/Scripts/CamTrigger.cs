using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTrigger : MonoBehaviour
{
    public Vector3 newCamPos, newPlayerPos;
    private CamController camController;
    // Start is called before the first frame update
    void Start()
    {
        camController = Camera.main.GetComponent<CamController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.gameObject.tag == "Player")
        {
            camController.minPos += newCamPos;
            camController.maxPos += newCamPos;
            collision.transform.position += newPlayerPos;
        }
    }
}
