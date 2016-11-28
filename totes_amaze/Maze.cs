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
                case LEVELS.DIFFICULT: break;
                case LEVELS.EXPERT: break;
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
                case LEVELS.DIFFICULT: break;
                case LEVELS.EXPERT: break;
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
                case LEVELS.DIFFICULT: break;
                case LEVELS.EXPERT: break;
                default: break;
            }
            return points;
        }
    }
}
