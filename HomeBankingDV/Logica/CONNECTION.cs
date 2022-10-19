using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms.PropertyGridInternal;

namespace HomeBankingDV
{
    internal class CONNECTION
    {
        private string connectionString;
        public CONNECTION()
        {
            //Cargo la cadena de conexión desde el archivo de properties
            connectionString = Properties.Resources.ConnectionStr;
             
        }
        public List<Usuario> inicializarUsuarios()
        {
            List<Usuario> misUsuarios = new List<Usuario>();

            //Defino el string con la consulta que quiero realizar
            string queryString = "SELECT * from dbo.Usuarios";

            // Creo una conexión SQL con un Using, de modo que al finalizar, la conexión se cierra y se liberan recursos
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                // Defino el comando a enviar al motor SQL con la consulta y la conexión
                SqlCommand command = new SqlCommand(queryString, connection);

                try
                {
                    //Abro la conexión
                    connection.Open();
                    //mi objecto DataReader va a obtener los resultados de la consulta, notar que a comando se le pide ExecuteReader()
                    SqlDataReader reader = command.ExecuteReader();
                    Usuario aux;
                    //mientras haya registros/filas en mi DataReader, sigo leyendo
                    while (reader.Read())
                    {
                        aux = new Usuario(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetBoolean(6), reader.GetBoolean(7));
                        misUsuarios.Add(aux);
                    }
                    //En este punto ya recorrí todas las filas del resultado de la query
                    reader.Close();



                    //YA cargué todos los domicilios, sólo me resta vincular
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return misUsuarios;
        }

        public List<Domicilio> inicializarDomicilios()
        {
            List<Domicilio> misDomicilios = new List<Domicilio>();
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                //Ahora cargo los domicilios
                string queryString = "SELECT * from dbo.Domicilios";
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Domicilio dom;
                    while (reader.Read())
                    {
                        dom = new Domicilio(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5));
                        misDomicilios.Add(dom);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return misDomicilios;
        }

        //devuelve el ID del usuario agregado a la base, si algo falla devuelve -1
        public int agregarUsuario(int Dni, string Nombre, string Mail, string Password, bool IsAdmin, bool Bloqueado)
        {
            //primero me aseguro que lo pueda agregar a la base
            int resultadoQuery;
            int idNuevoUsuario = -1;
            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "INSERT INTO [dbo].[Usuario] ([Dni],[Nombre],[Mail],[Password],[IsAdmin],[Bloqueado]) VALUES (@userDni,@userNombre,@userMail,@userPassword,@userIsAdmin,@UserBloqueado);";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@userDni", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@userNombre", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@userMail", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@userPassword", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@userIsAdmin", SqlDbType.Bit));
                command.Parameters.Add(new SqlParameter("@userBloqueado", SqlDbType.Bit));
                command.Parameters["@UserDni"].Value = Dni;
                command.Parameters["@userNombre"].Value = Nombre;
                command.Parameters["@userMail"].Value = Mail;
                command.Parameters["@userPassword"].Value = Password;
                command.Parameters["@userIsAdmin"].Value = IsAdmin;
                command.Parameters["@userBloqueado"].Value = Bloqueado;
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    resultadoQuery = command.ExecuteNonQuery();

                    //*******************************************
                    //Ahora hago esta query para obtener el ID
                    string ConsultaID = "SELECT MAX([ID]) FROM [dbo].[Usuario]";
                    command = new SqlCommand(ConsultaID, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    idNuevoUsuario = reader.GetInt32(0);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return -1;
                }
                return idNuevoUsuario;
            }
        }
        //devuelve la cantidad de elementos modificados en la base (debería ser 1 si anduvo bien)
        public int eliminarUsuario(int Id)
        {
            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "DELETE FROM [dbo].[Usuario] WHERE ID=@userId";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int));
                command.Parameters["@userId"].Value = Id;
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

        //devuelve la cantidad de elementos modificados en la base (debería ser 1 si anduvo bien)
        public int modificarUsuario(int Id, int Dni, string Nombre, string Mail, string Password, bool EsADM, bool Bloqueado)
        {
            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "UPDATE [dbo].[Usuario] SET Nombre=@UserNombre, Mail=@userMail,Password=@userPassword, EsADM=@userIsAdmin, Bloqueado=@userBloqueado WHERE ID=@userId;";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@userId", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@userDni", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@userNombre", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@userMail", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@userPassword", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@userIsAdmin", SqlDbType.Bit));
                command.Parameters.Add(new SqlParameter("@userBloqueado", SqlDbType.Bit));
                command.Parameters["@userId"].Value = Id;
                command.Parameters["@userDni"].Value = Dni;
                command.Parameters["@userNombre"].Value = Nombre;
                command.Parameters["@userMail"].Value = Mail;
                command.Parameters["@userPassword"].Value = Password;
                command.Parameters["@userIsAdmin"].Value = EsADM;
                command.Parameters["@userBloqueado"].Value = Bloqueado;
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    return command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 0;
                }
            }
        }

    }
}