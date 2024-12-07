using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;  // Add this to use the Thread class
using UnityEngine;

public class UDPReceive : MonoBehaviour
{
    Thread receiveThread;
    UdpClient client; 
    public int port = 5052;
    public bool startRecieving = true;
    public bool printToConsole = false;

    // Declare public string explicitly visible in the Inspector
    public string data = "";  // Explicitly declare the string as public

    public void Start()
    {
        // Start the receiving thread
        receiveThread = new Thread(new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }

    // Receive thread method to handle incoming data
    private void ReceiveData()
    {
        client = new UdpClient(port);
        while (startRecieving)
        {
            try
            {
                // Listen for data on any available IP and port
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] dataByte = client.Receive(ref anyIP); // Receive the byte data
                data = Encoding.UTF8.GetString(dataByte);  // Convert byte data to string

                // Optionally print to console if enabled
                if (printToConsole)
                {
                    print($"Received data: {data}");
                }
            }
            catch (Exception err)
            {
                print(err.ToString());  // Handle any exceptions
            }
        }
    }
}
