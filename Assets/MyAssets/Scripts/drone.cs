using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drone : MonoBehaviour
{
    [Header("設定")]
    public float BaseHoveringPow;
    Rigidbody rb;
    float Hovering;
    public List<float> SpeedMode;
    public List<GameObject> Camera;
    public float Quality;
    public GameObject HomePoint;
    public Animator DroneAnimator;
    [Header("状態")]
    public bool TakeOffModeFlag;
    public int SpeedModeFlag=0;
    public int CameraModeFlag=0;
    float speed;
    [Header("入力")]
    public float LeftVinput;
    public float LeftHinput;
    public float RightVinput;
    public float RightHinput;
    [Header("機能制限")]
    public List<string> restriction;
    void Start()
    {
        rb = this.GetComponent<Rigidbody> ();

        BaseHoveringPow = Quality*9.81f;
        Hovering = BaseHoveringPow;
        //最初のスピードを定義
        SpeedModeFlag=SpeedMode.Count/2;
        speed=SpeedMode[SpeedModeFlag];
    }
    void FixedUpdate()
    {
        //離陸モード変更
        if(Input.GetKeyDown(KeyCode.Space) && !restriction.Contains("離陸モード変更")){
            StartCoroutine(DelayAction(0.5f,"離陸"));
        }
        //スピードモード変更
        if(Input.GetKeyDown(KeyCode.M) && !restriction.Contains("スピードモード変更")){
            SpeedModeFlag=(SpeedModeFlag%SpeedMode.Count+1)%SpeedMode.Count;
            speed=SpeedMode[SpeedModeFlag];
        }
        //カメラ変更
        if(Input.GetKeyDown(KeyCode.E) && !restriction.Contains("カメラ変更")){
            CameraModeFlag=(CameraModeFlag%Camera.Count+1)%Camera.Count;
        }
        //キーボード操作
        if(Input.GetKey(KeyCode.W)){
            LeftVinput=1.0f;
        }
        else if(Input.GetKey(KeyCode.S)){
            LeftVinput=-1.0f;
        }
        else{
            LeftVinput=0f;
        }
        if(Input.GetKey(KeyCode.D)){
            LeftHinput=1.0f;
        }
        else if(Input.GetKey(KeyCode.A)){
            LeftHinput=-1.0f;
        }
        else{
            LeftHinput=0f;
        }
        if(Input.GetKey(KeyCode.I)){
            RightVinput=1.0f;
        }
        else if(Input.GetKey(KeyCode.K)){
            RightVinput=-1.0f;
        }
        else{
            RightVinput=0f;
        }
        if(Input.GetKey(KeyCode.L)){
            RightHinput=1.0f;
        }
        else if(Input.GetKey(KeyCode.J)){
            RightHinput=-1.0f;
        }
        else{
            RightHinput=0f;
        }
    }
    void Update()
    {

    }
    private IEnumerator DelayAction(float n,string x)
    {
        yield return new WaitForSecondsRealtime(n);
        if (x =="離陸"){
            TakeOffModeFlag=!TakeOffModeFlag;
        }
    }
}
