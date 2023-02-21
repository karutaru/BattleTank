using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TankHealth : MonoBehaviour
{
    public GameObject effectPrefab1;
    public GameObject effectPrefab2;
    public int tankHP;
    public TextMeshProUGUI hpLabel;
    private int tankMaxHP = 10;

    private void Start()
    {
        tankHP = tankMaxHP;
        hpLabel.text = "" + tankHP;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("EnemyShell"))
        {
            tankHP -= 1;
            hpLabel.text = "" + tankHP;

            Destroy(other.gameObject);

            if(tankHP >0)
            {
                GameObject effect1 = Instantiate(effectPrefab1, transform.position, Quaternion.identity);
                Destroy(effect1, 1.0f);
            }
            else
            {
                GameObject effect2 = Instantiate(effectPrefab2, transform.position, Quaternion.identity);
                Destroy(effect2, 1.0f);

                //Destroy(gameObject);

                this.gameObject.SetActive(false); //破壊せずにオフモードにし、以降のコードも実行

                Invoke("GoToGameOver", 1.5f);
            }
        }
    }

    void GoToGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void AddHP(int amount)
    {
        tankHP += amount;
        if(tankHP > tankMaxHP)
        {
            tankHP = tankMaxHP;
        }
        hpLabel.text = "" + tankHP;
    }
}
