using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    [SerializeField]
    private GameObject _Item;

    [SerializeField]
    private float _spawnLimit;

    [SerializeField]
    private float _limit;

    //public Vector3 _center;

    //public Vector3 _size;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(ItemDrop());
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
    }

    private void Spawn()
    {

        while (_spawnLimit < _limit)
        {
            //Vector3 pos = _center + new Vector3(Random.Range(-_size.x / 2, _size.x / 2), Random.Range(-_size.z / 2, _size.z / 2));
            Instantiate(_Item, transform.position, transform.rotation);
            _spawnLimit++;
            break;  
        }
    }

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireCube(transform.localPosition + _center,_size);

    //}
}
