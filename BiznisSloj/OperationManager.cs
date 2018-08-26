using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sajt.DataSloj;
using yWorks.Support;

namespace Sajt.BiznisSloj
{
    public class OperationManager
    {

        #region Singleton

        private volatile static  OperationManager   singleton;
        private  static  object syncObj=new object();
        public static OperationManager Singleton
        {
            get
            {

                if (singleton == null)
                {
                    lock (syncObj)
                    {
                        if (singleton == null)
                        {
                            singleton=new OperationManager();
                        }
                    }
                }

                return singleton;

            }
        }
        private OperationManager() { }

        #endregion

        private CimetEntities entities=new CimetEntities();

        

        public OperationResult executeOperation(Operation op)
        {
            OperationResult result;
            try
            {
                result = op.execute(this.entities);
            }
            catch (Exception ex)
            {
                result = new OperationResult();
                result.Message = ex.Message;
                result.Status = false;
            }
            return result;

        }

    }
}