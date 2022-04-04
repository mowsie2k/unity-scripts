using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomSwitch : MonoBehaviour
{
    public Vector2 cameraChange;
    public Vector3 playerChange;
    private CameraMovement cameraMovement;
    public bool requireText;
    public string locationName;
    public GameObject text;
    public Text locationText;

    // Start is called before the first frame update
    void Start()
    {
        cameraMovement = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cameraMovement.minPosition += cameraChange;
            cameraMovement.maxPosition += cameraChange;
            collision.transform.position += playerChange;
            if (requireText)
            {
                StartCoroutine(locationNameRoutine());
            }
        }
    }

    private IEnumerator locationNameRoutine()
    {
        text.SetActive(true);
        locationText.text = locationName;
        yield return new WaitForSeconds(4f);
        text.SetActive(false);
    }
}
