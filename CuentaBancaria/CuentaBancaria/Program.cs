using System;
using System.Collections.Generic;

namespace GestionCuentaBancaria
{
    internal class Program
    {
        public class CuentaBancaria
        {
            public double Saldo;
            public List<string> HistorialTransacciones;

            // Constructor para inicializar 
            public CuentaBancaria(double saldoInicial)
            {
                Saldo = saldoInicial;
                HistorialTransacciones = new List<string>();
                HistorialTransacciones.Add($"Cuenta creada con saldo inicial de: {saldoInicial:C2}");
            }

            // Deposita dinero 
            public void Depositar(double cantidad)
            {
                if (cantidad > 0)
                {
                    Saldo += cantidad;
                    Console.WriteLine($"Se han depositado {cantidad:C2}. Saldo actual: {Saldo:C2}");
                    HistorialTransacciones.Add($"Depósito: {cantidad:C2}");
                }
                else
                {
                    Console.WriteLine("La cantidad a depositar debe ser mayor que 0.");
                }
            }

            // Retiro de dinero 
            public void Retirar(double cantidad)
            {
                if (cantidad > 0)
                {
                    if (cantidad <= Saldo)
                    {
                        Saldo -= cantidad;
                        Console.WriteLine($"Se han retirado {cantidad:C2}. Saldo actual: {Saldo:C2}");
                        HistorialTransacciones.Add($"Retiro: {cantidad:C2}");
                    }
                    else
                    {
                        Console.WriteLine("Fondos insuficientes.");
                    }
                }
                else
                {
                    Console.WriteLine("La cantidad a retirar debe ser mayor que 0.");
                }
            }

            // Consultar el saldo actual
            public void ConsultarSaldo()
            {
                Console.WriteLine($"El saldo actual es: {Saldo:C2}");
            }
            
        }

        static void Main(string[] args)
        {
            // Inicializamos la cuenta bancaria con un saldo inicial
            CuentaBancaria cuenta = new CuentaBancaria(1000.00);
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\n--- Menú de Cuenta Bancaria ---");
                Console.WriteLine("1. Consultar saldo");
                Console.WriteLine("2. Depositar dinero");
                Console.WriteLine("3. Retirar dinero");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        cuenta.ConsultarSaldo();
                        break;
                    case "2":
                        DepositarDinero(cuenta);
                        break;
                    case "3":
                        RetirarDinero(cuenta);
                        break;
                    case "4":
                        continuar = false;
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }

        // Realizar el depósito
        public static void DepositarDinero(CuentaBancaria cuenta)
        {
            Console.Write("Introduzca la cantidad a depositar: ");
            double cantidad = double.Parse(Console.ReadLine());
            cuenta.Depositar(cantidad);
        }

        // Realizar el retiro
        public static void RetirarDinero(CuentaBancaria cuenta)
        {
            Console.Write("Introduzca la cantidad a retirar: ");
            double cantidad = double.Parse(Console.ReadLine());
            cuenta.Retirar(cantidad);
        }
    }
}
