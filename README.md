# C# Reverse Shell

A simple reverse shell in C#.

I created this after I learned about [this](https://zerosum0x0.blogspot.com/2016/05/xml-attack-for-c-remote-code-execution.html) vulnerability.

There are many explanations of this vulnerability but I didn't find a reverse shell payload for it. Dropping a web shell onto the box seems pointless when you can just have it provide you with a reverse shell.

The code uses fully-qualified names (such as System.Net.Sockets.TcpClient) everywhere so that no using statements are needed. This means that the contents of ReverseShell.cs can be pasted in as your xml payload without modification.
