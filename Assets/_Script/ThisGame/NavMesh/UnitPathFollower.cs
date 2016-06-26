using PigeonCoopToolkit.Navmesh2D;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class UnitPathFollower : MonoBehaviour
{
    public Transform m_Transform;
    public float m_Radius = 2; // 圆环的半径
    public float m_Theta = 0.1f; // 值越低圆环越平滑
    public Color m_Color = Color.green; // 线框颜色

    //---------------------------------------------
    float fCastRadius;
    public BaseUnit unit;
    public GameObject pathingTarget;
    private List<Vector2> path;

    bool m_bFindPath = true;

    void Start()
    {
        fCastRadius = m_Radius;
        m_Transform = transform;
        unit = GetComponent<BaseUnit>();
    }
    // LateUpdate is called once per frame
    void Update()
    {
        if (unit == null) return;

        switch (unit.currentState)
        {
            case UnitState.Birth:
                break;
            case UnitState.Normal:
                FindTarget();
                //FindNearEnemy();
                break;
            case UnitState.Die:
                break;
        }

    }

    void FindTarget()
    {
        if (pathingTarget == null)
        {
            pathingTarget = BattleManager.Instance.GetPathingTarget(unit.m_EnemyCamp, unit.m_UnitInfo);
        }

        if (pathingTarget != null && m_bFindPath)
        {
            if (m_bFindPath)
            {
                StartCoroutine(ComponentTools.SetWaitTime(0.3f, () => { m_bFindPath = true; }));
            }
            path = NavMesh2D.GetSmoothedPath(transform.position, pathingTarget.transform.position);
            m_bFindPath = false;
           
            //if (pathingTarget.transform.position != lastTargetPos)
            //{
            //    path = NavMesh2D.GetSmoothedPath(transform.position, pathingTarget.transform.position);
            //    lastTargetPos = pathingTarget.transform.position;
            //}
        }

        if (path != null && path.Count != 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, path[0], unit.m_UnitInfo.speed * Time.deltaTime);

            float fDis = Vector2.Distance(transform.position, path[0]);
            if (fDis < 0.01f)
            {
                path.RemoveAt(0);
            }

            //if (path.Count == 1)
            //{
            //    if (Mathf.Abs(transform.position.x - path[0].x) < 0.1f)
            //    {
            //        path.RemoveAt(0);
            //    }
            //}
            //else
            //{
            //    float fDis = Vector2.Distance(transform.position, path[0]);
            //    if (fDis  < 0.1f)
            //    {
            //        path.RemoveAt(0);
            //    }
            //}
            
        }

        
    }
    void FindNearEnemy()
    {
        if (pathingTarget != null)
        {
            BaseUnit te = pathingTarget.GetComponent<BaseUnit>();
            if (te != null)
            {
                if (te.m_UnitInfo.unitType != (int)UnitType.Crystal && !te.isDied)
                {
                    return;
                }
            }
        }

        RaycastHit2D[] obj = Physics2D.CircleCastAll(transform.position, fCastRadius, new Vector3(0, 0, 0));
        for (int i=0;i<obj.Length;i++)
        {
            Collider2D coll = obj[i].collider;
            BaseUnit bu = coll.gameObject.GetComponent<BaseUnit>();
            if (bu != null)
            {
                if (bu.m_Camp != unit.m_Camp)
                {
                    pathingTarget = coll.gameObject;
                    path.Clear();
                }
            }
        }
        
        
    }

    void OnDrawGizmos()
    {
        //Gizmos.DrawSphere(transform.position, fCastRadius);
        if (m_Transform == null) return;
        if (m_Theta < 0.0001f) m_Theta = 0.0001f;

        // 设置矩阵
        Matrix4x4 defaultMatrix = Gizmos.matrix;
        Gizmos.matrix = m_Transform.localToWorldMatrix;

        // 设置颜色
        Color defaultColor = Gizmos.color;
        Gizmos.color = m_Color;

        // 绘制圆环
        Vector3 beginPoint = Vector3.zero;
        Vector3 firstPoint = Vector3.zero;
        for (float theta = 0; theta < 2 * Mathf.PI; theta += m_Theta)
        {
            float x = m_Radius * Mathf.Cos(theta);
            float z = m_Radius * Mathf.Sin(theta);
            Vector3 endPoint = new Vector3(x, z, 0);
            if (theta == 0)
            {
                firstPoint = endPoint;
            }
            else
            {
                Gizmos.DrawLine(beginPoint, endPoint);
            }
            beginPoint = endPoint;
        }

        // 绘制最后一条线段
        Gizmos.DrawLine(firstPoint, beginPoint);

        // 恢复默认颜色
        Gizmos.color = defaultColor;

        // 恢复默认矩阵
        Gizmos.matrix = defaultMatrix;
    }
        void OnCollisionEnter2D(Collision2D coll)
    {
        //BaseUnit bu = coll.gameObject.GetComponent<BaseUnit>();
        //if (bu != null)
        //{
        //    if (bu.m_Camp != unit.m_Camp)
        //    {
        //        pathingTarget = coll.gameObject;
        //        path.Clear();
        //        FindTarget();
        //    }
        //}
    }
    void OnCollisionStay2D(Collision2D coll)
    {
        Debug.Log("");
    }

        void OnTriggerEnter2D(Collider2D coll)
    {
        //if (pathingTarget == coll.gameObject) return;

        //BaseUnit bu = coll.gameObject.GetComponent<BaseUnit>();
        //if (bu != null)
        //{
        //    if (bu.m_Camp != unit.m_Camp)
        //    {
        //        pathingTarget = coll.gameObject;
        //        path.Clear();
        //        FindTarget();
        //    }
        //}
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        Debug.Log("");
    }
}
