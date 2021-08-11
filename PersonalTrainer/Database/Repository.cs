using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;


namespace BartlomiejJagielloLab2ZadDom.Database
{
    class Repository
    {
        /// <summary>
        /// Used to connect to application database
        /// </summary>
        private readonly SqlConnection _connection = new SqlConnection(Properties.Resources.ConnectionString);
        
        /// <summary>
        /// Hashes any text using SHA-256
        /// </summary>
        /// <param name="text"></param>
        /// <returns>hashed string</returns>
        private string Hash(string text)
        {
            // Encode text string as bytes
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            // Library function to hash using SHA-256
            SHA256Managed hashString = new SHA256Managed();
            // Result of hashing byte array
            byte[] hashedBytes = hashString.ComputeHash(bytes);
            // Converting byte array to string using StringBuilder
            StringBuilder hashedString = new StringBuilder();
            foreach (byte b in hashedBytes)
            {
                // Convert byte to two hexadecimal, since c# string letter is stored on only 4 bytes
                hashedString.Append(String.Format("{0:x2}", b));
            }
            return hashedString.ToString();
        }

        /// <summary>
        /// Tries to login to database
        /// Checks if only one account with give parameters exists
        /// </summary>
        /// <param name="login">plain text login</param>
        /// <param name="password">plain text password</param>
        /// <returns>true if login was successful else false</returns>
        public bool Login(string login, string password)
        {
            string query = "SELECT COUNT(*) FROM Accounts WHERE Login='" + login + "' AND Password='" + Hash(password) + "';";
            int foundUsers = 0;
            try
            {
                _connection.Open();
                SqlCommand command = new SqlCommand(query, _connection);
                foundUsers = (int)command.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                _connection.Close();
                throw ex;
            }
            _connection.Close();

            return foundUsers == 1;
        }

        /// <summary>
        /// Checks if login is already used
        /// </summary>
        /// <param name="login">plain text login</param>
        /// <returns>true if login exists else false</returns>
        public bool FindLogin(string login)
        {
            string query = "SELECT COUNT(*) FROM Accounts WHERE Login='" + login + "';";
            int foundUsers = 0;
            try
            {
                _connection.Open();
                SqlCommand command = new SqlCommand(query, _connection);
                foundUsers = (int)command.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                _connection.Close();
                throw ex;
            }
            _connection.Close();

            return foundUsers > 0;
        }

        /// <summary>
        /// Creates new user and new account
        /// Both operations must end successfully or none of them will
        /// Raises SqlException
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="nickname"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="birthday"></param>
        public void CreateUserAccount(string login, string password, string nickname, string firstName, string lastName, string birthday)
        {
            string insertAccountQuery = "INSERT INTO Accounts (Login, Password) VALUES ('" + login + "','" + Hash(password) + "');";
            // Transaction which guarantees that account will be linked to user or both won't be created
            string insertNewUserAccountTransaction = 
                @"BEGIN TRANSACTION
                        INSERT INTO Accounts (Login, Password) VALUES ('" + login + "','" + Hash(password) + @"')
                        
                        INSERT INTO Users (Account, FirstName, LastName, Nickname, DateOfBirth) VALUES (SCOPE_IDENTITY(),'" + firstName + "','" + lastName + "','" + nickname + "','" + birthday + @"')
                  COMMIT TRANSACTION;";

            try
            {
                _connection.Open();

                SqlCommand commandInsertAccount = new SqlCommand(insertNewUserAccountTransaction, _connection);
                commandInsertAccount.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                _connection.Close();
                throw e;
            }
            _connection.Close();
        }

        /// <summary>
        /// Returns information about the user
        /// </summary>
        /// <param name="login">login of user whose data will be returned</param>
        /// <returns></returns>
        public DataTable GetUser(string login)
        {
            // Select information about the particular user
            string query =
                "SELECT Users.FirstName, Users.LastName, Users.Nickname, Users.DateOfBirth " +
                "FROM Users " +
                "JOIN Accounts " +
                "ON Users.Account = Accounts.Id " +
                "WHERE Accounts.Login = '" + login + "';";

            SqlDataAdapter adapter = new SqlDataAdapter(query, _connection);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        /// <summary>
        /// Returns information about all workouts in database
        /// </summary>
        /// <returns></returns>
        public DataTable GetWorkouts()
        {
            // Select all information related to workouts except sessions
            string query = @"
            SELECT WorkoutName, Description, Sets, EstimatedLength, Name, Reps, Time, Type, EqName
            FROM Workouts
            LEFT JOIN(
                SELECT Reps, Workout, Time, e.Name, et.Type, eq.Name EqName

            FROM ExercisesInWorkouts ew
                JOIN Exercises e

            JOIN ExerciseTypes et ON et.Id = e.Type

            JOIN Equipment eq on eq.Id = e.Equipment

            ON ew.Exercise = e.Id
                ) AS ew
            ON Workouts.Id = ew.Workout
            WHERE Workouts.Id = ew.Workout";

            SqlDataAdapter adapter = new SqlDataAdapter(query, _connection);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        /// <summary>
        /// Returns information about user sessions
        /// </summary>
        /// <param name="login">login of user whose sessions will be retrieved</param>
        /// <returns></returns>
        public DataTable GetUserSessions(string login)
        {
            // Select sessions
            string query = @"
            SELECT Sessions.Id, Users.Nickname, w.WorkoutName, w.Sets, Exercises.Name, EndDate, StartDate
            FROM Sessions
            LEFT JOIN Users 
	            LEFT JOIN Accounts 
	            ON Users.Account = Accounts.Id
            ON Users.Id = Sessions.SessionOwner
            LEFT JOIN Workouts w 
            INNER JOIN ExercisesInWorkouts ON ExercisesInWorkouts.Workout = w.Id
            INNER JOIN Exercises ON Exercises.Id = ExercisesInWorkouts.Exercise
            ON w.Id = Sessions.Workout
            WHERE Accounts.Login = '" + login + "';";

            SqlDataAdapter adapter = new SqlDataAdapter(query, _connection);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        /// <summary>
        /// Changes user parameters
        /// Both operations must end successfully or none of them will
        /// Raises SqlException
        /// </summary>
        /// <param name="login"></param>
        /// <param name="nickname"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="birthday"></param>
        public void UpdateUser(string login, string nickname, string firstName, string lastName, string birthday)
        {
            // Take user account id
            string queryGetAccountId = @"SELECT Accounts.Id
                FROM Accounts
                WHERE Accounts.Login = '" + login + "'";

            try
            {
                _connection.Open();

                SqlCommand commandGetAccountId = new SqlCommand(queryGetAccountId, _connection);
                int accountId = (int)commandGetAccountId.ExecuteScalar();

                // User user account id to update user value
                string queryUpdateUser = @"UPDATE Users
                SET FirstName = '" + firstName + "', LastName = '" + lastName + "', Nickname = '" + nickname + "', DateOfBirth = '" + birthday + @"'
                WHERE Account = " + accountId + ";";

                SqlCommand commandUpdateUser = new SqlCommand(queryUpdateUser, _connection);
                commandUpdateUser.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                _connection.Close();
                throw e;
            }
            _connection.Close();
        }

        /// <summary>
        /// Deletes session with given id
        /// </summary>
        /// <param name="sessionId"></param>
        public void DeleteSession(int sessionId)
        {
            string queryDeleteSession = "DELETE FROM Sessions WHERE Id=" + sessionId;

            try
            {
                _connection.Open();

                SqlCommand commandDeleteSession = new SqlCommand(queryDeleteSession, _connection);
                commandDeleteSession.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                _connection.Close();
                throw e;
            }
            _connection.Close();
        }


        /* unfinished
        /// <summary>
        /// Adds user entry log to database
        /// </summary>
        /// <param name="login">user's login</param>
        /// <param name="message">message associated with logging</param>
        private void addEntryLog(string login, EntryLogMessage message)
        {
            string queryAddEntryLog = "DELETE FROM Sessions WHERE Id=" + sessionId;

            try
            {
                _connection.Open();

                SqlCommand commandAddEntryLog = new SqlCommand(queryAddEntryLog, _connection);
                commandAddEntryLog.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                _connection.Close();
                throw e;
            }
            _connection.Close();
        }
        */
    }
}
