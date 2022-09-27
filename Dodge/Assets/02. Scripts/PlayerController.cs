using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // �̵��� ����� ������ٵ� ������Ʈ
    public Rigidbody playerRigidbody;
    public float speed = 15f; // �̵� �ӷ�
    public float rotateSpeed = 10f; // ȸ�� �ӵ�

    float h, v;

    [SerializeField]
    private KeyCode keyCodeAttack = KeyCode.Space;

    private BoxCollider boxCollider;

    private PlayerWeapon weapon;



    void Start()
    {

    }

    private void Awake()
    {
        weapon = GetComponent<PlayerWeapon>();
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

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == ("Enemy"))
        {

            Destroy(collision.gameObject); // �� ���

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

    // �̵� ���� �Լ��� © ���� Update���� FixedUpdate�� �� ����
    void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v); // new Vector3(h, 0, v)�� ���� ���̰� �Ǿ����Ƿ� dir�̶�� ������ �ְ� ���� ���ϰ� ����� �� �ְ� ��

        // �ٶ󺸴� �������� ȸ�� �� �ٽ� ������ �ٶ󺸴� ������ ���� ���� ����
        if (!(h == 0 && v == 0))
        {
            // �̵��� ȸ���� �Բ� ó��
            transform.position += dir * speed * Time.deltaTime;
            // ȸ���ϴ� �κ�. Point 1.
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotateSpeed);
        }
    }
   

}
