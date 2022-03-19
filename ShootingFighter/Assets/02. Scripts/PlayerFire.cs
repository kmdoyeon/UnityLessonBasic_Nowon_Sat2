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
            Instantiate(bulletPrefab, firePoint.position , Quaternion.identity);  // bulletPrefab은 원본

        

    /* GetKey 를 쓰려면
     위에 public float fireTimeGap = 0.3f; 이런 식으로 총알 발사되는 시간을 지정,
     private fireTimer; 타이머를 만듦 

    private void Awake()  -> 초기화 시킴 
    {
        fireTimer = fireTimeGap;
    }

    (업데이트에 쓰는 것)  

    if (input.GetKeyDown(KeyCode.Space))
    {
        Instantiate(bulletPrefab, firePoint.position , Quaternion.identity);
        fireTimer = fireTimeGap;
    }

    if ( fireTimer < 0 && 
            input.GetKey(KeyCode.Space))
    {
        Instantiate(bulletPrefab, firePoint.position , Quaternion.identity);
        fireTimer = fireTimeGap;  <- 타이머 다시 설정 
    }
    else
        fireTimer -= Time.deltaTime;

    */


}
}
