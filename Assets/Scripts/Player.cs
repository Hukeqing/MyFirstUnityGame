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
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Jump"), Input.GetAxis("Vertical")) * MoveSpeed * Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newShell = Instantiate(Shell, FirePoint.position, FirePoint.rotation);
            newShell.GetComponent<Rigidbody>().AddForce(FirePoint.forward * Force);
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
