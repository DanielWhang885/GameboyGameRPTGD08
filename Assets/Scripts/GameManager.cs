using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    [SerializeField] TextMeshProUGUI keyCountText;
    public float collectedKeyCount, initialKeyCount, keyCount;

    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        keyCount = GameObject.FindGameObjectsWithTag("Key").Length;
        initialKeyCount = GameObject.FindGameObjectsWithTag("Key").Length;
        Screen.SetResolution(1200, 1080, true);
    }

    // Update is called once per frame
    void Update()
    {
        keyCount = GameObject.FindGameObjectsWithTag("Key").Length;
        collectedKeyCount = initialKeyCount - keyCount;
        keyCountText.text = collectedKeyCount + "/" + initialKeyCount;
    }
}
