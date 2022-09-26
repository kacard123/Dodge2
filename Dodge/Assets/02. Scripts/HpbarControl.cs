using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpbarControl : MonoBehaviour
{
    // �ʿ��� �̹���
    [SerializeField]
    public Image hpImage;

    public float maxHP; // �ִ� ü��. ����Ƽ �����Ϳ��� ����
    public float currenthp;

    // ü�� ������
    [SerializeField]
    public float hpIncreaseSpeed;

    // ü�� ��ȸ�� ������ �ð�
    [SerializeField]
    private float hpReChargeTime;
    public float currentHPRechargeTime;

    // ü�� ���� ����
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
        hpImage.fillAmount = (float)currenthp / maxHP; // �̹����� FillAmount�� = ����ü��/�ִ�ü��
    }

    // ü�� ���� �޼ҵ�(count ��ŭ)
    public void DecreaseHP(float count)
    {
        hpUsed = true; // ü�� ����
        currentHPRechargeTime = 0f; // ���� ü�� ȸ���� 0

        if(currenthp - count > 0f) // ���� ü�� - count ���� 0���� ũ�ٸ�
        {
            currenthp -= count; // ���� ü�� = 0
        }

    }

    //  ü�� ���� �ð�
    private void HpReChargeTime()
    {
        if(hpUsed) // ü�� ���� ���� ��
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

