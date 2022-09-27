using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject weaponPrefab; // ������ �� �����Ǵ� �߻�ü ������
    [SerializeField]
    private float attackRate = 0.45f; // ���� �ӵ�

    public Transform target;

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
            // �߻�ü ������Ʈ ����
            GameObject weapon = Instantiate(weaponPrefab, transform.position, transform.rotation);//aternion.identity

            weapon.transform.LookAt(target);

            // attackRate �ð���ŭ ���
            yield return new WaitForSeconds(attackRate);
        }
    }
}
