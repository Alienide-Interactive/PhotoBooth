using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgrounANimController : MonoBehaviour
{
    private Animator anim;
    private bool appear;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        appear = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) {
            appear = !appear;
            if (appear == true) {
                AppearForground();
            }
            else {
                DisAppearForground();
            }
        }
    }

    public void AppearForground() {
        anim.SetBool("ForgroundAppear", true);
    }
    public void DisAppearForground()
    {
        anim.SetBool("ForgroundAppear", false);
    }
}
