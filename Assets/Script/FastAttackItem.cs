using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastAttackItem : MonoBehaviour
{
    private GameObject[] targets;
    public AudioClip getSound;
    public GameObject effectPrefab;
    public CameraColor cameraColor;
    public CameraColor cameraColor2;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Color newColor = new Color(100, 0, 0); //Color newColor = new Color(42, 97, 183);
            cameraColor.ChangeBackgroundColor(newColor);
            cameraColor2.ChangeBackgroundColor(newColor);

            targets = GameObject.FindGameObjectsWithTag("EnemyShotShell");

            foreach(GameObject t in targets)
            {
                t.GetComponent<EnemyShotShell>().FastTime(true);
            }

            AudioSource.PlayClipAtPoint(getSound, transform.position);
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            Destroy(gameObject);
        }
    }
}
