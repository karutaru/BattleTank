using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public GameObject effectPrefab;
    public GameObject effectPrefab2;
    public int objectHP;
    public GameObject[] itemPrefab;
    public int scoreValue;
    private ScoreManager sm;

    private void Start()
    {
        sm = GameObject.Find("ScoreLabel").GetComponent<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other) {
        
        if(other.CompareTag("Shell"))
        {
            objectHP -= 1; //オブジェクトのHPを1ずつ減少させる

            if(objectHP > 0) //HPが0よりも大きい場合
            {
                Destroy(other.gameObject);
                GameObject effect = Instantiate(effectPrefab, other.transform.position, Quaternion.identity);
                Destroy(effect, 2.0f);
            }
            else //HPが0以下になった場合
            {
                Destroy(other.gameObject);

                GameObject effect2 = Instantiate(effectPrefab2, other.transform.position, Quaternion.identity);

                Destroy(effect2, 2.0f);

                Destroy(this.gameObject);

                sm.AddScore(scoreValue);

                int itemNumber = Random.Range(0, itemPrefab.Length);

                if(itemPrefab.Length != 0)
                {
                    Vector3 pos = transform.position;
                    Instantiate(itemPrefab[itemNumber], new Vector3(pos.x, pos.y + 0.6f, pos.z), Quaternion.identity);
                }
            }
        }
    }
}
