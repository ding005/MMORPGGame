using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//==============================
//Author:			Mr.ding
//CreateTime:		2021-05-07 10:42:06
//Version:			1.0.1
//==============================

public class BoxMove : MonoBehaviour {

    public GameObject box;

    [SerializeField]
    private float moveSpeed;

    private Vector3 m_TargetPos;
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonUp(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray ,out raycastHit))
            {
                if (raycastHit.collider.gameObject.Equals("Ground"))
                {
                    m_TargetPos = raycastHit.transform.localPosition;
                }
            }
            
        }
        if (m_TargetPos != Vector3.zero)
        {
            if (Vector3.Distance(m_TargetPos, box.transform.localPosition) > 0.1)
            {
                Vector3 director = m_TargetPos - transform.localPosition;
                director = director.normalized;
                director = director * Time.deltaTime * moveSpeed;
                transform.LookAt(m_TargetPos);
                transform.Translate(Vector3.forward*Time.deltaTime * moveSpeed,Space.Self);
            }
        }
    }
}
