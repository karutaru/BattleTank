using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public AudioClip sound;

    public void OnStartButtonClicked()
    {
        StartCoroutine(GoToMain());
    }

    private IEnumerator GoToMain()
    {
        AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position);

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("Main");
    }
}
