using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DynamicGameButton : MonoBehaviour
{
    public GameObject LinkedObject { get; private set; }
    public void Init(GameObject obj)
    {
        LinkedObject = obj;
        gameObject.name = $"Button_{LinkedObject.name}";
        GetComponentInChildren<TMP_Text>().text = LinkedObject.name;
        gameObject.SetActive(true);
    }
}
