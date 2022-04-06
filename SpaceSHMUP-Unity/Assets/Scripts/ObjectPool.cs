/**** 
 * Created by: Qadeem Qureshi
 * Date Created: March 28, 2022
 * 
 * Last Edited by: Qadeem Qureshi
 * Last Edited: April 06, 2022
 * 
 * Description: Create a pool of objs for reuse
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool POOL;

    #region POOL Singleton
    void CheckPoolIsInScene()
    {
        if (POOL == null)
            POOL = this;
    }
    #endregion

    private Queue<GameObject> projectiles = new Queue<GameObject>();

    [Header("Pool Settings")]
    public GameObject projectilePrefab;
    public int poolStartSize = 5;

    private void Awake()
    {
        CheckPoolIsInScene();
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < poolStartSize; i++)
            projectiles.Enqueue(projectilePrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
