using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


// 총알 관련 로직
public class Bullet : MonoBehaviour
{

    // 총알 속도 
    public float speed = 5.0f;


    void Start() {

    }

    void Update() {
        // 총알 앞으로 전진: 생성되자마자 z축으로 전진 
        this.transform.Translate(new Vector3(0, 0, this.speed * Time.deltaTime));
        Destroy(gameObject, 3);
    }

}
