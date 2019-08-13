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

    public static int cnt = 36;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(transform.forward * MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-transform.forward * MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-transform.right * MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(transform.right * MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.Translate(-transform.up * MoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(transform.up * MoveSpeed * Time.deltaTime);
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject newShell = Instantiate(Shell, FirePoint.position, FirePoint.rotation);
            newShell.GetComponent<Rigidbody>().AddForce(transform.forward * Force);
            Destroy(newShell, 3);
        }
        leaveNum.text = "剩余方块：" + cnt.ToString();
        if (cnt == 0)
        {
            leaveNum.gameObject.SetActive(false);
            GameOver.SetActive(true);
        }
    }
}
