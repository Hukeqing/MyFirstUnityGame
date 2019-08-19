using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public GameObject shell;
    public float force;

    public Text leaveNum;
    public GameObject gameOver;

    public Transform firePoint;

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
        transform.Translate(Time.deltaTime * moveSpeed * new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Jump"), Input.GetAxis("Vertical")));
        
        Camera.main.fieldOfView -= scroll * Time.deltaTime * Input.GetAxis("Mouse ScrollWheel");

        if (Input.GetMouseButtonDown(0))
        {
            GameObject newShell = Instantiate(shell, firePoint.position, firePoint.rotation);
            newShell.GetComponent<Rigidbody>().AddForce(firePoint.forward * force);
            Destroy(newShell, 3);
        }

        var position = transform.position;
        var shouldposition = new Vector3(Mathf.Clamp(position.x, min.x, max.x), Mathf.Clamp(position.y, min.y, max.y), Mathf.Clamp(position.z, min.z, max.z));
        position = shouldposition;
        transform.position = position;
    }

    public void Down()
    {
        cnt--;
        if (cnt == 0)
        {
            leaveNum.gameObject.SetActive(false);
            gameOver.SetActive(true);
        }
        leaveNum.text = "剩余方块：" + cnt.ToString();
    }
}
