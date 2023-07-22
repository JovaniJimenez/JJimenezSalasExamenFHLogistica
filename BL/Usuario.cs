using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {


        public static ML.Result GetUsuario()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConection()))
                {
                    string query = "GetAllUsuario";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;


                        DataTable tableDenominacion = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tableDenominacion);

                        if (tableDenominacion.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in tableDenominacion.Rows)
                            {

                                ML.Usuario usuario = new ML.Usuario();
                                usuario.IdUsuario = int.Parse(row[0].ToString());
                                usuario.Supervisor = new ML.Supervisor();
                                usuario.Supervisor.IdSupervisor = int.Parse(row[1].ToString());
                                usuario.Nombre = row[2].ToString();
                               
                                usuario.ApellidoPaterno = row[3].ToString();
                                usuario.ApellidoMaterno = row[4].ToString();
                                result.Objects.Add(usuario);
                            }

                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = " No existen registros en la tabla";
                        }

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
        //GetAllAsignaciones
        public static ML.Result GetUsuarioaAsiganciones()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConection()))
                {
                    string query = "GetAllAsignaciones";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;


                        DataTable tableDenominacion = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tableDenominacion);

                        if (tableDenominacion.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in tableDenominacion.Rows)
                            {

                                ML.Asignacion asignacion = new ML.Asignacion();
                                asignacion.Usuario = new ML.Usuario();
                                asignacion.Equipo = new ML.Equipo();
                                asignacion.Area = new ML.Area();
                                asignacion.Marca = new ML.Marca();
                                asignacion.IdAsignacion = int.Parse(row[0].ToString());
                                asignacion.Usuario.IdUsuario = int.Parse(row[1].ToString());

                                asignacion.Equipo.IdEquipo = int.Parse(row[2].ToString());
                                asignacion.Usuario.Nombre = row[3].ToString();
                                asignacion.Marca.IdMarca= int.Parse(row[4].ToString());

                                asignacion.Marca.NombreMarca = row[5].ToString();
                                asignacion.Area.IdArea= int.Parse(row[6].ToString());
                                asignacion.Area.Descripccion = row[7].ToString();

                                asignacion.Equipo.IdMarca = int.Parse(row[8].ToString());
                                asignacion.Equipo.Modelo = row[9].ToString();
                                asignacion.FechaAsignada = DateTime.Parse(row[10].ToString());


                                result.Objects.Add(asignacion);
                            }

                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = " No existen registros en la tabla";
                        }

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
