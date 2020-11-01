using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{

    //    定义一个仓库（Repoistory）类，用于存取对象，其中包含：
    //一个int类型的常量version
    //一个静态只读的字符串connection，以后可用于连接数据库
    //思考Respoitory应该是static类还是实例类更好



   static class Repoistory
    {


        const int version = 10;




      static  private string _connection;


      static  public string Connection
        {
            get
            {
                return _connection;
            }
        }





    }
}
