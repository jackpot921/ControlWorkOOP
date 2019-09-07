using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWorkOOP
{
    public abstract class Files
    {
        public string Name { get; internal set; }
        public string Extention { get; internal set; }
        public string Size { get; internal set; }

        public virtual void Parse(string input)
        {
            string[] splitInfo = input.Split(new char[] { '.', '(', ')', ';' }, StringSplitOptions.RemoveEmptyEntries);
            Name = splitInfo[0];
            Extention = splitInfo[1];
            Size = splitInfo[2];
        }
    }

    public class TextFiles : Files
    {
        public string Content { get; internal set; }

        public override void Parse(string input)
        {
            string[] splitInfo = input.Split(new char[] { '.', '(', ')', ';' }, StringSplitOptions.RemoveEmptyEntries);
            base.Parse(input);
            Content = splitInfo[3];
        }

        public override string ToString()
        {
            return "Text:" + "\n\r" + 
                "\t" + $"{Name}.{Extention}" + "\n\r" +
                "\t\t" + $"Extention: {Extention}" + "\n\r" +
                "\t\t" + $"Size: {Size}" + "\n\r" +
                "\t\t" + $"Content: {Content}";
        }
    }

    public class ImageFiles : Files
    {
        public string Resolution { get; internal set; }

        public override void Parse(string input)
        {
            string[] splitInfo = input.Split(new char[] { '.', '(', ')', ';' }, StringSplitOptions.RemoveEmptyEntries);
            base.Parse(input);
            Resolution = splitInfo[3];
        }

        public override string ToString()
        {
            return "Images:" + "\n\r" +
                "\t" + $"{Name}.{Extention}" + "\n\r" +
                "\t\t" + $"Extention: {Extention}" +  "\n\r" + 
                "\t\t" + $"Size: {Size}" + "\n\r" +
                "\t\t" + $"Resolution: {Resolution}";
        }
    }

    public class MovieFiles : ImageFiles
    {
        public string Length { get; internal set; }

        public override void Parse(string input)
        {
            string[] splitInfo = input.Split(new char[] { '.', '(', ')', ';' }, StringSplitOptions.RemoveEmptyEntries);
            base.Parse(input);
            Resolution = splitInfo[3];
            Length = splitInfo[4];
        }

        public override string ToString()
        {
            return "Movies:" + "\n\r" +
                "\t" + $"{Name}.{Extention}" + "\n\r" +
                "\t\t" + $"Extention: {Extention}" + "\n\r" +
                "\t\t" + $"Size: {Size}" + "\n\r" +
                "\t\t" + $"Resolution: {Resolution}" + "\n\r" +
                "\t\t" + $"Length: {Length}";
        }
    }
    public class OtherFiles : Files
    {
        public string Data { get; private set; }

        public override void Parse(string input)
        {
            string[] splitInfo = input.Split(new char[] { '.', '(', ')', ';' }, StringSplitOptions.RemoveEmptyEntries);
            base.Parse(input);
            Data = splitInfo[3];
        }
        public override string ToString()
        {
            return "Other:" + "\n\r" +
                "\t" + $"{Name}.{Extention}" + "\n\r" +
                "\t\t" + $"Extention: {Extention}" + "\n\r" +
                "\t\t" + $"Size: {Size}" + "\n\r" +
                "\t\t" + $"Data: {Data}";
        }
    }
}
