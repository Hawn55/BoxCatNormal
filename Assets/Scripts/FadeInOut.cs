using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    [SerializeField]
    Text m_TapStart;

    bool m_IsPlus = false;

    void Update()
    {
        m_TapStart.color = new Color( 1, 1, 1, ( m_TapStart.color.a + ( m_IsPlus ? 1: - 1 ) * Time.deltaTime ) );

        if( !m_IsPlus )
        {
            if( m_TapStart.color.a <= 0 )
            {
                m_IsPlus = true;
            }
        }
        else
        {
            if( m_TapStart.color.a >= 1 )
            {
                m_IsPlus = false;
            }
        }
    }
}
