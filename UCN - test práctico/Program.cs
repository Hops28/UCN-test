using System;

namespace UCN___test_práctico
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false, good;
            int seleccion;

            do
            {
                Console.WriteLine("Elija una de las siguientes opciones:");
                Console.WriteLine("1) Cocientes de elementos positivos, negativos y ceros.");
                Console.WriteLine("2) Mínimo y máximo de la suma de 4 de 5 valores.");
                Console.WriteLine("3) Convertidor formato de hora 12 horas a 24 horas.");
                Console.WriteLine("4) Terminar proceso (Salir)");
                
                do
                {
                    Console.Write("--> ");
                    good = int.TryParse(Console.ReadLine(), out seleccion);

                    if (!good)
                        Console.WriteLine("-- Tiene que ingresar un número --");
                    else if (seleccion <= 0)
                    {
                        good = false;
                        Console.WriteLine("-- Tiene que ser un número positivo --");
                    }
                    else if (seleccion > 4)
                    {
                        good = false;
                        Console.WriteLine("-- Tiene que ser un número entre 1 y 4 --");
                    }
                } while (!good);

                switch (seleccion)
                {
                    case 1:
                        Ejercicio1();
                        break;
                    case 2:
                        Ejercicio2();
                        break;
                    case 3:
                        Ejercicio3();
                        break;
                    case 4:
                        exit = true;
                        break;
                }
            } while (!exit);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void Ejercicio1 ()
        {
            // Dada una matriz de enteros, calcular los cocientes de sus elementos que son positivos, negativos
            // y cero. Imprime el valor decimal de cada fracción en una nueva línea.

            // En este ejercicio el arreglo será para 15 enteros, sean positivos, negativos o cero

            Console.WriteLine("Escriba el tamaño del arreglo (5 - 20)");
            int size;
            bool band;

            // Pidiendo al usuario el tamaño del arreglo
            do
            {
                band = int.TryParse(Console.ReadLine(), out size);

                if (!band)
                    Console.WriteLine("-- Tiene que ingresar un número --");
                else if (size <= 0)
                {
                    band = false;
                    Console.WriteLine("-- Tiene que ser un número positivo --");
                }
                else if (size < 5 || size > 20)
                {
                    band = false;
                    Console.WriteLine("-- Tiene que ser un número entre 5 y 20 --");
                }
            } while (!band);

            Console.WriteLine($"\nIngrese {size} números para el arreglo");

            plusMinus(LlenarArreglo(size));
        }

        public static int [] LlenarArreglo (int size)
        {
            int [] arreglo = new int[size];

            // variable booleana para validar los valores
            bool isnumber;

            // variable entera donde se almacenará el valor numérico
            int valor;

            for (int i = 0; i < size; i++)
            {
                do
                {
                    // Se comienzan a pedir los valores
                    Console.Write($"Ingrese el número ({i + 1}): ");
                    isnumber = int.TryParse(Console.ReadLine(), out valor);

                    if (!isnumber)
                        Console.WriteLine("-- Tiene que ingresar un número --");
                } while (!isnumber);

                // Una vez ingresado correctamente los valores se asigna 
                // a una de las posiciones del arreglo
                arreglo[i] = valor;
            }

            return arreglo;
        }

        public static void plusMinus(int [] arreglo)
        {
            // Con las siguientes variables se almacenará
            // La cantidad de valores positivos, negativos, y ceros
            // también la cantidad de valores en el arreglo
            int positivos = 0, negativos = 0, ceros = 0, cantidad;

            cantidad = arreglo.Length;

            for (int i = 0; i < cantidad; i++)
            {
                if (arreglo[i] > 0)
                    positivos++;
                else if (arreglo[i] < 0)
                    negativos++;
                else
                    ceros++;
            }

            // Se imprimen los resultados
            Console.WriteLine($"\nCantidad : {cantidad}\nPositivos : {positivos}\nNegativos : {negativos}\nCeros : {ceros}\n");

            Console.WriteLine("Los cocientes son:");
            Console.WriteLine("Positivos / Cantidad : {0:N6}", (double)positivos / (double)cantidad);
            Console.WriteLine("Negativos / Cantidad : {0:N6}", (double)negativos / (double)cantidad);
            Console.WriteLine("Ceros / Cantidad : {0:N6}", (double)ceros / (double)cantidad);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void Ejercicio2()
        {
            // Dados cinco enteros positivos, encuentre los valores mínimo y máximo que se pueden calcular
            // sumando exactamente cuatro de los cinco enteros.A continuación, imprima los respectivos
            // valores mínimo y máximo en una sola línea de dos enteros largos separados por espacios.

            Console.WriteLine("Ingrese los valores para el arreglo");

            miniMaxSum(LlenarArreglo(5));
        }

        public static void miniMaxSum(int [] arreglo)
        {
            // Se almacenarán los resultados en un arreglo
            // Y luego se determinará cuál es el menor y cuál es el mayor
            int[] resultados = new int[5];

            // Se guardará la sumatoria de todos los casos
            int suma;

            Console.WriteLine();

            // Se efectuan las operaciones
            for (int i = 0; i < 5; i++)
            {
                // Se inicializa en 0 cuando empieza cada caso
                suma = 0;

                // Se recorre el arreglo evaluando que se sumen todos menos uno diferente en cada caso
                for (int j = 0; j < 5; j++)
                {
                    // Se realiza la evaluación
                    if (i != j)
                    {
                        Console.Write($"{arreglo[j]} ");
                        suma += arreglo[j];
                    }

                    if (j < 4 && i != j)
                        Console.Write("+ ");
                }
                Console.WriteLine($"= {suma}");

                // Se guarda la sumatoria en cada posicion de este arreglo
                resultados[i] = suma;
            }

            // Se identifica cuál es el mayor y el menor
            int mayor, menor;
            mayor = menor = resultados[0];

            for (int i = 0; i < 5; i++)
            {
                // Si el valor del arreglo es mayor al valor mayor actual
                // entonces se le asigna el nuevo valor a la variable 'mayor'
                if (resultados[i] > mayor)
                {
                    mayor = resultados[i];
                }

                // Si el valor del arreglo es menor al valor menor actual
                // entonces se le asigna el nuevo valor a la variable 'menor'
                if (resultados[i] < menor)
                {
                    menor = resultados[i];
                }
            }

            Console.WriteLine($"\nLa suma mínima es: {menor}");
            Console.WriteLine($"La suma máxima es: {mayor}");
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void Ejercicio3()
        {
            // Dada una hora en formato de 12 horas AM/PM, conviértala en hora militar (24 horas)

            int hora, minuto, segundo, AMPM;
            bool bh, bm, bs, b;

            // Se piden los datos para la hora
            do
            {
                b = true;
                
                Console.Write("Ingrese la hora : ");
                bh = int.TryParse(Console.ReadLine(), out hora);

                Console.Write("Ingrese los minutos : ");
                bm = int.TryParse(Console.ReadLine(), out minuto);

                Console.Write("Ingrese los segundos : ");
                bs = int.TryParse(Console.ReadLine(), out segundo);

                bool band = true;

                do
                {
                    Console.WriteLine("\nElija el periodo del día:\n1) AM\n2) PM");
                    Console.Write("--> ");
                    
                    band = int.TryParse(Console.ReadLine(), out AMPM);
                } while (!band || AMPM < 1 || AMPM > 2);

                // Se verifica si todo está ingresado correctamente
                if (!bh || !bm || !bs)
                {
                    b = false;
                    Console.WriteLine("-- Tiene que ingresar números en todos los campos --");
                }
                else if (hora <= 0 || minuto <= 0 || segundo <= 0)
                {
                    b = false;
                    Console.WriteLine("-- Tiene que ser un número positivo --");
                }
                else if (hora > 12 || minuto > 60 || segundo > 60)
                {
                    b = false;
                    Console.WriteLine("-- Tienen que ser números válidos para hora : minutos : segundos --");
                }
            } while (!b);

            // Cadena donde se guardará lo que ingresamos para la hora
            string hora12 = "";

            if (hora < 10)
                hora12 += "0" + Convert.ToString(hora) + ":";
            else
                hora12 += Convert.ToString(hora) + ":";

            if (minuto < 10)
                hora12 += "0" + Convert.ToString(minuto) + ":";
            else
                hora12 += Convert.ToString(minuto) + ":";

            if (segundo < 10)
                hora12 += "0" + Convert.ToString(segundo) + Convert.ToString(AMPM == 1 ? "AM" : "PM");
            else
                hora12 += Convert.ToString(segundo) + Convert.ToString(AMPM == 1 ? "AM" : "PM");

            // Console.WriteLine(hora12);

            Console.WriteLine($"\nHora en formato de 12 horas --> {hora12}\nHora en formato de 24 horas --> {timeConversion(hora12)}\n");
        }

        public static string timeConversion(string str)
        {
            string periodo = str.Substring(8, 2);
            string hora = str.Substring(0, 2);
            string minuto = str.Substring(3, 2);
            string segundo = str.Substring(6, 2);

            if (periodo.Equals("AM"))
            {
                if (hora.Equals("12"))
                    hora = "00";
            }
            else
            {
                if (!hora.Equals("12"))
                    hora = Convert.ToString(int.Parse(hora) + 12);
            }

            string hora24 = hora + ":" + minuto + ":" + segundo;

            return hora24;
        }
    }
}
