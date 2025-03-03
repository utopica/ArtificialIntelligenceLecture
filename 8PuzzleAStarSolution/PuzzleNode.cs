using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightPuzzleAStarSolution
{
    public class PuzzleNode
    {
        public int[,] State { get; set; }
        public PuzzleNode Parent { get; set; }
        public int G { get; set; } 
        public int H { get; set; } 
        public int F => G + H; 
        public string Move { get; set; } 

        public PuzzleNode(int[,] state, PuzzleNode parent = null, string move = "")
        {
            State = new int[3, 3];
            Array.Copy(state, State, state.Length);
            Parent = parent;
            Move = move;
            G = parent != null ? parent.G + 1 : 0;
        }

        public void CalculateHeuristic(int[,] goalState)
        {
            H = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (State[i, j] != 0) 
                    {
                        FindTargetPosition(State[i, j], goalState, out int targetI, out int targetJ);
                        H += Math.Abs(i - targetI) + Math.Abs(j - targetJ);
                    }
                }
            }
        }

        private void FindTargetPosition(int value, int[,] goalState, out int targetI, out int targetJ)
        {
            targetI = targetJ = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (goalState[i, j] == value)
                    {
                        targetI = i;
                        targetJ = j;
                        return;
                    }
                }
            }
        }
    }
}
