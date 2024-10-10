using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColliders : MonoBehaviour
{
    public Collider colliderLanca;
    public Collider colliderPe;
    public Collider colliderDash;
    public GameObject smoke;
    public GameObject trail;
    public Collider impact;

    public void AtivarLanca()
    {
        colliderLanca.enabled = true;
        trail.SetActive(true);
    }
    public void DesativarLanca()
    {
        colliderLanca.enabled = false;
        trail.SetActive(false);
    }

    public void AtivarPe()
    {
        colliderPe.enabled = true;
    }
    public void DesativarPe()
    {
        colliderPe.enabled = false;
    }
    public void AtivarDash()
    {
        colliderDash.enabled = true;
        trail.SetActive(true);
    }
    public void DesativarDash()
    {
        colliderDash.enabled = false;
        trail.SetActive(false);
    }

    public void AtivarSmoke()
    {
        smoke.SetActive(true);
    }
    public void DesativarSmoke()
    {
        smoke.SetActive(false);
    }

    public void AtivarImpact()
    {
        impact.enabled = true;
        
    }
    public void DesativarImpact()
    {
        impact.enabled = false;
        
    }
}
