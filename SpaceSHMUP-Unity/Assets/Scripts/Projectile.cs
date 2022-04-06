/****
 *Created by: Qadeem Qureshi
 *Date Created: March 28, 2022
*
*Last Edited by: Qadeem Qureshi
 * Last Edited: April 06, 2022
 *
 *Description: Handles projectile off screen behavior
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private BoundsCheck bc;
    // Start is called before the first frame update
    void Awake()
    {
        bc = GetComponent<BoundsCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bc.offUp)
        {
            Destroy(gameObject);
        }
    }
}
