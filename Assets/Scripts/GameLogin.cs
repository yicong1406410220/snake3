using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogin : MonoBehaviour {

    public Sprite wall;
    public Sprite SnakeBody;
    public Sprite food;
    public Sprite lucency;

    public Image[] Grid1s;
    public Image[] Grid2s;
    public Image[] Grid3s;
    public Image[] Grid4s;
    public Image[] Grid5s;
    public Image[] Grid6s;
    public Image[] Grid7s;
    public Image[] Grid8s;
    public Image[] Grid9s;
    public Image[] Grid10s;
    public Image[] Grid11s;
    public Image[] Grid12s;
    public Image[] Grid13s;
    public Image[] Grid14s;
    public Image[] Grid15s;
    public Image[] Grid16s;

    public Image[,] GridGroup;//图片数组

    public MapMessage[,] MapMessages;

    public Direction direction = Direction.right;

    // Use this for initialization
    void Start ()
    {
        ClearMap();
        InitMap();
        RefreshScreen();

    }

    /// <summary>
    /// 刷新屏幕
    /// </summary>
    private void RefreshScreen()
    {
        for (int i = 0; i < 16; i++)
        {
            for (int j = 0; j < 16; j++)
            {
                if (MapMessages[i, j] == MapMessage.MapNull)
                {
                    GridGroup[i, j].sprite = lucency;
                }
                else if (MapMessages[i, j] == MapMessage.Wall)
                {
                    GridGroup[i, j].sprite = wall;
                }
                else if (MapMessages[i, j] == MapMessage.Body)
                {
                    GridGroup[i, j].sprite = SnakeBody;
                }
                else if (MapMessages[i, j] == MapMessage.food)
                {
                    GridGroup[i, j].sprite = food;
                }
                else
                {
                    Debug.LogError("超出地图初始化分支。。。");
                }

            }
        }
    }

    /// <summary>
    /// 初始化地图
    /// </summary>
    private void InitMap()
    {
        MapMessages = new MapMessage[16, 16];
        for (int i = 0; i < 16; i++)
        {
            for (int j = 0; j < 16; j++)
            {
                MapMessages[i, j] = MapMessage.MapNull;
            }
        }
        for (int i = 0; i < 16; i++)
        {
            MapMessages[0, i] = MapMessage.Wall;
            MapMessages[i, 0] = MapMessage.Wall;
            MapMessages[15, i] = MapMessage.Wall;
            MapMessages[i, 15] = MapMessage.Wall;
        }
    }

    /// <summary>
    /// 清理地图
    /// </summary>
    private void ClearMap()
    {
        GridGroup = new Image[16, 16];
        for (int i = 0; i < 16; i++)
        {
            GridGroup[i, 0] = Grid16s[i];
            GridGroup[i, 1] = Grid15s[i];
            GridGroup[i, 2] = Grid14s[i];
            GridGroup[i, 3] = Grid13s[i];
            GridGroup[i, 4] = Grid12s[i];
            GridGroup[i, 5] = Grid11s[i];
            GridGroup[i, 6] = Grid10s[i];
            GridGroup[i, 7] = Grid9s[i];
            GridGroup[i, 8] = Grid8s[i];
            GridGroup[i, 9] = Grid7s[i];
            GridGroup[i, 10] = Grid6s[i];
            GridGroup[i, 11] = Grid5s[i];
            GridGroup[i, 12] = Grid4s[i];
            GridGroup[i, 13] = Grid3s[i];
            GridGroup[i, 14] = Grid2s[i];
            GridGroup[i, 15] = Grid1s[i];
        }

        for (int i = 0; i < 16; i++)
        {
            for (int j = 0; j < 16; j++)
            {
                GridGroup[i, j].sprite = lucency;
            }
        }
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.D))
        {
            direction = Direction.left;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            direction = Direction.right;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            direction = Direction.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Direction.down;
        }

        ////虚拟轴控制移动
        //float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");
        //if (Mathf.Abs(h) > 0.2 || Mathf.Abs(v) > 0.2)
        //{
        //    if (h > 0.2)
        //    {
        //        direction = Direction.left;
        //    }
        //    else if (h < -0.2)
        //    {
        //        direction = Direction.right;
        //    }
        //    else if (v > 0.2)
        //    {
        //        direction = Direction.up;
        //    }
        //    else if (v < -0.2)
        //    {
        //        direction = Direction.down;
        //    }
        //    Debug.Log("h = " + h + "; v =" + v);
        //}

    }




}
