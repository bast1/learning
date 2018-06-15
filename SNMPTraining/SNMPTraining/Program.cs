using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using SnmpSharpNet;

namespace ConsoleApp1
{
    public class Printer
    {
        public string Ip { get; set; }

        public Printer(string _ip)
        {
            Ip = _ip;
        }

        public string GetHersteller()
        {
            // SNMP community name
            OctetString community = new OctetString("public");
            // Define agent parameters class
            AgentParameters param = new AgentParameters(community);
            // Set SNMP version to 1 (or 2)
            param.Version = SnmpVersion.Ver1;
            // Construct the agent address object
            // IpAddress class is easy to use here because
            //  it will try to resolve constructor parameter if it doesn't
            //  parse to an IP address
            IpAddress agent = new IpAddress(Ip);

            // Construct target
            UdpTarget target = new UdpTarget((IPAddress)agent, 161, 250, 1);

            // Pdu class used for all requests
            Pdu pdu = new Pdu(PduType.Get);
            pdu.VbList.Add(".1.3.6.1.2.1.25.3.2.1.3.1"); //sysDescr

            // Make SNMP request
            try
            {
                SnmpV1Packet result = (SnmpV1Packet)target.Request(pdu, param);


                // If result is null then agent didn't reply or we couldn't parse the reply.
                if (result != null)
                {
                    // ErrorStatus other then 0 is an error returned by 
                    // the Agent - see SnmpConstants for error definitions
                    if (result.Pdu.ErrorStatus != 0)
                    {
                        // agent reported an error with the request
                        return "Error in SNMP reply.";
                    }
                    else
                    {
                        // Reply variables are returned in the same order as they were added
                        //  to the VbList
                        target.Close();
                        return result.Pdu.VbList[0].Value.ToString();
                    }
                }
                else
                {
                    target.Close();
                    return "No response received from SNMP agent.";
                }


            }
            catch { target.Close(); return "Fehler"; }
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            Printer Drucker1 = new Printer("172.16.0.102");
            Printer Drucker2 = new Printer("172.16.0.103");
            Printer Drucker3 = new Printer("172.16.0.116");


            Console.WriteLine("{0}", Drucker1.GetHersteller());
            Console.WriteLine("{0}", Drucker2.GetHersteller());
            Console.WriteLine("{0}", Drucker3.GetHersteller());


            Console.ReadLine();
        }
    }
}
