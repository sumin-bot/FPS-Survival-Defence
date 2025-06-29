using UnityEngine;

public class CloseWeapon : MonoBehaviour
{
    public string closeWeaponName; // 무기 구분 변수

    // 웨폰 유형
    public bool isHand;
    public bool isAxe;
    public bool isPickaxe;

    public float range;
    public int damage;
    public float workSpeed;
    public float attackDelay;
    public float attackDelayA; // 공격 활성화 딜레이 변수
    public float attackDelayB; // 공격 비활성화 딜레이 변수

    public Animator anim;
    
}
