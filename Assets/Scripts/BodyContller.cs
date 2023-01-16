using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyContller : MonoBehaviour
{
    [SerializeField]
    CatController m_CatController;

    [SerializeField]
    StageContller m_Stage;

    void OnCollisionEnter( Collision collision )
    {
        if( collision.gameObject.tag == "Player" )
        {
            m_Stage.OnEat();
            m_CatController.EatVoice();
        }
    }
}
