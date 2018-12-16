using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HwyApi.Logics
{
    public class TicTacToe
    {
        public enum State
        {
            NONE = 0,
            X = 1,
            O = 2
        }
        public string MatchId { get; set; }
        public UserInfo PlayerOne { get; set; }
        public UserInfo PlayerTwo { get; set; }
        public Dictionary<int, State> gameState { get; set; }

        public IReadOnlyList<int[]> WinnerStateList = new List<int[]>
        {
            new int[] {0,1,2},
            new int[] {3,4,5},
            new int[] {6,7,8},
            new int[] {0,3,6},
            new int[] {1,4,7},
            new int[] {2,5,8},
            new int[] {0,4,8},
            new int[] {2,4,6}
        };

        public TicTacToe() {
            MatchId = Guid.NewGuid().ToString();
            gameState = new Dictionary<int, State>
            {
                { 0, State.NONE }, { 1, State.NONE }, { 2, State.NONE },
                { 3, State.NONE }, { 4, State.NONE }, { 5, State.NONE },
                { 6, State.NONE }, { 7, State.NONE }, { 8, State.NONE }
            };
        }

        public void UpdateGameState (int position, State move)
        {
            this.gameState[position] = move;
        }

        public UserInfo CheckWinner()
        {
            if (IsWinner(PlayerOne))
                return PlayerOne;

            if (IsWinner(PlayerTwo))
                return PlayerOne;

            return null;
        }

        public bool IsWinner(UserInfo userInfo)
        {
            var playerMoves = this.gameState
                .Where(state => state.Value == userInfo.userState)
                .Select(state => state.Key);

            return WinnerStateList.Any(state => state.All(
                winNum => playerMoves.Contains(winNum)
            ));
        }
    }
}
