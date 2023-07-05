using System.Collections;

namespace NFC_Test_Sys_K10.domain
{
    public interface IBaseScripts
    { 
        Hashtable startTest(Hashtable ht);

        void delay(int ms);
    }
}
