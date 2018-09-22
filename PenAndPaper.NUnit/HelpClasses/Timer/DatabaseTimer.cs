using NUnit.Framework.Interfaces;
using PenAndPaper.NUnit.HelpClasses.Exceptions;
using System;
using System.Data.SqlClient;
using static PenAndPaper.NUnit.HelpClasses.Timer.Timer;

namespace PenAndPaper.NUnit.HelpClasses.Timer
{
    internal class DatabaseTimer
    {
        private readonly string connectionString = string.Empty;

        public DatabaseTimer()
        {
            connectionString = "Server=HYRULE;Database=DbTest;Trusted_Connection=True;MultipleActiveResultSets=true";
        }

        public DatabaseTimer(string connectionString)
        {
            if (connectionString == string.Empty)
                throw new DatabaseException("connectionString is requered and can't be empty;");
            this.connectionString = connectionString;
        }

        public void Insert(string className, string methodName, TestStatus testStatus, long time, Approach approach)
        {
            if (className.Equals(string.Empty) || methodName.Equals(string.Empty))
                throw new DatabaseException("ClassName and MethodName are requered inputs and can't be empty.");
            DateTime date = DateTime.Now;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // TODO
                }
                catch (Exception e)
                {
                    throw new DatabaseException("While inserting the data into the database a mistake happened and the process was interrupted.", e);
                }
            }
        }
    }
}
