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

    /// <summary>
    /// 地图信息
    /// </summary>
    public MapMessage[,] MapMessages;

    public Direction direction = Direction.right;

    public Direction key = Direction.right;

    public List<Direction> mPos = new List<Direction>();

    public float SpacingTime = 0.1f;

    public float LastMoveTime = 0f;

    bool IsLose = false;

    //食物是不是在
    bool eat = true;

    int x = 2;//蛇头坐标
    int y = 4;
    int q = 2;//蛇尾坐标
    int w = 4;
    int score = 0;
    int i = 0; //移动步数


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
                else if (MapMessages[i, j] == MapMessage.Food)
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
        FoodCreate();
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

    /// <summary>
    /// 食物生成
    /// </summary>
    void FoodCreate()
    {
        int fx, fy;
        do
        {
            fx = Random.Range(0, 16);                       //为何是21 而不是CHANG 
            fy = Random.Range(0, 16);                       //为何是19 而不是KUAN ，可见你修改过CHANG和而不是KUAN 就忘记修改这里了//这就是使用魔数的麻烦点，维修性差→_→ 
        } while (MapMessages[fx,fy] != MapMessage.MapNull);
        MapMessages[fx,fy] = MapMessage.Food;
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.A))
        {
            direction = Direction.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
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

    }

    // 如果启用 MonoBehaviour，则每个固定帧速率的帧都将调用此函数
    private void FixedUpdate()
    {

        if (IsLose)
        {
            return;
        }

        if (Time.timeSinceLevelLoad - LastMoveTime < SpacingTime)
        {
            return;
        }
        LastMoveTime = Time.timeSinceLevelLoad;

        if ((direction == Direction.left && key != Direction.right) || (direction == Direction.up && key != Direction.down) 
            || (direction == Direction.down && key != Direction.up) || (direction == Direction.right && key != Direction.left))
            key = direction;

        mPos.Add(key);
        switch (key)
        {
            case Direction.up:
                y++;
                break;
            case Direction.right:
                x++;
                break;
            case Direction.left:
                x--;
                break;
            case Direction.down:
                y--;
                break;

            /* 您可以有任意数量的 case 语句 */
            default: /* 可选的 */
                Debug.LogError("输入错误...");
                break;
        }

        eat = true;
        if (MapMessages[x,y] == MapMessage.Food)
            eat = false;

        if (eat)
            i++;

        if (MapMessages[x, y] == MapMessage.Wall || MapMessages[x, y] == MapMessage.Body)
        {
            IsLose = true;
            RefreshScreen();
            Debug.Log("游戏失败...");
            return;
        }         //撞墙或咬自己。 

        MapMessages[x, y] = MapMessage.Body;

        if (i > 3)
        {
            if (eat)
            {
                Direction TailDirection = mPos[i - 4];                          //蛇尾方向
                switch (TailDirection)
                {
                    case Direction.up:
                        w++;
                        break;
                    case Direction.right:
                        q++;
                        break;
                    case Direction.left:
                        q--;
                        break;
                    case Direction.down:
                        w--;
                        break;

                    /* 您可以有任意数量的 case 语句 */
                    default: /* 可选的 */
                        Debug.LogError("输入错误...");
                        break;
                }
                MapMessages[q, w] = MapMessage.MapNull;
            }
            else
            {
                FoodCreate();
                ++score;
                Debug.Log("分数为..." + score);
            }     
        }
        RefreshScreen();
    }

}
