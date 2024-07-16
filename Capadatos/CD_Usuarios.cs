using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data.SqlClient;
using System.Data;

namespace Capadatos
{
    public class CD_Usuarios
    {
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();

            try
            {
                using (SqlConnection conexion=new SqlConnection(Conexion.cn))
                {
                    string query = "SELECT IdUsuario,Nombre,Apellido,Correo,Clave,Reestablecer,Activo FROM USUARIO";

                    SqlCommand cmd = new SqlCommand(query,conexion);

                    cmd.CommandType = CommandType.Text;

                    conexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            lista.Add(
                                new Usuario() { IdUsuario=Convert.ToInt32(dr["IdUsuario"]),
                                Nombre=dr["Nombre"].ToString(),
                                Apellido=dr["Apellido"].ToString(),
                                Correo=dr["Correo"].ToString(),
                                Clave=dr["Clave"].ToString(),
                                Reestablecer=Convert.ToBoolean(dr["Reestablecer"]),
                                Activo=Convert.ToBoolean(dr["Activo"])
                                }
                            );
                        }
                    }

                }
            }
            catch
            {
                lista = new List<Usuario>();
            }

            return lista;
        }
    }
}
