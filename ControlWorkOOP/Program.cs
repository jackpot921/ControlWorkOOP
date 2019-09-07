using CollectionsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorkOOP
{
    class Program
    {
        /*string text = @"Text: file.txt(6B); Some string content
Image: img.bmp(19MB); 1920х1080
Text:data.txt(12B); Another string
Text:data1.txt(7B); Yet another string
Movie:logan.2017.mkv(19GB); 1920х1080; 2h12m";*/

        static void Main(string[] args)
        {
            string text = @"Text: file.txt(6B); Some string content
Image: img.bmp(19MB); 1920x1080
Text:data.txt(12B); Another string
Text:data1.txt(7B); Yet another string
Movie:logan.2017.mkv(19GB); 1920x1080; 2h12m
VSFile:program.cs(12B); some program";
            
            MyList<Files> fileList = new MyList<Files>();
            string[] files = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < files.Length; i++)
            {
                string[] split = files[i].Split(':');
                string fileType = split[0].ToLower();
                switch (fileType)
                {
                    case "text":
                        TextFiles textFile = new TextFiles();
                        textFile.Parse(split[1]);
                        fileList.Add(textFile);
                        break;
                    case "image":
                        ImageFiles imageFile = new ImageFiles();
                        imageFile.Parse(split[1]);
                        fileList.Add(imageFile);
                        break;
                    case "movie":
                        MovieFiles movieFile = new MovieFiles();
                        movieFile.Parse(split[1]);
                        fileList.Add(movieFile);
                        break;
                    default:
                        OtherFiles otherFile = new OtherFiles();
                        otherFile.Parse(split[1]);
                        fileList.Add(otherFile);
                        break;
                }
            }
            for (int i = 0; i < fileList.Count; i++)
            {
                Console.WriteLine(fileList[i].ToString());
            }
            Console.ReadKey();
        }
    }
}
