using UnityEngine;
using UnityEngine.AI;

public class Animal : MonoBehaviour
{
    [SerializeField]
    protected string animalName;
    [SerializeField]
    protected int hp;

    [SerializeField]
    protected float walkSpeed;
    [SerializeField]
    protected float runSpeed;
    [SerializeField]
    protected float turningSpeed;

    protected Vector3 destination;

    // ���� ����
    protected bool isAction;
    protected bool isWalking;
    protected bool isRunning;
    protected bool isDead;

    [SerializeField]
    protected float walkTime;
    [SerializeField]
    protected float runTime;
    [SerializeField]
    protected float waitTime;
    protected float currentTime;

    [SerializeField]
    protected Animator anim;
    [SerializeField]
    protected Rigidbody rigid;
    [SerializeField]
    protected BoxCollider boxCol;
    protected AudioSource audioSource;
    protected NavMeshAgent nav;

    [SerializeField]
    protected AudioClip[] sound_Normal;
    [SerializeField]
    protected AudioClip sound_Hurt;
    [SerializeField]
    protected AudioClip sound_Dead;

    protected void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
        currentTime = waitTime;
        isAction = true;
    }

    protected void Update()
    {
        if (!isDead)
        {
            Move();
            ElapseTime();
        }
    }

    protected void Move()
    {
        if (isWalking || isRunning)
            nav.SetDestination(transform.position + destination * 5f);
    }

    protected void ElapseTime()
    {
        if (isAction)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
                ReSet();
        }
    }

    protected virtual void ReSet()
    {
        isWalking = false; isRunning = false; isAction = true;
        nav.speed = walkSpeed;
        nav.ResetPath();
        anim.SetBool("Walking", isWalking); anim.SetBool("Running", isRunning);
        destination.Set(Random.Range(-0.2f, 0.2f), 0f, Random.Range(0.5f, 1f));
    }

    protected void TryWalk()
    {
        isWalking = true;
        anim.SetBool("Walking", isWalking);
        nav.speed = walkSpeed;
        currentTime = walkTime;
        Debug.Log("�ȱ�");
    }

    public virtual void Damage(int _dmg, Vector3 _targetPos)
    {
        if (!isDead)
        {
            hp -= _dmg;

            if (hp <= 0)
            {
                Dead();
                return;
            }

            PlaySE(sound_Hurt);
            anim.SetTrigger("Hurt");
        }
    }

    protected void Dead()
    {
        PlaySE(sound_Dead);
        isWalking = false;
        isRunning = false;
        isDead = true;
        anim.SetTrigger("Dead");
    }

    protected void RandomSound()
    {
        int _random = Random.Range(0, 3);
        PlaySE(sound_Normal[_random]);
    }

    protected void PlaySE(AudioClip _clip)
    {
        audioSource.clip = _clip;
        audioSource.Play();
    }
}
