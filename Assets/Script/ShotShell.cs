using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShotShell : MonoBehaviour
{
    public float shotSpeed;
    public GameObject shellPrefab;
    public AudioClip shotSound;
    private float interval = 0.75f;
    private float timer = 0;
    private int shotCount;
    public TextMeshProUGUI shellLabel;
    private int shotMaxCount = 20;

    void Start()
    {
        shotCount = shotMaxCount;
        shellLabel.text = "" + shotCount;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space) && timer > interval && shotCount > 0)
        {
            shotCount -= 1;

            shellLabel.text = "" + shotCount;
            
            timer = 0.0f;

            GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity);
            Rigidbody shellRb = shell.GetComponent<Rigidbody>();
            shellRb.AddForce(transform.forward * shotSpeed);
            Destroy(shell, 3.0f);
            AudioSource.PlayClipAtPoint(shotSound, transform.position);
        }
    }
    public void AddShell(int amount)
    {
        shotCount += amount;

        if(shotCount > shotMaxCount)
        {
            shotCount = shotMaxCount;
        }
        shellLabel.text = "" + shotCount;
    }
}
