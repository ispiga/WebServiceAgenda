using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
[ServiceContract]
public interface IServiceMyAgenda
{
    [OperationContract]
    int NuevoContacto(MyAgenda agenda);

    [OperationContract]
    int EditarContacto(MyAgenda agenda);

    [OperationContract]
    int ElimirarContacto(int idContacto);

    [OperationContract]
    MyAgenda BuscarContacto(int idContacto);

    [OperationContract]
    List<MyAgenda> MostrarContactos();
}

[DataContract]
public class MyAgenda
{
    int _Id;
    string _Nombre;
    string _Apellidos;
    string _Telefono;
    string _Correo;

    [DataMember]
    public int Id
    {
        get { return _Id; }
        set { _Id = value; }
    }

    [DataMember]
    public string Nombre
    {
        get { return _Nombre; }
        set { _Nombre = value; }
    }

    [DataMember]
    public string Apellidos
    {
        get { return _Apellidos; }
        set { _Apellidos = value; }
    }

    [DataMember]
    public string Telefono
    {
        get { return _Telefono; }
        set { _Telefono = value; }
    }

    [DataMember]
    public string Correo
    {
        get { return _Correo; }
        set { _Correo = value; }
    }
}
