using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 이동에 사용할 리지드바디 컴포넌트
    public Rigidbody playerRigidbody;
    public float speed = 8f; // 이동 속력

    void Start()
    {
       
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
}
