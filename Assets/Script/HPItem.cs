using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPItem : MonoBehaviour
{
    public AudioClip getSound;
    public GameObject effectPrefab;
    private int reward = 3;
    private TankHealth th;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            th = GameObject.Find("Tank").GetComponent<TankHealth>();
            th.AddHP(reward);

            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(getSound, transform.position);
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
        }
    }
}
