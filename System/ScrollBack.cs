using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBack : MonoBehaviour
{
    [SerializeField, Header("視差効果"), Range(0,1)]
    private float _parallaxEffect;

    private GameObject _cam;
    private float _length;
    private float _startPosX;

    

    void Start()
    {
        _startPosX = transform.position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
        _cam = Camera.main.gameObject;
    }

    private void FixedUpdate()
    {
        Parallax();
    }

    void Parallax()
    {
        // 無限スクロールに使用するパラメーター
        float temp = _cam.transform.position.x * (1 - _parallaxEffect);
        // 背景の視差効果に使用するパラメーター
        float dist = _cam.transform.position.x * _parallaxEffect;

        transform.position = new Vector3(_startPosX + dist, transform.position.y, transform.position.z);

        // 無限スクロール
        if (temp > _startPosX + _length) _startPosX += _length;
        else if (temp < _startPosX - _length) _startPosX -= _length;
    }
}