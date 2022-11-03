using BuscaminasAuth;
using BuscaminasData;
using BuscaminasDomain.GameBoard;
using System.Collections.Generic;

namespace BuscaminasDomain.GameRules
{
    public class MultiPlayerGame : Game, IBEObjectConverter<BuscaminasBE.MultiplayerGame>
    {
        private const int MAX_UNCOVER_MINES_PER_TURN = 5;

        private Turn turn;
        private List<Player> players;

        private int minesUncoveredThisTurn = 0;

        private MultiPlayerGameMapper gameMapper = new MultiPlayerGameMapper();

        public List<Player> Players
        {
            get { return players; }
        }

        public override bool UserCanRestartGame()
        {
            return false;
        }

        internal MultiPlayerGame(Board board, List<Player> players) : base(board)
        {
            this.players = players;
            this.turn = new Turn(players);
            this.gameState = GameState.LOOKING_FOR_RIVAL;
        }

        public BuscaminasBE.MultiplayerGame ToBEObject()
        {
            var multiplayerGame = new BuscaminasBE.MultiplayerGame();
            multiplayerGame.Id = id;
            multiplayerGame.GameStateId = (int) gameState;
            multiplayerGame.TimePlayedInSeconds = timePlayedInSeconds;
            multiplayerGame.Board = board.ToBEObject();
            multiplayerGame.Turn = turn.ToBEObject();

            List<BuscaminasBE.Player> bePlayers = new List<BuscaminasBE.Player>();
            foreach(Player player in players)
            {
                BuscaminasBE.Player bePlayer = new BuscaminasBE.Player();
                bePlayer.GameId = id;
                bePlayer.UserId = player.UserId;
                bePlayer.Score = player.Score;

                bePlayers.Add(bePlayer);
            }
            multiplayerGame.Players = bePlayers;

            return multiplayerGame;
        }

        internal override void HandleEmptyCellSelected(EmptyCell emptyCell)
        {
            ChangeTurn();
            ResetMinesUncoveredCounter();

            base.HandleEmptyCellSelected(emptyCell);
        }

        internal override void HandleMineSelected(MineCell mine)
        {
            board.FlagCell(mine.Position, true);
            IncrementPlayerScore();

            minesUncoveredThisTurn++;

            if (minesUncoveredThisTurn >= MAX_UNCOVER_MINES_PER_TURN)
            {
                ChangeTurn();
                ResetMinesUncoveredCounter();
            }
        }

        internal override void HandleNumberSelected(NumberCell numberCell)
        {
            base.HandleNumberSelected(numberCell);
            ChangeTurn();
            ResetMinesUncoveredCounter();
        }

        internal void UpdateIds(BuscaminasBE.MultiplayerGame game)
        {
            if (game == null)
            {
                return;
            }
            id = game.Id;
            board.UpdateIds(game.Board);
        }

        protected override void OnListenerAttached()
        {
            // solo notifica al listener el estado actual del juego
            // apenas éste empieza a escuchar
            listener.OnPlayerTurnChanged(turn.CurrentPlayer, false);

            Player p1 = players[0];
            Player p2 = null;
            if (players.Count == 2)
            {
                p2 = players[1];
            }
            listener.ShowPlayers(p1, p2);
        }

        protected override GameMapper GetGameMapper()
        {
            return gameMapper;
        }

        protected override bool IsUserFlagEnabled()
        {
            return false;
        }

        protected override bool CurrentUserCanPlay()
        {
            return turn.CanPlay(GetCurrentUserPlayer());
        }

        private void ResetMinesUncoveredCounter()
        {
            minesUncoveredThisTurn = 0;
        }

        private void ChangeTurn()
        {
            if (turn.CanPlay(GetCurrentUserPlayer()))
            {
                turn.ChangeTurn();
                gameMapper.UpdateTurn(id, turn.ToBEObject());

                listener.OnPlayerTurnChanged(turn.CurrentPlayer, true);
            }
        }

        private void IncrementPlayerScore()
        {
            turn.CurrentPlayer?.IncrementScore();
            gameMapper.UpdatePlayerScore(id, turn.CurrentPlayer?.UserId, turn.CurrentPlayer?.Score);
        }

        private Player GetCurrentUserPlayer()
        {
            return players.Find(p => p.UserId == Authentication.GetInstance().UserId);
        }
    }
}