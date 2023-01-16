using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    [SerializeField]
    StageContller m_StageContller;

    [SerializeField]
    Transform m_GoalTrans;

    void Update()
    {
        m_GoalTrans.Rotate( new Vector3( 0, 0.5f, 0 ) );
    }

    void OnCollisionEnter( Collision collision )
    {
        if( collision.gameObject.tag == "Player" )
        {
            m_StageContller.OnGoal();
        }
    }
}
