using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

public class UDPReceive : MonoBehaviour
{
    Thread receiveThread;
    UdpClient client;
    public int port = 5052;
    public bool startRecieving = true;
    public bool printToConsole = false;

    // Declare public strings explicitly visible in the Inspector
    public string data = "";             // Raw received data
    public string currentGesture = "";   // Current hand gesture (extracted from the data)

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

                // Extract the current gesture (last index of the data array)
                if (!string.IsNullOrEmpty(data))
                {
                    string[] dataArray = data.Trim('[', ']').Split(','); // Remove brackets and split the data
                    if (dataArray.Length > 0)
                    {
                        currentGesture = dataArray[dataArray.Length - 1].Trim(); // Get the last item
                    }
                }

                // Optionally print to console if enabled
                if (printToConsole)
                {
                    print($"Received data: {data}");
                    print($"Current Gesture: {currentGesture}");
                }
            }
            catch (Exception err)
            {
                print(err.ToString());  // Handle any exceptions
            }
        }
    }
}
