using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [HideInInspector]
    public float Speed;
    [HideInInspector]
    public float Distance;



    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(this.gameObject.transform.position, new Vector3(Distance, transform.position.y, transform.position.z), Time.deltaTime * Speed);
    }
    private void Update()
    {
        if(this.gameObject.transform.position.x == Distance)
        {
            Destroy(this.gameObject);
        }

    }
    
}
