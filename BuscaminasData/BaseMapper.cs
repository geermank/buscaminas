using System;

namespace BuscaminasData
{
    public abstract class BaseMapper
    {
        protected SqlDatabase database = new SqlDatabase(Constants.CONNECTION_STRING);

        protected void RunDatabaseOperation(Action action, bool transaction = false)
        {
            database.OpenConnection();
            if (transaction)
            {
                database.RunTransaction();
            }

            bool finishedWithError = false;
            string errorMessage = null;
            try
            {
                action();
                if (transaction)
                {
                    database.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                finishedWithError = true;
                errorMessage = ex.Message;
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
                if (errorMessage == null)
                {
                    errorMessage = "Ha ocurrido un error";
                }
                throw new DatabaseException(errorMessage);
            }
        }
    }
}
