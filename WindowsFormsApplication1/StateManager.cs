using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace WindowsFormsApplication1
{
    class StateManager
    {
        public enum stateList
        {
            not_init,
            browser_init,
            browser_load_finish,
            waiting_for_request,
            busy

        }

        public static stateList state = stateList.not_init;


        public static void initForm()
        {
            if (state <= stateList.not_init)
            {
                Globals.form1 = new Form1();
                Globals.form1.Show();

                state = stateList.browser_init;
            }

            //Thread.Sleep(1000);
           
            //while (! Globals.form1.isLoadFinish )
            //{
                
            //    Thread.Sleep(1000);
            //}
            //state = stateList.browser_load_finish;


        }

    }
}
