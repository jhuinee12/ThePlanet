using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Play_Manager : MonoBehaviour
{
    // 아이콘 이동
    private float Xforce = 1.5f;
    private float Yforce = 6;

    public GameObject camera_GO; // 카메라 오브젝트 선언
    public GameObject HP_Gauge_Img_GO; // HP 게이지 오브젝트 선언

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 카메라 오브젝트 위치값에 주인공 위치값을 입력
        if (transform.position.y > 0 && transform.position.y < 7) // 카메라 영역 제한
        {
            camera_GO.transform.position = new Vector3(camera_GO.transform.position.x, transform.position.y, camera_GO.transform.position.z);
        }

        // 스마트폰, 마우스 조작 시 (위치 감지)
        if (Input.GetMouseButton(0))
        {
            Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (MousePos.x > 0)
            {
                transform.GetComponent<Rigidbody2D>().velocity = new Vector2(Xforce, Yforce);
            }
            else
            {
                transform.GetComponent<Rigidbody2D>().velocity = new Vector2(-Xforce, Yforce);
            }
        }

        // 컴퓨터 왼쪽키
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(-Xforce, Yforce);
        }
        // 컴퓨터 오른쪽키
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(Xforce, Yforce);
        }

        // 3번의 목숨이 죽으면 게임 종료
        if (HP_Gauge_Img_GO.GetComponent<Image>().fillAmount <= 0)
        {   
            Debug.Log("게임 오버!");
            SceneManager.LoadScene("EndGame");
        }
        // 화면 밖으로 나오면 게임 종료
        if (transform.position.y < -5.0f)
        {
            Debug.Log("게임 오버!");
            SceneManager.LoadScene("EndGame");
        }

        // 게임 오브젝트가 화면 밖으로 나가지 못하게
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < 0.05f) pos.x = 0.05f;
        if (pos.x > 0.95f) pos.x = 0.95f;
        if (pos.y < 0f) pos.y = 0f;
        if (pos.y > 0.85f) pos.y = 0.85f;

        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
    IEnumerator HP_Change(float damage)
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(0.1f);
            HP_Gauge_Img_GO.GetComponent<Image>().fillAmount -= damage; // HP 데미지 처리
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("아얏!");
        StartCoroutine(HP_Change(0.035f));
        transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        transform.GetComponent<Rigidbody2D>().freezeRotation = false;
        transform.GetComponent<Rigidbody2D>().velocity = -Vector2.up * Yforce;
        transform.GetComponent<Rigidbody2D>().AddTorque(6f);
    }
}
