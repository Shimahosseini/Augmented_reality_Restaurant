using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class movement : MonoBehaviour
{

    static Animator anim;
    public float speed = 10.0F;
    public float rotationSpeed = 100.0F;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("issitting", false);
        anim.SetBool("iswalking", false);
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        if (translation < 0) translation = 0;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation*= Time.deltaTime;
        transform.Translate(0,0,translation);
        transform.Rotate(0, rotation, 0);



        if (translation != 0)
        {
            anim.SetBool("iswalking", true);
        }

        else
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {

                anim.SetBool("iswalking", false);

                if (anim.GetBool("issitting"))
                {

                    anim.SetBool("issitting", false);
                }
                else
                {
                    anim.SetBool("issitting", true);


                }
            }

        }  

        
    }
}



