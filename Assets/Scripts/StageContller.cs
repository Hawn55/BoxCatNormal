using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageContller : MonoBehaviour
{
    [SerializeField]
    GameObject m_Prefab;

    [SerializeField]
    GameObject m_3DRoot;

    [SerializeField]
    GameObject m_Panel;

    [SerializeField]
    Text m_CountText;

    [SerializeField]
    Text m_StageText;

    [Header( "ステージパネル" )]
    [SerializeField]
    Animator m_PanelAnim;

    [SerializeField]
    GameObject m_NextPanel;

    [Header( "結果パネル" )]
    [SerializeField]
    GameObject m_ResultPanel;

    [Header( "クリア時のファンファーレ" )]
    [SerializeField]
    AudioClip m_Fanfa;

    [SerializeField]
    AudioSource m_VoiceAudioSource;

    private Vector3 m_ClickPosition;
    int m_Count;

    void Start()
    {
        if( StaticRunTime.stage == 0 )
            StaticRunTime.stage = 1;

        m_StageText.text = "ステージ " + StaticRunTime.stage.ToString();

        m_Count = 6;
        m_CountText.text = "残り" + m_Count.ToString();

        if( StaticRunTime.stage < 4 && !StaticRunTime.m_IsStage[ StaticRunTime.stage - 1 ] )
        {
            m_PanelAnim.enabled = true;
        }
    }

    void Update()
    {
        if( Input.GetMouseButtonDown( 0 ) )
        {
            if( m_Panel.activeSelf )
                return;

            if( StaticRunTime.stage < 4 && !StaticRunTime.m_IsStage[ StaticRunTime.stage - 1 ] )
                return;

            if( m_Count == 0 )
            {
                OnPanel();
                return;
            }

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );

            if( Physics.Raycast( ray, out hit ) )
            {
                Debug.Log( hit.point );//デバッグログにヒットした場所を出す

                GameObject g = Instantiate( m_Prefab, hit.point, m_Prefab.transform.rotation );

                g.transform.SetParent( m_3DRoot.transform );

                m_Count--;
                m_CountText.text = "残り" + m_Count.ToString();
            }
        }
    }

    public void OnPanel()
    {
        if( StaticRunTime.stage > 3 ||  StaticRunTime.m_IsStage[ StaticRunTime.stage - 1 ] )
        {
            m_Panel.SetActive(true);
        }
    }

    public void OnReturn()
    {
        m_Panel.SetActive( false );
    }

    public void OnReStart()
    {
        SceneManager.LoadScene( "Stage" + StaticRunTime.stage.ToString() );
    }

    public void OnCity()
    {
        SceneManager.LoadScene( "City" );
    }

    public void OnGoal()
    {
        if( StaticRunTime.stage == 5 )
        {
            m_ResultPanel.SetActive(true);
            m_VoiceAudioSource.clip = m_Fanfa;
            m_VoiceAudioSource.Play();
        }
        else
        {
            StaticRunTime.stage++;
            SceneManager.LoadScene( "Stage" + StaticRunTime.stage.ToString() );
        }
    }

    public void OnNext()
    {
        if( m_NextPanel != null )
        {
            m_NextPanel.SetActive( true );
        }
        else
        {
            OnTurtoEnd();
        }
    }

    public void OnTurtoEnd()
    {
        StaticRunTime.m_IsStage[ StaticRunTime.stage - 1 ] = true;
        m_PanelAnim.gameObject.SetActive(false);
    }

    public void OnEat()
    {
        m_Count = 0;
        m_CountText.text = "残り" + m_Count.ToString();
    }

    /// <summary>
    /// ドラック開始のイベントハンドラ
    /// </summary>
    /*
    void OnMouseDown()
    {
        clickPosition = Input.mousePosition;
        clickPosition.z = 10f;
        Instantiate( Prefab, Camera.main.ScreenToWorldPoint( clickPosition ), Prefab.transform.rotation );
    }
    */
}
