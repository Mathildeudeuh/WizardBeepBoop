using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawnn : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D colliderTriggered)
    {
        Debug.Log(colliderTriggered);
        Debug.Log(colliderTriggered.gameObject);
        colliderTriggered.transform.position = Vector3.zero;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
