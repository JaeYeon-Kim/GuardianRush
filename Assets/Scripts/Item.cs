using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    // 아이템 타입 지정 
    public enum Type{ Ammo, Coin, Grenade, Heart, Weapon };
    public Type type;
    public int value;

    void Update() {
        transform.Rotate(Vector3.up * 20 * Time.deltaTime);
    }



}
