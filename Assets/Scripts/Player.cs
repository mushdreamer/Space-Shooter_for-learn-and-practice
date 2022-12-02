using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 10.0f;//搞一个基础速度
    /*接下来我们要创建发射子弹的冷却时间，发射子弹属于玩家行为因此在Player文件里进行编辑（Bullets定义了子弹的性质但是发射子弹是玩家行为因此不在Bullets编辑）
      首先fireRate是发射一颗子弹的冷却时间，我们规定发射一枚子弹后0.5秒后才可以发射下一颗子弹
      概念
      Time.time
      The time at the beginning of this frame (Read Only).计算游戏一共进行了多久
      冷却时间的逻辑：我们运用游戏总共的时长来创建一个冷却系统
      我们通过让每一次的冷却时间都加上游戏进行的时间形成“新的冷却时间”
      让“新的冷却时间”-“游戏进行的时间”=0.5实现游戏时长在增加但是冷却还是0.5
      因此我们需要引入一个新的变量canFire（开枪状态）来记录这个“新的冷却时间”
      “游戏进行的时间”大于“新的冷却时间”就等价于“游戏进行的时间”-“新的冷却时间”>0就等价于游戏时长-（游戏时长+冷却时间）>0就等价于冷却时间<0就等价于没有冷却时间因此是可以开枪的*/
    private float fireRate = 0.3f;//创建冷却时间
    private float canFire;//创建“新的冷却时间”
    /*根据玩家按键来进行上下左右的移动：创建两个变量来接受按键参数，根据unity的设定，当玩家按上键和右键时会返还1，下键和左键会返还-1，因此这两个变量会根据玩家按键
     来给予一个正或负的速度来进行上下左右移动*/
    float getHorizontal;/*创建横向方向*/
    float getVertical;/*创建纵向方向*/
    private SpawnManager spawnManager;//在player里面定义一个variable使其能够直接锁定到Spawn Manager文件里
    /*概念
      [SerializeField]
      使用时，原先不显示在inspector（在unity中编辑GameObject的特性的面板）里面的private变量将显示出来*/
    [SerializeField]
    /*使用private这样bullets就不会被其他东西替换掉，玩家也没有权限访问bullets的属性，更加安全*/
    /*在Player这里加入GameObject能够将我们定义好的Bullets拖到Unity的Script里来定义这个bullets GameObject，实现GameObject bullets等价于Unity Bullets*/
    private GameObject bullets;
    [SerializeField]
    private int health = 3;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);

        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();//这样spawnManager这个variable就能够调用SpawnManager文件里面的函数了
    }

    // Update is called once per frame每秒都要检查的状态都写在update里
    void Update()
    {
        /*每秒都要移动因此写到这里*/
        playerMovement();
        /*射击的每一秒都要计算检查冷却系统因此写到这里*/
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > canFire)
        {
            playerShoot();
        }
        playerDeath();
    }

    void playerMovement()
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
        * Transform
        * The Transform is used to store a GameObject’s position, rotation, scale and parenting state
          用于Position,Rotation,Scale
        * transform.Translate
          Moves the transform in the direction移动距离 */

        /* 速度公式 1：基础速度（float speed）* 方向（GetAxis）* 时间（deltaTime）* 位置参数（不用于计算，是重要的位置参数，因此所有坐标移动都要用到）*/
        /*        transform.Translate(Vector3.right * Time.deltaTime * speed * getHorizontal);
                transform.Translate(Vector3.up * Time.deltaTime * speed * getVertical);*/
        /*速度公式 2：新位置参数（内部包含了xy轴的方向返还值）* 时间 * 基础速度*/
        /*transform.Translate(new Vector3(getHorizontal, getVertical, 0) * Time.deltaTime * speed);*/



        /*速度公式 3：在第二条速度公式的基础上将新位置参数改成一个新的变量,实现速度=方向*时间*基础速度*/
        getHorizontal = Input.GetAxis("Horizontal");/*横向方向的键位读取*/
        getVertical = Input.GetAxis("Vertical");/*纵向方向的键位读取*/

        Vector3 direction = new Vector3(getHorizontal, getVertical, 0);

        transform.Translate(direction * speed * Time.deltaTime);

        //限制玩家移动范围在屏幕内
        /*概念
          transform.position
          The position property of a GameObject’s Transform, which is accessible in the Unity Editor and through scripts. 
          Alter this value to move a GameObject. Get this value to locate the GameObject in 3D world space.可用于调用位置参数*/
        /*if (transform.position.y>=7.82087f)
        {
            transform.position = new Vector3(transform.position.x, 7.82087f, 0);
        }
        else if(transform.position.y<=-7.82087f)
        {
            transform.position = new Vector3(transform.position.x, -7.82087f, 0);
        }
        if (transform.position.x >= 17.20577f)
        {
            transform.position = new Vector3(17.20577f, transform.position.y, 0);
        }
        else if (transform.position.x <= -17.20577f)
        {
            transform.position = new Vector3(-17.20577f, transform.position.y, 0);
        }*/

        /*滚动屏幕逻辑（视觉效果非实际滚动）
          当玩家在最右边屏幕上时，让玩家从左边出现。反之玩家在最左边屏幕时，让玩家从右边出现
          当玩家在最上面屏幕时，让玩家在下面出现，繁殖玩家在最下面屏幕时，让玩家从上面出现*/
        if (transform.position.y >= 7.82087f)
        {
            transform.position = new Vector3(transform.position.x, -5.807765f, 0);
        }
        else if (transform.position.y <= -5.80628f)
        {
            transform.position = new Vector3(transform.position.x, 7.8464151f, 0);
        }
        if (transform.position.x >= 17.20577f)
        {
            transform.position = new Vector3(-17.20577f, transform.position.y, 0);
        }
        else if (transform.position.x <= -17.20577f)
        {
            transform.position = new Vector3(17.20577f, transform.position.y, 0);
        }
    }
    void playerShoot()
    {
            canFire = Time.time + fireRate;
            Instantiate(bullets, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            health -= 1;
        }
    }
    void playerDeath()
    {
        if(health < 1)
        {
            spawnManager.nomoreEnemy();
            Destroy(this.gameObject);
        }
    }
}
