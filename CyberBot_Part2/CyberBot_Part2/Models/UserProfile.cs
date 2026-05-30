using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Models;

public class UserProfile
{
    public string GetArt(){
        string Art =@"       
  ____ _           _     ____        _   
 / ___| |__   __ _| |_  | __ )  ___ | |_ 
| |   | '_ \ / _` | __| |  _ \ / _ \| __|
| |___| | | | (_| | |_  | |_) | (_) | |_ 
 \____|_| |_|\__,_|\__| |____/ \___/ \__|
 -------------------------------------------
       By Mpho Baloyi
----------------------------------------------
 ";

        return Art;
    }
}