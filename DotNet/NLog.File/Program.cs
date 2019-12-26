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
		public static Boolean truncateCheckSum = false;

		public static MyDbConnect MyDb;

		static void Main(string[] args)
		{
			logger.Info("Nlog starting");

			MyDb = new MyDbConnect(@"Server = (localDB)\MSSQLLocalDB; Integrated Security = true; database = pops");

			ProcessDupes();

			// check for 2nd argument supplied requesting truncate CheckSum table
			if (args.Length==2)
			{
				if (args[1].ToLower() == "true") truncateCheckSum = true;
			}

			if (ValidateFolder(args[0]))
			{
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
					logger.Info($"{di.FullName} exists");
					Console.WriteLine($"[{di.FullName}] - path exists.");
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
				Console.WriteLine($"The process failed: {e.ToString()}" );
				return false;
			}
		}

		static void ProcessFiles(DirectoryInfo sourceDir)
		{
			string message = "{0},{1},{2},{3}";

			//Process all the jpg files in the source directory tree
			foreach (FileInfo fi in sourceDir.GetFiles("*", SearchOption.AllDirectories))
			{
				//calculate the SHA string for the file
				var result = CalcSHA(fi);

				// write to CSV file
				csvFile.Info(string.Format(message, 
											fi.FullName,
											fi.DirectoryName,
											fi.Length,
											result.SHA)
					);
				
				// insert row into CheckSum table
				CheckSum_ins(	result.SHA,
								fi.FullName, 
								fi.Extension,
								fi.CreationTimeUtc,
								fi.DirectoryName,
								fi.Length,
								result.timerMs);
			}
		}

		private static void CheckSum_ins(	string mySHA,
											string fullName,
											string fileExt,
											DateTime fileCreateDt,
											string directoryName,
											long fileLength,
											int timerMs)
		{
			using (SqlCommand sqlCmd = new SqlCommand("spCheckSum_ins", Cn))
			{
				sqlCmd.CommandType = CommandType.StoredProcedure;
				sqlCmd.Parameters.AddWithValue("@SHA", mySHA);
				sqlCmd.Parameters.AddWithValue("@Folder", directoryName);
				sqlCmd.Parameters.AddWithValue("@TheFileName", fullName);
				sqlCmd.Parameters.AddWithValue("@FileExt", fileExt);
				sqlCmd.Parameters.AddWithValue("@FileSize", (int)fileLength);
				sqlCmd.Parameters.AddWithValue("@FileCreateDt", fileCreateDt);
				sqlCmd.Parameters.AddWithValue("@TimerMs", timerMs);
				sqlCmd.Parameters.AddWithValue("@Notes", DBNull.Value);
				sqlCmd.ExecuteNonQuery();
			}
		}

		// calculate the SHA256 checksum for the file and return it with the elapsed processing time using tuple
		static (string SHA, int timerMs) CalcSHA(FileInfo fi)
		{
			var watch = System.Diagnostics.Stopwatch.StartNew();

			FileStream fs = fi.OpenRead();
			fs.Position = 0;

			// ComputeHash - returns byte array  
			byte[] bytes = SHA256.Create().ComputeHash(fs);

			// BitConverter used to put all bytes into one string, hyphen delimited  
			string bitString = BitConverter.ToString(bytes);

			watch.Stop();
			Console.WriteLine($"{fi.Name}, length: {fi.Length}, execution time: {watch.ElapsedMilliseconds} ms");

			return (SHA: bitString, timerMs: (int)watch.ElapsedMilliseconds);
		}

		static void DbTest(string connectionString)
		{
			// open the DB connection and save in variable Cn
			var dbCn = new MyDbConnect(connectionString);
			Cn = dbCn.Cn;

			// if command line argument 2 is set to true
			if (truncateCheckSum)
			{
				// clear the CheckSum table
				using (SqlCommand sqlCmd = new SqlCommand("truncate table CheckSum", Cn))
				{
					sqlCmd.CommandType = CommandType.Text;
					sqlCmd.ExecuteNonQuery();
				}
			}
		}

		static void ProcessDupes()
		{
			popsDataSet myDupes = MyDb.DupesTable();
			foreach(popsDataSet.CheckSumDupsRow dupesRow in myDupes.CheckSumDups.Rows)
			{
				Console.WriteLine($"Id: {dupesRow.Id}, SHA: {dupesRow.SHA}");
			}

		}

	}
}
		
