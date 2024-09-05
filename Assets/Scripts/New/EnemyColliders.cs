using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColliders : MonoBehaviour
{
    public Collider colliderLanca;
    public Collider colliderPe;
    public Collider colliderDash;

    public void AtivarLanca()
    {
        colliderLanca.enabled = true;
    }
    public void DesativarLanca()
    {
        colliderLanca.enabled = false;
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
    }
    public void DesativarDash()
    {
        colliderDash.enabled = false;
    }
}
