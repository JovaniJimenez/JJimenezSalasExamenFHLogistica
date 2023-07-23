using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ML;

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

                                asignacion.Area.IdArea = int.Parse(row[4].ToString());
                                asignacion.Area.Descripccion = row[5].ToString();

                                asignacion.Marca.IdMarca= int.Parse(row[6].ToString());

                                asignacion.Marca.NombreMarca = row[7].ToString();
                              

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


        public static ML.Result GetEquipos()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConection()))
                {
                    string query = "GetEquipos";
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

                                ML.Equipo equipo = new ML.Equipo();
                                equipo.IdEquipo = int.Parse(row[0].ToString());
                                equipo.Modelo = row[1].ToString();
                                equipo.ClaveInventario = row[2].ToString();


                                equipo.TipoEquipo = new ML.TipoEquipo();
                                equipo.TipoEquipo.IdTipoEquipo = int.Parse(row[3].ToString());
                                equipo.TipoEquipo.NombreTipo = row[4].ToString();

                               
                                result.Objects.Add(equipo);
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


        public static ML.Result AddUsuario(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {


                //string Nombre, string ApellidoPaterno,string Correo, int Edad, string Domicilio
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConection()))
                {
                    string query = "UsuarioAdd";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;


                        SqlParameter[] collection = new SqlParameter[5];//numero de datos a procesar
                        collection[0] = new SqlParameter("IdSupervisor", SqlDbType.Int);
                        collection[0].Value = usuario.Supervisor.IdSupervisor;
                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = usuario.Nombre;

                        collection[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoPaterno;

                        collection[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[3].Value = usuario.ApellidoMaterno;

                        collection[4] = new SqlParameter("FechaIngreso", SqlDbType.DateTime);
                        collection[4].Value = usuario.FechaIngreso;
                       
                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();


                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrió un error al ingresar el usuario";
                        }



                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrió un error al ingresar el usuario";
            }
            return result;

        }
        public static ML.Result GetByIdUsuario(int idUsuario)
        {

            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConection()))
                {
                    string query = "GetByIdUsuario";

                    using (SqlCommand cmd = new SqlCommand())
                    {

                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = idUsuario;


                        cmd.Parameters.AddRange(collection);

                        DataTable tableUsuario = new DataTable();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {

                            da.Fill(tableUsuario);

                            //Estrutura de control -foreach 
                            if (tableUsuario.Rows.Count > 0)
                            {
                                DataRow row = tableUsuario.Rows[0];//0

                                ML.Usuario usuario = new ML.Usuario();
                                usuario.Supervisor = new Supervisor();
                                usuario.IdUsuario = int.Parse(row[0].ToString());
                                usuario.Supervisor.IdSupervisor = int.Parse(row[1].ToString());
                                usuario.Supervisor.NombreSupervisor =  row[2].ToString();

                                usuario.Nombre = row[3].ToString();
                                usuario.ApellidoPaterno = row[4].ToString();
                                usuario.ApellidoMaterno = row[5].ToString();
                                usuario.FechaIngreso = DateTime.Parse(row[6].ToString());
                                

                                result.Object = usuario; //boxing

                                result.Correct = true;
                            }
                            else
                            {
                                result.Correct = false;
                                result.ErrorMessage = "No existen registros sobre la tabla Usuario";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result;

        }






        public static ML.Result UpdateUsuario(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConection()))
                {
                    string query = "UpdateUsuario";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;


                        SqlParameter[] collection = new SqlParameter[6];//numero de datos a procesar
                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = usuario.IdUsuario;
                        collection[1] = new SqlParameter("IdSupervisor", SqlDbType.Int);
                        collection[1].Value = usuario.Supervisor.IdSupervisor;
                        collection[2] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[2].Value = usuario.Nombre;

                        collection[3] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[3].Value = usuario.ApellidoPaterno;

                        collection[4] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[4].Value = usuario.ApellidoMaterno;

                        collection[5] = new SqlParameter("FechaIngreso", SqlDbType.DateTime);
                        collection[5].Value = usuario.FechaIngreso;
                        

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();


                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrió un error al modificar el usuario";
                        }



                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrió un error al modificar el usuario";
            }



            return result;
        }



        public static ML.Result GetSupervisor()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConection()))
                {
                    string query = "GetSupervisor";
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

                                ML.Supervisor supervisor = new ML.Supervisor();
                                supervisor.IdSupervisor = int.Parse(row[0].ToString());
                                supervisor.NombreSupervisor = row[1].ToString();
                              


                                result.Objects.Add(supervisor);
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
