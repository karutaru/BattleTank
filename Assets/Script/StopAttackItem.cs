using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAttackItem : MonoBehaviour
{
    private GameObject[] targets;
    public AudioClip getSound;
    public GameObject effectPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            targets = GameObject.FindGameObjectsWithTag("EnemyShotShell");

            foreach(GameObject t in targets)
            {
                t.GetComponent<EnemyShotShell>().AddStopTimer(5.0f);
            }

            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(getSound, transform.position);
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
        }
    }
}
