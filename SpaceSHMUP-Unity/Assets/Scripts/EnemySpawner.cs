/**** 
 * Created by: Qadeem Qureshi
 * Date Created: March 28, 2022
 * 
 * Last Edited by: Qadeem Qureshi
 * Last Edited: March 28, 2022
 * 
 * Description: Spawns enemies on screen
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Settings:")]
    public GameObject[] prefabEnemies;
    public float enemySpawnPerSecond;
    public float enemyDefaultPadding;

    private BoundsCheck bndsCheck;

    // Start is called before the first frame update
    void Start()
    {
        bndsCheck = GetComponent<BoundsCheck>();
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);
    }

    void SpawnEnemy()
    {
        int idx = Random.Range(0, prefabEnemies.Length);
        GameObject go = Instantiate(prefabEnemies[idx]);

        //Position enemy above the screen with random x pos

        float enemyPadding = go.GetComponent<BoundsCheck>() ? enemyDefaultPadding : Mathf.Abs(go.GetComponent<BoundsCheck>().radius);

        Vector3 pos = Vector3.zero;
        float xMin = -bndsCheck.camWidth + enemyPadding;
        float xMax = bndsCheck.camWidth - enemyPadding;

        pos.x = Random.Range(xMin, xMax);
        pos.y = bndsCheck.camHeight + enemyPadding;

        go.transform.position = pos;

        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);
    }
}
