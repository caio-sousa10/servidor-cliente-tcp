using System.Net;
using System.Net.Sockets;
using System.Text;

// protocolo tcp = garantia de entrega de dados


// criando servidor socket TCP

TcpListener listener = new TcpListener(IPAddress.Any, 13);
listener.Start();
Console.WriteLine("Esperando conexão...");
TcpClient client = listener.AcceptTcpClient();
Console.WriteLine("Conexão estabelecida!");
NetworkStream ns = client.GetStream();

try
{
    // lendo dados do cliente
    byte[] bufferRecebeDoCliente = new byte[1024];
    int bytesLidos = ns.Read(bufferRecebeDoCliente, 0, bufferRecebeDoCliente.Length);
    Console.WriteLine("Dados recebidos do cliente: " + Encoding.ASCII.GetString(bufferRecebeDoCliente, 0, bytesLidos));

    // enviando dados para cliente
    byte[] bufferEnviaProCliente = Encoding.ASCII.GetBytes("Ola cliente");
    ns.Write(bufferEnviaProCliente, 0, bufferEnviaProCliente.Length);

    // encerrando comunicacao
    ns.Close();
    client.Close();
    listener.Stop();
}
catch (Exception ex)
{
    Console.WriteLine("Exceção: " + ex.Message);
}
