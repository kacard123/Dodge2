using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        // �߻�ü�� �ε��� ������Ʈ�� �±װ� "Enemy"�̸�
        if (collision.CompareTag("Enemy"))
        {
            // �ε��� ������Ʈ ���ó�� (��)
            Destroy(collision.gameObject);
            // �� ������Ʈ ����(�߻�ü)
            Destroy(gameObject);
        }
    }
}
