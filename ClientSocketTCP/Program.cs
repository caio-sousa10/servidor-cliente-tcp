using System.Net.Sockets;
using System.Text;

// criando cliente TCP
TcpClient client = new TcpClient("localhost", 13); // no caso do client estar na mesma maquina
                                                   // (caso contrario trocar localhost por IP)
NetworkStream ns = client.GetStream();

// enviando dados para o servidor
byte[] bufferEnviaParaServidor = Encoding.ASCII.GetBytes("Ola servidor");
ns.Write(bufferEnviaParaServidor, 0, bufferEnviaParaServidor.Length);

// recebendo dados do servidor
byte[] bufferRecebeDoServidor = new byte[256];
int bytesLidos = ns.Read(bufferRecebeDoServidor, 0, bufferRecebeDoServidor.Length);
Console.WriteLine("Dados recebidos do servidor: " + Encoding.ASCII.GetString(bufferRecebeDoServidor, 0, bytesLidos));

// finalizando conexao/comunicacao
client.Close();
ns.Close();