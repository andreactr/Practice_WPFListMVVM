using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.ComponentModel;
using System.Xml.Linq;

namespace Tracking.Model
{
    public class MainModel
    {
        public List<Track> GetLeftTracking()
        {

            return new List<Track> {
            new Track{Check=false, Id= 1, Type= 1, Tracking= "T1"},
            new Track{Check=false, Id= 2, Type= 1, Tracking= "T2"},
            new Track{Check=false, Id= 3, Type= 1, Tracking= "T3"}
            }; 
        }
        public List<Track> GetRigthTracking()
        {

            return new List<Track> {
            new Track{Check = false,  Id= 4, Type= 1, Tracking= "T4"},
            new Track{Check = false,  Id= 5, Type= 1, Tracking= "T5"},
            new Track{Check = false,  Id= 6, Type= 1, Tracking= "T6"}
            };
        }

        public void Move(Track selected, ref List<Track> left, ref List<Track> right, MoveType option)
        {
            if (selected == null)
                throw new Exception("No hay filas seleccionadas");
            if (option == MoveType.LeftToRight)
            {
                left.Remove(selected);
                right.Add(selected);

            }
            else if (option == MoveType.RightToLeft)
            {
                right.Remove(selected);
                left.Add(selected);
            }

        }
        public void MoveMultiple(ref List<Track> left, ref List<Track> right, MoveType option)
        {
            

            if (option == MoveType.LeftToRight)
            {
                //Obtener todos los items con check en true con linq y guardarlos en una lista nueva
                //Recorrer la lista nueva que obtuviste anteriormente y con ella ir borrando los elementos de left y agregarlos a right

                var newleft= left.Where(x => x.Check == true).ToList();
                if (newleft == null)
                    throw new Exception("No hay filas seleccionadas");
                foreach (var item in newleft)//que no recorra left sino la nueva lista
                {
                    
                    if(item.Check == true) 
                    { 
                         left.Remove(item);
                         right.Add(item);
                        item.Check = false;
                    }
                   
                }

            }
            else if (option == MoveType.RightToLeft)
            {
                var newright = right.Where(x => x.Check == true).ToList();
                if (newright == null)
                    throw new Exception("No hay filas seleccionadas");
                foreach (var item in newright)//que no recorra left sino la nueva lista
                {

                    if (item.Check == true)
                    {
                        right.Remove(item);
                        left.Add(item);
                        item.Check = false;
                    }
                }
            }
        }
    }

    public enum MoveType
    {
        LeftToRight,
        RightToLeft
    }
}
