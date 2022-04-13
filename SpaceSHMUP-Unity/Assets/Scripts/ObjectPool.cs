/**** 
 * Created by: Qadeem Qureshi
 * Date Created: April 6, 2022
 * 
 * Last Edited by: Qadeem Qureshi
 * Last Edited: April 6, 2022
 * 
 * Description: Create a pool of objects for reuse
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool POOL;
    #region POOL SINGLETON
    void CheckPool()
    {
        if (POOL == null) POOL = this;
        else Debug.LogError("Too many pools");
    }
    #endregion

    private Queue<GameObject> projectiles = new Queue<GameObject>(); //hold the projectiles

    [Header("Pool Settings")]
    public GameObject projectilePrefab;
    public int poolStartSize = 5;

    private void Awake()
    {
        CheckPool();
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < poolStartSize; i++)
        {
            GameObject projectileGO = Instantiate(projectilePrefab);
            projectiles.Enqueue(projectileGO);
            projectileGO.SetActive(false);
        }
    }

    // Update is called once per frame
    public GameObject GetObject() //get the first object from the queue
    {
        if (projectiles.Count > 0)
        {
            GameObject go = projectiles.Dequeue();
            go.SetActive(true);
            return go;
        }
        else{
            Debug.LogWarning("Out of Objects");
            return null;
        }
    }

    public void ReturnObject(GameObject go) //put item back in the queue
    {
        projectiles.Enqueue(go);
        go.SetActive(false);
    }
}