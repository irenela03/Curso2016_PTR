<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

public enum TipoGravedad
{
  Critica,
  Menor,
  Informe
}

void Main()
{
  ControlCentral cc = new ControlCentral();
  
  cc.AddSensor(new SensorFuego());
  cc.AddSensor(new SensorIngreso("Puerta Principal"));
  cc.AddSensor(new SensorIngreso("Ventana Cocina"));
  cc.Run();
  
  //  no volvemos mas!!
}

public class ControlCentral
{
  private List<ISensor> _sensores;
  
  public ControlCentral()
  {
    _sensores = new List<ISensor>();
  }
  
  public void AddSensor(ISensor sensor)
  {
    //  aca asociamos la alarma producida por el sensor con el procesador del CC
    sensor.Alarma += ProcesarAlarma;
    _sensores.Add(sensor);
  }
  
  public void Run()
  {
    List<Task> tareas = new List<Task>();
    
    //  lanzamos un proceso para cada sensor
    foreach (var sensor in _sensores)
    {
      Console.WriteLine ("Ejecutando Sensor...");
      tareas.Add(Task.Run((Action)sensor.Run));
    }
    Task.WaitAll(tareas.ToArray());
  }
  
  private void ProcesarAlarma(DatoAlarma data)
  {
    Console.WriteLine ("\nAlarma recibida desde {0}", data.Origen);
    Console.WriteLine ("PROCESANDO!!!");
  }
}

public interface ISensor
{
  event Action<DatoAlarma> Alarma;
  
  void Run();
}

public class DatoAlarma
{
  public string Origen { get; set; }
  public string Mensaje { get; set; }
  public TipoGravedad Gravedad { get; set; }
}

public class SensorFuego : ISensor
{
  public event Action<DatoAlarma> Alarma;
  private Random _rnd = new Random();
  
  public void Run()
  {
    while (true)
    {
      Thread.Sleep(2000);
      if (_rnd.Next(0, 20) == 19)
      {
        //  Console.WriteLine ("Lanzando alarma...");
        if (Alarma != null)
          Alarma(new DatoAlarma() { Origen = "FUEGO" });
      }
      else
        Console.Write (".");
    }
  }
}

public class SensorIngreso : ISensor
{
  public event Action<DatoAlarma> Alarma;
  private Random _rnd;
  private string _sector;
  
  public SensorIngreso(string sector)
  {
    _sector = sector;
    _rnd = new Random(_sector.GetHashCode());
  }
  
  public void Run()
  {
    while (true)
    {
      Thread.Sleep(1000);
      if (_rnd.Next(0, 25) == 24)
      {
        //  Console.WriteLine ("Lanzando alarma...");
        if (Alarma != null)
          Alarma(new DatoAlarma() { Origen = string.Format("INGRESO {0}", _sector) });
      }
      else
        Console.Write ("+");
    }
  }
}