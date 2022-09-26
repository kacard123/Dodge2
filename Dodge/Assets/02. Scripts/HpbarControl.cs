using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpbarControl : MonoBehaviour
{
    // 필요한 이미지
    [SerializeField]
    public Image hpImage;

    public float maxHP; // 최대 체력. 유니티 에디터에서 지정
    public float currenthp;

    // 체력 증가량
    [SerializeField]
    public float hpIncreaseSpeed;

    // 체력 재회복 딜레이 시간
    [SerializeField]
    private float hpReChargeTime;
    public float currentHPRechargeTime;

    // 체력 감소 여부
    private bool hpUsed;

    private void Start()
    {
        currenthp = maxHP;
    }

    private void Update()
    {
        HpReChargeTime();
        HpRecover();
        GaugeUpdate();
    }

    public void GaugeUpdate()
    {
        hpImage.fillAmount = (float)currenthp / maxHP; // 이미지의 FillAmount값 = 현재체력/최대체력
    }

    // 체력 감소 메소드(count 만큼)
    public void DecreaseHP(float count)
    {
        hpUsed = true; // 체력 감소
        currentHPRechargeTime = 0f; // 현재 체력 회복은 0

        if(currenthp - count > 0f) // 현재 체력 - count 값이 0보다 크다면
        {
            currenthp -= count; // 현재 체력 = 0
        }

    }

    //  체력 충전 시간
    private void HpReChargeTime()
    {
        if(hpUsed) // 체력 감소 중일 때
        {
            if (currentHPRechargeTime < hpReChargeTime)
                currentHPRechargeTime++;
            else
                hpUsed = false;
        }
    }

    private void HpRecover()
    {
        if(!hpUsed && currenthp < maxHP)
        {
            currenthp += hpIncreaseSpeed;
        }
    }
}

