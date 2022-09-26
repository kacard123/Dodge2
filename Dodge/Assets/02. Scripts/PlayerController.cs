using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // �̵��� ����� ������ٵ� ������Ʈ
    public Rigidbody playerRigidbody;
    public float speed = 8f; // �̵� �ӷ�

    [SerializeField]
    private KeyCode keyCodeAttack = KeyCode.Space;

    private PlayerWeapon weapon;

    private void Awake()
    {
        weapon = GetComponent<PlayerWeapon>();
    }

    // private HpbarControl hpbarControl;

    void Start()
    {
        // hpbarControl = FindObjectOfType<HpbarControl>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Enemy"))
        {

            Destroy(collision.gameObject); // �� ���

        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            // ���� ����Ű �Է��� ������ ��� z���� ���ֱ�
            playerRigidbody.AddForce(0f, 0f, speed);

        }

        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            // �Ʒ��� ����Ű �Է��� ������ ��� -z���� ���ֱ�
            playerRigidbody.AddForce(0f, 0f, -speed);

        }

        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            // ������ ����Ű �Է��� ������ ��� x���� ���ֱ�
            playerRigidbody.AddForce(speed, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            // ���� ����Ű �Է��� ������ ��� -x���� ���ֱ�
            playerRigidbody.AddForce(-speed, 0f, 0f);

        }

        if (Input.GetKeyDown(keyCodeAttack))
        {
            weapon.StartFiring();
        }
        else if (Input.GetKeyUp(keyCodeAttack))
        {
            weapon.StopFiring();
        }

    }

    public void Die()
    {
        // �ڽ��� ���� ������Ʈ�� ��Ȱ��ȭ
        gameObject.SetActive(false);

        // ���� �����ϴ� GameManager Ÿ���� ������Ʈ�� ã�Ƽ� ��������
        GameManager gameManager = FindObjectOfType<GameManager>();
        // ������ GameManager ������Ʈ�� EndGame() �޼��� ����
        gameManager.EndGame();  
    }

}
