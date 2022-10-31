using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    /// <summary>
    /// GameController.
    /// 
    /// Handles the main scene logic.
    /// </summary>

   

    /// <summary>
    /// 
    /// Cube Params.
    /// 

    private float MoveSpeed;
    private float MoveDistance;
    private float CubeRespawnTimer;


    [SerializeField]
    private GameObject Cube;

    [SerializeField]
    private Text _RespawnInputText;
    [SerializeField]
    private Text _SpeedInputText;
    [SerializeField]
    private Text _DistanceInputText;

    IEnumerator RespawnTimer(float timer)
    {
        RespawnObj();
        yield return new WaitForSeconds(timer);
        StartCoroutine(RespawnTimer(CubeRespawnTimer));
    }

    void Start()
    {
        MoveSpeed = 10f;
        MoveDistance = 15f;
        CubeRespawnTimer = 2f;
        StartCoroutine(RespawnTimer(CubeRespawnTimer));
    }


    private void RespawnObj()
    {
        if (_SpeedInputText.text != "" && _DistanceInputText.text != "" && _RespawnInputText.text != "")
        {
            try
            {
                MoveSpeed = float.Parse(_SpeedInputText.text);
                MoveDistance = float.Parse(_DistanceInputText.text);
                CubeRespawnTimer = float.Parse(_RespawnInputText.text);
            }
            catch (Exception e)
            {
                Debug.LogError($"Can`t parse string to float {e}");
            }
        }
        

        if (!Cube.gameObject.GetComponent<CubeController>())
        {
            Debug.LogError($"Object {Cube} does not have CubeController Script");
            return;
        }
        GameObject _cube = Instantiate(Cube, Cube.transform.position, Cube.transform.rotation);
        _cube.gameObject.GetComponent<CubeController>().Speed = MoveSpeed;
        _cube.gameObject.GetComponent<CubeController>().Distance = MoveDistance;
    }



}
