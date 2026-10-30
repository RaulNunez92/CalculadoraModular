namespace CalculadoraModular;

internal class Program
{
    static void Main(string[] args)
    {
        bool continuar = true;

        // RF-11 / RN-06: Proceso cíclico para repetir operaciones
        do
        {
            MostrarMenu();
            byte opcion = LeerOpcion(); // Optimización: 1 byte (0 a 255)

            switch (opcion)
            {
                case 1: // Sumar
                    ProcesarOperacion("Suma", "+", Sumar);
                    break;

                case 2: // Restar
                    ProcesarOperacion("Resta", "-", Restar);
                    break;

                case 3: // Multiplicar
                    ProcesarOperacion("Multiplicación", "×", Multiplicar);
                    break;

                case 4: // Dividir
                    ProcesarDivision();
                    break;

                case 5: // RF-13 / CP-11: Salir
                    Console.WriteLine("\n>> Gracias por usar la Calculadora Modular. ¡Hasta pronto!");
                    continuar = false;
                    break;

                default: // RF-12 / CP-07: Opción inválida
                    Console.WriteLine("\n>> Error: Opción no válida. Por favor, elija entre 1 y 5.");
                    break;
            }

        } while (continuar);
    }

    // ==========================================
    // 1. MÉTODOS MATEMÁTICOS PUROS (RF-04 a RF-07)
    // ==========================================
    private static decimal Sumar(decimal a, decimal b) => a + b;
    private static decimal Restar(decimal a, decimal b) => a - b;
    private static decimal Multiplicar(decimal a, decimal b) => a * b;
    private static decimal Dividir(decimal a, decimal b) => a / b;

    // ==========================================
    // 2. MÉTODOS DE CAPTURA Y VALIDACIÓN (RF-03, RF-08)
    // ==========================================
    private static decimal CapturarNumero(string mensaje)
    {
        decimal numero;
        Console.Write(mensaje);

        // CP-06 / RN-02: Si escribe letras, vuelve a solicitarlo defensivamente
        while (!decimal.TryParse(Console.ReadLine() ?? "", out numero))
        {
            Console.WriteLine(">> Error: Entrada no numérica.");
            Console.Write(mensaje);
        }

        return numero;
    }

    private static byte LeerOpcion()
    {
        Console.Write("Seleccione una opción (1-5): ");
        byte.TryParse(Console.ReadLine() ?? "", out byte opcion);
        return opcion;
    }

    // ==========================================
    // 3. MÉTODOS DE INTERFAZ Y PRESENTACIÓN (RF-01, RF-10)
    // ==========================================
    private static void MostrarMenu()
    {
        Console.WriteLine("\n=================================");
        Console.WriteLine("       CALCULADORA MODULAR       ");
        Console.WriteLine("=================================");
        Console.WriteLine("1. Sumar");
        Console.WriteLine("2. Restar");
        Console.WriteLine("3. Multiplicar");
        Console.WriteLine("4. Dividir");
        Console.WriteLine("5. Salir");
        Console.WriteLine("---------------------------------");
    }

    private static void ProcesarOperacion(string nombreOp, string operador, Func<decimal, decimal, decimal> operacion)
    {
        Console.WriteLine($"\n--- Operación: {nombreOp} ---");
        decimal a = CapturarNumero("Ingrese el primer número: ");
        decimal b = CapturarNumero("Ingrese el segundo número: ");

        decimal resultado = operacion(a, b);
        Console.WriteLine($">> Resultado: {a} {operador} {b} = {resultado}");
    }

    private static void ProcesarDivision()
    {
        Console.WriteLine("\n--- Operación: División ---");
        decimal a = CapturarNumero("Ingrese el dividendo: ");
        decimal b = CapturarNumero("Ingrese el divisor: ");

        // RF-09 / RN-03 / CP-05: Evitar división por cero
        if (b == 0)
        {
            Console.WriteLine(">> Error: No es posible dividir entre cero. Operación cancelada.");
            return;
        }

        decimal resultado = Dividir(a, b);
        Console.WriteLine($">> Resultado: {a} / {b} = {resultado}");
    }
}
