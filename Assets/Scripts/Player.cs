using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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


    // 총알 프리팹
    public GameObject bullet;

    // 총구 트랜스폼
    public Transform muzzle;

    // 카메라
    private Camera camera;

    // 방향
    private Vector3 direction;


    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<PlayerController>();
        this.camera = Camera.main;
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

        transform.LookAt(transform.position + moveVelocity);
        Attack();
    }

    void Attack() {
        //마우스 왼 클릭
        if (Input.GetMouseButtonDown(0)) {
            // 광선 충돌체 정보 
            RaycastHit hit;


            // 마우스 포인터가 바닥에서 어디에 위치해 있는지 알아온다.
            if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                // 오브젝트의 방향을 마우스 클릭한 곳으로 지정
                this.direction = (hit.point - this.transform.position);
                this.direction.y = this.transform.position.y;
                this.transform.forward = this.direction;

                // 총알 생성.
                GameObject bulletGO = Instantiate(this.bullet);

                // 총알 위치와 각도를 총구와 같게 한다.
                bulletGO.transform.position = this.muzzle.transform.position;
                bulletGO.transform.rotation = this.muzzle.transform.rotation;
            }
        }
    }
    
}
