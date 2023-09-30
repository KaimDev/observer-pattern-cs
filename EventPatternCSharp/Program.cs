namespace EventPatternCSharp;

using static System.Console;

public class Program
{
    public static void Main(string[] args)
    {
        Person Person1 = new Person();

        Person1.PropertyChanged += Person1_PersonPropertyChanged;

        for (;;)
        {
            WriteLine("Modificar la propiedad: \n1.Name \n2.LastName \n3.Ver Valores: ");
            string StringOption = ReadLine();
            int OptionToInt;

            if (string.IsNullOrEmpty(StringOption))
            {
                break;
            }

            if (int.TryParse(StringOption, null, out OptionToInt) && OptionToInt == 1 || OptionToInt == 2 || OptionToInt == 3)
            {
                if (OptionToInt == 1) 
                {
                    WriteLine("Escriba algo: ");
                    Person1.Name = ReadLine();
                    
                    if (String.IsNullOrEmpty(Person1.Name))
                    {
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine("Error: No se permiten campos vacios\n");
                        ForegroundColor = ConsoleColor.White;
                    }
                }

                if (OptionToInt == 2)
                {
                    WriteLine("Escriba algo: ");
                    Person1.LastName = ReadLine();

                    if (String.IsNullOrEmpty(Person1.LastName))
                    {
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine("Error: No se permiten campos vacios\n");
                        ForegroundColor = ConsoleColor.White;
                    }
                }

                if (OptionToInt == 3)
                {
                    string? NameValue = Person1.Name;
                    string? LastNameValue = Person1.LastName;

                    if (!String.IsNullOrEmpty(NameValue) || !String.IsNullOrEmpty(LastNameValue))
                    {
                        ForegroundColor = ConsoleColor.Blue;
                        WriteLine($"Name: {NameValue} \nLastName: {LastNameValue}");
                        ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine("Error: No hay valores todavia\n");
                        ForegroundColor = ConsoleColor.White;
                    }
                }
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Error: Escriba un numero valido\n");
                ForegroundColor = ConsoleColor.White;
            }
        }
    }

    private static void Person1_PersonPropertyChanged(object Sender, PersonPropertyChangedEventArgs EventInfo)
    {
        if (EventInfo.EventCode == EventCodes.ChangeNameSuccessful)
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine($"El valor de la propiedad {EventInfo.PropertyName} fue cambiado\n");
            ForegroundColor = ConsoleColor.White;
        }

        if (EventInfo.EventCode == EventCodes.ChangeNameFailed)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine($"Error al intentar cambiar el valor de la propiedad {EventInfo.PropertyName}\n");
            ForegroundColor = ConsoleColor.White;
        }

        if (EventInfo.EventCode == EventCodes.ChangeNameCanceled)
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"El valor de la propiedad {EventInfo.PropertyName} es el mismo\n");
            ForegroundColor = ConsoleColor.White;
        }

        if (EventInfo.EventCode == EventCodes.ChangeLastNameSuccessful)
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine($"El valor de la propiedad {EventInfo.PropertyName} fue cambiado\n");
            ForegroundColor = ConsoleColor.White;
        }

        if (EventInfo.EventCode == EventCodes.ChangeLastNameFailed)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine($"Error al intentar cambiar el valor de la propiedad {EventInfo.PropertyName}\n");
            ForegroundColor = ConsoleColor.White;
        }

        if (EventInfo.EventCode == EventCodes.ChangeLastNameCanceled)
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"El valor de la propiedad {EventInfo.PropertyName} es el mismo\n");
            ForegroundColor = ConsoleColor.White;
        }
    }
}

