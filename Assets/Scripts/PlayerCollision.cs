using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public RaycastHit collisionHit;
    public List<Transform> pList = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //PlayerRay (drawing raycasts on player in unity game window)
        Debug.DrawRay(transform.position, Vector3.up * 3, Color.yellow);
        Debug.DrawRay(transform.position, Vector3.down * 3, Color.green);
    }
        /*{
            Player Up collision check
            {
                if (hit.collider != null)
                {
                    canJump = true;
                    Debug.Log(hit.collider.name);
                }
            }
        }
    }
            */
    }
