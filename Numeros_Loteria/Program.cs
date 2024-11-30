using System;
using System.Runtime.CompilerServices;

class Programa_Principal
{

    public static void Main(string[] args)
    {
        // Secuencia de instrucciones del programa principal
        bool validado = false;
        string numeroquegana = "";
        while (!validado)
        {
            
            Console.WriteLine("Introduce el número ganador");
            numeroquegana = Console.ReadLine();
            if (Numeros_Loteria.validarNumero(numeroquegana))
                validado = true;
            else
            {
                Console.WriteLine("Número introducido no válido");
                validado = false;
            }
        }
        Console.WriteLine("introduce la serie ganadora");
        string seriequegana = Console.ReadLine();

        // En este punto en pantalla se ven los números a comprobar. A continuación los limpio de la pantalla.

        Console.Clear();

        // Una vez introducidos los números ganadores, a continuación comienza la parte de comprobación de los que tienes.

        Numeros_Loteria NumeroSerieGanador = new Numeros_Loteria(numeroquegana, seriequegana);
        string opcion = "";
        
        while (opcion != "0")
        {
            Console.WriteLine("INTRODUCE 1 PARA COMPROBRAR EL NUMERO QUE TIENES. CUALQUIER OTRO NÚMERO PARA SALIR");
            opcion = Console.ReadLine();
            switch (opcion)
            {
                
                case "1":
                    validado = false;
                    string NumeroQueTengo = "";
                    while (!validado)
                    {
                        Console.WriteLine("Introduce el número que tienes");
                        NumeroQueTengo = Console.ReadLine();
                        if (Numeros_Loteria.validarNumero(NumeroQueTengo))
                            validado = true;
                        else
                        {
                            Console.WriteLine("Número introducido no valido");
                            validado = false;
                        }
                    }
                    Console.WriteLine("Introduce la serie que tienes");
                    string SerieQueTengo = Console.ReadLine();
                    bool k = NumeroSerieGanador.comprobarCoincidenciaNumero(NumeroQueTengo);
                    bool h = NumeroSerieGanador.comprobarCoincidenciaNumeroSerie(NumeroQueTengo, SerieQueTengo);
                    bool w = NumeroSerieGanador.comprobarCoincidenciaTresUltimasCifras(NumeroQueTengo);
                    if (k)
                    { 
                        Console.WriteLine("Los números coinciden");
                        
                        if (h)
                            Console.WriteLine("La serie coincide");
                    
                    }
                    else
                    {
                        
                        if (w)
                            Console.WriteLine("Coinciden las tres últimas cifras");
                        else
                            Console.WriteLine("Las tres últimas cifras no coinciden");
                    }
                    break;

                default:
                    Console.WriteLine("HA ELEGIDO SALIR DEL PROGRAMA. MUCHAS GRACIAS Y ADIOS");
                    break;

            }
        }
    }

}

class Numeros_Loteria
{
    // Propiedades
    private string numero = "";
    private string serie = "";

    // metodos setter y getter

    public void setNumero (string numero)
    { this.numero = numero; }

    public string getNumero () 
    { return this.numero; }

    public string getSerie () 
    
    { return serie;}

    public void setSerie (string serie)
    { this.serie = serie; } 

    // metodo construcctor de los objetos resultantes de esta serie

    public Numeros_Loteria(string numero, string serie)
    { 
        this.serie = serie;
        this.numero = numero;
       
    }
     
    // metodos operativos de los objetos resultantes de esta clase
    
    public bool comprobarCoincidenciaNumeroSerie (string numero, string serie)
    {
        if ((this.numero == numero) && (this.serie==serie))
            return true;
        else
            return false;
    }

    public bool comprobarCoincidenciaNumero(string numero)
    {
        if (this.numero == numero)
            return true;
        else
            return false;

    }

    public bool comprobarCoincidenciaTresUltimasCifras (string numero)
    {
        bool igual = true;
        int i = numero.Length - 1;
        while ((i >= 2) && (igual))
        {
            if (numero[i] == this.numero[i])
                igual= true;
            else 
                igual = false;
            i--;
        }
        return igual;
    }

    // Método estático para ver si, tanto el numero ganador como el introducido a comprobar, cumple los requisitos de un número de 5 digitos

    public static bool validarNumero (string numero)
    {
        if (numero.Length != 5)
            return false;
        else
        {
            try
            {
                int numeroEntero = int.Parse(numero);
                if ((numeroEntero > 0) && (numeroEntero < 100000))
                    return true;
                else
                    return false;

            }
            catch (Exception e)
            {
                return false;
            }
        }
    }

}