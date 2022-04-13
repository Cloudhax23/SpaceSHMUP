/**** 
 * Created by: Qadeem Qureshi
 * Date Created: April 6, 2022
 * 
 * Last Edited by: Qadeem Qureshi
 * Last Edited: April 11, 2022
 * 
 * Description: Behavior for the projectile
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private BoundsCheck bc;
    private ObjectPool op;
    // Start is called before the first frame update
    void Awake()
    {
        bc = GetComponent<BoundsCheck>();
        op = ObjectPool.POOL;
    }

    // Update is called once per frame
    void Update()
    {
        if (bc.offUp)
        {
            gameObject.SetActive(false);
            bc.offUp = false;
        }
    }
}
