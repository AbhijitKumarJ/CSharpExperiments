using System;
using System.Diagnostics;

namespace ConsoleApp1
{
    public class GitUtils
    {
        public static void ShowGitStatus(string repositoryPath)
        {
            ExecuteGitCommand(repositoryPath, "status");
        }

        public static void ShowGitLog(string repositoryPath)
        {
            ExecuteGitCommand(repositoryPath, "log --oneline -10");
        }

        private static void ExecuteGitCommand(string repositoryPath, string command)
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = "git",
                Arguments = command,
                WorkingDirectory = repositoryPath,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = Process.Start(processInfo))
            {
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                Console.WriteLine(output);
            }
        }
    }

}