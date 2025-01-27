• Información relevante para hacer build y ejecutar el proyecto.
1.El proyecto se desarrollo utilizando la ultima versión de .NET (la cual es la version 9) por lo que es importante tener esta misma version instalada antes de ejecutar el proyecto.
2.Ejecutar en la base de datos, de manera local el mismo script que me enviaron para crear la base de datos con información llamada "StoreSample".
3.En el proyecto, remplazar los datos en la cadena de conexión a la base de datos con las credenciales de su instancia local, la cual se encuentra en el archivo appsettings.json. Deberan remplazar los campos Server Name, User Id y Password. El nombre de la base de datos No ya que este deberia de ser el mismo si ejecutaron el paso 2 mencionado anteriormente.
4.Ejecutar el proyecto con el perfil Https (El puerto por defecto es el 7016 pero si ustedes lo tienen ocupado, este cambiara al 5052 y se debera actualizar el puerto en los endpoints mencionado a continuación)

Endpoints para probar el proyecto:
GET https://localhost:7016/api/customers/order-predictions
GET https://localhost:7016/api/orders/customers/85
GET https://localhost:7016/api/employees
GET https://localhost:7016/api/shippers
GET https://localhost:7016/api/products

POST https://localhost:7016/api/orders
BODY:
{
    "order": {
        "empid":2, 
        "shipperid":2, 
        "shipname":"Jesus Test", 
        "shipaddress":"Str Jesus", 
        "shipcity":"New York", 
        "orderdate":"2025-01-26", 
        "requireddate":"2025-01-28", 
        "shippeddate":"2025-01-28", 
        "freight":28.90, 
        "shipcountry":"COL"
    },
    "productid":3, 
    "unitprice":4500, 
    "qty":3, 
    "discount":0
}
 
• Cualquier información relevante sobre la prueba que se quiera mencionar para ser tenida en cuenta durante la revisión.
1.Se implemento la arquitectura limpia para la estructuracion del proyecto y se tuvieron en cuenta los principios SOLID.
2.Debido a que la prueba tecnica indica construir sentencias DML, utilicé el ORM Dapper para que puedan visualizar facilmente cada una de las sentencias SQL las cuales encontraran en los diferentes repositorios. Sin embargo hay escenarios de requerimientos en los que Dapper no es la forma mas adecuada de trabajar y seria mas conveniente utilzar otros ORM's como lo son Entity Framework. Un caso de esto es cuando se requiere manejar estado o hacer seguimiento de los cambios que tiene un objeto el cual va a representar una entidad de la base de datos.
3.He escrito la cadena de conexión a la base de datos en el archivo appsettings.json para que tengan la facilidad de modificarla para hacer la revision del proyecto (ya que actualmente tiene el usuario y contraseña de mi instancia local y deben modificar estos datos con los datos de acceso a su instancia). Sin embargo esto es una mala práctica y seria mas adecuado guardar este dato en una variable de entorno o en el archivo de user secrets (Para desarrollo) ó utilizar una variable de entorno en Azure o el proveedor de nube deseado (Para producción).
4.Aunque no se pedia en la prueba, se creo un Middleware para manejar las excepciones globales de la aplicacion y se utilizo Dapper para el mapeo de las entidades, ya que es una mala práctica exponer directamente las entidades de la aplicación al usuario. 
5.Se habilito CORS para que pueda recibir solicitudes desde cualquier origen, metodo y cabecera con el motivo de facilitar el proceso de revision. Sin embargo solo se deberia de agregar los origines especificos que van a consumir el API.

• Breve explicación sobre como se ejecutó la prueba.
1. Realicé las pruebas consumiendo los endpoints de la aplicacion directamente desde Postman.
1. No implementé pruebas unitarias debido a que actualmente todos los metodos implementados en la aplicación tienen como finalidad realizar operaciones contra la base de datos. Debido a que utilicé Dapper, este ORM actualmente no cuenta con alguna forma nativa de testearlo y tampoco permite crear una base de datos local y validar que efectivamente se esten realizando las operaciones contra la base de datos, por lo que realmente dificulta este proceso de hacer pruebas. Estuve investigando algnunas formas de realizar las pruebas con este ORM en internet pero en mi opinion, los metodos utilizados no validan que realmente los metodos funcionen bien y en este caso en especifico, creo que se deberian realizar las pruebas manuales.
