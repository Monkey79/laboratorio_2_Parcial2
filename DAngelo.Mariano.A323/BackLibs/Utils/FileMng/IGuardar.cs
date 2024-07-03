using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackLibs.Utils.FileMng
{
    public interface IGuardar<T>
    {
        void Guardar(T t, string ruta);
    }
}
