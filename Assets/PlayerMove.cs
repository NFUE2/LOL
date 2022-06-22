using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    //NavMeshAgent자료형의 변수명Agent를 선언
    NavMeshAgent Agent; 

    // Start is called before the first frame update
    void Start()
    {
        //Agent에 이 스크립트가 들어가게될 게임오브젝트에서 NavMeshAgent를 가져옵니다.
        Agent = GetComponent<NavMeshAgent>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //게임화면에서 나의 마우스 위치로 Ray를 생성합니다.
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //마우스 우클릭 및 Ray의 끝에 충돌체가 있다면 그 지점을 읽어와서 Hit에 저장합니다.
        if (Input.GetMouseButtonDown(1) && Physics.Raycast(ray,out RaycastHit Hit))
        {
            //Ray가 충돌되었던 위치를 도착지점으로 설정하고 이동하게됩니다.
            Agent.destination = Hit.point;
        }
    }
}
