1. Quines són les característiques i els escenaris d'ús de les metodologies àgils de desenvolupament de programari? Explica amb detall i posa un exemple.

Primero, que son las metodologías ágiles? Son enfoques en el que el desarrollo del Software se hace de manera más flexible y adaptable ya que se hace en colaboración constante con los clientes.

### ¿Cuáles son sus características principales?  
- **Tiempos de trabajos cortos**: Se divide todo el proyecto en varias partes, cada cual suele durar de 1 a 4 semanas, en este tiempo se desarrollan partes funcionales del producto.  
- **Colaboración constante**: Incluimos de manera activa al cliente, de esta manera garantizamos que el producto cumpla con lo que se quiere.  
- **Flexibilidad ante cambios**: Al estar divididas en pequeñas entregas, si el cliente quiere agregar o cambiar alguna funcionalidad, se puede implementar en la siguiente entrega.  
- **Equipos autoorganizados**: Los mismos miembros del equipo deciden cómo abordar las tareas dentro del sprint.  
- **Comunicación constante**: Se hacen reuniones regulares, para garantizar que todo el mundo cuente con información de los demás.  
- **Entrega de valor**: Se prioriza entregar primero las funcionalidades más importantes del proyecto, y dejando para el final las que son menos importantes.

### En qué escenarios podría utilizarse?  

Es esencial usarlo en proyectos con requisitos que van variando, ya que puede ser que el cliente no tenga seguro desde un principio qué es todo lo que tendrá el proyecto, o si el mercado es muy cambiante.  
También para proyectos innovadores ya que usualmente en este tipo de proyectos van saliendo ideas y funcionalidades nuevas en medio del desarrollo.  
Lo ideal es utilizarlo en equipos pequeños/medianos ya que a más grande sea el equipo más organización se necesitará para no pisar trabajos de otros y el diálogo es mucho más fácil.  

### Ejemplo:  
Te mandan a desarrollar un juego de cartas en el que el cliente abra sobres y de él salgan Puchamones, con el elemento tierra, fuego y agua.  

- **Primer sprint:** Se desarrollan 5 cartas de cada elemento, una animación de abrir un cofre y que te salga 1 carta del sobre.  
  - **Revisión del cliente:** Nos dice que le gustaría que a la hora de ir a abrir sobres el cliente pueda elegir entre 5 sobres.  

- **Segundo sprint:** Desarrollamos una función que permite al usuario elegir cuál de los 5 sobres de Puchamon quiere abrir, además de desarrollar 5 cartas más de cada tipo.  
  - **Revisión del cliente:** Creo que sería mejor si es como una ruleta para elegir el sobre, que puedes ir deslizando a la derecha o a la izquierda para elegir el sobre, además me gustaría que los usuarios puedan hacer peleas con los Puchamones.  

etc etc...

## 2. Què són els dobles de prova? Explica amb detall els diferents tipus i posa un exemple d’ús per a una solució en C#

Los dobles de pruebas vendrían siendo (como dice mi querida IA) "actores de reemplazo" para reemplazar partes del código que dependen de algo externo, como podría ser enviar correos electrónicos, conectarse a una base de datos, consultar APIs.  
Cuando estamos haciendo nuestro programa, no siempre queremos llamar estas funciones externas. No queremos que se nos envíe un correo cada que probamos el código, y en ese momento es donde entran los dobles de prueba.

### Tipos de dobles de prueba

1. **Stub**: Te devolverá siempre lo que tú le hayas guardado como respuesta. Por ejemplo, si llamas a un método para obtener datos de un usuario, te devolverá siempre la respuesta que tú hayas guardado.

2. **Mock**: El mock es parecido al stub, te devuelve lo que tú hayas guardado, pero además te dice si lo hiciste de manera correcta.

3. **Fake**: El fake sirve como una versión más sencilla de lo real que está imitando. Por ejemplo, si tienes una base de datos, en lugar de llamarla, guardará los datos en una lista.

4. **Spy**: Mientras que el mock verifica si se han hecho las cosas de manera correcta, el spy toma nota de todo. Observa y registra desde cuántas veces llamaste al método, qué parámetros se usaron en cada llamada y en qué orden se llamaron los métodos.

5. **Dummy**: No hace nada... igual de importante que Neville Longbottom (Harry Potter).

### Ejemplo de Mock en C#

#### Esto sería un ejemplo de programa que envía correos.

```csharp
// Interfaz para un servicio de correos
public interface IEmailService
{
    void SendEmail(string to, string subject, string body);
}

// Clase que procesa pedidos
public class OrderProcessor
{
    private IEmailService _emailService;

    public OrderProcessor(IEmailService emailService)
    {
        _emailService = emailService;
    }

    public void ProcessOrder(string orderDetails, string customerEmail)
    {
        // Aquí iría la lógica del pedido (omitir para simplificar)
        
        // Enviar correo de confirmación
        _emailService.SendEmail(customerEmail, "Pedido confirmado", "Gracias por su compra.");
    }
}

Y ESTE SERIA EL TEST UTILIZANDO EL MOCK 

[TestClass]
public class OrderProcessorTests
{
    [TestMethod]
    public void ShouldSendConfirmationEmailWhenOrderIsProcessed()
    {
        // Crear un "Mock" del servicio de correos (simulador)
        var emailServiceMock = new Mock<IEmailService>();

        // Crear la clase que vamos a probar, usando el mock
        var orderProcessor = new OrderProcessor(emailServiceMock.Object);

        // Llamar al método que queremos probar
        orderProcessor.ProcessOrder("Detalles del pedido", "cliente@ejemplo.com");

        // Verificar que el servicio de correos fue llamado correctamente
        emailServiceMock.Verify(
            email => email.SendEmail(
                "cliente@ejemplo.com", 
                "Pedido confirmado", 
                "Gracias por su compra."
            ),
            Times.Once
        );
    }
}
[TestClass]
public class OrderProcessorTests
{
    [TestMethod]
    public void ShouldSendConfirmationEmailWhenOrderIsProcessed()
    {
        // Crear un "Mock" del servicio de correos (simulador)
        var emailServiceMock = new Mock<IEmailService>();

        // Crear la clase que vamos a probar, usando el mock
        var orderProcessor = new OrderProcessor(emailServiceMock.Object);

        // Llamar al método que queremos probar
        orderProcessor.ProcessOrder("Detalles del pedido", "cliente@ejemplo.com");

        // Verificar que el servicio de correos fue llamado correctamente
        emailServiceMock.Verify(
            email => email.SendEmail(
                "cliente@ejemplo.com", 
                "Pedido confirmado", 
                "Gracias por su compra."
            ),
            Times.Once
        );
    }
}

