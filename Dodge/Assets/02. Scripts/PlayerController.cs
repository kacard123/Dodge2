using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 이동에 사용할 리지드바디 컴포넌트
    public Rigidbody playerRigidbody;
    public float speed = 15f; // 이동 속력
    public float rotateSpeed = 10f; // 회전 속도

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
            // 위쪽 방향키 입력이 감지된 경우 z방향 힘주기
            playerRigidbody.AddForce(0f, 0f, speed);

        }

        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            // 아래쪽 방향키 입력이 감지된 경우 -z방향 힘주기
            playerRigidbody.AddForce(0f, 0f, -speed);

        }

        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            // 오른쪽 방향키 입력이 감지된 경우 x방향 힘주기
            playerRigidbody.AddForce(speed, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            // 왼쪽 방향키 입력이 감지된 경우 -x방향 힘주기
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

            Destroy(collision.gameObject); // 적 사망

        }
    }

    public void Die()
    {
        // 자신의 게임 오브젝트를 비활성화
        gameObject.SetActive(false);

        // 씬에 존재하는 GameManager 타입의 오브젝트를 찾아서 가져오기
        GameManager gameManager = FindObjectOfType<GameManager>();
        // 가져온 GameManager 오브젝트의 EndGame() 메서드 실행
        gameManager.EndGame();  
    }

    // 이동 관련 함수를 짤 때는 Update보다 FixedUpdate가 더 좋음
    void FixedUpdate()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v); // new Vector3(h, 0, v)가 자주 쓰이게 되었으므로 dir이라는 변수에 넣고 향후 편하게 사용할 수 있게 함

        // 바라보는 방향으로 회전 후 다시 정면을 바라보는 현상을 막기 위해 설정
        if (!(h == 0 && v == 0))
        {
            // 이동과 회전을 함께 처리
            transform.position += dir * speed * Time.deltaTime;
            // 회전하는 부분. Point 1.
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotateSpeed);
        }
    }
   

}
