 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armswing : MonoBehaviour
{
    public GameObject lefthand;
    public GameObject righthand;
    public GameObject righthandknife;
    public GameObject righthandsword;
   //  public GameObject leftcamera;
    //public GameObject rightcamera;
    public GameObject centercamera;

    public GameObject forwarddirection;

    public OVRInput.RawButton leftgrab = OVRInput.RawButton.LHandTrigger;
    public OVRInput.RawButton rightgrab = OVRInput.RawButton.RHandTrigger;

    private Vector3 previousframeleftposition;
    private Vector3 previousframerightposition;
    private Vector3 previousframeplayerposition;
    private Vector3 thisframeleftposition;
    private Vector3 thisframerightposition;
    private Vector3 thisframeplayerposition;

    public float speed = 70;
    private float handspeed;
    private float handspeed1;
    private float handspeed2;


    // Start is called before the first frame update
    void Start()
    {
        previousframeplayerposition = transform.position;
        previousframeleftposition = lefthand.transform.position;
        previousframerightposition = righthand.transform.position;
        previousframerightposition = righthandknife.transform.position;
        previousframerightposition = righthandsword.transform.position;
        

    }

    // Update is called once per frame
    void Update()
    {
        //if (OVRInput.Get(OVRInput.RawButton.LHandTrigger))
        //{
        //    if (OVRInput.Get(OVRInput.RawButton.RHandTrigger))
        //    {
        //        armswinger();
        //    }
        //}
        if((OVRInput.Get(leftgrab)&&OVRInput.Get(rightgrab)))
            {
            
            armswinger();
        }
    }
    private void armswinger()
    {
        //float yrotation = centercamera.transform.eulerAngles.y;
        //forwarddirection.transform.eulerAngles = new Vector3(0, yrotation, 0);

        thisframeleftposition = lefthand.transform.position;
        thisframerightposition = righthand.transform.position;
        thisframerightposition = righthandknife.transform.position;
        thisframerightposition = righthandsword.transform.position;
        thisframeplayerposition = transform.position;
        var playerdistancemove = Vector3.Distance(thisframeplayerposition, previousframeplayerposition);
        var leftdistancemoved = Vector3.Distance(thisframeleftposition, previousframeleftposition);
        var rightdistancemoved = Vector3.Distance(thisframerightposition, previousframerightposition);
        var Rknifedistancemoved = Vector3.Distance(thisframerightposition, previousframerightposition);
        var Rsworddistancemoved=Vector3.Distance(thisframerightposition,previousframerightposition);
        handspeed = ((leftdistancemoved - playerdistancemove) + (rightdistancemoved - playerdistancemove));
        handspeed1 = ((leftdistancemoved - playerdistancemove) + (Rknifedistancemoved - playerdistancemove));
        handspeed2 = ((leftdistancemoved - playerdistancemove) + (Rsworddistancemoved - playerdistancemove));

        if (Time.timeSinceLevelLoad > 1f)
            transform.position += forwarddirection.transform.forward * handspeed * speed * Time.deltaTime;
        if (Time.timeSinceLevelLoad > 1f)
            transform.position += forwarddirection.transform.forward * handspeed1 * speed * Time.deltaTime;
        if (Time.timeSinceLevelLoad > 1f)
            transform.position += forwarddirection.transform.forward * handspeed2 * speed * Time.deltaTime;


        previousframeleftposition = thisframeleftposition;
        previousframerightposition = thisframerightposition;
       
        previousframeplayerposition = thisframeplayerposition;
    } 
}

