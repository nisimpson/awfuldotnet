using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwfulNET.Core.Common
{
    public class CompareThreadByWeightScore : IComparer<ThreadMetadata>
    {
        private static CompareThreadByWeightScore instance;
        public static CompareThreadByWeightScore Instance
        {
            get
            {
                if (instance == null)
                    instance = new CompareThreadByWeightScore();

                return instance;
            }
        }

        private CompareThreadByWeightScore() { }

        public int Compare(ThreadMetadata x, ThreadMetadata y)
        {
            if (y == null)
                return 0;

            if (x == null)
                return 1;

            int xScore = ComputeScore(x);
            int yScore = ComputeScore(y);
            return xScore.CompareTo(yScore);
        }

        private int ComputeScore(ThreadMetadata x)
        {
            /// ranking is as follows:
            /// 0) closed threads
            /// 1) old threads with new posts
            /// 2) new threads
            /// 3) old threads with no new posts 

            // baseline; new threads wil have a score of 0
            int score = 0;

            // closed threads have the lowest possible value
            if (x.IsClosed)
                score = int.MinValue;

            if (!x.IsNew)
            {
                // old threads with no new posts have the highest score
                if (x.NewPostCount < 1)
                    score = int.MaxValue;
                else
                    score = x.NewPostCount;
            }

            return score;
        }
    }

    public class CompareThreadByKilledByDate : IComparer<ThreadMetadata>
    {
        public static readonly CompareThreadByKilledByDate Instance = new CompareThreadByKilledByDate();

        private CompareThreadByKilledByDate() { }

        public int Compare(ThreadMetadata x, ThreadMetadata y)
        {
            if (object.ReferenceEquals(x, y))
                return 0;

            return y.KilledByDate.CompareTo(x.KilledByDate);
        }
    }
}
