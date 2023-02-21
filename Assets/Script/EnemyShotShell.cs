using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotShell : MonoBehaviour
{
    public float shotSpeed;
    public GameObject enemyShellPrefab;
    public AudioClip shotSound;
    public bool fastShell = false;
    public CameraColor cameraColor;
    public CameraColor cameraColor2;
    private int count;
    private float stopTimer = 3.0f;

    void Update()
    {
        if(fastShell == true) 
        {
            count += 20;
        }
        else
        {
            count += 1;
        }
        stopTimer -= Time.deltaTime;

        if(count >= 900 && stopTimer <= 0)
        {
            count = 0;
            GameObject enemyShell = Instantiate(enemyShellPrefab, transform.position, Quaternion.identity);
            Rigidbody enemyShellRb = enemyShell.GetComponent<Rigidbody>();

            enemyShellRb.AddForce(transform.forward * shotSpeed);

            AudioSource.PlayClipAtPoint(shotSound, transform.position);

            Destroy(enemyShell, 3.0f);
        }
    }
    public void AddStopTimer(float amount)
    {
        stopTimer = amount;
    }

    public void FastTime(bool amount)
    {
        fastShell = amount;
        StartCoroutine(FastTimeEnd());
    }

    IEnumerator FastTimeEnd() {

        yield return new WaitForSeconds(5.0f);
        Color newColor = new Color(42, 97, 183);
        cameraColor.ChangeBackgroundColor(newColor);
        cameraColor2.ChangeBackgroundColor(newColor);

        fastShell = false;
    }
}
