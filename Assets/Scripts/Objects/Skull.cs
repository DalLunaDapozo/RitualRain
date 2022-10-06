using UnityEngine;

public class Skull : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    
    public void Turn_On()
    {
        anim.SetTrigger("turn_on");
    }
}
