using Backend;

var list = new DoublyLinkedList<string>();
int opcion = -1;

do
{
    Console.Clear();
    Console.WriteLine("=== MENÚ LISTA DOBLEMENTE LIGADA ===");
    Console.WriteLine("1. Adicionar ");
    Console.WriteLine("2. Mostrar hacia adelante");
    Console.WriteLine("3. Mostrar hacia atrás");
    Console.WriteLine("4. Ordenar descendentemente");
    Console.WriteLine("5. Mostrar las modas");
    Console.WriteLine("6. Mostrar Grafico");
    Console.WriteLine("7. Existe un elemento");
    Console.WriteLine("8. Eliminar una ocurrencia");
    Console.WriteLine("9. Eliminar todas las ocurrencias");
    Console.WriteLine("0. Salir");
    Console.Write("\nSeleccione una opción: ");

    if (int.TryParse(Console.ReadLine(), out opcion))
    {
        switch (opcion)
        {
            case 1:
                Console.Write("Ingrese el valor a adicionar (palabra o número): ");
                string? valorAdd = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(valorAdd))
                {
                    list.AddOrdered(valorAdd);
                    Console.WriteLine("\n¡Elemento adicionado correctamente en orden!");
                }
                else
                {
                    Console.WriteLine("\nEl valor no puede estar vacío.");
                }
                break;

            case 2:
                Console.WriteLine("\n--- Recorrido Hacia Adelante ---");
                Console.WriteLine(list.ToString());
                break;

            case 3:
                Console.WriteLine("\n--- Recorrido Hacia Atrás ---");
                Console.WriteLine(list.ToStringReverse());
                break;

            case 4:
                list.SortDescending();
                Console.WriteLine("\n¡Lista ordenada descendentemente con éxito!");
                Console.WriteLine(list.ToString());
                break;

            case 5:
                Console.WriteLine("\n--- Mostrar las Modas ---");
                var modes = list.GetModes();
                if (modes.Count > 0)
                {
                    Console.WriteLine($"El/los elemento(s) que más se repiten (Moda): {string.Join(", ", modes)}");
                }
                else
                {
                    Console.WriteLine("La lista está vacía, no hay modas que calcular.");
                }
                break;

            case 7:
                Console.Write("Ingrese el valor que desea buscar (palabra o número): ");
                string? valorBuscar = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(valorBuscar))
                {
                    bool encontrado = list.Contains(valorBuscar);
                    if (encontrado)
                        Console.WriteLine($"\nEl elemento '{valorBuscar}' SÍ existe en la lista.");
                    else
                        Console.WriteLine($"\nEl elemento '{valorBuscar}' NO se encuentra en la lista.");
                }
                else
                {
                    Console.WriteLine("\nEl valor no puede estar vacío.");
                }
                break;

            case 8:
                Console.Write("Ingrese el valor que desea eliminar: ");
                string? valorEliminar = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(valorEliminar))
                {
                    list.Remove(valorEliminar);
                    Console.WriteLine($"\nSe ha procesado la eliminación del elemento '{valorEliminar}'.");
                }
                else
                {
                    Console.WriteLine("\nEl valor no puede estar vacío.");
                }
                break;
    else
                {
                    Console.WriteLine("\nPor favor, ingrese un número válido.");
                }

                if (opcion != 0)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
        }
        while (opcion != 0)

            }
}
