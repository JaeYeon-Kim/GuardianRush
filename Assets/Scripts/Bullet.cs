using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 총알 관련 로직
public class Bullet : MonoBehaviour
{
    public int damage;

    private void OnCollisionEnter(Collision collision) {

        // 탄피 처리 
        if(collision.gameObject.tag == "Floor") {
            Destroy(gameObject, 3);
        }
        // 총알 처리 
        else if(collision.gameObject.tag == "Wall") {
            Destroy(gameObject);
        }
    }
}
