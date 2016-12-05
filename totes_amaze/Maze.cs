using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace totes_amaze
{
    public enum LEVELS
    {
        EASY,
        INTERMEDIATE,
        DIFFICULT,
        EXPERT,
        OVER
    }

    public class Maze
    {
        public struct Pair
        {
            public Point start;
            public Point end;
            public Pair(Point s, Point e)
            {
                this.start = s;
                this.end = e;
            }
        }
        private LEVELS level = LEVELS.EASY;
        private const int division = 6;

        public LEVELS Next(bool next)
        {
            if (next)
            {
                switch (level)
                {
                    case LEVELS.EASY: level = LEVELS.INTERMEDIATE; break;
                    case LEVELS.INTERMEDIATE: level = LEVELS.DIFFICULT; break;
                    case LEVELS.DIFFICULT: level = LEVELS.EXPERT; break;
                    default: level = LEVELS.OVER; break;
                }
            }
            return level;
        }

        /// <summary>
        /// get division of current level
        /// </summary>
        public int Division
        {
            get
            {
                int div = 0;
                switch (level)
                {
                    case LEVELS.EASY: div = division; break;
                    case LEVELS.INTERMEDIATE: div = division * 2; break;
                    case LEVELS.DIFFICULT: div = division * 3; break;
                    case LEVELS.EXPERT: div = division * 4; break;
                    default: break;
                }
                return div;
            }
        }

        /// <summary>
        /// returns the location of Key object scaled to coordinates
        /// according to division
        /// e.g. (x,y) = (division, division) is (canvas.Height, canvas.Width)
        /// </summary>
        public Point Key()
        {
            Point p = new Point();
            switch (level)
            {
                case LEVELS.EASY: p = new Point(4, 1); break;
                case LEVELS.INTERMEDIATE: p = new Point(10, 7); break;
                case LEVELS.DIFFICULT: p = new Point(8, 13); break;
                case LEVELS.EXPERT: p = new Point(13, 17); break;
                default: break;
            }
            return p;
        }

        /// <summary>
        /// return the location of Door object scaled to coordinates
        /// according to division
        /// e.g. (x,y) = (division/2, division/2) is (canvas.Width/2, canvas.Height/2)
        /// </summary>
        public Point Door()
        {
            Point p = new Point();
            switch (level)
            {
                case LEVELS.EASY: p = new Point(1, 5); break;
                case LEVELS.INTERMEDIATE: p = new Point(3, 0); break;
                case LEVELS.DIFFICULT: p = new Point(2, 4); break;
                case LEVELS.EXPERT: p = new Point(3, 4); break;
                default: break;
            }
            return p;
        }

        /// <summary>
        /// returns the starting points for Bars in a list
        /// of coordinate points according to division
        /// NOTE! startx <= endx and starty <= endy
        /// e.g. (x,y) = (division/2, division/2) is (canvas.Width/2, canvas.Height/2)
        /// </summary>
        public List<Pair> Bars()
        {
            List<Pair> points = new List<Pair>();
            switch (level)
            {
                case LEVELS.EASY:
                    points.Add(new Pair(new Point(3, 3), new Point(3, 5)));
                    points.Add(new Pair(new Point(1, 2), new Point(1, 4)));
                    points.Add(new Pair(new Point(4, 4), new Point(5, 4)));
                    break;
                case LEVELS.INTERMEDIATE:
                    points.Add(new Pair(new Point(6, 2), new Point(6, 4)));
                    points.Add(new Pair(new Point(8, 6), new Point(8, 11)));
                    points.Add(new Pair(new Point(1, 10), new Point(1, 11)));
                    points.Add(new Pair(new Point(1, 2), new Point(3, 2)));
                    points.Add(new Pair(new Point(3, 7), new Point(6, 7)));
                    break;
                case LEVELS.DIFFICULT: 
                    points.Add(new Pair(new Point(2, 8), new Point(2, 11))); //v
                    points.Add(new Pair(new Point(10, 2), new Point(10, 6)));  // v
                    points.Add(new Pair(new Point(5, 12), new Point(5, 16)));   //v
                    points.Add(new Pair(new Point(16, 2), new Point(16, 7)));// v
                    points.Add(new Pair(new Point(3, 3), new Point(7, 3))); //h
                    points.Add(new Pair(new Point(11, 14), new Point(17, 14)));//h
                    points.Add(new Pair(new Point(4, 9), new Point(11, 9)));//h
                    break;
                case LEVELS.EXPERT: 
                    points.Add(new Pair(new Point(17, 9), new Point(17, 14))); //v
                    points.Add(new Pair(new Point(3, 2), new Point(3, 6)));  // v
                    points.Add(new Pair(new Point(9, 14), new Point(9, 21)));   //v
                    points.Add(new Pair(new Point(10, 5), new Point(10, 9)));// v
                    points.Add(new Pair(new Point(20, 2), new Point(20, 7)));// v
                    points.Add(new Pair(new Point(3, 21), new Point(7, 21))); //h
                    points.Add(new Pair(new Point(11, 15), new Point(17, 15))); //h
                    points.Add(new Pair(new Point(4, 12), new Point(11, 12))); //h
                    points.Add(new Pair(new Point(11, 7), new Point(16, 7))); // h
                    points.Add(new Pair(new Point(16, 17), new Point(20, 17))); // h
                    break;
                default: break;
            }
            return points;
        }
    }
}
