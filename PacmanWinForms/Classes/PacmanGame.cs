﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Media;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

public delegate void MyAction(Task t, string msg);

namespace PacmanWinForms
{
    public enum GameState : byte
    {
        GAMEOVER = 0,
        GAMEPAUSE = 1,
        GAMERUN = 2
    }

    public enum Direction : Int16
    {
        UP = 0,
        LEFT = 1,
        DOWN = 2,
        RIGHT = 3,
        STOP = 14
    }

    public enum GhostColor : byte
    {
        RED = 0,
        BLUE = 1,
        YELLOW = 2,
        PINK = 3
    }

    public class PacmanGame
    {
        public Direction pacmanDirection = Direction.STOP;
        private Direction pacmanNextDirection = Direction.STOP;
        public Direction redGhostDirection = Direction.RIGHT;
        public Direction blueGhostDirection = Direction.RIGHT;
        public Direction pinkGhostDirection = Direction.RIGHT;
        public Direction yellowGhostDirection = Direction.RIGHT;

        public int Delay
        {
            get { return _delay; }
            set { _delay = (value < 10) ? 10 : value; }
        }

        public GameState State = GameState.GAMEOVER;
        public Color ColorBody = Color.Black;
        public Color ColorHead = Color.Yellow;
        public Task PacmanRunner;
        public Task RedGhostRunner;
        public Task BlueGhostRunner;
        public Task PinkGhostRunner;
        public Task YellowGhostRunner;
        public Task BoardRunner;

        private int ghostDelay = 0;

        private int _delay = 70;
        private int score = 0;
        private Point bonus;
        
        private frmPacmanGame parentForm;
        private PacmanBoard board;
        private Pacman Pacman;
        private Pacman RedGhost;
        private Pacman BlueGhost;
        private Pacman PinkGhost;
        private Pacman YellowGhost;

        private Direction[] directions = new Direction[4];

        List<Point> wallList = new List<Point>();
        List<Point> dotList = new List<Point>();
        List<Point> boxList = new List<Point>();
        List<Point> boxDoorList = new List<Point>();
        List<Point> bonusList = new List<Point>();


        public PacmanGame(frmPacmanGame frm, Panel p)
        {
            parentForm = frm;
            board = new PacmanBoard(p);
            this.Init();
        }

        private void Init()
        {
            wallList = PointLists.banPointList();
            dotList = PointLists.dotPointList();
            boxList = PointLists.boxPointList();
            boxDoorList = PointLists.boxDoorPointList();
            bonusList = PointLists.bonusPointList();

            directionsInit();
            State = GameState.GAMEOVER;
            pacmanDirection = Direction.STOP;

            Pacman = new Pacman(new Point(27, 40), pacmanDirection);
            
            RedGhost = new Pacman(new Point(27, 22), Direction.RIGHT);
            BlueGhost = new Pacman(new Point(27, 29), Direction.LEFT);
            PinkGhost = new Pacman(new Point(32, 29), Direction.LEFT);
            YellowGhost = new Pacman(new Point(23, 29), Direction.LEFT);

            score = 0;
            Delay = 70;
            RePaint();
        }

        public void Run()
        {
            State = GameState.GAMERUN;
            BoardRunner = new Task(runGame);
            BoardRunner.Start();
            PacmanRunner = new Task(runPacman);
            PacmanRunner.Start();
            RedGhostRunner = new Task(runRedGhost);
            RedGhostRunner.Start();
            BlueGhostRunner = new Task(runBlueGhost);
            BlueGhostRunner.Start();
            PinkGhostRunner = new Task(runPinkGhost);
            PinkGhostRunner.Start();
            YellowGhostRunner = new Task(runYellowGhost);
            YellowGhostRunner.Start();

            RePaint();
        }

        public void RePaint()
        {
            parentForm.SuspendLayout();
            board.Resize();
            wallPaint();
            board.DrawPacMan(Pacman.Point, ColorHead, pacmanDirection);
            parentForm.redGhostMove(RedGhost.Point, RedGhost.Direction);
            parentForm.blueGhostMove(BlueGhost.Point, BlueGhost.Direction);
            parentForm.YellowGhostMove(YellowGhost.Point, YellowGhost.Direction);
            parentForm.PinkGhostMove(PinkGhost.Point, PinkGhost.Direction);

            //board.DrawGhost(RedGhost.Point, ghostDir);
            parentForm.ResumeLayout(false);
        }

        private void runBlueGhost()
        {
            while (State != GameState.GAMEOVER)
            {
                try
                {
                    BlueGhost = ghostMove(BlueGhost.Point, BlueGhost.Direction);
                    parentForm.blueGhostMove(BlueGhost.Point, BlueGhost.Direction);
                    BlueGhostRunner.Wait(_delay + ghostDelay);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void runYellowGhost()
        {
            while (State != GameState.GAMEOVER)
            {
                try
                {
                    YellowGhost = ghostMove(YellowGhost.Point, YellowGhost.Direction);
                    parentForm.YellowGhostMove(YellowGhost.Point, YellowGhost.Direction);
                    YellowGhostRunner.Wait(_delay + ghostDelay);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void runPinkGhost()
        {
            while (State != GameState.GAMEOVER)
            {
                try
                {
                    PinkGhost = ghostMove(PinkGhost.Point, PinkGhost.Direction);
                    parentForm.PinkGhostMove(PinkGhost.Point, PinkGhost.Direction);
                    PinkGhostRunner.Wait(_delay + ghostDelay);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void runRedGhost()
        {
            while (State != GameState.GAMEOVER)
            {
                try
                {
                    RedGhost = ghostMove(RedGhost.Point, RedGhost.Direction);
                    parentForm.redGhostMove(RedGhost.Point, RedGhost.Direction);
                    RedGhostRunner.Wait(_delay +  ghostDelay);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void runPacman()
        {
            while (State != GameState.GAMEOVER)
            {
                try
                {

                    board.ClearPacMan(Pacman.Point);
                    Pacman = pacmanMove(Pacman.Point, pacmanDirection);
                    board.DrawPacMan(Pacman.Point, Color.Yellow, Pacman.Direction);

                    eatDots(Pacman.Point);
                    eatBonus(Pacman.Point);
                    dotPaint();
                    bonusPaint();

                    string data = Pacman.Point.ToString() + "@" + score + "%" + Delay;
                    parentForm.Write(data);

                    PacmanRunner.Wait(_delay);

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void runGame()
        {
            while (State != GameState.GAMEOVER)
            {
                try
                {
                    checkForWin();
                    doorPaint();
                    wallPaint();
                    BoardRunner.Wait(_delay);

                }
                catch (Exception ex) { }//MessageBox.Show(ex.ToString()); }
            }
        }

        private Pacman ghostMove(Point StartPoint, Direction d)
        {
            Pacman Ghost = new Pacman(StartPoint, d);

            if (State != GameState.GAMERUN)
            { 
                return Ghost;
            }
            
            int randomInitValue ,i;
            using (RNGCryptoServiceProvider rg = new RNGCryptoServiceProvider())
            {
                byte[] rno = new byte[5];
                rg.GetBytes(rno);
                randomInitValue = BitConverter.ToInt32(rno, 0);
            }
            Random rnd = new Random(randomInitValue);

            List<Direction> nextPossibleDir = possibleDirections(StartPoint, d);

            if (nextPossibleDir.Count != 0)
            {
                i = rnd.Next(0, nextPossibleDir.Count);
                d = nextPossibleDir[i];
            }
            Ghost = new Pacman(nextPoint(StartPoint, d), d);
            
            return Ghost;
            
        }

        private Pacman pacmanMove(Point StartPoint, Direction d)
        {
            bool pass = false;
            Point nextP;
            bool conflictCheck;
            if (State != GameState.GAMERUN)
            {
                return new Pacman(StartPoint, d);
            }

            foreach (Direction dir in directions)
            {
                nextP = nextPoint(StartPoint, dir);
                conflictCheck = collisionCheck(nextP, StartPoint);

                if (conflictCheck && dir == pacmanNextDirection )
                {
                    pacmanDirection = dir;
                    pacmanNextDirection = Direction.STOP;
                    return new Pacman(nextP, dir);
                }
                else if (conflictCheck && dir == d)
                {
                    pass = true;
                }
            }

            if (pass) return new Pacman(nextPoint(StartPoint, d), d);
            else return new Pacman(StartPoint, d);
        }

        private bool collisionCheck(Point P, Point PrevP)
        {
            Pacman Ghost = new Pacman(P, Direction.STOP);
            Ghost.posInit(P);
            //List<Point> mergedList = new List<Point>();
            //mergedList = boxDoorList.Union(wallList).ToList();
            List<Point> commonPoints = Ghost.perimeter.Intersect(wallList.Select(u => u)).ToList();

            return (commonPoints.Count == 0);
        }

        private List<Direction> possibleDirections(Point P, Direction curDir)
        {
            List<Direction> dList = new List<Direction>();
            foreach (Direction d in directions)
            {
                //if (checkForConflict(nextPoint(P, d), P) && d != curDir &&  Math.Abs(d - curDir) != 2) dList.Add(d);
                if (checkForConflict(nextPoint(P, d), P) && Math.Abs(d - curDir) != 2) dList.Add(d);
            }
            return dList;
        }

        private bool outOfBox(Point P)
        {
            Pacman Ghost = new Pacman(P, Direction.STOP);
            Ghost.posInit(P);

            List<Point> commonPoints = Ghost.perimeter.Intersect(boxList.Select(u => u)).ToList();

            return (commonPoints.Count == 0);
        }

        private bool checkForConflict(Point P, Point PrevP)
        {
            Pacman Ghost = new Pacman(P, Direction.STOP);
            Ghost.posInit(P);
            List<Point> mergedList = new List<Point>();
            if (outOfBox(PrevP))
            {
                mergedList = boxDoorList.Union(wallList).ToList();
            }
            else
            {
                mergedList = wallList;
            }
            List<Point> commonPoints = Ghost.perimeter.Intersect(mergedList.Select(u => u)).ToList();

            return (commonPoints.Count == 0);
        }
     
        private Point nextPoint(Point P, Direction D)
        {
            Point nextP = new Point();
            nextP = P;
            switch (D)
            {
                case Direction.UP:
                    nextP.Y--;
                    break;
                case Direction.DOWN:
                    nextP.Y++;
                    break;
                case Direction.RIGHT:
                    nextP.X++;
                    break;
                case Direction.LEFT:
                    nextP.X--;
                    break;
                case Direction.STOP:

                    break;
            }
            return nextP;
        }

        private void eatDots(Point P)
        {
            Pacman item = new Pacman(P, Direction.STOP);
            item.coreInit(P);
            for(int i = 0; i <= dotList.Count - 1; i++)
            {
                foreach (Point corePoint in item.core)
                {
                    if (corePoint.X == dotList[i].X && corePoint.Y == dotList[i].Y)
                    {
                        dotList.RemoveAt(i);
                        score += 10;
                        Stream s = Properties.Resources.Pacman_Waka_Waka_Cut;
                        SoundPlayer player = new SoundPlayer(s);
                        player.Play();
                       // parentForm.playSound(Properties.Resources.Pacman_Waka_Waka_Cut);
                        break;
                    }
                }
            }

        }

        private void eatBonus(Point P)
        {
            Pacman item = new Pacman(P, Direction.STOP);
            item.coreInit(P);
            for (int i = 0; i <= bonusList.Count - 1; i++)
            {
                foreach (Point corePoint in item.core)
                {
                    if (corePoint.X == bonusList[i].X && corePoint.Y == bonusList[i].Y)
                    {
                        bonusList.RemoveAt(i);
                        score += 5;
                        parentForm.playSound(Properties.Resources.Pacman_Waka_Waka_Cut);
                        break;
                    }
                }
            }
        }

        private bool checkPosition(Point P)
        {
            Pacman.posInit(P);

            List<Point> commonPoints = Pacman.perimeter.Intersect(wallList.Select(u => u)).ToList();

            return (commonPoints.Count == 0);
        }

        private void checkForWin()
        {
            if (dotList.Count == 0)
            {
                parentForm.playSound(Properties.Resources.Pacman_Intermission);
                State = GameState.GAMEOVER;
            }
        }
        
        public void setDirection(Direction d)
        {

            if (checkPosition(nextPoint(Pacman.Point, d)))
            {
                pacmanDirection = d;
                //pacmanNextDirection = Direction.STOP;
                Pacman.Direction = d;
                Debug.WriteLine("Passed : "+d);
            }
            else
            {
                 pacmanNextDirection = d;
                 Debug.WriteLine("Wait : " + d);
            }
        }

        private void doorPaint()
        {
            foreach (Point p in boxDoorList)
            {
                board.DrawDoor(p, Color.SlateBlue);
            }
        }

        private void wallPaint()
        {
            foreach (Point p in wallList)
            {
                board.DrawRect(p, Color.DarkBlue);
            }
        }

        private void dotPaint()
        {
            foreach (Point p in dotList)
            {
                board.DrawDot(p, Color.White);
            }
        }

        private void bonusPaint()
        {
            foreach (Point p in bonusList)
            {
                board.DrawBonus(p, Color.White);
            }
        }

        public void Stop()
        {
            State = GameState.GAMEOVER;
        }

        public void Pause()
        {
            if (State == GameState.GAMERUN) State = GameState.GAMEPAUSE;
        }

        public void Continue()
        {
            if (State == GameState.GAMEPAUSE) State = GameState.GAMERUN;
        }

        private void directionsInit()
        {
            directions[0] = Direction.UP;
            directions[1] = Direction.RIGHT;
            directions[2] = Direction.DOWN;
            directions[3] = Direction.LEFT;
        }
    }
}
