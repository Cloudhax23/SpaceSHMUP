/**** 
 * Created by: Qadeem Qureshi
 * Date Created: March 28, 2022
 * 
 * Last Edited by: Qadeem Qureshi
 * Last Edited: March 28, 2022
 * 
 * Description: Spawns Enemies
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Settings")]
    public GameObject[] prefabEnemies; //prefabs for the enemies
    public Stack<GameObject> prefabEnemiesS; //we love stacks
    public float enemiesPerSecond; //enemies per second
    public float enemyDefaultPadding; //padding between enemies positions

    private BoundsCheck bndCheck;



    // Start is called before the first frame update
    void Start()
    {
        bndCheck = GetComponent<BoundsCheck>();
        prefabEnemiesS = new Stack<GameObject>();
        foreach(GameObject g in prefabEnemies)
        {
            prefabEnemiesS.Push(g);
        }
        InvokeRepeating("SpawnEnemy", 1f / enemiesPerSecond, 1f/enemiesPerSecond);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy()
    {
        //we love stacks

        int i = Random.Range(0, prefabEnemiesS.Count);
        Stack<GameObject> tmp = new Stack<GameObject>();
        for(int j = 0; j < i; j++)
        {
            tmp.Push(prefabEnemiesS.Pop());
        }
        GameObject go = Instantiate<GameObject>(prefabEnemiesS.Peek());
        while (tmp.Count > 0) prefabEnemiesS.Push(tmp.Pop());

        //if the enemy has padding, get it, else, use the default padding
        float enemyPadding = go.GetComponent<BoundsCheck>() != null ? Mathf.Abs(go.GetComponent<BoundsCheck>().radius)  : enemyDefaultPadding;

        Vector3 pos = Vector3.zero;
        float xMin = -bndCheck.camWidth + enemyPadding;
        float xMax =  bndCheck.camWidth - enemyPadding;
        //spawn at a random x position at the top of the screen
        pos.x = Random.Range(xMin, xMax);
        pos.y = bndCheck.camHeight + enemyPadding;

        go.transform.position = pos;
    }
}
