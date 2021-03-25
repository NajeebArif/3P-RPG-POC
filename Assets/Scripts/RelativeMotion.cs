using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelativeMotion : MonoBehaviour
{
    [SerializeField] private Transform target;
    public float rotSpeed = 15f;

    void Update() {
        Vector3 movement = Vector3.zero;
        float horInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        if (horInput != 0 || vertInput != 0) {
            movement.x = horInput;
            movement.z = vertInput;
            Quaternion tmp = target.rotation;
            target.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
            movement = target.TransformDirection(movement);
            target.rotation = tmp;
            Quaternion direction = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Lerp(transform.rotation,direction, rotSpeed*Time.deltaTime);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

}
