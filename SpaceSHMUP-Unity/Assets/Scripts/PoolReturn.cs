/**** 
 * Created by: Qadeem Qureshi
 * Date Created: April 6, 2022
 * 
 * Last Edited by: Qadeem Qureshi
 * Last Edited: April 11, 2022
 * 
 * Description: Return things to the object pool
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolReturn : MonoBehaviour
{
    private ObjectPool op;
    // Start is called before the first frame update
    void Start()
    {
        op = ObjectPool.POOL;
    }

    // Update is called once per frame
    private void OnDisable()
    {
        op?.ReturnObject(this.gameObject);
    }
}
