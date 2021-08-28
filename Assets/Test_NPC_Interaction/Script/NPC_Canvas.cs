using UnityEngine;

public class NPC_Canvas : MonoBehaviour
{
    [SerializeField]
    private GameObject _NPC;

    [SerializeField]
    private GameObject _txtBox;


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Touch");
            _txtBox.SetActive(true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        _txtBox.SetActive(false);
    }

    private void Death()
    {
        Destroy(_NPC);
    }
}
