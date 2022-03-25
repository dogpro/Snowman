using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeThePass : MonoBehaviour
{
    [SerializeField] private GameObject _snowPass;
    private PlayerMovement _playerMovement;
    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent<PlayerMovement>(out _playerMovement);
    }
    private void OnTriggerExit(Collider other)
    {
        other.TryGetComponent<PlayerMovement>(out _playerMovement);
        _playerMovement = null;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && _playerMovement != null)
        {
            gameObject.SetActive(false);
            GameObject snowPass = Instantiate(_snowPass, this.transform.position, Quaternion.identity, this.transform);
            snowPass.SetActive(true);
            GameObject.Destroy(gameObject, 1f);
        }
    }

}
