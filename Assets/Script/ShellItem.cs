using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellItem : MonoBehaviour
{
    public AudioClip getSound;
    public GameObject effectPrefab;
    private ShotShell ss;
    private int reward = 5; //弾をいくつ回復させるか

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ss = GameObject.Find("ShotShell").GetComponent<ShotShell>();
            ss.AddShell(reward);

            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(getSound, transform.position);
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
        }
    }
}
