using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class AndroidController : MonoBehaviour
{
    private Rigidbody _androidRig;
    
    [SerializeField] private float runPower;

    /// <summary>
    /// 左右移動の速度上限。Rigidbodyの"Speed"（＝現在の速度）がこの値を超えないように処理される。
    /// </summary>
    [SerializeField] private float limitSpeed;

    [SerializeField] private float jumpPower;

    /// <summary>
    /// 接地面の大きさ。値が小さすぎると崖際で接地判定が得られないので注意。キャラの大きさに合わせて調節する予定。
    /// </summary>
    [SerializeField] private float contactAreaSize;

    /// <summary>
    /// キャラクターと地面の距離がこの値以下であれば接地していると判断する。
    /// </summary>
    [SerializeField] private float judgeGroundedDistance;

    /// <summary>
    /// アンドロイドを動かすベロシティ。
    /// </summary>
    private Vector2 velocity;

    /// <summary>
    /// このアンドロイドに電気くんが入っているか
    /// </summary>
    public bool isActive = false;

    private void Awake()
    {
        _androidRig = GetComponent<Rigidbody>();
    }

    //移動関数。電気くんから呼び出す
    public void Move(Vector2 vec)
    {        
        // Moveアクションの入力取得
        velocity = vec;
    }
    //ジャンプ。電気くんから呼び出す
    public void Jump()
    {
        // ジャンプする力を与える
        if (CheckIsGrounded())
        {
            _androidRig.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            SEManager.seInstance.PlayAndroidJumpSE();
        }
    }

    //ForceMode.ForceはFixedUpdateで使わなければならない(マシンスペックの影響を受けて演算結果が変わってしまうため)
    private void FixedUpdate()
    {
        //空中では加速しない
        if (CheckIsGrounded())
        {
            //速度制限仮バージョン。limitSpeedを越えていたら一定の値に固定する
            if (_androidRig.velocity.magnitude > limitSpeed)
            {
                _androidRig.velocity = _androidRig.velocity.normalized * limitSpeed;
            }
            //でなければ加速する。ただし電気くんが入っていなければ加速しない。
            else if(isActive)
            {
                // 移動方向の力を与える
                _androidRig.AddForce(new Vector3(velocity.x, 0, velocity.y) * runPower);
            }
        }

        //画面外処理関数
        //OffScreenAndroid();
    }

    //接地判定
    private bool CheckIsGrounded()
    {
        //BoxCastで要求される引数。足元判定の大きさの半分。要求されるのはVector3型なので引数として渡すタイミングでVector3.oneと乗算して使用
        float halfExtents = contactAreaSize * 0.5f;



        //真下に向かってBoxCastを行い、衝突したらtrue、しなければfalseを返す
        //キャラクターの身長が低すぎる場合、引数centerをY+方向に引き上げる必要あり。castの開始地点に重なっているオブジェクトからは接触判定を得られないため。
        return Physics.BoxCast(transform.position + Vector3.up * 0.25f, Vector3.one * halfExtents, Vector3.down, Quaternion.identity, judgeGroundedDistance);
    }

    //プレイヤーが画面外に出るのを防止する
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

    //エディター用機能
#if UNITY_EDITOR
    private RaycastHit rayHit;

    //接地判定をギズモで可視化。デバッグ用。
    void OnDrawGizmos()
    {
        //BoxCastで要求される引数。足元判定の大きさの半分。要求されるのはVector3型なのでVector3.oneと乗算して使用
        //DrawWireQubeの引数にする場合は半分ではなく元の値（1辺の長さ）が必要なので、渡すタイミングで2倍にする。
        float halfExtents = contactAreaSize * 0.5f;

        //真下に向かってBoxCastを行う
        bool isHit = Physics.BoxCast(transform.position + Vector3.up * 0.25f, Vector3.one * halfExtents, Vector3.down,out rayHit, Quaternion.identity, judgeGroundedDistance);

        //ギズモ描画の指示
        if (isHit)
        {
            //接地しているなら地面まで緑でハコと直線を
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, Vector3.down * rayHit.distance);
            Gizmos.DrawWireCube(transform.position + Vector3.down * rayHit.distance, Vector3.one * halfExtents * 2);
        }
        else
        {
            //接地していなければ赤で長い直線を
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, Vector3.down * 30);
        }
    }
#endif
}
