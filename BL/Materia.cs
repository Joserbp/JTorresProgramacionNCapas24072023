using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//import
//include
//using

namespace BL
{
    public class Materia
    {
        public static ML.Result GetById(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            try
            {
                //METODO
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {

                using (SqlConnection context = new SqlConnection(DL.Conexion.Get()))
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "SELECT IdMateria, Nombre, Costo, Creditos FROM Materia"; //Orden y filtrar  //JOIN
                    cmd.Connection = context;

                    SqlDataAdapter da = new SqlDataAdapter(cmd); //Puente Base de datos y Programa ObtenerDatos
                    DataTable tablaMateria = new DataTable();

                    da.Fill(tablaMateria);

                    if(tablaMateria.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();
                         
                        foreach(DataRow row in tablaMateria.Rows)
                        {
                            // CONVERT PARSE
                            ML.Materia materia = new ML.Materia();
                            materia.IdMateria = byte.Parse(row[0].ToString());
                            materia.Nombre = row[1].ToString();
                            materia.Costo = decimal.Parse(row[2].ToString());
                            materia.Creditos = byte.Parse(row[3].ToString());
                            Console.WriteLine();
                            result.Objects.Add(materia);

                        }
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Tabla no contiene información";
                    }

                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
                result.Correct = false;
            }
            return result;
        }
        public static ML.Result Add(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            //Destruir los objetos utilizados dentro de el

            try
            {
                //Bloque codigo que puede tener error
                using (SqlConnection conn = new SqlConnection(DL.Conexion.Get()))
                {
                    // SqlCommand cmd = new SqlCommand("INSERT INTO [Materia]([Nombre],[Creditos],[Costo]) VALUES (@Nombre, @Creditos,@Costo)", conn);
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.CommandText = "INSERT INTO[Materia]([Nombre],[Creditos],[Costo]) VALUES(@Nombre, @Creditos, @Costo)";
                    cmd1.Connection = conn;

                    cmd1.Parameters.AddWithValue("@Nombre", materia.Nombre);
                    cmd1.Parameters.AddWithValue("@Creditos", materia.Creditos);
                    cmd1.Parameters.AddWithValue("@Costo", materia.Costo);

                    cmd1.Connection.Open();

                    int rowsAffected = cmd1.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrio un error al insertar el materia " + materia.Nombre;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;

        }
    }
}
