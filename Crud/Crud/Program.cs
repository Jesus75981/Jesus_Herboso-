using System;
using System.Collections.Generic;

namespace CRUD_OO_Extended
{
    class Persona
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public Persona(string nombre, int edad, string direccion, string telefono)
        {
            Nombre = nombre;
            Edad = edad;
            Direccion = direccion;
            Telefono = telefono;
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}, Edad: {Edad}, Dirección: {Direccion}, Teléfono: {Telefono}";
        }
    }

    class CrudPersonas
    {
        private List<Persona> personas;

        public CrudPersonas()
        {
            personas = new List<Persona>
            {
                new Persona("Juan", 25, "Calle A, Ciudad B", "123-456-789"),
                new Persona("Maria", 30, "Calle X, Ciudad Y", "987-654-321"),
                new Persona("Carlos", 22, "Calle Z, Ciudad W", "555-111-222")
            };
        }

        public void AgregarPersona(string nombre, int edad, string direccion, string telefono)
        {
            personas.Add(new Persona(nombre, edad, direccion, telefono));
        }

        public void MostrarPersonas()
        {
            foreach (var persona in personas)
            {
                Console.WriteLine(persona.ToString());
            }
        }

        public Persona BuscarPersona(string nombre)
        {
            return personas.Find(p => p.Nombre == nombre);
        }

        public void EliminarPersona(string nombre)
        {
            Persona persona = BuscarPersona(nombre);
            if (persona != null)
            {
                personas.Remove(persona);
                Console.WriteLine($"{nombre} ha sido eliminado.");
            }
            else
            {
                Console.WriteLine($"{nombre} no encontrado.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CrudPersonas crud = new CrudPersonas();

            while (true)
            {
                Console.WriteLine("\n--- Menú ---");
                Console.WriteLine("1. Mostrar Personas");
                Console.WriteLine("2. Agregar Persona");
                Console.WriteLine("3. Buscar Persona");
                Console.WriteLine("4. Eliminar Persona");
                Console.WriteLine("5. Salir");

                Console.Write("Seleccione una opción: ");
                int opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("\nLista de personas:");
                        crud.MostrarPersonas();
                        break;
                    case 2:
                        Console.Write("\nIngrese el nombre: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Ingrese la edad: ");
                        int edad = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Ingrese la dirección: ");
                        string direccion = Console.ReadLine();
                        Console.Write("Ingrese el teléfono: ");
                        string telefono = Console.ReadLine();
                        crud.AgregarPersona(nombre, edad, direccion, telefono);
                        Console.WriteLine("Persona agregada con éxito.");
                        break;
                    case 3:
                        Console.Write("\nIngrese el nombre a buscar: ");
                        string nombreBuscar = Console.ReadLine();
                        Persona personaEncontrada = crud.BuscarPersona(nombreBuscar);

                        if (personaEncontrada != null)
                        {
                            Console.WriteLine($"Persona encontrada: {personaEncontrada.ToString()}");
                        }
                        else
                        {
                            Console.WriteLine($"{nombreBuscar} no encontrado.");
                        }
                        break;
                    case 4:
                        Console.Write("\nIngrese el nombre a eliminar: ");
                        string nombreEliminar = Console.ReadLine();
                        crud.EliminarPersona(nombreEliminar);
                        break;
                    case 5:
                        Console.WriteLine("Saliendo del programa.");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, seleccione nuevamente.");
                        break;
                }
            }
        }
    }
}
