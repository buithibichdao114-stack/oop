using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; 
        string fullName = "Bùi Thị Bích Đào";
        string studentId = "10125062";
        string className = "12425TN";
        string githubUsername = "buithibichdao114-stackoop";
        string email = "buithibichdao@gmail.com";

        // In ra màn hình, phân cách giữa các thông tin bằng đúng 1 dấu tab (\t)
        Console.WriteLine($"{fullName}\t{studentId}\t{className}\t{githubUsername}\t{email}");
    }
}