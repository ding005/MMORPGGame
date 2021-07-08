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
public class RoleCtrl : MonoBehaviour {

    //不赋值 默认的是vector3.zero
    public Vector3 m_TargetPos;

    //CharacterController 一个特殊的刚体
    private CharacterController m_CharacterController;

    [SerializeField]
    private float m_Speed = 1;

    /// <summary>
    /// 转身速度
    /// </summary>
    private float m_RotationSpeed = 0.2f;


    /// <summary>
    /// 转身方向
    /// </summary>
    private Quaternion m_Quaternion;

    private float gravity = 20f;

    private Vector3 moveDirection = Vector3.zero;

    void Start ()
    {
        m_CharacterController = gameObject.transform.GetComponent<CharacterController>();
    }

    void Update()
    {
        if (m_CharacterController == null) return;
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("鼠标位置 == "+ Input.mousePosition);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitinfo;
            //碰到物体会返回true
            if (Physics.Raycast(ray, out hitinfo))
            {
                //CurrentCultureIgnoreCase 不区分大小写
                if (hitinfo.collider.gameObject.name.Equals("Ground", System.StringComparison.CurrentCultureIgnoreCase))
                {
                    m_TargetPos = hitinfo.point;
                    //Debug.DrawLine(Camera.main.transform.position, m_targetPos);
                }
            }
        }
        if (m_TargetPos != Vector3.zero)
        {
            Debug.DrawLine(Camera.main.transform.position, m_TargetPos);
        }
        //让角色贴着地面
        if (!m_CharacterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= m_Speed;
        }
        if (m_TargetPos != Vector3.zero || m_CharacterController.isGrounded)
        {
            //不能是零 因为移动的时候有小数 导致来回颤动
            if (Vector3.Distance(m_TargetPos, transform.position) > 0.1f)
            {
                Vector3 director = m_TargetPos - transform.position;
                director = director.normalized; //归一化 方向上x y z长度为1
                director = director * Time.deltaTime * m_Speed;
                //transform.LookAt(m_TargetPos, Vector3.up);
                Debug.Log("director == " + director);
                m_CharacterController.Move(director);
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;//模拟重力
        m_CharacterController.Move(moveDirection * Time.deltaTime);//移动

    }
}
