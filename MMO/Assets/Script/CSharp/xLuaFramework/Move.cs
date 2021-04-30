using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//==============================
//Author:			Mr.ding
//CreateTime:		2021-04-30 14:47:16
//Version:			1.0.1
//==============================

public class Move : MonoBehaviour {

    //不赋值 默认的是vector3.zero
    public Vector3 m_targetPos;

    [SerializeField]
    private float m_speed = 5;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitinfo;
            //碰到物体会返回true
            if (Physics.Raycast(ray,out hitinfo))
            {
                if (hitinfo.collider.gameObject.name.Equals("Ground"))
                {
                    m_targetPos = hitinfo.point;
                    Debug.Log(m_targetPos);
                }
            }
        }
        if (m_targetPos != Vector3.zero)
        {
            //不能是零 因为移动的时候有小数 导致来回颤动
            if (Vector3.Distance(m_targetPos,transform.localPosition)>0.1)
            {
                transform.LookAt(m_targetPos);
                transform.Translate(Vector3.forward * Time.deltaTime * m_speed,Space.Self);
            }
            
        }
	}
}
