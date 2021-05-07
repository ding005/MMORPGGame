using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//==============================
//Author:			Mr.ding
//CreateTime:		2021-04-30 14:47:16
//Version:			1.0.1
//==============================
//两个物体都必须带有碰撞器(Collider)，其中一个物体还必须带有Rigidbody刚体。
//lookAt  主要是物体的z轴朝着目标点
public class Move : MonoBehaviour {

    //不赋值 默认的是vector3.zero
    public Vector3 m_targetPos;

    //CharacterController 一个特殊的刚体
    private CharacterController m_CharacterController;

    [SerializeField]
    private float m_speed = 1;
    // Use this for initialization
    void Start ()
    {
        m_CharacterController = gameObject.transform.GetComponent<CharacterController>();

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
                //CurrentCultureIgnoreCase 不区分大小写
                if (hitinfo.collider.gameObject.name.Equals("Ground",System.StringComparison.CurrentCultureIgnoreCase))
                {
                    m_targetPos = hitinfo.point;
                    Debug.Log(m_targetPos);
                }
            }
        }
        //让角色贴着地面
        if (!m_CharacterController.isGrounded)
        {
            m_CharacterController.Move((transform.position + new Vector3(0,-1000,0))- transform.position);
        }
        if (m_targetPos != Vector3.zero)
        {
            //不能是零 因为移动的时候有小数 导致来回颤动
            if (Vector3.Distance(m_targetPos,transform.position) >0.1f)
            {
                Vector3 director = m_targetPos - transform.position;
                director = director.normalized; //归一化
                Debug.Log("director = " + director + " Time.deltaTime = " + Time.deltaTime + " m_speed = " + m_speed);
                director = director * Time.deltaTime * m_speed;
                //Debug.Log("director = " + director);

                transform.LookAt(m_targetPos,Vector3.up);
                m_CharacterController.Move(m_targetPos);
            }
            
        }
	}
}
