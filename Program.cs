using csharp_lista_indirizzi.classes;
using System.Net;

var path = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName).FullName).FullName).FullName;
StreamReader file = File.OpenText(@$"{path}\data\addresses.csv");

var addresses = new List<Address>();

while (!file.EndOfStream)
{
    string? line = file.ReadLine();
    var element = line.Split(',');

    if (element.Length == 6)
    {
        string name = element[0];
        string surname = element[1];
        string street = element[2];
        string city = element[3];
        string province = element[4];
        string zip = element[5];

        var address = new Address(CheckString(name), CheckString(surname), CheckString(street), CheckString(city), CheckString(province), CheckString(zip));
        addresses.Add(address);
    } 
    else
    {
        continue;
    }
}
file.Close();

for (int i = 1; i < addresses.Count; i++)
{
    Console.WriteLine(addresses[i].name);
    Console.WriteLine(addresses[i].surname);
    Console.WriteLine(addresses[i].street);
    Console.WriteLine(addresses[i].city);
    Console.WriteLine(addresses[i].province);
    Console.WriteLine(addresses[i].zip);
    Console.WriteLine();
}

var outputFilePath = @$"{path}\data\listaindirizzi.txt";

if (!File.Exists(outputFilePath))
{
    StreamWriter outputFile = File.CreateText(outputFilePath);
    for (int i = 1; i < addresses.Count; i++)
    {
        outputFile.WriteLine(addresses[i].name);
        outputFile.WriteLine(addresses[i].surname);
        outputFile.WriteLine(addresses[i].street);
        outputFile.WriteLine(addresses[i].city);
        outputFile.WriteLine(addresses[i].province);
        outputFile.WriteLine(addresses[i].zip);
        outputFile.WriteLine();
    }
    outputFile.Close();
}

string CheckString(string str)
{
    if (str == "")
    {
        return "NULL";
    }

    else if (str.Substring(0, 1) == " ")
    {
        return str.Substring(1, str.Length - 1);
    }

    else return str;
}