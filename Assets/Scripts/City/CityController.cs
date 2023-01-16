using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CityController : MonoBehaviour
{
    [Header( "カメラアニメーション" )]
    [SerializeField]
    Animator m_MainCameraAnimator;

    float sec;
    float rot;

    [Header( "声" )]
    [SerializeField]
    AudioSource m_VoiceAudioSource;

    [SerializeField]
    AudioClip m_CatAudio;

    [Header( "テキスト" )]
    [SerializeField]
    GameObject m_Title;

    [SerializeField]
    GameObject m_TapArea;

    [Header( "ステージパネル" )]
    [SerializeField]
    GameObject m_StageIcon;

    [SerializeField]
    GameObject m_StageIconB;

    [SerializeField]
    Animator m_Panel;

    [SerializeField]
    Animator m_Panel2;

    void Start()
    {
        Screen.SetResolution( 1280, 800, false, 60 );

        m_TapArea.gameObject.SetActive( false );

        if( StaticRunTime.stage == 0 )
        {
            StartCoroutine( CatVoice() );
        }
        else
        {
            StartCoroutine( OnTap() );
        }
    }

    void Update()
    {
        sec = Time.deltaTime;

        if( Input.GetMouseButtonDown( 0 ) )
        {
            if( m_TapArea.gameObject.activeSelf )
            {
                StartCoroutine( OnTap() );
            }
        }
    }

    IEnumerator CatVoice()
    {
        yield return new WaitForSeconds( 3f );
        m_VoiceAudioSource.Play();

        yield return new WaitForSeconds( 1f );

        m_TapArea.gameObject.SetActive( true );
    }

    IEnumerator OnTap()
    {
        m_MainCameraAnimator.enabled = true;
        m_TapArea.gameObject.SetActive( false );
        m_Title.SetActive( false );

        yield return new WaitForSeconds( 2f );

        m_StageIcon.SetActive( true );
        //m_StageIconB.SetActive( true );
    }

    public void OnIconTap()
    {
        m_Panel.enabled = true;
    }

    public void OnIconTap2()
    {
        m_Panel2.enabled = true;
    }

    public void OnStageTap()
    {
        StaticRunTime.stage = 1;
        SceneManager.LoadScene( "Stage" + StaticRunTime.stage.ToString() );
    }
}
