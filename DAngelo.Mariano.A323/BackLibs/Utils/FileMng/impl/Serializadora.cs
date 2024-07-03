using BackLibs.CstException;
using BackLibs.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BackLibs.Utils.FileMng.impl
{
    public class Serializadora : IGuardar<List<Serie>>
    {
        public void Guardar(List<Serie> series, string ruta) {            
            StreamWriter sw = null;
            try {
                sw = new StreamWriter(ruta);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Serie>));
                xmlSerializer.Serialize(sw, series);
            }catch (Exception ex) {
                //TODO LogMng
                Debug.WriteLine(ex.Message);
                throw new BackLogException($"Error al guardar la lista en formato XML.{ex.Message}", ex);
            }finally{
                sw.Close();
            }
        }

        void IGuardar<List<Serie>>.Guardar(List<Serie> series, string ruta) {
            try {
                string json = JsonSerializer.Serialize(series, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(ruta, json);
            }catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                throw new BackLogException($"Error al guardar la lista en formato JSON.{ex.Message}", ex);
            }
        }
    }
}
