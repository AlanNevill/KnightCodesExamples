using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.Targets;
using NLog.Layouts;
using System.IO;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;

namespace NLog.File
{
	class Program
	{
		public static Logger logger		= LogManager.GetLogger("fileLogger");
		public static Logger csvFile	= LogManager.GetLogger("CSVfile");
		public static SqlConnection Cn { get; set; }

		public static DirectoryInfo sourceDir;

		static void Main(string[] args)
		{
			logger.Info("Nlog starting");

			if (ValidateFolder(args[0]))
			{
				DbTest(@"Server=(localDB)\MSSQLLocalDB;Integrated Security=true;database=pops");
				ProcessFiles(sourceDir);
				CSVtest();
			}


			Console.WriteLine("Finished - press any key to close");
			Console.ReadLine();

			logger.Info("Nlog finished");

		}

		static void CSVtest()
		{
			Console.WriteLine("csvTest start");
			logger.Info("csvTest starting");

			// write to CSV file
			csvFile.Info(message: "log message 1");
			csvFile.Info("Message 2 with \"quotes\" and \nnew line characters.");
			csvFile.Info("info message 3");

			string message = "{0},{1},{2},{3}";
			csvFile.Info(string.Format( message,"run 1", "SHA", "Folder", "file name"));

			csvFile.Info(string.Format(message, 1, 1234567, "c:\\something\\dd dd\\", "text.xlsx"));

			logger.Info("csvTest finished");
			Console.WriteLine("csvTest finish");
		}

		static bool ValidateFolder(string folderArg)
		{
			// Specify the directories you want to manipulate.
			DirectoryInfo di = new DirectoryInfo(@folderArg);
			try
			{
				// Determine whether the directory exists.
				if (di.Exists)
				{
					// Indicate that the directory already exists.
					logger.Info("{0} exists", di.FullName);
					Console.WriteLine("{0} path exists.", di.FullName);
					sourceDir = di;
					return true;
				}

				Console.WriteLine("{0} path does not exist.", folderArg);
				logger.Info("{0} does not exist", folderArg);
				return false;

			}
			catch (Exception e)
			{
				logger.Error(e);
				Console.WriteLine("The process failed: {0}", e.ToString());
				return false;
			}
		}

		static void ProcessFiles(DirectoryInfo sourceDir)
		{
			string message = "{0},{1},{2},{3}";

			//Process all the jpg files in the source directory tree
			foreach (FileInfo fi in sourceDir.GetFiles("*", SearchOption.AllDirectories))
			{
				//calculate the SHA string 
				string mySHA = CalcSHA(fi);

				// write to CSV file
				csvFile.Info(string.Format(message, 
											fi.FullName,
											fi.DirectoryName,
											fi.Length,
											mySHA)
					);

				CheckSum_ins(mySHA, fi.FullName, fi.DirectoryName, fi.Length);
			}
		}

		private static void CheckSum_ins(string mySHA, string fullName, string directoryName, long fileLength)
		{
			using (SqlCommand sqlCmd = new SqlCommand("spCheckSum_ins", Cn))
			{
				sqlCmd.CommandType = CommandType.StoredProcedure;
				sqlCmd.Parameters.AddWithValue("@SHA", mySHA);
				sqlCmd.Parameters.AddWithValue("@Folder", directoryName);
				sqlCmd.Parameters.AddWithValue("@TheFileName", fullName);
				sqlCmd.Parameters.AddWithValue("@FileSize", fileLength);
				sqlCmd.Parameters.AddWithValue("@Notes", DBNull.Value);

				sqlCmd.ExecuteNonQuery();
			}
		}

		static string CalcSHA(FileInfo fi)
		{
			var watch = System.Diagnostics.Stopwatch.StartNew();

			FileStream fs = fi.OpenRead();
			fs.Position = 0;

			// ComputeHash - returns byte array  
			byte[] bytes = SHA256.Create().ComputeHash(fs);

			// BitConverter used to put all bytes into one string, hypen delimited  
			string bitString = BitConverter.ToString(bytes);

			watch.Stop();
			Console.WriteLine($"{fi.Name}, length: {fi.Length}, execution time: {watch.ElapsedMilliseconds} ms");

			return bitString;
		}

		static void DbTest(string connectionString)
		{
			var dbCn = new MyDbConnect(connectionString);
			Cn = dbCn.Cn;

			using (SqlCommand sqlCmd = new SqlCommand("spCheckSum_ins", Cn))
			{
				sqlCmd.CommandType = CommandType.StoredProcedure;
				sqlCmd.Parameters.AddWithValue("@SHA", "99-88-77-66-55-44-33-22-11");
				sqlCmd.Parameters.AddWithValue("@Folder", @"C:\Logs\");
				sqlCmd.Parameters.AddWithValue("@TheFileName", "Csharp test filename 2.txt");
				sqlCmd.Parameters.AddWithValue("@FileSize", 42);
				sqlCmd.Parameters.AddWithValue("@Notes", DBNull.Value);

				sqlCmd.ExecuteNonQuery();
			}

		}

	}
}
		
