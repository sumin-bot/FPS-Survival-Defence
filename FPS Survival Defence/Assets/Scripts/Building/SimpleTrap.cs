using System.Collections;
using UnityEngine;

public class SimpleTrap : MonoBehaviour
{
    private Rigidbody[] rigid;
    [SerializeField]
    private GameObject go_Meat;

    [SerializeField]
    private int damage;

    private bool isActivated = false;

    private AudioSource audioSource;
    [SerializeField]
    private AudioClip sound_Activate;

    void Start()
    {
        rigid = GetComponentsInChildren<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isActivated)
        {
            if (other.transform.tag != "Untagged")
            {
                isActivated = true;
                audioSource.clip = sound_Activate;
                audioSource.Play();

                Destroy(go_Meat);

                for (int i = 0; i < rigid.Length; i++)
                {
                    rigid[i].useGravity = true;
                    rigid[i].isKinematic = false;
                }

                if (other.transform.name == "Player")
                {
                    other.transform.GetComponent<StatusController>().DecreaseHP(damage);
                }
            }
        }
    }
}
