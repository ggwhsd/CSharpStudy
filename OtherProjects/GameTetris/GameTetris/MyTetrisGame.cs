using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTetris
{
    /*
     * 
     *  游戏类主要包含如下核心逻辑：游戏引擎、游戏地图、游戏元素、胜负机制、碰撞检测、移动变化、反馈机制、声音和音乐
     *  ·游戏框架引擎，本质上就是一个循环，此处就是Run方法
     *      ·引擎中通过循环进行界面刷新来显示游戏动态效果，循环频率一般设定在50ms一次
     *      ·如果有检测输入事件，这个一般为事件驱动方式（界面程序）或者异步检测方式（控制台），若有，则执行相应处理逻辑
     *      ·游戏事件处理主要做如下几件事情:
     *          ·游戏地图数据更新，比如当前方块不在移动，则需要固定到地图数据里面
     *          ·游戏元素更新，比如俄罗斯方块变形，下落，左移
     *          ·游戏元素边界碰撞检测，比如俄罗斯方块是否到达最低端，是否下方、右方、左方有其他方块阻碍移动等。
     *          ·游戏元素碰撞之后的处理逻辑，是否消除地图上的一行，还是只是添加到地图上。
     *          ·游戏胜负检测
     *          ·游戏状态反馈，界面需要有进度、分数等信息显示。
     *  ·
     *      
     */
    class MyTetrisGame : MyGame
    {
        private int loops;
        private bool bkeyDown = false;
        private MyDraw myDraw;
        private MyMap map;
        private MyScore score;
        private TetrisBlock block;
        private TetrisBlock nextBlock;

        public bool BkeyDown { get => bkeyDown; set => bkeyDown = value; }

        protected override void GameInit()
        {
            SetTitle("建议版本俄罗斯方块");
            //设置游戏画面刷新率 每50毫秒一次  
            SetUpdateRate(10);
            //设置光标隐藏  
            SetCursorVisible(false);
            //纵坐标上面少了4，是为了隐藏即将下落的方块
            Console.SetWindowSize(MyMap.Size_x*2+ 24, MyMap.Size_y-4);
            Console.CursorVisible = false;
            myDraw = new MyDraw(MySymbol.RECT_SOLID, ConsoleColor.Black);
            map = new MyMap();
            score = new MyScore(myDraw);
            myDraw.DrawMatrix(map.Map, 0, 0);
            block = TetrisBlock.GetRandom();
            nextBlock = TetrisBlock.GetRandomNext();
            myDraw.DrawTetrisBlock(block);
            //横向为两个字符位置表示一个符号和汉字，纵向都是1个。
            myDraw.DrawText("下一个", MyMap.Size_x*2 + 4, 9, ConsoleColor.Yellow);
            myDraw.DrawTetrisBlock(nextBlock);
            score.DrawScore();

        }

        protected override void GameLoop()
        {
            //base.GameLoop();
            loops++;
            if (loops == 20)
            {
                loops = 0;
                //当前方块是否碰到地图的底部
                if (map.IsDownTouch(block))
                {
                    //到达，则在地图上将其添加
                    map.AddBlocks(block);
                    //计算是否得分
                    int line = map.FullCheck();
                    if (line > 0)
                    {
                        score.AddScore(line);
                    }
                    //计算是否gameover
                    if (map.CheckOver())
                    {
                        SetIsOver(true);
                    }
                    //重绘地图
                    myDraw.DrawMatrix(map.Map, 0, 0);
                    //界面上清空下一个俄罗斯方块
                    myDraw.EraserTetrisBlock(nextBlock);
                    //将下一个方块作为当前方块
                    block = TetrisBlock.GetBlocks(nextBlock.Type);
                    //重新获取下一个方块
                    nextBlock = TetrisBlock.GetRandomNext();
                    //绘制下一个方块
                    myDraw.DrawTetrisBlock(nextBlock);
                    return;
                }
                //当前方块清楚，准备重绘位置
                myDraw.EraserTetrisBlock(block);
                block.Move(new MyPoint(0, 1));
                myDraw.DrawTetrisBlock(block);
            }
            //分数更新频率 20个周期更新一次。
            score.DrawScore();
        }

        protected override void GameExit()
        {
            map = new MyMap();
            string str = string.Format("游戏结束，你的得分为{0}", score.Score);
            myDraw.DrawText(str, MyMap.Size_x/2, MyMap.Size_y/2, ConsoleColor.White);
            Console.SetCursorPosition(MyMap.Size_x / 2, MyMap.Size_y /2 +1);
            Console.CursorVisible = true;
            Console.ReadLine();
        }

        protected override void GameKeyDown(MyKeyboardEventArgs e)
        {
            base.GameKeyDown(e);
            if (BkeyDown)
                return;
            if (e.Key == MyKeys.Down)
            {
                if (map.IsDownTouch(block))
                {
                    map.AddBlocks(block);
                    int line = map.FullCheck();
                    if (line > 0)
                    {
                        score.AddScore(line);
                    }
                    if (map.CheckOver())
                    {
                        SetIsOver(true);
                    }
                    myDraw.DrawMatrix(map.Map, 0, 0);
                    myDraw.EraserTetrisBlock(nextBlock);
                    block = TetrisBlock.GetBlocks(nextBlock.Type);
                    nextBlock = TetrisBlock.GetRandomNext();
                    myDraw.DrawTetrisBlock(nextBlock);
                    return;
                }
                myDraw.EraserTetrisBlock(block);
                block.Move(new MyPoint(0, 1));
                myDraw.DrawTetrisBlock(block);
            }
            if (e.Key == MyKeys.Up)
            {
                BkeyDown = true;
                //计算旋转之后的俄罗斯方块的坐标
                TetrisBlock temp = TetrisBlock.RotateBlocks(block.Type, block.Origin);
                //判断该方块是否会与其他方块碰撞，如果碰撞，则说明不能旋转。
                if (map.CanNotRotate(temp))
                    return;
                //若能旋转，则清楚掉原先的方块
                myDraw.EraserTetrisBlock(block);
                block = temp;
                //绘制新的方块。清楚和绘制实际上算法一样，只是一个画方块，一个画空格
                myDraw.DrawTetrisBlock(block);
            }
            if (e.Key == MyKeys.Left)
            {
                BkeyDown = true;
                if (map.IsLeftTouch(block))
                {
                    return;
                }
                myDraw.EraserTetrisBlock(block);
                block.Move(new MyPoint(-1, 0));
                myDraw.DrawTetrisBlock(block);
            }
            if (e.Key == MyKeys.Right)
            {
                BkeyDown = true;
                if (map.IsRightTouch(block))
                {
                    return;
                }
                myDraw.EraserTetrisBlock(block);
                block.Move(new MyPoint(1, 0));
                myDraw.DrawTetrisBlock(block);
            }
            if (e.Key == MyKeys.Escape)
            {
                SetIsOver(true);
            }
        }

        protected override void GameKeyUp(MyKeyboardEventArgs e)
        {
            base.GameKeyUp(e);
            if (BkeyDown)
            {
                BkeyDown = false;
            }
        }
    }
}
