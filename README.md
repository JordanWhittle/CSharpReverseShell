# C# Reverse Shell

A simple reverse shell I created after I learned about [this vulnerability](https://zerosum0x0.blogspot.com/2016/05/xml-attack-for-c-remote-code-execution.html).

There are many explanations of this vulnerability but I didn't find a reverse shell payload for it. Dropping a web shell onto the box seems pointless when you can just have it provide you with a reverse shell.

The code uses fully-qualified names (such as System.Net.Sockets.TcpClient) everywhere so that no using statements are needed. This means that the contents of [ReverseShell.cs](https://github.com/JordanWhittle/CSharpReverseShell/blob/master/ReverseShell/ReverseShell.cs) can be pasted in as your xml payload without modification.

# Usage
The main intended use of this program is to be embedded in an XML payload. [You can take an example payload from here](https://github.com/JordanWhittle/CSharpReverseShell/blob/master/ReverseShell/Payload.xml). I call it an example payload because although it is a working payload, I have only tested it on the box that I wrote it for.

You could also compile this and run it if you want; it's how I tested it. I'm not sure why you'd want to use that though because existing shells written in c would run almsot anywhere already.

### Note: this shell is not encrypted. it's possible (and quite simple) to use encryption though if necessary
