using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    [SerializeField]
    private GameObject _Item;

    [SerializeField]
    private float _Radius = 1f;

    //[SerializeField]
    //private int _xPos;

    //[SerializeField]
    //private int _zPos;

    //[SerializeField]
    //private int _itemCount;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(ItemDrop());
    }

    // Update is called once per frame
    void Update()
    {
        SpawnObjectAtRandom();
    }

    //IEnumerator ItemDrop()
    //{
    //    while(_itemCount < 50)
    //    {
    //        _xPos = Random.Range(-50, 50);
    //        _zPos = Random.Range(-50, 50);

    //        Instantiate(_Item, new Vector3(_xPos, 0.5f, _zPos), Quaternion.identity);
    //        yield return new WaitForSeconds(0.1f);
    //        _itemCount += 1;
    //    }
    //}


    private void SpawnObjectAtRandom()
    {
        Vector3 randompos = Random.insideUnitSphere * _Radius;

        Instantiate(_Item, randompos, Quaternion.identity);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(this.transform.position, _Radius);
    }
}
