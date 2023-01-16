using UnityEngine;
using UnityEngine.AI;

public class CatController : MonoBehaviour
{
    [SerializeField]
    public Transform m_Goal;

    [SerializeField]
    Transform[] m_RotationPos;

    NavMeshAgent agent;
    Animator animator;

    [SerializeField]
    BoxCollider m_BoxCollider;

    [Header( "声" )]
    [SerializeField]
    AudioSource m_VoiceAudioSource;

    [SerializeField]
    AudioClip m_CatAudio;

    [SerializeField]
    AudioClip m_CatEat;

    int m_RandomNo = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Reset()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

            if( m_Goal != null )
            {
                agent.destination = m_Goal.position;
                m_Goal = null;

                if( m_VoiceAudioSource != null )
                {
                    m_VoiceAudioSource.clip = m_CatAudio;
                    m_VoiceAudioSource.Play();
                }
            }
            else if( m_RotationPos.Length > m_RandomNo && m_RotationPos[ m_RandomNo ] != null )
            {
                if( !agent.pathPending && agent.remainingDistance < 0.5f )
                {
                    agent.destination = m_RotationPos[ m_RandomNo ].position;
                    m_RandomNo = ( m_RotationPos.Length - 1 ) > m_RandomNo ? m_RandomNo + 1: 0;
                }
            }

        animator.SetFloat( "Speed", agent.velocity.sqrMagnitude );
    }

    public void EatVoice()
    {
        m_VoiceAudioSource.clip = m_CatEat;
        m_VoiceAudioSource.Play();
    }
}