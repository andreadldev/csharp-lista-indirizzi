using csharp_lista_indirizzi.classes;

var path = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName).FullName).FullName).FullName;
StreamReader file = File.OpenText(@$"{path}\data\addresses.csv");

var addresses = new List<string>();
//var addresses = new List<Address>();

while (!file.EndOfStream)
{
    string line = file.ReadLine();
    //Console.WriteLine(line);
    addresses.Add(line);
}
file.Close();

for (int i = 1; i < addresses.Count; i++)
{
    if (i > 1)
    {
        Console.WriteLine();
    }
    string address = addresses[i];
    string[] arr = address.Split(",");

    for (int x = 0; x < arr.Length; x++)
    {
        Console.Write("\"" + arr[x]);
        if (x != arr.Length - 1)
        {
            Console.Write("\", ");
        }
        else Console.Write("\"");
    }
}