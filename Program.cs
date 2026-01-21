using System;

namespace CajeroAutomatico
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float saldo = 3000; //saldo inicial
            int nipCorrecto = 1234; // nip 
            string historialMovimientos = ""; // guarada todos los movimientos
            historialMovimientos += "- Saldo Inicial: $3000\n"; // guarda saldo inicial

            int opcion; // guarda opcion del menu principal

            // ciclo principal 
            do
            {
                Console.Clear();
                Console.WriteLine("<<<<< CAJERO AUTOMATICO >>>>>");
                Console.WriteLine($"Saldo Actual: ${saldo}");
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                Console.WriteLine("1. Ingreso de efectivo");
                Console.WriteLine("2. Retiro de efectivo");
                Console.WriteLine("3. Consulta de saldo");
                Console.WriteLine("4. Movimientos");
                Console.WriteLine("5. Salir");
                Console.WriteLine("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                
                Console.Write("Seleccione una opcion: ");
                
                opcion = int.Parse(Console.ReadLine());
                
                if (opcion == 5)
                {
                    break;
                }

                // para validar opcion del menu principal
                if (opcion < 1 || opcion > 5)
                {
                    Console.WriteLine("\nError, opcion no valida, presione una tecla para continuar");
                    Console.ReadLine();
                    continue;
                }

                // se solicita nip 
                Console.Write("\nIngrese el NIP para confirmar movimiento: ");
                int nipIngresado = int.Parse(Console.ReadLine());

                if (nipIngresado != nipCorrecto)
                {
                    Console.WriteLine("Error, NIP incorrecto, operacion cancelada");
                    Console.ReadLine();
                    continue; // regreso al menu
                }

                // menu principal del cajero
                switch (opcion)
                {
                    case 1: // ingrreso efectivo
                        Console.Write("\nCuanto desea ingresar?: $");
                        float deposito = float.Parse(Console.ReadLine());

                        // posibles errores
                        if (deposito <= 0)
                        {
                            Console.WriteLine("Error, la cantidad debe ser mayor a 0");
                        }
                        else
                        {
                            saldo = saldo + deposito; // nuevoo saldo
                            Console.WriteLine("Deposito exitoso");
                            // se guarada mov.
                            historialMovimientos += $"- Deposito: +${deposito} | Saldo: ${saldo}\n";
                        }
                        break;

                    case 2: // retiro de efectivo
                        Console.Write("\n¿Cuanto desea retirar?: $");
                        float retiro = float.Parse(Console.ReadLine());

                        // posibles errores
                        if (retiro <= 0)
                        {
                            Console.WriteLine("Error, la cantidad debe ser mayor a 0");
                        }
                        
                        else if (retiro > saldo)
                        {
                            Console.WriteLine("Error, no hay suficientes fondos para este retiro");
                        }
                        else
                        {
                            saldo = saldo - retiro; // se resta saldo
                            Console.WriteLine("Retiro exitoso, tome su efectivo");
                            // se guardada mov.
                            historialMovimientos += $"- Retiro: -${retiro} | Saldo: ${saldo}\n";
                        }
                        break;

                    case 3: // consulta saldo general
                        Console.WriteLine($"\n>>> SU SALDO DISPONIBLE ES: ${saldo}");
                        break;

                    case 4: // movimientos general
                        Console.WriteLine("\n>>> HISTORIAL DE MOVIMIENTOS <<<");
                        historialMovimientos += $"- Se ha revisado movimientos\n";
                        // see imprime donde se fue guardando
                        Console.WriteLine(historialMovimientos);
                        break;
                }

                Console.WriteLine("\nPresione una tecla para volver al menu principal");
                Console.ReadLine();

            } while (opcion != 5);

            Console.WriteLine("Gracias por usar el cajero");
        }
    }
}