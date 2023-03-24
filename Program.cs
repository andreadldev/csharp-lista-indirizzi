var path = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).FullName).FullName).FullName).FullName;
StreamReader file = File.OpenText(@$"{path}\data\addresses.csv");

while (!file.EndOfStream)
{
    string line = file.ReadLine();
    Console.WriteLine(line);
}

file.Close();