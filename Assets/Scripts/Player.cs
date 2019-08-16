using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float MoveSpeed;
    public GameObject Shell;
    public float Force;

    public Text leaveNum;
    public GameObject GameOver;

    public Transform FirePoint;

    public Vector3 min;
    public Vector3 max;

    public int scroll;

    public int cnt = 36;

    private void Start()
    {
        leaveNum.text = "剩余方块：" + cnt.ToString();
    }

    void Update()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Jump"), Input.GetAxis("Vertical")) * MoveSpeed * Time.deltaTime);
        
        Camera.main.fieldOfView -= scroll * Time.deltaTime * Input.GetAxis("Mouse ScrollWheel");

        if (Input.GetMouseButtonDown(0))
        {
            GameObject newShell = Instantiate(Shell, FirePoint.position, FirePoint.rotation);
            newShell.GetComponent<Rigidbody>().AddForce(FirePoint.forward * Force);
            Destroy(newShell, 3);
        }
        Vector3 shouldposition = new Vector3(Mathf.Clamp(transform.position.x, min.x, max.x), Mathf.Clamp(transform.position.y, min.y, max.y), Mathf.Clamp(transform.position.z, min.z, max.z));
        transform.position = shouldposition;
    }

    public void Down()
    {
        cnt--;
        if (cnt == 0)
        {
            leaveNum.gameObject.SetActive(false);
            GameOver.SetActive(true);
        }
        leaveNum.text = "剩余方块：" + cnt.ToString();
    }
}
