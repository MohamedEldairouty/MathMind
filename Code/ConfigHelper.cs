using System;
using System.IO;

public static class ConfigHelper
{
   public static string GetConnectionString()
   {
      string configFilePath = "config.txt";
      if (File.Exists(configFilePath))
      {
         return File.ReadAllText(configFilePath).Trim();
      }
      else
      {
         throw new FileNotFoundException("Configuration file 'config.txt' not found.");
      }
   }
}