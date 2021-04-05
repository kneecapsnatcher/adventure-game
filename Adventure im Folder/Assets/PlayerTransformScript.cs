using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransformScript : MonoBehaviour
{
	private Vector3 scaleChange;
	private float yaxis;
    // Start is called before the first frame update
    void Start()
    {
      //  scaleChange = new Vector3 (-1f, -1f, -1f);
    }

    // Update is called once per frame
    void Update()
    {
		//yaxis = transform.position.y / 10;
        //transform.localScale = yaxis * scaleChange;
    }
}

//all of this is too much, the sprite gets far too small, there has to be a better way to do this