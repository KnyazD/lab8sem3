﻿using System;
using System.IO;
using System.IO.Compression;
using System.Xml;
using System.Xml.Serialization;
using Animal_;

namespace lab8_CS
{
    internal class task2
    {
       /* public static void Main(string[] args)
        {
            Cow cow = new Cow("Jordana", "USA", false);
            XmlSerializer serializer = new XmlSerializer(typeof(Animal));
            using (TextWriter writer = new StreamWriter("animal.xml"))
            {
                serializer.Serialize(writer, cow);
            }
            
            using (XmlReader reader = XmlReader.Create("animal.xml"))
            {
                Animal deserializedAnimal = (Animal)serializer.Deserialize(reader);
                Console.WriteLine("Deserialized Animal:");
                Console.WriteLine($"Name: {deserializedAnimal.Name}");
                Console.WriteLine($"Country: {deserializedAnimal.Country}");
                Console.WriteLine($"Classification: {deserializedAnimal.GetClassificationAnimal()}");
                Console.WriteLine($"Favorite Food: {deserializedAnimal.GetFavouriteFood()}");
                Console.WriteLine($"Hello: {deserializedAnimal.SayHello()}");
            }
        }*/
         public static void Main(string[] args)
        {
             Console.WriteLine("Введите путь к директории для поиска файла: ");
             string path = Console.ReadLine();
             
             Console.WriteLine("Введите имя файла для поиска: ");
             string fileName = Console.ReadLine();
             
             string filePath = SearchFileInDirectory(path, fileName);
        
             if (filePath != null)
             {
                 Console.WriteLine($"Файл найден: {filePath}");
                 Console.Write("Хотите ли вы его сжать (да/нет)? ");
                 string compressInput = Console.ReadLine();
        
                 if (compressInput.ToLower() == "да")
                 {
                     CompressFile(filePath);
                     Console.WriteLine("Файл успешно сжат.");
                 }
                 else
                 {
                     DisplayFileContents(filePath);
                 }
             }
             else
             {
                 Console.WriteLine($"Файл с именем '{fileName}' не найден в указанной директории и ее поддиректориях.");
             }
         }
        
         static string SearchFileInDirectory(string directoryPath, string fileName)
        {
             string[] files = Directory.GetFiles(directoryPath, fileName, SearchOption.AllDirectories);
             if (files.Length > 0)
             {
                 return files[0];
             }
             return null;
         }
        
         static void DisplayFileContents(string filePath)
         {
             using (FileStream fileStream = File.OpenRead(filePath))
             {
                 using (StreamReader reader = new StreamReader(fileStream))
                 {
                     string fileContents = reader.ReadToEnd();
                     Console.WriteLine("Содержимое файла:");
                     Console.WriteLine(fileContents);
                }
             }
         }
        
         static void CompressFile(string filePath)
         {
             string compressedFilePath = filePath + ".gz";
             using (FileStream originalFileStream = File.OpenRead(filePath))
             {
                 using (FileStream compressedFileStream = File.Create(compressedFilePath))
                 {
                     using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                     {
                         originalFileStream.CopyTo(compressionStream);
                     }
                 }
             }
         } 
    }
}