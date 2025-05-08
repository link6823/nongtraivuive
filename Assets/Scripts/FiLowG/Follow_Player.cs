using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Follow_Player : MonoBehaviour
{

    public GameObject ditheo;
    public GameObject muctieu;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        ditheo.transform.position = new Vector3(muctieu.transform.position.x, muctieu.transform.position.y, ditheo.transform.position.z);
    }
}
