using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 3.5f;//搞一个基础速度
    /*根据玩家按键来进行上下左右的移动：创建两个变量来接受按键参数，根据unity的设定，当玩家按上键和右键时会返还1，下键和左键会返还-1，因此这两个变量会根据玩家按键
     来给予一个正或负的速度来进行上下左右移动*/
    float getHorizontal;
    float getVertical;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        /* 概念
         * Input.GetAxis
         * Returns the value of the virtual axis identified by axisName.返还unity本身定义的按键参数
         * The value will be in the range -1...1 for keyboard and joystick input devices.通过Input.GetAxis来实现记录玩家按键返还1或-1的参数
         * Vector3
         * Representation of 3D vectors and points.用于移动坐标
         * This structure is used throughout Unity to pass 3D positions and directions around. It also contains functions for doing common vector operations.
         * deltaTime
         * It is done by calling a timer every frame per second that holds the time between now and last call in milliseconds. 
         * Thereafter the resulting number (delta time) is used to calculate how far, for instance, a video game character would have travelled during that time.
         * 用一个计时器来计算一段时间用于计算距离等游戏要素
         速度公式：基础速度（float speed）*方向（GetAxis）*时间（deltaTime）*位置参数（不用于计算，是重要的位置参数，因此所有坐标移动都要用到）*/
        getHorizontal = Input.GetAxis("Horizontal");
        getVertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * speed * getHorizontal);
        transform.Translate(Vector3.up * Time.deltaTime * speed * getVertical);
    }
}
