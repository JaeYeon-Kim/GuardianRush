using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;


/*
[RequireComponent] -> 
1) 스크립트를 게임 오브젝트에 추가하려할 때 해당 게임 오브젝트에 PlayerController 컴포넌트가 없다면 자동으로 추가해줌
2) 이 스크립트가 제대로 동작하기 위해 PlayerController가 필요하다는 것을 명시해줌 
*/
[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{

    // 캐릭터 이동 속도 설정 
    public float moveSpeed = 5f;
    PlayerController controller;
    Animator anim;
    bool wDown;


    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        wDown = Input.GetButton("Walk");
        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // 균일한 이동속도를 위해 정규화를 해줌 : 정규화란 벡터의 방향을 유지하면서 길이를 1로 만드는 과정 
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.Move(moveVelocity);

        anim.SetBool("isRun", moveVelocity != Vector3.zero);
        anim.SetBool("isWalk", wDown);

        transform.LookAt(transform.position + moveVelocity);
    }
}
