using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using MySql.Data.MySqlClient;

/* *********************************************************************************
 * PROGRAM: MYSQLCONNECTION
 * 
 * The purpose of this application is to provide a demo of using the MySQL
 * connection.  This application was originally created for two reasons:
 * 
 *  1. To the time the most efficient parts of connecting and loading data from
 *     a database (i.e. - should we share a connection across the application for
 *     performance improvements, or is it acceptable to create a new connection each
 *     time we actually need to load data?)
 *     
 *  2. To provide an interface for students to practice developing Connection Strings
 *     and to test and learn SQL statements.
 *     
 * And that's it!
 * ********************************************************************************* */

namespace MySQLConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            MySqlConnection conn = new MySqlConnection();
            MySqlCommand command;
            Stopwatch sw = new Stopwatch();

            Console.WriteLine("Type a ConnectionString and hit ENTER...");

            string cmd = Console.ReadLine();
            
            // If the user types an exit command of some kind, we can exit the loop
            while (cmd != "quit" || cmd != "exit")
            {
                // If the user is asking for help...
                if (cmd.Equals("help") || cmd.Equals("idk"))
                {
                    // Provide them with some help...
                    Console.WriteLine("Hint: UID=<user>;PASSWORD=<password>;SERVER=<server>");
                }
                else
                {
                    // If the connection is already open, then we're taking a SQL statement...
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        // Start the stopwatch to see how long this query takes...

                        sw.Start();

                        // Create the command using the open connection and assign the SQL
                        // statement to the "CommandText" for execution...
                        command = conn.CreateCommand();
                        command.CommandText = cmd;

                        // Try to run this code, if it produces an exception we'll catch it to
                        // better recover...
                        try
                        {
                            // Write the number of rows affected.
                            Console.WriteLine(command.ExecuteNonQuery().ToString() + " rows affected");
                        }
                        catch (Exception ex)
                        {
                            // Write the error to the console so people can know what they did wrong...
                            Console.WriteLine("Error: " + ex.Message);
                            Console.WriteLine("Try again.");
                        }

                        // Write the amount of time it took to execute this query (from the perspective
                        // of our local stopwatch -- this is not the amount of time it took to execute
                        // the query on the server)...
                        Console.WriteLine(sw.Elapsed.TotalSeconds.ToString() + " seconds to run query");
                        sw.Stop();
                    }
                    else
                    {
                        // If the connection isn't open, then it's either closed or there's something
                        // wrong with it...

                        // Start the stopwatch to see how long creating this connection takes...
                        sw.Start();

                        // Create a new connection object given this command string...
                        conn = new MySqlConnection(cmd);

                        // Open the connection...
                        conn.Open();
                        
                        // Output the time it takes to create the connection...
                        Console.WriteLine("Time to Connection: " + sw.Elapsed.Seconds.ToString());
                        sw.Stop();
                    }
                }
                
                // This line will wait for the user to input a line of code.  The "ReadLine"
                // method is blocking, thus preventing the while loop from going any further
                // until the user enters a command...
                cmd = Console.ReadLine();
            }

            // The user wants to quit, so if the connection isn't already closed, we're going
            // to go ahead and close it...
            if (conn.State != System.Data.ConnectionState.Closed)
            {
                conn.Close();
            }
        }
    }
}
