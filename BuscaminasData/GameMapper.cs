using System;
using System.Collections.Generic;

namespace BuscaminasData
{
    public abstract class GameMapper
    {
        protected SqlDatabase database = new SqlDatabase(Constants.CONNECTION_STRING);

        public void SaveSelectMove(int gameId, int timePlayed, BuscaminasBE.BoardCell cell)
        {
            void saveAction()
            {
                UpdateTimePlayed(gameId, timePlayed);
                MarkCellAsSelected(cell);
            }
            RunDatabaseOperation(saveAction, true);
        }

        public void SaveFlagMove(int gameId, BuscaminasBE.Board board, BuscaminasBE.BoardCell cell, int timePlayed)
        {
            void saveAction()
            {
                MarkCellAsFlagged(cell);
                UpdateBoard(gameId, board);
                UpdateTimePlayed(gameId, timePlayed);
            }
            RunDatabaseOperation(saveAction, true);
        }

        protected void MarkCellAsSelected(BuscaminasBE.BoardCell cell)
        {
            IDictionary<string, object> selectedCellParams = new Dictionary<string, object>();
            selectedCellParams.Add("@cellId", cell.Id);
            selectedCellParams.Add("@selected", cell.Selected);
            selectedCellParams.Add("@flagged", cell.Flagged);
            database.ExecuteNonQuery("UPDATE_CELL_SELECTED", selectedCellParams);
        }

        protected void MarkCellAsFlagged(BuscaminasBE.BoardCell cell)
        {
            IDictionary<string, object> selectedCellParams = new Dictionary<string, object>();
            selectedCellParams.Add("@cellId", cell.Id);
            selectedCellParams.Add("@flagged", cell.Flagged);
            database.ExecuteNonQuery("UPDATE_CELL_FLAGGED", selectedCellParams);
        }

        protected void RunDatabaseOperation(Action action, bool transaction = false)
        {
            database.OpenConnection();
            if (transaction)
            {
                database.RunTransaction();
            }

            bool finishedWithError = false;
            try
            {
                action();
                if (transaction)
                {
                    database.CommitTransaction();
                }
            }
            catch (Exception)
            {
                finishedWithError = true;
                if (transaction)
                {
                    database.RollbackTransaction();
                }
            }
            finally
            {
                database.CloseConnection();
            }

            if (finishedWithError)
            {
                throw new DatabaseException("Ha ocurrido un error");
            }
        }

        private void UpdateBoard(int id, BuscaminasBE.Board board)
        {
            IDictionary<string, object> updateBoardParams = new Dictionary<string, object>();
            updateBoardParams.Add("@boardId", id);
            updateBoardParams.Add("@numberOfMinesFlagged", board.NumberOfMinesFlagged);
            updateBoardParams.Add("@numberOfCellsFlagged", board.NumberOfCellsFlagged);
            database.ExecuteNonQuery("UPDATE_BOARD", updateBoardParams);
        }

        private void UpdateTimePlayed(int gameId, int timePlayed)
        {
            IDictionary<string, object> updateTimePlayedParams = new Dictionary<string, object>();
            updateTimePlayedParams.Add("@gameId", gameId);
            updateTimePlayedParams.Add("@timePlayed", timePlayed);
            database.ExecuteNonQuery("UPDATE_TIME_PLAYED", updateTimePlayedParams);
        }
    }
}
