using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearUnitScript : MonoBehaviour
{
    [SerializeField] private BearUnitScriptableObject _data;

    private void OnEnable()
    {
        StartCoroutine(TimeToDie(_data.lifeSpan));
    }

    IEnumerator TimeToDie(float time)
    {
        yield return new WaitForSeconds(time);
        BearUnitPoolScript.instance.DespawnGameObject(this.gameObject);
    }
}
