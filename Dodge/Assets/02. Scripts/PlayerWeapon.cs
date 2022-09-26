using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject weaponPrefab; // 공격할 때 생성되는 발사체 프리팹
    [SerializeField]
    private float attackRate = 0.45f; // 공격 속도

    public void StartFiring()
    {
        StartCoroutine("TryAttack");
    }

    public void StopFiring()
    {
        StopCoroutine("TryAttack");
    }

    private IEnumerator TryAttack()
    {
        while (true)
        {
            // 발사체 오브젝트 생성
            Instantiate(weaponPrefab, transform.position, Quaternion.identity);

            // attackRate 시간만큼 대기
            yield return new WaitForSeconds(attackRate);
        }
    }
}
