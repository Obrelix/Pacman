﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacmanWinForms
{
    public class Pacman
    {
        public Point Point;
        public Direction Direction;
        private Point[] Perimeter = new Point[12];
        private Point[] Core = new Point[4];

        public Pacman(Point point, Direction direction)
        {
            this.Point = point;
            this.Direction = direction;
            perimeter(point);
            core(point);
        }

        public Point[] perimeter(Point p)
        {
            // Akra

            Perimeter[0] = p;
            Perimeter[1] = new Point(p.X + 1, p.Y);
            Perimeter[2] = new Point(p.X + 2, p.Y);

            Perimeter[3] = new Point(p.X + 3, p.Y);
            Perimeter[4] = new Point(p.X + 3, p.Y + 1);
            Perimeter[5] = new Point(p.X + 3, p.Y + 2);

            Perimeter[6] = new Point(p.X + 3, p.Y + 3);
            Perimeter[7] = new Point(p.X + 2, p.Y + 3);
            Perimeter[8] = new Point(p.X + 1, p.Y + 3);

            Perimeter[9] = new Point(p.X, p.Y + 3);
            Perimeter[10] = new Point(p.X, p.Y + 2);
            Perimeter[11] = new Point(p.X, p.Y + 1);
            return Perimeter;
        }

        public Point[] core(Point p)
        {
            Core[0] = new Point(p.X + 2, p.Y + 2);
            Core[1] = new Point(p.X + 2, p.Y + 3);
            Core[2] = new Point(p.X + 3, p.Y + 3);
            Core[3] = new Point(p.X + 3, p.Y + 2);
            return Core;
        }
    }

    public class PacmanRun
    {
        

        public Point Point = new Point();
        public Direction pacmanDirection = Direction.STOP;
        private Direction pacmanNextDirection = Direction.STOP;
        Task PacmanRunner;
        private int _delay = 70;

        Pacman pacman;

        public GameState State = GameState.GAMEOVER;

        List<Point> wallList = new List<Point>();
        List<Point> boxDoorList = new List<Point>();
        List<Point> roadList = new List<Point>();
        private Direction[] directions = new Direction[4];
        private frmPacmanGame parentForm;
        private PacmanBoard board;

        public PacmanRun(frmPacmanGame frm, PacmanBoard b)
        {
            parentForm = frm; 
            board = b;
            this.Init();
        }

        public int Delay
        {
            get { return _delay; }
            set { _delay = (value < 10) ? 10 : value; }
        }


        public Point[] perimeter()
        {
            
            return pacman.perimeter(pacman.Point);
        }

        public Point[] core()
        {
            return pacman.core(pacman.Point);
        }


        public void Run()
        {
            State = GameState.GAMERUN;
            PacmanRunner = new Task(runPacman);
            PacmanRunner.Start();
        }

        private void Init()
        {
            boxDoorList = PointLists.boxDoorPointList();
            wallList = PointLists.banPointList();
            roadList = SmallScaleLists.RoadList();
            pacman = new Pacman(new Point(26, 39), pacmanDirection);
            directionsInit();
            State = GameState.GAMEOVER;
        }

        public void reset()
        {
            board.ClearPacMan(pacman.Point);
            pacman = new Pacman(new Point(26, 39), Direction.STOP);
        }

        public Point scalePoint(Point P)
        {
            return new Point((int)(P.X * PacmanBoard.cellWidth / PacmanBoard.modelCellWidth) + 1,
                (int)(P.Y * PacmanBoard.cellHeight / PacmanBoard.modelCellHeight) + 1);
        }

        private void runPacman()
        {
            while (State != GameState.GAMEOVER)
            {
                try
                {
                    this.Point = pacman.Point;
                    board.ClearPacMan(pacman.Point);
                    Point sp = scalePoint(pacman.Point);
                    List<Point> commonPoints = roadList.Where(u => u == sp).ToList();
                    if(commonPoints.Count != 0) Debug.WriteLine("Passed:  " + sp.ToString());
                    else Debug.WriteLine("Rejected:  " + sp.ToString());
                    pacman = pacmanMove(pacman.Point, pacmanDirection);
                    board.DrawPacMan(pacman.Point, Color.Yellow, pacman.Direction);
                    PacmanRunner.Wait(_delay);

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
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

            foreach (Direction direction in directions)
            {
                nextP = nextPoint(StartPoint, direction);
                conflictCheck = collisionCheck(nextP);

                if (conflictCheck && direction == pacmanNextDirection)
                {
                    pacmanDirection = pacmanNextDirection;
                    pacmanNextDirection = Direction.STOP;
                    return new Pacman(nextP, pacmanNextDirection);
                }
                else if (conflictCheck && direction == d)
                {
                    pass = true;
                }
            }

            if (pass) return new Pacman(nextPoint(StartPoint, d), d);
            else return new Pacman(StartPoint, d);
        }

        private bool collisionCheck(Point P)
        {
            Pacman Ghost = new Pacman(P, Direction.STOP);
            List<Point> mergedList = new List<Point>();
            mergedList = boxDoorList.Union(wallList).ToList();
            List<Point> commonPoints = Ghost.perimeter(P).Intersect(mergedList.Select(u => u)).ToList();

            return (commonPoints.Count == 0);
        }

        public void setDirection(Direction d)
        {

            if (collisionCheck(nextPoint(pacman.Point, d)))
            {
                pacmanDirection = d;
                //pacmanNextDirection = Direction.STOP;
                pacman.Direction = d;
                Debug.WriteLine("Passed : " + d);
            }
            else
            {
                pacmanNextDirection = d;
                Debug.WriteLine("Wait : " + d);
            }
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


        private void directionsInit()
        {
            directions[0] = Direction.UP;
            directions[1] = Direction.RIGHT;
            directions[2] = Direction.DOWN;
            directions[3] = Direction.LEFT;
        }
    }
}