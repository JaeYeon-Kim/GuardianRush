using UnityEngine;


/*
데미지를 받게하는 인터페이스

damage: 대미지 크기
hitPoint: 공격당한 위치
hitNormal: 공격당한 표면의 방향 

캐릭터가 총을 쏴서 오브젝트를 공격할 때 공격당한 오브젝트의 구체적인 타입 검사는 필요 없음
공격당한 오브젝트가 IDamageable을 상속했다면 해당 오브젝트의 OnDamage() 메서드만 호출하면 됨 
*/
public interface IDamageable
{
    void onDamage(float damage, Vector3 hitPoint, Vector3 hitNormal);
}


