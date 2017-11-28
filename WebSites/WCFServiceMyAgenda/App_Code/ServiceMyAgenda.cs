using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class ServiceMyAgenda : IServiceMyAgenda
{
    string cadenaConexion = ConfigurationManager.ConnectionStrings["myConexion"].ConnectionString;

    public MyAgenda BuscarContacto(int idContacto)
    {
        MyAgenda contactoAgenda = new MyAgenda();

        try
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            conexion.Open();

            SqlCommand cmd = new SqlCommand("sp_Seleccionar_Eliminar_Contacto", conexion);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Operacion", "S");
            cmd.Parameters.AddWithValue("@Id", idContacto);

            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                if (rd.Read())
                {
                    contactoAgenda.Id = rd.GetInt32(0);
                    contactoAgenda.Nombre = rd.GetString(1);
                    contactoAgenda.Apellidos = rd.GetString(2);
                    contactoAgenda.Telefono = rd.GetString(3);
                    contactoAgenda.Correo = rd.GetString(4);
                }
            }
            else
            {
                throw new Exception("No hay Registros");
            }

            conexion.Close();
        }

        catch (Exception ex)
        {
            throw new Exception("Error al Eliminar", ex);
        }

        return contactoAgenda;
    }

    public int EditarContacto(MyAgenda agenda)
    {
        int res = 0;

        try
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            conexion.Open();

            SqlCommand cmd = new SqlCommand("sp_Insertar_Actualizar_Contacto", conexion);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Operacion", "A");
            cmd.Parameters.AddWithValue("@Id", agenda.Id);
            cmd.Parameters.AddWithValue("@Nombre", agenda.Nombre);
            cmd.Parameters.AddWithValue("@Apellidos", agenda.Apellidos);
            cmd.Parameters.AddWithValue("@Telefono", agenda.Telefono);
            cmd.Parameters.AddWithValue("@Correo", agenda.Correo);

            res = cmd.ExecuteNonQuery();

            conexion.Close();
        }

        catch (Exception ex)
        {
            throw new Exception("Error al Editar", ex);
        }

        return res;
    }

    public int ElimirarContacto(int idContacto)
    {
        int res = 0;

        try
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            conexion.Open();

            SqlCommand cmd = new SqlCommand("sp_Seleccionar_Eliminar_Contacto", conexion);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Operacion", "E");
            cmd.Parameters.AddWithValue("@Id", idContacto);

            res = cmd.ExecuteNonQuery();

            conexion.Close();
        }

        catch (Exception ex)
        {
            throw new Exception("Error al Eliminar", ex);
        }

        return res;
    }

    public List<MyAgenda> MostrarContactos()
    {
        List<MyAgenda> lista = new List<MyAgenda>();

        try
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            conexion.Open();

            SqlCommand cmd = new SqlCommand("sp_Seleccionar_Eliminar_Contacto", conexion);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Operacion", "");
            cmd.Parameters.AddWithValue("@Id", "");

            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                while (rd.Read())
                {
                    lista.Add(new MyAgenda
                    {
                        Id = rd.GetInt32(0),
                        Nombre = rd.GetString(1),
                        Apellidos = rd.GetString(2),
                        Telefono = rd.GetString(3),
                        Correo = rd.GetString(4)
                    });
                }
            }
            else
            {
                throw new Exception("No hay Registros");
            }

            conexion.Close();
        }

        catch (Exception ex)
        {
            throw new Exception("Error al Eliminar", ex);
        }

        return lista;
    }

    public int NuevoContacto(MyAgenda agenda)
    {
        int res = 0;

        try
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);

            conexion.Open();

            SqlCommand cmd = new SqlCommand("sp_Insertar_Actualizar_Contacto", conexion);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Operacion", "I");
            cmd.Parameters.AddWithValue("@Id", agenda.Id);
            cmd.Parameters.AddWithValue("@Nombre", agenda.Nombre);
            cmd.Parameters.AddWithValue("@Apellidos", agenda.Apellidos);
            cmd.Parameters.AddWithValue("@Telefono", agenda.Telefono);
            cmd.Parameters.AddWithValue("@Correo", agenda.Correo);

            res = cmd.ExecuteNonQuery();

            conexion.Close();
        }

        catch (Exception ex)
        {
            throw new Exception("Error al Insertar", ex);
        }

        return res;
    }
}
