using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBack : MonoBehaviour
{
    [SerializeField, Header("��������"), Range(0,1)]
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
        // �����X�N���[���Ɏg�p����p�����[�^�[
        float temp = _cam.transform.position.x * (1 - _parallaxEffect);
        // �w�i�̎������ʂɎg�p����p�����[�^�[
        float dist = _cam.transform.position.x * _parallaxEffect;

        transform.position = new Vector3(_startPosX + dist, transform.position.y, transform.position.z);

        // �����X�N���[��
        if (temp > _startPosX + _length) _startPosX += _length;
        else if (temp < _startPosX - _length) _startPosX -= _length;
    }
}