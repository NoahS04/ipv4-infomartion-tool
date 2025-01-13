/*ipv4 ip1 = new ipv4(28, 168, 1, 255, 24);
Console.ForegroundColor = ConsoleColor.Gray;
Console.WriteLine(ip1.networkclass);
Console.WriteLine(ip1.sub.subnetmask);
Console.WriteLine(ip1.submask.hostbits);
Console.WriteLine(ip1.submask.netbits);
Console.WriteLine(ip1.submask.hostcount);
Console.WriteLine(ip1.sub.binary);
Console.WriteLine(ip1.sub.broadcastadress);
Console.WriteLine(ip1.sub.miniipadress);
Console.WriteLine(ip1.sub.maxipadress);*/


int runmain = 1;
while (runmain == 1)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("===========[ IPv4 Info-Konverter ]===========");
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.WriteLine("Bitte gib eine IPv4-Adresse im Format x.x.x.x/x ein:");

    string input = Console.ReadLine();

    string[] ip2 = input.Split('/');
    string ip4 = ip2[0];
    int s1 = Int32.Parse(ip2[1]);

    string[] ip3 = ip4.Split('.');
    int b1 = Int32.Parse(ip3[0]);
    int b2 = Int32.Parse(ip3[1]);
    int b3 = Int32.Parse(ip3[2]);
    int b4 = Int32.Parse(ip3[3]);
    if (b1 < 0 || b1 > 255 || b2 < 0 || b2 > 255 || b3 < 0 || b3 > 255 || b4 < 0 || b4 > 255 || s1 < 0 || s1 > 32)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("IPv4-Adresse ist im falschen Format!");
        Console.ForegroundColor = ConsoleColor.Green;

        Console.WriteLine("=============================================");
        Console.ForegroundColor = ConsoleColor.Gray;
        return;
    }
    else
    {
        ipv4 ipinput = new ipv4(b1, b2, b3, b4, s1);
        Console.ForegroundColor = ConsoleColor.Gray;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("| Netzwerkklasse: ");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write(ipinput.networkclass);

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("| IP-Typ: ");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write(ipinput.iptype);

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("| Hostbits: ");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write(ipinput.submask.hostbits);

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("| Netzbits: ");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write(ipinput.submask.netbits);

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("| Subnetzmaske: ");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write(ipinput.sub.subnetmask);

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("| Hostanzahl: ");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write(ipinput.submask.hostcount);

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("| Binär: ");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write(ipinput.sub.binary);

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("| Broadcast-Adresse: ");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write(ipinput.sub.broadcastadress);

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("| IP Range: ");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write(ipinput.sub.miniipadress);
        Console.Write(" - ");
        Console.Write(ipinput.sub.maxipadress);
    }
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine();
    Console.WriteLine("=============================================");
    Console.ForegroundColor = ConsoleColor.Gray;
}
class ipv4
{
    private int _byte1;
    private int _byte2;
    private int _byte3;
    private int _byte4;
    private string _iptype;
    private string _networkclass;
    public subnet sub;
    public subnetmask submask;

    public int byte1
    {
        get { return _byte1; }
        set { _byte1 = value; }
    }

    public int byte2
    {
        get { return _byte2; }
        set { _byte2 = value; }
    }

    public int byte3
    {
        get { return _byte3; }
        set { _byte3 = value; }
    }

    public int byte4
    {
        get { return _byte4; }
        set { _byte4 = value; }
    }

    public string iptype
    {
        get
        {
            iptypecheck();
            return _iptype;
        }
        set { _iptype = value; }
    }

    public string networkclass
    {
        get
        {
            networkclasscheck();
            return _networkclass;
        }
        set { _networkclass = value; }
    }

    public ipv4(int b1, int b2, int b3, int b4, int s1)
    {
        byte1 = b1;
        byte2 = b2;
        byte3 = b3;
        byte4 = b4;
        sub = new subnet(s1, b1, b2, b3, b4);
        submask = new subnetmask(s1);
    }

    public void iptypecheck()
    {
        if (byte1 == 10)
        {
            _iptype = "Private";
        }
        else if (byte1 == 172 && byte2 >= 16 && byte2 <= 31)
        {
            _iptype = "Private";
        }
        else if (byte1 == 192 && byte2 == 168)
        {
            _iptype = "Private";
        }
        else
        {
            _iptype = "Public";
        }
    }

    public void networkclasscheck()
    {
        if (byte1 >= 0 && byte1 <= 127)
        {
            _networkclass = "A";
        }
        else if (byte1 >= 128 && byte1 <= 191)
        {
            _networkclass = "B";
        }
        else if (byte1 >= 192 && byte1 <= 223)
        {
            _networkclass = "C";
        }
        else if (byte1 >= 224 && byte1 <= 239)
        {
            _networkclass = "D";
        }
        else if (byte1 >= 240 && byte1 <= 255)
        {
            _networkclass = "E";
        }
    }
}

class subnet
{
    private int _b1;
    private int _b2;
    private int _b3;
    private int _b4;
    private int _networkbytes;
    private string _subnetmask;
    private string _binary;
    private int[] bits;
    private string _broadcastadress;
    private string _minipadress;
    private string _maxipadress;

    public int networkbytes
    {
        get { return _networkbytes; }
        set { _networkbytes = value; }
    }

    public string binary
    {
        get
        {
            getbits();
            return _binary;
        }
    }

    public subnet(int s1, int b1, int b2, int b3, int b4)
    {
        networkbytes = s1;
        _b1 = b1;
        _b2 = b2;
        _b3 = b3;
        _b4 = b4;
    }

    public string subnetmask
    {
        get
        {
            getsubnetmask();
            return _subnetmask;
        }
    }

    public string broadcastadress
    {
        get
        {
            getbroadcast();
            return _broadcastadress;
        }
    }

    public string miniipadress
    {
        get
        {
            getminip();
            return _minipadress;
        }
    }

    public string maxipadress
    {
        get
        {
            getmaxip();
            return _maxipadress;
        }
    }
    public void getsubnetmask()
    {
        int temmpnetworkbytes = networkbytes;
        string subnetmask = "";
        for (int i = 0; i <= 3; i++)
        {
            int tempsubnetmask = 0;
            for (int a = 7; a >= 0; a--)
            {
                if (temmpnetworkbytes > 0)
                {
                    tempsubnetmask = tempsubnetmask + (int)Math.Pow(2, a);
                    //Console.Write(tempsubnetmask);
                    temmpnetworkbytes--;
                }
                else
                {
                    tempsubnetmask = tempsubnetmask + 0;
                }
            }
            if (i < 3)
            {
                subnetmask = subnetmask + tempsubnetmask + ".";
            }
            else
            {
                subnetmask = subnetmask + tempsubnetmask;
            }
            //Console.WriteLine(subnetmask);
            _subnetmask = subnetmask;
        }
    }
    public int[] getbits()
    {
        bits = new int[32];
        for (int i = 0; i <= 31; i++)
        {
            if (i >= 0 && i <= 7)
            {
                int valuebyte = 128;
                int b1_2 = _b1;
                for (int a = 0; a <= 7; a++)
                {
                    if (b1_2 >= valuebyte)
                    {
                        bits[i + a] = 1;
                        b1_2 = b1_2 - valuebyte;
                    }
                    else
                    {
                        bits[i + a] = 0;
                    }
                    valuebyte = valuebyte / 2;
                }
                i += 7;
            }
            else if (i >= 8 && i <= 15)
            {
                int valuebyte = 128;
                int b2_2 = _b2;
                for (int a = 0; a <= 7; a++)
                {
                    if (b2_2 >= valuebyte)
                    {
                        bits[i + a] = 1;
                        b2_2 = b2_2 - valuebyte;
                    }
                    else
                    {
                        bits[i + a] = 0;
                    }
                    valuebyte = valuebyte / 2;
                }
                i = i + 7;
            }
            else if (i >= 16 && i <= 23)
            {
                int valuebyte = 128;
                int b3_2 = _b3;
                for (int a = 0; a <= 7; a++)
                {
                    if (b3_2 >= valuebyte)
                    {
                        bits[i + a] = 1;
                        b3_2 = b3_2 - valuebyte;
                    }
                    else
                    {
                        bits[i + a] = 0;
                    }
                    valuebyte = valuebyte / 2;
                }
                i = i + 7;
            }
            else if (i >= 24 && i <= 31)
            {
                int valuebyte = 128;
                int b4_2 = _b4;
                for (int a = 0; a <= 7; a++)
                {
                    if (b4_2 >= valuebyte)
                    {
                        bits[i + a] = 1;
                        b4_2 = b4_2 - valuebyte;
                    }
                    else
                    {
                        bits[i + a] = 0;
                    }
                    valuebyte = valuebyte / 2;
                }
                i = i + 7;
            }
        }

        for (int i = 0; i < 31; i++)
        {
            _binary = _binary + bits[i].ToString();
        }

        return bits;
    }

    public void getbroadcast()
    {
        int[] broadcast = bits;
        string broadcastadress = "";
        int temmpnetworkbytes = _networkbytes;
        for (int i = 0; i <= 3; i++)
        {
            int tempbc = 0;
            for (int a = 0; a <= 7; a++)
            {
                int bitcount = i * 8 + a;
                if (temmpnetworkbytes > 0)
                {
                    if (broadcast[bitcount] == 0)
                    {
                        tempbc = tempbc + 0;
                    }
                    else
                    {
                        tempbc = tempbc + (int)Math.Pow(2, 7 - a);
                    }
                    //Console.Write(tempsubnetmask);
                    temmpnetworkbytes--;
                }
                else
                {
                    tempbc = tempbc + (int)Math.Pow(2, 7 - a);
                }
            }
            if (i < 3)
            {
                broadcastadress = broadcastadress + tempbc.ToString() + ".";
            }
            else
            {
                broadcastadress = broadcastadress + tempbc;
            }
            //Console.WriteLine(subnetmask);
            _broadcastadress = broadcastadress;
        }

    }

    public void getminip()
    {
        int[] minip = bits;
        string minipadress = "";
        int temmpnetworkbytes = _networkbytes;
        for (int i = 0; i <= 3; i++)
        {
            int tempmin = 0;
            for (int a = 0; a <= 7; a++)
            {
                int bitcount = i * 8 + a;
                if (temmpnetworkbytes > 0)
                {
                    if (minip[bitcount] == 0)
                    {
                        tempmin = tempmin + 0;
                    }
                    else
                    {
                        tempmin = tempmin + (int)Math.Pow(2, 7 - a);
                    }
                    //Console.Write(tempsubnetmask);
                    temmpnetworkbytes--;
                }
                else
                {
                    tempmin = tempmin + 0;
                }
            }
            if (i < 3)
            {
                minipadress = minipadress + tempmin.ToString() + ".";
            }
            else
            {
                tempmin = tempmin + 1;
                minipadress = minipadress + tempmin;
            }
            //Console.WriteLine(subnetmask);
            _minipadress = minipadress;
        }

    }
    public void getmaxip()
    {
        int[] maxip = bits;
        string maxipadress = "";
        int temmpnetworkbytes = _networkbytes;
        for (int i = 0; i <= 3; i++)
        {
            int tempmax = 0;
            for (int a = 0; a <= 7; a++)
            {
                int bitcount = i * 8 + a;
                if (temmpnetworkbytes > 0)
                {
                    if (maxip[bitcount] == 0)
                    {
                        tempmax = tempmax + 0;
                    }
                    else
                    {
                        tempmax = tempmax + (int)Math.Pow(2, 7 - a);
                    }
                    //Console.Write(tempsubnetmask);
                    temmpnetworkbytes--;
                }
                else
                {
                    tempmax = tempmax + (int)Math.Pow(2, 7 - a);
                }
            }
            if (i < 3)
            {
                maxipadress = maxipadress + tempmax.ToString() + ".";
            }
            else
            {
                tempmax = tempmax - 1;
                maxipadress = maxipadress + tempmax;
            }
            //Console.WriteLine(subnetmask);
            _maxipadress = maxipadress;
        }

    }
}

class subnetmask
{
    private int _hostbits;
    private int _netbits;
    private int _hostcount;

    public subnetmask(int s1)
    {
        _hostbits = 32 - s1;
        _netbits = s1;
    }

    public int hostbits
    {
        get { return _hostbits; }
        set { _hostbits = value; }
    }

    public int netbits
    {
        get { return _netbits; }
        set { _netbits = value; }
    }

    public int hostcount
    {
        get
        {
            hostcounter();
            return _hostcount;
        }
    }

    public void hostcounter()
    {
        _hostcount = (int)Math.Pow(2, _hostbits) - 2;
    }
}
