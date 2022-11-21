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
    }
}
