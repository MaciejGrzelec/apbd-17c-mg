internal class Program
{
    private static void Main(string[] args)
    {
        int int1 = 1;
        int int2;

        string str1 = "1";
        string str2 = "true";
        
        bool bool1 = Convert.ToBoolean(str2);

        int1 = Convert.ToInt32(str1);
        int2 = int.Parse(str1);

        var var1 = int2;

        var student1 = new Student();

        Console.WriteLine(student1.id); 
        
        int[] numbers = new int[3];
        Console.WriteLine(numbers[0]);
        //placeholdery
        string name = string.Format("{0} {1}", str1, str2);
        Console.WriteLine(name);

        string list = string.Join(", ", numbers);
        Console.WriteLine(list);
        string str1CSharp;
        String strDotNet;


        try
        {

        } catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }


    }
}

public class Student
{
    public int id = 1;
}