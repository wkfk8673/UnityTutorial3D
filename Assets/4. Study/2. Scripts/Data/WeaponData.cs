using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Objects/WeaponData")]

// monobehaviour: 객체상태로 존재(component)
// ScriptableObject : asset 상태로 존재 
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public int attackDamage;
    public int attackRange;
}



