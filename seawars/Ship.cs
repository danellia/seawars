using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seawars
{
    class oneShip
    {
        public int size;
        public object Ship;
        protected object ship;
        public position pos;
        protected bool horizontal;

        public oneShip(position _pos)
        {
            size = 1;
            pos = _pos;
            ship = new position[] { pos };
            horizontal = true;
        }

        public object get()
        {
            Ship = ship;
            return Ship;
        }

        //public bool checkBorders(ArrayList ships)
        //{
        //    bool isPossible = true; 
        //    for (int i = pos.x - size; i <= pos.x + size; ++i)
        //    {
        //        for (int j = pos.y - size; j <= pos.y + size; ++j)
        //        {
        //            for (int k = 0; k < ships.Count; ++k)
        //            {
        //                position temp = new position(i, j);
        //                //if (ships[k] == null)
        //                //{
        //                //    continue;
        //                //}
        //                if(ships[k].pos.x == temp.x && ships[k].pos.y == temp.y)
        //                {
        //                    isPossible = false; 
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //    return isPossible;
        //}
        public bool checkBorders(List<oneShip> ships)
        {
            for (int i = pos.x - size; i <= pos.x + size; ++i)
            {
                for (int j = pos.y - size; j <= pos.y + size; ++j)
                {
                    foreach (var ship in ships)
                    {
                        position temp = new position(i, j);
                        for (int k = 0; k < ship.size; ++k)
                        {
                            if (ship.horizontal)
                            {
                                object[] tempShip = (object[])ship.get();
                                position tempPos = (position)tempShip[k];
                                if (tempPos.x == temp.x && tempPos.y == temp.y)
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                object[,] tempShip = (object[,])ship.get();
                                position tempPos = (position)tempShip[0, k];
                                if (tempPos.x == temp.x && tempPos.y == temp.y)
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }
    }

    class twoShip : oneShip
    {
        public twoShip(position _pos, bool _horizontal) : base (_pos)
        {
            size = 2;
            horizontal = _horizontal;
            pos = _pos;
            fill();
        }

        protected void fill()
        {
            if(horizontal)
            {
                position[] temp = new position[size];
                for(int i = 0; i < size; ++i) temp[i] = new position(pos.x + i, pos.y + i);
                ship = temp;
            }
            else
            {
                position[,] temp = new position[1, size];
                for (int i = 0; i < size; ++i) temp[0, i] = new position(pos.x + i, pos.y + i);
                ship = temp;
            }
        }
    }

    class threeShip : twoShip
    {
        public threeShip(position _pos, bool _horizontal) : base (_pos, _horizontal)
        {
            size = 3;
            horizontal = _horizontal;
            pos = _pos;
            fill();
        }
    }

    class fourShip : twoShip
    {
        public fourShip(position _pos, bool _horizontal) : base(_pos, _horizontal)
        {
            size = 4;
            horizontal = _horizontal;
            pos = _pos;
            fill();
        }
    }

    class position
    {
        public int x;
        public int y;

        public position(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

    }
}
