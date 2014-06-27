using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace COMEX.MaracadoAutomatico.CMD3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("CopyRight® MIASOFT s.r.l");
                Console.WriteLine("Iniciando marcado automatico...............");
                Datos.dbComexEntities db = new Datos.dbComexEntities();
                List<Datos.USERINFO> empleados = db.USERINFO.Where(e => e.ISMARCADO == true).ToList();
                Datos.Machines dispositivo = db.Machines.Take(1).ToList()[0];
                int p = 0;
                foreach (Datos.USERINFO empleado in empleados)
                {
                    Datos.CHECKINOUT marcado = new Datos.CHECKINOUT();
                    marcado.USERID = empleado.USERID;
                    DateTime salida = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 5, 1);
                    marcado.CHECKTIME = salida;
                    marcado.CHECKTYPE = "O";
                    marcado.VERIFYCODE = 1;
                    marcado.SENSORID = dispositivo.MachineNumber.ToString();
                    marcado.WorkCode = 0;
                    marcado.sn = "0351140200162";
                    marcado.UserExtFmt = 1;

                    Datos.CHECKINOUT marcadoAux = db.CHECKINOUT.FirstOrDefault(m => m.USERID == marcado.USERID && m.CHECKTIME == marcado.CHECKTIME);
                    if (marcadoAux == null)
                    {
                        db.CHECKINOUT.Add(marcado);
                        p++;
                    }
                    Console.WriteLine("se generó la marcacion de {0} .", empleado.NAME);
                }
                if (p > 0)
                {
                    db.SaveChanges();
                }

                Console.WriteLine("Proceso concluido con éxito :) :) :).......");
            }
            catch (Exception r)
            {
                Console.WriteLine("Error: {0}", r.Message);
                Console.WriteLine("Source : {0}", r.Source);
                Console.WriteLine("Metodo : {0}", r.TargetSite);
            }
            Console.ReadLine();
        }
    }
}
