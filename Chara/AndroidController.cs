using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class AndroidController : MonoBehaviour
{
    //�ϐ��錾
    /// <summary>
    /// ���̃A���h���C�h��Rigidbody���擾���Ċi�[����B������AddFroce()����ƃL�����������I
    /// </summary>
    private Rigidbody _androidRig;

    /// <summary>
    /// ���E�ړ�����́B�l���傫����΂�苭�������A�������₷���Ȃ�B
    /// </summary>
    [SerializeField] private float runPower;

    /// <summary>
    /// ���E�ړ��̑��x����BRigidbody��"Speed"�i�����݂̑��x�j�����̒l�𒴂��Ȃ��悤�ɏ��������B
    /// </summary>
    [SerializeField] private float limitSpeed;

    /// <summary>
    /// �W�����v�͂�...�ł����˂�...
    /// </summary>
    [SerializeField] private float jumpPower;

    /// <summary>
    /// �ڒn�ʂ̑傫���B�l������������ƊR�ۂŐڒn���肪�����Ȃ��̂Œ��ӁB�L�����̑傫���ɍ��킹�Ē��߂���\��B
    /// </summary>
    [SerializeField] private float contactAreaSize;

    /// <summary>
    /// �L�����N�^�[�ƒn�ʂ̋��������̒l�ȉ��ł���ΐڒn���Ă���Ɣ��f����B
    /// </summary>
    [SerializeField] private float judgeGroundedDistance;

    /// <summary>
    /// �A���h���C�h�𓮂����x���V�e�B�B
    /// </summary>
    private Vector2 velocity;

    /// <summary>
    /// ���̃A���h���C�h�ɓd�C���񂪓����Ă��邩
    /// </summary>
    public bool isActive = false;

    private void Awake()
    {
        //���g��Rigidbody�擾
        _androidRig = GetComponent<Rigidbody>();
    }

    //�ړ��֐��B�d�C���񂩂�Ăяo��
    public void Move(Vector2 vec)
    {        
        // Move�A�N�V�����̓��͎擾
        velocity = vec;
    }
    //�W�����v�B�d�C���񂩂�Ăяo��
    public void Jump()
    {
        // �W�����v����͂�^����
        if (CheckIsGrounded())
        {
            _androidRig.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            SEManager.seInstance.PlayAndroidJumpSE();
        }
    }

    //ForceMode.Force��FixedUpdate�Ŏg��Ȃ���΂Ȃ�Ȃ�(�}�V���X�y�b�N�̉e�����󂯂ĉ��Z���ʂ��ς���Ă��܂�����)
    private void FixedUpdate()
    {
        //�󒆂ł͉������Ȃ�
        if (CheckIsGrounded())
        {
            //���x�������o�[�W�����BlimitSpeed���z���Ă�������̒l�ɌŒ肷��
            if (_androidRig.velocity.magnitude > limitSpeed)
            {
                _androidRig.velocity = _androidRig.velocity.normalized * limitSpeed;
            }
            //�łȂ���Ή�������B�������d�C���񂪓����Ă��Ȃ���Ή������Ȃ��B
            else if(isActive)
            {
                // �ړ������̗͂�^����
                _androidRig.AddForce(new Vector3(velocity.x, 0, velocity.y) * runPower);
            }
        }

        //��ʊO�����֐�
        //OffScreenAndroid();
    }

    //�ڒn����
    private bool CheckIsGrounded()
    {
        //BoxCast�ŗv�����������B��������̑傫���̔����B�v�������̂�Vector3�^�Ȃ̂ň����Ƃ��ēn���^�C�~���O��Vector3.one�Ə�Z���Ďg�p
        float halfExtents = contactAreaSize * 0.5f;



        //�^���Ɍ�������BoxCast���s���A�Փ˂�����true�A���Ȃ����false��Ԃ�
        //�L�����N�^�[�̐g�����Ⴗ����ꍇ�A����center��Y+�����Ɉ����グ��K�v����Bcast�̊J�n�n�_�ɏd�Ȃ��Ă���I�u�W�F�N�g����͐ڐG����𓾂��Ȃ����߁B
        return Physics.BoxCast(transform.position + Vector3.up * 0.25f, Vector3.one * halfExtents, Vector3.down, Quaternion.identity, judgeGroundedDistance);
    }

    //�v���C���[����ʊO�ɏo��̂�h�~����
    private void OffScreenAndroid()
    {
        Vector3 pos = transform.position;

        float distance = pos. x- Camera.main.transform.position.x;
        Vector3 min = Camera.main.ViewportToWorldPoint(new Vector3(distance, 0, 0));
        Vector3 max = Camera.main.ViewportToWorldPoint(new Vector3(distance, 1, 1));

        Vector3 rigidbodySpeed = Time.fixedDeltaTime * _androidRig.velocity;
        _androidRig.position = new Vector3(
        Mathf.Clamp(_androidRig.position.x, min.x - rigidbodySpeed.x, max.x - rigidbodySpeed.x),
        Mathf.Clamp(_androidRig.position.y, min.y - rigidbodySpeed.y, max.y - rigidbodySpeed.y),
        0.0f
        );
    }

    //�G�f�B�^�[�p�@�\
#if UNITY_EDITOR
    private RaycastHit rayHit;

    //�ڒn������M�Y���ŉ����B�f�o�b�O�p�B
    void OnDrawGizmos()
    {
        //BoxCast�ŗv�����������B��������̑傫���̔����B�v�������̂�Vector3�^�Ȃ̂�Vector3.one�Ə�Z���Ďg�p
        //DrawWireQube�̈����ɂ���ꍇ�͔����ł͂Ȃ����̒l�i1�ӂ̒����j���K�v�Ȃ̂ŁA�n���^�C�~���O��2�{�ɂ���B
        float halfExtents = contactAreaSize * 0.5f;

        //�^���Ɍ�������BoxCast���s��
        bool isHit = Physics.BoxCast(transform.position + Vector3.up * 0.25f, Vector3.one * halfExtents, Vector3.down,out rayHit, Quaternion.identity, judgeGroundedDistance);

        //�M�Y���`��̎w��
        if (isHit)
        {
            //�ڒn���Ă���Ȃ�n�ʂ܂ŗ΂Ńn�R�ƒ�����
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, Vector3.down * rayHit.distance);
            Gizmos.DrawWireCube(transform.position + Vector3.down * rayHit.distance, Vector3.one * halfExtents * 2);
        }
        else
        {
            //�ڒn���Ă��Ȃ���ΐԂŒ���������
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, Vector3.down * 30);
        }
    }
#endif
}
