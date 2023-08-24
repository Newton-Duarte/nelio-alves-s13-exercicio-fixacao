string sourcePath = "file.csv";
string targetPath = "summary.csv";
string targetFolder = "out";
string outPath = Path.Combine(targetFolder, targetPath);

try
{
  if (!Directory.Exists(targetFolder))
  {
    Directory.CreateDirectory(targetFolder);
  }
  else
  {
    File.Create(outPath).Close();
  }

  string[] lines = File.ReadAllLines(sourcePath);

  using (StreamWriter sw = File.AppendText(outPath))
  {
    foreach(string line in lines)
    {
      var splitLine = line.Split(",");
      string product = splitLine[0];
      double price = double.Parse(splitLine[1]);
      int quantity = int.Parse(splitLine[2]);
      double total = price * quantity;

      sw.WriteLine(@$"{product},{total:F2}");
    }
  }
}
catch (IOException e)
{
  Console.WriteLine(e.Message);
}