
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using TpvhostGenNHibernate.EN.Rest;
using TpvhostGenNHibernate.CEN.Rest;
using TpvhostGenNHibernate.CAD.Rest;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception ex)
        {
                throw ex;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
        try
        {
                // Insert the initilizations of entities using the CEN classes


                // p.e. CustomerCEN customer = new CustomerCEN();
                // customer.New_ (p_user:"user", p_password:"1234");
                // Duenyo
                DuenyoCEN duenyoCEN = new DuenyoCEN ();
                int duenyo1 = duenyoCEN.Nuevo ("DNI1", "Duenyo1", "apellido1", "60260545", "algo");
                // Empresa
                EmpresaCEN empresaCEN = new EmpresaCEN ();
                int empresa1 = empresaCEN.Nuevo ("empresa1", "direccion", duenyo1);

                //// Negocio
                NegocioCEN negocioCEN = new NegocioCEN ();

                int negocio1 = negocioCEN.Nuevo ("negocio1", "direccion1", "ciudad1", "602065", "provincia1", "pais1", empresa1);

                ///*Me esta pediendo mesa*/
                MesaCEN mesaCEN = new MesaCEN ();
                int mesa1 = mesaCEN.Nuevo (negocio1);

                // Empleados (todos)
                EmpleadoCEN empleadoCEN = new EmpleadoCEN ();
                int empCajero = empleadoCEN.Nuevo (negocio1, "empleado1", "empleado1Apellido1", "algo");
                int empEncargado = empleadoCEN.Nuevo (negocio1, "empleado2", "empleado2Apellido2", "algoa");
                int empCamarero = empleadoCEN.Nuevo (negocio1, "empleado3", "empleado3Apellido2", "algob");

                //ROL
                RolCEN rolCEN = new RolCEN ();
                //Rol cajero
                rolCEN.NuevoCajero (TpvhostGenNHibernate.Enumerated.Rest.EmpleoEnum.Cajero, empCajero);

                //Rol Encargado
                rolCEN.NuevoEncargado (TpvhostGenNHibernate.Enumerated.Rest.EmpleoEnum.Encargado, empEncargado);

                //Rol Camarero
                //rolCEN.Nue(TpvhostGenNHibernate.Enumerated.Rest.EmpleoEnum.Camarero, empCamarero);
                //rolCEN.AsignarCamarero();

                // comanda
                //ComandaCEN comandaCEN = new ComandaCEN ();
                //int comanda1 = comandaCEN.Nuevo (TpvhostGenNHibernate.Enumerated.Rest.EstadoComandaEnum.preparado, camarero1, mesa1, DateTime.Now);

                // Cliente
                ClienteCEN clienteCEN = new ClienteCEN ();
                int cliente1 = clienteCEN.Nuevo ("YSKSK5", "cliente1", "apellido1", negocio1);

                // Caja
                CajaCEN cajaCEN = new CajaCEN ();
                int caja1 = cajaCEN.Nuevo (negocio1, "CAJA1");

                // Categoria servicio
                CategoriaServicioCEN categoriaServicioCEN = new CategoriaServicioCEN ();
                int luz = categoriaServicioCEN.Nuevo ("Luz");
                int agua = categoriaServicioCEN.Nuevo ("Agua");

                // Servicios
                ServicioCEN servicioCEN = new ServicioCEN ();
                int servicio1 = servicioCEN.Nuevo (negocio1, "servicio1", luz);
                int servicio2 = servicioCEN.Nuevo (negocio1, "servicio2", agua);

                // Unidad medida
                UnidadMedidaCEN unidadMedidaCEN = new UnidadMedidaCEN ();
                int kilo = unidadMedidaCEN.Nuevo ("Kilogramo");
                int litro = unidadMedidaCEN.Nuevo ("Litro");

                // PRoductos
                ProductoCEN productoCEN = new ProductoCEN ();
                int patatas = productoCEN.Nuevo (kilo, negocio1, "patatas");
                int aceite = productoCEN.Nuevo (litro, negocio1, "aceite");

                // Provedoores
                ProveedorCEN proveedorCEN = new ProveedorCEN ();
                int proveedor1 = proveedorCEN.Nuevo ("NombrePRovedoor", "602646465", "correco@correo.com");

                // Metodo de pago
                TipoPagoCEN tipoPagoCEN = new TipoPagoCEN ();
                int tarjeta = tipoPagoCEN.Nuevo ("Tarjeta");
                int efectivo = tipoPagoCEN.Nuevo ("Efectivo");
                int cheque = tipoPagoCEN.Nuevo ("Cheque");

                // Tipo de cobro
                TipoCobroCEN tipoCobroCEN = new TipoCobroCEN ();
                int tarjetaCobro = tipoCobroCEN.Nuevo ("Tarjeta");
                int efectivoCobro = tipoCobroCEN.Nuevo ("Efectivo");
                int chequeCobro = tipoCobroCEN.Nuevo ("Cheque");

                List<LineaPlatoEN> lineaPlatoENs1 = new List<LineaPlatoEN>(){
                        new LineaPlatoEN (0, 6, new ProductoCAD ().ReadOID (patatas), null),
                        new LineaPlatoEN (0, 4, new ProductoCAD ().ReadOID (aceite), null)
                };

                // Plato
                PlatoCEN platoCEN = new PlatoCEN ();
                int patatasFritas = platoCEN.Nuevo ("Patatas fritas", 6, lineaPlatoENs1);



                //plato Menu
                List<LineaPlatoEN> lineaPlatoENs2 = new List<LineaPlatoEN>(){
                        new LineaPlatoEN (0, 3, new ProductoCAD ().ReadOID (patatas), null),
                        new LineaPlatoEN (0, 2, new ProductoCAD ().ReadOID (aceite), null)
                };
                int patatasFritasMenu = platoCEN.Nuevo ("Patatas fritas Menu", 3, lineaPlatoENs2);

                /* Linea Platos
                 * LineaPlatoCEN lineaPlatoCEN = new LineaPlatoCEN ();
                 * lineaPlatoCEN.Nuevo (0.3, patatas, patatasFritas);
                 * lineaPlatoCEN.Nuevo (0.05, aceite, patatasFritas);
                 *
                 * // Linea plato menu
                 * lineaPlatoCEN.Nuevo (0.1, patatas, patatasFritasMenu);
                 * lineaPlatoCEN.Nuevo (0.03, aceite, patatasFritasMenu);
                 */

                //liena de menu
                List<LineaMenuEN> lineaMenuENs = new List<LineaMenuEN>(){
                        new LineaMenuEN (0, 1, new  PlatoCAD ().ReadOID (patatas), null)
                };

                // Menu
                MenuCEN menuCEN = new MenuCEN ();
                int menu1 = menuCEN.Nuevo ("Menu diario 1", lineaMenuENs);


                //linea compra Servicio

                List<LineaCompraProveedorEN> lineaCompraProveedorENs = new List<LineaCompraProveedorEN>(){
                        new LineaCompraProveedorEN (0, 1, new ServicioCEN ().ReadOID (luz), null, null,100),
                        new LineaCompraProveedorEN (0, 1, null, null, new ProductoCEN ().ReadOID (patatas),120)
                };

                CompraProveedorCEN compraProveedorCEN = new CompraProveedorCEN ();
                compraProveedorCEN.Nuevo (lineaCompraProveedorENs, proveedor1, negocio1, TpvhostGenNHibernate.Enumerated.Rest.EstadoCompraProveedorEnum.pendiente, DateTime.Now);

                //   LineaMenuCEN lineaMenuCEN = new LineaMenuCEN ();
                //  lineaMenuCEN.Nuevo (1, menu1, patatasFritasMenu);

                //Factura
                //FacturaCEN facturaCEN = new FacturaCEN ();
                //int factura1 = facturaCEN.Nuevo ("150", DateTime.Now, 150, "descripcion1", comanda1, cliente1);

                // Pago
                //PagoCEN pagoCEN = new PagoCEN ();
                //int pago1 = pagoCEN.New_ (170, new DateTime (2022, 10, 10), 1504556);


                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }
}
}
}
