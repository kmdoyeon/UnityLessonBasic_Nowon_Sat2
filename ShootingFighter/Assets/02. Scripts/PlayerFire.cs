using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Instantiate(bulletPrefab, firePoint.position , Quaternion.identity);  // bulletPrefab�� ����

        

    /* GetKey �� ������
     ���� public float fireTimeGap = 0.3f; �̷� ������ �Ѿ� �߻�Ǵ� �ð��� ����,
     private fireTimer; Ÿ�̸Ӹ� ���� 

    private void Awake()  -> �ʱ�ȭ ��Ŵ 
    {
        fireTimer = fireTimeGap;
    }

    (������Ʈ�� ���� ��)  

    if (input.GetKeyDown(KeyCode.Space))
    {
        Instantiate(bulletPrefab, firePoint.position , Quaternion.identity);
        fireTimer = fireTimeGap;
    }

    if ( fireTimer < 0 && 
            input.GetKey(KeyCode.Space))
    {
        Instantiate(bulletPrefab, firePoint.position , Quaternion.identity);
        fireTimer = fireTimeGap;  <- Ÿ�̸� �ٽ� ���� 
    }
    else
        fireTimer -= Time.deltaTime;

    */


}
}
