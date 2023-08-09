using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Materia
    {
        public static void GetAll()
        {
            BL.Materia.GetAll();
            // Acceder a objects y mostrar en consola 
        }
        public static void Add()
        {
            ML.Materia materia = new ML.Materia();


            Console.WriteLine("Ingrese el nombre de la materia");
            materia.Nombre = Console.ReadLine();

            Console.WriteLine("Ingreso los créditos de la materia");
            materia.Creditos = byte.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el costo de la materia");
            materia.Costo = decimal.Parse(Console.ReadLine());

            ML.Result result = BL.Materia.Add(materia);

            if (result.Correct)
            {
                Console.WriteLine("La materia se inserto correctamente");
            }else
            {
                Console.WriteLine("Ocurrio un error al insertar la materia" + result.ErrorMessage);
                Console.WriteLine(result.Ex);
            }
        }

        public static void Update()
        {

        }

        public static void Delete()
        {

        }
    }
}
