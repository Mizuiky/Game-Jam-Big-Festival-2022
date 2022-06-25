using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Petal : MonoBehaviour
{
    public Animator animator;

    public float _timeToDesapear;

    public void Glow()
    {
        this.gameObject.SetActive(true);
        animator.SetBool("glow", true);
    }
}
