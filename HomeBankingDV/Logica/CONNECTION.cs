using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms.PropertyGridInternal;
using HomeBankingDV.Logica;

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
            string queryString = "SELECT * from dbo.Usuario";

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
                string queryString = "SELECT * from dbo.Domicilio";
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
            string queryString = "INSERT INTO [dbo].[Usuario] ([userDni],[userNombre],[userApellido],[userMail],[userPassword],[userIsAdmin],[userBloqueado]) VALUES (@userDni,@userNombre,@userMail,@userPassword,@userIsAdmin,@UserBloqueado);";
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


        //tp2 - inicio



        public int insertarMovimiento(int _idCajaAhorro, float _monto, string _accion)
        {
            int resultadoQuery;

            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "INSERT INTO [dbo].[movimiento] ([monto],[idCajaDeAhorro],[detalle],[fecha]) VALUES (@monto,@idCajaDeAhorro,@detalle,CURRENT_TIMESTAMP);";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@monto", SqlDbType.Float));
                command.Parameters.Add(new SqlParameter("@idCajaDeAhorro", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@detalle", SqlDbType.NVarChar));

                command.Parameters["@monto"].Value = _monto;
                command.Parameters["@idCajaDeAhorro"].Value = _idCajaAhorro;
                command.Parameters["@detalle"].Value = _accion;

                try
                {
                    connection.Open();
                    resultadoQuery = command.ExecuteNonQuery();

                    string ConsultaID = "SELECT MAX([idMovimiento]) FROM [dbo].[movimiento]";
                    command = new SqlCommand(ConsultaID, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    resultadoQuery = reader.GetInt32(0);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return -1;
                }
                return resultadoQuery;
            }
        }






        public CajaDeAhorro TraerCajaAhorro(int _idCaja)
        {
            CajaDeAhorro laCajaDeAhorro = null;
            string queryString = "SELECT * from dbo.cajaAhorro_v2 where idCajaDeAhorro = @idCajaDeAhorro";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@idCajaDeAhorro", SqlDbType.Int));
                command.Parameters["@idCajaDeAhorro"].Value = _idCaja;
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        laCajaDeAhorro = new CajaDeAhorro(reader.GetInt32(0), reader.GetInt32(1), (float)reader.GetDouble(2));
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return laCajaDeAhorro;
        }








        public List<Movimiento> inicializarMovimientos()
        {
            List<Movimiento> misMovimientos = new List<Movimiento>();

            string queryString = "SELECT * from dbo.movimiento";

            using (SqlConnection connection =new SqlConnection(connectionString))
            {   SqlCommand command = new SqlCommand(queryString, connection);
                try {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Movimiento aux;
                    while (reader.Read())
                    {
                        int idCajaAhooro = reader.GetInt32(2);
                        CajaDeAhorro lacaja = this.TraerCajaAhorro(idCajaAhooro);
                        aux = new Movimiento(reader.GetInt32(0), (float)reader.GetDouble(1), lacaja, reader.GetString(3), reader.GetDateTime(4));
                        misMovimientos.Add(aux);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return misMovimientos;
        }













        public int cambiarMontoEnCajaDeAhorro(int _idCaja, float _monto)
        {
            int resultadoQuery;

            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "UPDATE [dbo].[cajaAhorro_v2] SET saldoCajaDeAhorro = @saldoCajaDeAhorro where idCajaDeAhorro = @idCajaDeAhorro;";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@idCajaDeAhorro", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@saldoCajaDeAhorro", SqlDbType.Float));
                command.Parameters["@idCajaDeAhorro"].Value = _idCaja;
                command.Parameters["@saldoCajaDeAhorro"].Value = _monto;
                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    resultadoQuery = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return -1;
                }
                return resultadoQuery;
            }
        }




        public int agregaragregarUsuario_v2(int _Dni, string _Nombre, string _Apellido, string _Mail, string _Password)
        {
            int resultadoQuery;

            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "INSERT INTO [dbo].[Usuario] ([userDni],[userNombre],[userApellido],[userMail],[userPassword],[userIsAdmin],[userBloqueado]) VALUES (@userDni,@userNombre,@userApellido,@userMail,@userPassword,@userIsAdmin,@UserBloqueado);";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@userDni", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@userNombre", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@userApellido", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@userMail", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@userPassword", SqlDbType.NVarChar));
                command.Parameters.Add(new SqlParameter("@userIsAdmin", SqlDbType.Bit));
                command.Parameters.Add(new SqlParameter("@userBloqueado", SqlDbType.Bit));
                command.Parameters["@UserDni"].Value = _Dni;
                command.Parameters["@userNombre"].Value = _Nombre;
                command.Parameters["@userApellido"].Value = _Apellido;
                command.Parameters["@userMail"].Value = _Mail;
                command.Parameters["@userPassword"].Value = _Password;
                command.Parameters["@userIsAdmin"].Value = 0;
                command.Parameters["@userBloqueado"].Value = 0;

                try
                {
                    connection.Open();
                    //esta consulta NO espera un resultado para leer, es del tipo NON Query
                    resultadoQuery = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return -1;
                }
                return resultadoQuery;
            }
        }



        public int agregaragregarCajaAhorro_v2(int _cbu)
        {
            int resultadoQuery;

            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "INSERT INTO [dbo].[cajaAhorro_v2] ([cbuCajaDeAhorro],[saldoCajaDeAhorro]) VALUES (@cbuCajaDeAhorro,@saldoCajaDeAhorro);";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@cbuCajaDeAhorro", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@saldoCajaDeAhorro", SqlDbType.Float));
                command.Parameters["@cbuCajaDeAhorro"].Value = _cbu;
                command.Parameters["@saldoCajaDeAhorro"].Value = 0;
                try
                {   connection.Open();
                    resultadoQuery = command.ExecuteNonQuery();

                    string ConsultaID = "SELECT MAX([idCajaDeAhorro]) FROM [dbo].[cajaAhorro_v2]";
                    command = new SqlCommand(ConsultaID, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    resultadoQuery = reader.GetInt32(0);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return -1;
                }
                return resultadoQuery;
            }
        }




        public int agregaragregaTitular_v2(int _idUser, int _idCA)
        {
            int resultadoQuery;

            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "INSERT INTO [dbo].[titulares_v2] ([idCAtitular],[idUstitular]) VALUES (@idCAtitular,@idUstitular);";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@idCAtitular", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@idUstitular", SqlDbType.Int));
                command.Parameters["@idCAtitular"].Value = _idCA;
                command.Parameters["@idUstitular"].Value = _idUser;
                try
                {
                    connection.Open();
                    resultadoQuery = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return -1;
                }
                return resultadoQuery;
            }
        }


        public int eliminarTitular_v2(int _idUser, int _idCA)
        {
            int resultadoQuery;

            string connectionString = Properties.Resources.ConnectionStr;
            string queryString = "DELETE FROM [dbo].[titulares_v2] WHERE idCAtitular = @idCAtitular AND idUstitular = @idUstitular;";
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(new SqlParameter("@idCAtitular", SqlDbType.Int));
                command.Parameters.Add(new SqlParameter("@idUstitular", SqlDbType.Int));
                command.Parameters["@idCAtitular"].Value = _idCA;
                command.Parameters["@idUstitular"].Value = _idUser;
                try
                {
                    connection.Open();
                    resultadoQuery = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return -1;
                }
                return resultadoQuery;
            }
        }

        public List<CajaDeAhorro> inicializarCajasDeAhorro()
        {
            List<CajaDeAhorro> misCajaDeAhorro = new List<CajaDeAhorro>();

            //Defino el string con la consulta que quiero realizar
            string queryString = "SELECT * from dbo.cajaAhorro_v2";
            //string queryString = "SELECT idCajaDeAhorro ,CAST(saldoCajaDeAhorro AS INT) as saldoCajaDeAhorro ,saldoCajaDeAhorro from dbo.cajaAhorro_v2";
            

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
                    CajaDeAhorro aux;
                    //mientras haya registros/filas en mi DataReader, sigo leyendo
                    while (reader.Read())
                    {
                        aux = new CajaDeAhorro(reader.GetInt32(0), reader.GetInt32(1), (float)reader.GetDouble(2));
                        misCajaDeAhorro.Add(aux);
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
            return misCajaDeAhorro;
        }



        public List<TitularesRel> inicializarTituLaresRel()
        {
            List<TitularesRel> misCajaDeAhorro = new List<TitularesRel>();

            //Defino el string con la consulta que quiero realizar
            string queryString = "SELECT * from dbo.titulares_v2";

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
                    TitularesRel aux;
                    //mientras haya registros/filas en mi DataReader, sigo leyendo
                    while (reader.Read())
                    {
                        aux = new TitularesRel(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2));
                        misCajaDeAhorro.Add(aux);
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
            return misCajaDeAhorro;
        }


        //tp2 - fin

    }
}