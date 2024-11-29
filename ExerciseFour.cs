using System;

class Program
{
    public const MsgLargeRect = "Introdueix l'amplada del rectangle:";
    public const MsgAltRect = "Introdueix l'altura del rectangle:";
    public const MsgAreaResult = "L'àrea del rectangle és: ";
    public const MsgRadiCirc = "Introdueix el radi del cercle:";
    public const MsgCircunResult = "La circumferència del cercle és: ";
    public const MsgResultBig = "L'àrea és més gran de 50";
    public const MsgResultMiddle = "L'àrea és entre 20 i 50";
    public const MsgResultSmall = "L'àrea és menor o igual a 20";

    static void Main(string[] args)
    {
        // Sol·licita l'entrada de l'usuari per calcular l'àrea d'un rectangle
        Console.WriteLine(MsglargeRect);
        double width = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine(MsgAltRect);
        double height = Convert.ToDouble(Console.ReadLine());

        // Calcula l'àrea
        double area = width * height;
        Console.WriteLine(MsgAreaResult + area);

        // Sol·licita l'entrada de l'usuari per calcular la circumferència d'un cercle
        Console.WriteLine(MsgRadiCirc);
        double radius = Convert.ToDouble(Console.ReadLine());
        double circumference = 2 * Math.PI * radius;

        Console.WriteLine(MsgCircunResult + circumference);

        // Imprimeix un missatge basat en el valor de l'àrea
        if (area > 50)
        {
            Console.WriteLine(MsgResultBig);
        }
        else if (area > 20)
        {
            Console.WriteLine(MsgResultMiddle);
        }
        else
        {
            Console.WriteLine(MsgResultSmall);
        }
    }
}