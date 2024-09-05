using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    public GameObject arrow;
    public Transform spawnPoint;
    public float shootForce;


    private void OnTriggerEnter(Collider chao)
    {

        if (chao.CompareTag("Player"))
        {
            ShootPlayer();
        }
    }
    private void ShootPlayer()
    {
        GameObject bulletObj = Instantiate(arrow, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletRig.transform.forward * shootForce);
        Destroy(bulletObj, 1f);

    }

   
}
