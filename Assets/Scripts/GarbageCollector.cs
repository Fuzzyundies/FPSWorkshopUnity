using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollector : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerExit(Collider other)
    {
        for (var i = other.transform.childCount; i-- > 0;)
        {
            Destroy(other.transform.GetChild(0).gameObject);
        }
        Destroy(other.gameObject);
        Debug.Log("Destroyed " + other.ToString());
    }
}

