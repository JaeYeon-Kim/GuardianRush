using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    Vector3 velocity;
    Rigidbody myRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        // RigidBody 객체 가져오기 
        myRigidBody = GetComponent<Rigidbody>();
    }


    public void Move(Vector3 _velocity) {
        velocity = _velocity;
    }

    public void FixedUpdate() {
       myRigidBody.MovePosition(myRigidBody.position + velocity * Time.fixedDeltaTime);    
    }
}
