using BuscaminasDomain.GameBoard;
using BuscaminasDomain.GameRules.Factories.Restorers;
using System.Collections.Generic;

namespace BuscaminasDomain.GameRules.Factories
{
    public class MultiplayerGameRestorer : GameRestorer
    {

        public MultiplayerGameRestorer(BuscaminasBE.MultiplayerGame gameToRestore) 
            : base(new MultiplayerGameFactory(), gameToRestore)
        {
            // empty constructor body
        }

        protected override Game RestoreGame(BuscaminasBE.Game game)
        {
            BuscaminasBE.MultiplayerGame gameToRestore = (BuscaminasBE.MultiplayerGame) game;

            List<Player> players = new List<Player>();
            foreach (BuscaminasBE.Player player in gameToRestore.Players)
            {
                Player p = new Player(player);
                players.Add(p);
            }

            Turn turn = new Turn(players, gameToRestore.Turn.CurrentPlayerId, gameToRestore.Turn.Number);
            Board board = boardRestorer.RestoreBoard(gameToRestore.Board);
            GameState gameState = (GameState) game.GameStateId;

            return new MultiPlayerGame(board, players, turn, 
                gameToRestore.Id, gameState, gameToRestore.TimePlayedInSeconds);
        }
    }
}
