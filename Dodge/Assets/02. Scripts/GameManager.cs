using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI 관련 라이브러리
using UnityEngine.SceneManagement; // 씬 관리 관련 라이브러리
using TMPro; // TextMeshPro 관련 라이브러리

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; // 게임오버 시 활성화할 텍스트 게임 오브젝트
    public TextMeshPro timeText; // 생존 시간을 표시할 텍스트 컴포넌트
    public TextMeshPro recordText; // 최고 기록을 표시할 텍스트 컴포넌트

    private float surviveTime; // 생존 시간
    private bool isGameOver; // 게임오버 상태

    void Start()
    {
        // 생존 시간과 게임오버 상태 초기화
        surviveTime = 0;
        isGameOver = false;
    }

    void Update()
    {
        // 게임오버가 아닌 동안
        if(!isGameOver)
        {
            // 생존 시간 갱신
            surviveTime += Time.deltaTime;
            // 갱신한 생존 시간을 timeText 텍스트 컴포넌트를 이용해 표시
            timeText.text = "Time: " + (int)surviveTime;
        }

        else
        {
            // 게임오버 상태에서 R키를 누른 경우
            if(Input.GetKeyDown(KeyCode.R))
            {
                // SampleScene 씬을 로드
                SceneManager.LoadScene("MainScene");
            }
        }
    }
    
    // 현재 게임을 게임오버 상태로 변경하는 메서드
    public void EndGame()
    {
        // 현재 상태를 게임오버 상태로 전환
        isGameOver = true;
        // 게임오버 텍스트 게임 오브젝트를 활성화
        gameoverText.SetActive(true);
    }
}
