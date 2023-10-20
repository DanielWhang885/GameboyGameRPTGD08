using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTrigger : MonoBehaviour
{
    public Vector3 newCamPos, newPlayerPos;
    private GameObject cam;
    public int keysAmount = 1;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.gameObject.tag == "Player" && GameManager._instance.collectedKeyCount >= keysAmount)
        {
            cam.transform.position = newCamPos;
            cam.transform.position = newCamPos;
            collision.transform.position += newPlayerPos;
            Destroy(gameObject);
        }
    }
}
